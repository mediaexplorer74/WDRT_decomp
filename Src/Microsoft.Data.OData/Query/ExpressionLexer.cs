﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace Microsoft.Data.OData.Query
{
	// Token: 0x020000C5 RID: 197
	[DebuggerDisplay("ExpressionLexer ({text} @ {textPos} [{token}]")]
	internal sealed class ExpressionLexer
	{
		// Token: 0x060004C2 RID: 1218 RVA: 0x00010072 File Offset: 0x0000E272
		internal ExpressionLexer(string expression, bool moveToFirstToken, bool useSemicolonDelimeter)
			: this(expression, moveToFirstToken, useSemicolonDelimeter, false)
		{
		}

		// Token: 0x060004C3 RID: 1219 RVA: 0x00010080 File Offset: 0x0000E280
		internal ExpressionLexer(string expression, bool moveToFirstToken, bool useSemicolonDelimeter, bool parsingFunctionParameters)
		{
			this.ignoreWhitespace = true;
			this.text = expression;
			this.textLen = this.text.Length;
			this.useSemicolonDelimeter = useSemicolonDelimeter;
			this.parsingFunctionParameters = parsingFunctionParameters;
			this.SetTextPos(0);
			if (moveToFirstToken)
			{
				this.NextToken();
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x060004C4 RID: 1220 RVA: 0x000100D2 File Offset: 0x0000E2D2
		// (set) Token: 0x060004C5 RID: 1221 RVA: 0x000100DA File Offset: 0x0000E2DA
		internal ExpressionToken CurrentToken
		{
			get
			{
				return this.token;
			}
			set
			{
				this.token = value;
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x060004C6 RID: 1222 RVA: 0x000100E3 File Offset: 0x0000E2E3
		internal string ExpressionText
		{
			get
			{
				return this.text;
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x060004C7 RID: 1223 RVA: 0x000100EB File Offset: 0x0000E2EB
		internal int Position
		{
			get
			{
				return this.token.Position;
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x000100F8 File Offset: 0x0000E2F8
		private bool IsValidWhiteSpace
		{
			get
			{
				char? c = this.ch;
				int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
				return num != null && char.IsWhiteSpace(this.ch.Value);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x060004C9 RID: 1225 RVA: 0x00010148 File Offset: 0x0000E348
		private bool IsValidDigit
		{
			get
			{
				char? c = this.ch;
				int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
				return num != null && char.IsDigit(this.ch.Value);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x00010198 File Offset: 0x0000E398
		private bool IsValidStartingCharForIdentifier
		{
			get
			{
				char? c = this.ch;
				int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
				return num != null && (char.IsLetter(this.ch.Value) || this.ch == '_' || this.ch == '$' || PlatformHelper.GetUnicodeCategory(this.ch.Value) == UnicodeCategory.LetterNumber);
			}
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x060004CB RID: 1227 RVA: 0x00010240 File Offset: 0x0000E440
		private bool IsValidNonStartingCharForIdentifier
		{
			get
			{
				char? c = this.ch;
				int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
				return num != null && (char.IsLetterOrDigit(this.ch.Value) || ExpressionLexer.AdditionalUnicodeCategoriesForIdentifier.Contains(PlatformHelper.GetUnicodeCategory(this.ch.Value)));
			}
		}

		// Token: 0x060004CC RID: 1228 RVA: 0x000102B0 File Offset: 0x0000E4B0
		internal bool TryPeekNextToken(out ExpressionToken resultToken, out Exception error)
		{
			int num = this.textPos;
			char? c = this.ch;
			int? num2 = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
			char? c2 = ((num2 == null) ? null : new char?(this.ch.Value));
			ExpressionToken expressionToken = this.token;
			resultToken = this.NextTokenImplementation(out error);
			this.textPos = num;
			this.ch = c2;
			this.token = expressionToken;
			return error == null;
		}

		// Token: 0x060004CD RID: 1229 RVA: 0x00010344 File Offset: 0x0000E544
		internal ExpressionToken NextToken()
		{
			Exception ex = null;
			ExpressionToken expressionToken = this.NextTokenImplementation(out ex);
			if (ex != null)
			{
				throw ex;
			}
			return expressionToken;
		}

		// Token: 0x060004CE RID: 1230 RVA: 0x00010364 File Offset: 0x0000E564
		internal string ReadDottedIdentifier(bool acceptStar)
		{
			this.ValidateToken(ExpressionTokenKind.Identifier);
			StringBuilder stringBuilder = null;
			string text = this.CurrentToken.Text;
			this.NextToken();
			while (this.CurrentToken.Kind == ExpressionTokenKind.Dot)
			{
				this.NextToken();
				if (this.CurrentToken.Kind != ExpressionTokenKind.Identifier)
				{
					if (this.CurrentToken.Kind != ExpressionTokenKind.Star)
					{
						throw ExpressionLexer.ParseError(Strings.ExpressionLexer_SyntaxError(this.textPos, this.text));
					}
					if (!acceptStar || (this.PeekNextToken().Kind != ExpressionTokenKind.End && this.PeekNextToken().Kind != ExpressionTokenKind.Comma))
					{
						throw ExpressionLexer.ParseError(Strings.ExpressionLexer_SyntaxError(this.textPos, this.text));
					}
				}
				if (stringBuilder == null)
				{
					stringBuilder = new StringBuilder(text, text.Length + 1 + this.CurrentToken.Text.Length);
				}
				stringBuilder.Append('.');
				stringBuilder.Append(this.CurrentToken.Text);
				this.NextToken();
			}
			if (stringBuilder != null)
			{
				text = stringBuilder.ToString();
			}
			return text;
		}

		// Token: 0x060004CF RID: 1231 RVA: 0x00010470 File Offset: 0x0000E670
		internal ExpressionToken PeekNextToken()
		{
			ExpressionToken expressionToken;
			Exception ex;
			this.TryPeekNextToken(out expressionToken, out ex);
			if (ex != null)
			{
				throw ex;
			}
			return expressionToken;
		}

		// Token: 0x060004D0 RID: 1232 RVA: 0x00010490 File Offset: 0x0000E690
		internal bool ExpandIdentifierAsFunction()
		{
			ExpressionTokenKind kind = this.token.Kind;
			if (kind != ExpressionTokenKind.Identifier)
			{
				return false;
			}
			int num = this.textPos;
			char? c = this.ch;
			int? num2 = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
			char? c2 = ((num2 == null) ? null : new char?(this.ch.Value));
			ExpressionToken expressionToken = this.token;
			bool flag = this.ignoreWhitespace;
			this.ignoreWhitespace = false;
			int position = this.token.Position;
			while (this.MoveNextWhenMatch(ExpressionTokenKind.Dot) && this.MoveNextWhenMatch(ExpressionTokenKind.Identifier))
			{
			}
			bool flag2 = this.CurrentToken.Kind == ExpressionTokenKind.Identifier && this.PeekNextToken().Kind == ExpressionTokenKind.OpenParen;
			if (flag2)
			{
				this.token.Text = this.text.Substring(position, this.textPos - position);
				this.token.Position = position;
			}
			else
			{
				this.textPos = num;
				this.ch = c2;
				this.token = expressionToken;
			}
			this.ignoreWhitespace = flag;
			return flag2;
		}

		// Token: 0x060004D1 RID: 1233 RVA: 0x000105B2 File Offset: 0x0000E7B2
		internal void ValidateToken(ExpressionTokenKind t)
		{
			if (this.token.Kind != t)
			{
				throw ExpressionLexer.ParseError(Strings.ExpressionLexer_SyntaxError(this.textPos, this.text));
			}
		}

		// Token: 0x060004D2 RID: 1234 RVA: 0x000105DE File Offset: 0x0000E7DE
		private static Exception ParseError(string message)
		{
			return new ODataException(message);
		}

		// Token: 0x060004D3 RID: 1235 RVA: 0x000105E8 File Offset: 0x0000E7E8
		private ExpressionToken NextTokenImplementation(out Exception error)
		{
			error = null;
			if (this.ignoreWhitespace)
			{
				this.ParseWhitespace();
			}
			int num = this.textPos;
			char? c = this.ch;
			char valueOrDefault = c.GetValueOrDefault();
			ExpressionTokenKind expressionTokenKind;
			if (c != null)
			{
				if (valueOrDefault <= ':')
				{
					switch (valueOrDefault)
					{
					case '\'':
					{
						char value = this.ch.Value;
						do
						{
							this.AdvanceToNextOccuranceOf(value);
							if (this.textPos == this.textLen)
							{
								error = ExpressionLexer.ParseError(Strings.ExpressionLexer_UnterminatedStringLiteral(this.textPos, this.text));
							}
							this.NextChar();
						}
						while (this.ch != null && this.ch == value);
						expressionTokenKind = ExpressionTokenKind.StringLiteral;
						goto IL_3D8;
					}
					case '(':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.OpenParen;
						goto IL_3D8;
					case ')':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.CloseParen;
						goto IL_3D8;
					case '*':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Star;
						goto IL_3D8;
					case '+':
						break;
					case ',':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Comma;
						goto IL_3D8;
					case '-':
					{
						bool flag = this.textPos + 1 < this.textLen;
						if (flag && char.IsDigit(this.text[this.textPos + 1]))
						{
							this.NextChar();
							expressionTokenKind = this.ParseFromDigit();
							if (ExpressionLexerUtils.IsNumeric(expressionTokenKind))
							{
								goto IL_3D8;
							}
							this.SetTextPos(num);
						}
						else if (flag && this.text[num + 1] == "INF"[0])
						{
							this.NextChar();
							this.ParseIdentifier();
							string text = this.text.Substring(num + 1, this.textPos - num - 1);
							if (ExpressionLexerUtils.IsInfinityLiteralDouble(text))
							{
								expressionTokenKind = ExpressionTokenKind.DoubleLiteral;
								goto IL_3D8;
							}
							if (ExpressionLexerUtils.IsInfinityLiteralSingle(text))
							{
								expressionTokenKind = ExpressionTokenKind.SingleLiteral;
								goto IL_3D8;
							}
							this.SetTextPos(num);
						}
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Minus;
						goto IL_3D8;
					}
					case '.':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Dot;
						goto IL_3D8;
					case '/':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Slash;
						goto IL_3D8;
					default:
						if (valueOrDefault == ':')
						{
							this.NextChar();
							expressionTokenKind = ExpressionTokenKind.Colon;
							goto IL_3D8;
						}
						break;
					}
				}
				else
				{
					switch (valueOrDefault)
					{
					case '=':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Equal;
						goto IL_3D8;
					case '>':
						break;
					case '?':
						this.NextChar();
						expressionTokenKind = ExpressionTokenKind.Question;
						goto IL_3D8;
					default:
						if (valueOrDefault == '[')
						{
							this.ParseBracketedExpression('[', ']');
							expressionTokenKind = ExpressionTokenKind.BracketedExpression;
							goto IL_3D8;
						}
						if (valueOrDefault == '{')
						{
							this.ParseBracketedExpression('{', '}');
							expressionTokenKind = ExpressionTokenKind.BracketedExpression;
							goto IL_3D8;
						}
						break;
					}
				}
			}
			if (this.IsValidWhiteSpace)
			{
				this.ParseWhitespace();
				expressionTokenKind = ExpressionTokenKind.Unknown;
			}
			else if (this.IsValidStartingCharForIdentifier)
			{
				this.ParseIdentifier();
				expressionTokenKind = ExpressionTokenKind.Identifier;
			}
			else if (this.IsValidDigit)
			{
				expressionTokenKind = this.ParseFromDigit();
			}
			else if (this.textPos == this.textLen)
			{
				expressionTokenKind = ExpressionTokenKind.End;
			}
			else if (this.useSemicolonDelimeter && this.ch == ';')
			{
				this.NextChar();
				expressionTokenKind = ExpressionTokenKind.SemiColon;
			}
			else if (this.parsingFunctionParameters && this.ch == '@')
			{
				this.NextChar();
				if (this.textPos == this.textLen)
				{
					error = ExpressionLexer.ParseError(Strings.ExpressionLexer_SyntaxError(this.textPos, this.text));
					expressionTokenKind = ExpressionTokenKind.Unknown;
				}
				else if (!this.IsValidStartingCharForIdentifier)
				{
					error = ExpressionLexer.ParseError(Strings.ExpressionLexer_InvalidCharacter(this.ch, this.textPos, this.text));
					expressionTokenKind = ExpressionTokenKind.Unknown;
				}
				else
				{
					this.ParseIdentifier();
					expressionTokenKind = ExpressionTokenKind.ParameterAlias;
				}
			}
			else
			{
				error = ExpressionLexer.ParseError(Strings.ExpressionLexer_InvalidCharacter(this.ch, this.textPos, this.text));
				expressionTokenKind = ExpressionTokenKind.Unknown;
			}
			IL_3D8:
			this.token.Kind = expressionTokenKind;
			this.token.Text = this.text.Substring(num, this.textPos - num);
			this.token.Position = num;
			this.HandleTypePrefixedLiterals();
			if (this.token.Kind == ExpressionTokenKind.Identifier)
			{
				if (ExpressionLexerUtils.IsInfinityOrNaNDouble(this.token.Text))
				{
					this.token.Kind = ExpressionTokenKind.DoubleLiteral;
				}
				else if (ExpressionLexerUtils.IsInfinityOrNanSingle(this.token.Text))
				{
					this.token.Kind = ExpressionTokenKind.SingleLiteral;
				}
				else if (this.token.Text == "true" || this.token.Text == "false")
				{
					this.token.Kind = ExpressionTokenKind.BooleanLiteral;
				}
				else if (this.token.Text == "null")
				{
					this.token.Kind = ExpressionTokenKind.NullLiteral;
				}
			}
			return this.token;
		}

		// Token: 0x060004D4 RID: 1236 RVA: 0x00010AC8 File Offset: 0x0000ECC8
		private bool MoveNextWhenMatch(ExpressionTokenKind id)
		{
			if (id == this.PeekNextToken().Kind)
			{
				this.NextToken();
				return true;
			}
			return false;
		}

		// Token: 0x060004D5 RID: 1237 RVA: 0x00010AF0 File Offset: 0x0000ECF0
		private void HandleTypePrefixedLiterals()
		{
			ExpressionTokenKind expressionTokenKind = this.token.Kind;
			if (expressionTokenKind != ExpressionTokenKind.Identifier)
			{
				return;
			}
			if (!(this.ch == '\''))
			{
				return;
			}
			string text = this.token.Text;
			if (string.Equals(text, "datetime", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.DateTimeLiteral;
			}
			else if (string.Equals(text, "datetimeoffset", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.DateTimeOffsetLiteral;
			}
			else if (string.Equals(text, "time", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.TimeLiteral;
			}
			else if (string.Equals(text, "guid", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.GuidLiteral;
			}
			else if (string.Equals(text, "binary", StringComparison.OrdinalIgnoreCase) || string.Equals(text, "X", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.BinaryLiteral;
			}
			else if (string.Equals(text, "geography", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.GeographyLiteral;
			}
			else if (string.Equals(text, "geometry", StringComparison.OrdinalIgnoreCase))
			{
				expressionTokenKind = ExpressionTokenKind.GeometryLiteral;
			}
			else
			{
				if (!this.parsingFunctionParameters || !string.Equals(text, "null", StringComparison.OrdinalIgnoreCase))
				{
					return;
				}
				expressionTokenKind = ExpressionTokenKind.NullLiteral;
			}
			int position = this.token.Position;
			do
			{
				this.NextChar();
			}
			while (this.ch != null && this.ch != '\'');
			char? c = this.ch;
			int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
			if (num == null)
			{
				throw ExpressionLexer.ParseError(Strings.ExpressionLexer_UnterminatedLiteral(this.textPos, this.text));
			}
			this.NextChar();
			this.token.Kind = expressionTokenKind;
			this.token.Text = this.text.Substring(position, this.textPos - position);
		}

		// Token: 0x060004D6 RID: 1238 RVA: 0x00010CB4 File Offset: 0x0000EEB4
		private void NextChar()
		{
			if (this.textPos < this.textLen)
			{
				this.textPos++;
				if (this.textPos < this.textLen)
				{
					this.ch = new char?(this.text[this.textPos]);
					return;
				}
			}
			this.ch = null;
		}

		// Token: 0x060004D7 RID: 1239 RVA: 0x00010D14 File Offset: 0x0000EF14
		private ExpressionTokenKind ParseFromDigit()
		{
			char value = this.ch.Value;
			this.NextChar();
			ExpressionTokenKind expressionTokenKind;
			if ((value == '0' && this.ch == 'x') || this.ch == 'X')
			{
				expressionTokenKind = ExpressionTokenKind.BinaryLiteral;
				do
				{
					this.NextChar();
					if (this.ch == null)
					{
						break;
					}
				}
				while (UriPrimitiveTypeParser.IsCharHexDigit(this.ch.Value));
			}
			else
			{
				expressionTokenKind = ExpressionTokenKind.IntegerLiteral;
				while (this.IsValidDigit)
				{
					this.NextChar();
				}
				if (this.ch == '.')
				{
					expressionTokenKind = ExpressionTokenKind.DoubleLiteral;
					this.NextChar();
					this.ValidateDigit();
					do
					{
						this.NextChar();
					}
					while (this.IsValidDigit);
				}
				if (this.ch == 'E' || this.ch == 'e')
				{
					expressionTokenKind = ExpressionTokenKind.DoubleLiteral;
					this.NextChar();
					if (this.ch == '+' || this.ch == '-')
					{
						this.NextChar();
					}
					this.ValidateDigit();
					do
					{
						this.NextChar();
					}
					while (this.IsValidDigit);
				}
				if (this.ch == 'M' || this.ch == 'm')
				{
					expressionTokenKind = ExpressionTokenKind.DecimalLiteral;
					this.NextChar();
				}
				else if (this.ch == 'd' || this.ch == 'D')
				{
					expressionTokenKind = ExpressionTokenKind.DoubleLiteral;
					this.NextChar();
				}
				else if (this.ch == 'L' || this.ch == 'l')
				{
					expressionTokenKind = ExpressionTokenKind.Int64Literal;
					this.NextChar();
				}
				else if (this.ch == 'f' || this.ch == 'F')
				{
					expressionTokenKind = ExpressionTokenKind.SingleLiteral;
					this.NextChar();
				}
			}
			return expressionTokenKind;
		}

		// Token: 0x060004D8 RID: 1240 RVA: 0x00010FB9 File Offset: 0x0000F1B9
		private void ParseWhitespace()
		{
			while (this.IsValidWhiteSpace)
			{
				this.NextChar();
			}
		}

		// Token: 0x060004D9 RID: 1241 RVA: 0x00010FCC File Offset: 0x0000F1CC
		private void ParseBracketedExpression(char startingCharacter, char endingCharacter)
		{
			int i = 1;
			this.NextChar();
			while (i > 0)
			{
				if (this.ch == '\'')
				{
					this.AdvanceToNextOccuranceOf('\'');
				}
				if (this.ch == startingCharacter)
				{
					i++;
				}
				else if (this.ch == endingCharacter)
				{
					i--;
				}
				char? c = this.ch;
				int? num = ((c != null) ? new int?((int)c.GetValueOrDefault()) : null);
				if (num == null)
				{
					throw new ODataException(Strings.ExpressionLexer_UnbalancedBracketExpression);
				}
				this.NextChar();
			}
		}

		// Token: 0x060004DA RID: 1242 RVA: 0x000110A4 File Offset: 0x0000F2A4
		private void AdvanceToNextOccuranceOf(char endingValue)
		{
			this.NextChar();
			while (this.ch != null && this.ch != endingValue)
			{
				this.NextChar();
			}
		}

		// Token: 0x060004DB RID: 1243 RVA: 0x000110EE File Offset: 0x0000F2EE
		private void ParseIdentifier()
		{
			do
			{
				this.NextChar();
			}
			while (this.IsValidNonStartingCharForIdentifier);
		}

		// Token: 0x060004DC RID: 1244 RVA: 0x00011100 File Offset: 0x0000F300
		private void SetTextPos(int pos)
		{
			this.textPos = pos;
			this.ch = ((this.textPos < this.textLen) ? new char?(this.text[this.textPos]) : null);
		}

		// Token: 0x060004DD RID: 1245 RVA: 0x00011149 File Offset: 0x0000F349
		private void ValidateDigit()
		{
			if (!this.IsValidDigit)
			{
				throw ExpressionLexer.ParseError(Strings.ExpressionLexer_DigitExpected(this.textPos, this.text));
			}
		}

		// Token: 0x0400019F RID: 415
		private static readonly HashSet<UnicodeCategory> AdditionalUnicodeCategoriesForIdentifier = new HashSet<UnicodeCategory>(new ExpressionLexer.UnicodeCategoryEqualityComparer())
		{
			UnicodeCategory.LetterNumber,
			UnicodeCategory.NonSpacingMark,
			UnicodeCategory.SpacingCombiningMark,
			UnicodeCategory.ConnectorPunctuation,
			UnicodeCategory.Format
		};

		// Token: 0x040001A0 RID: 416
		private readonly string text;

		// Token: 0x040001A1 RID: 417
		private readonly int textLen;

		// Token: 0x040001A2 RID: 418
		private readonly bool useSemicolonDelimeter;

		// Token: 0x040001A3 RID: 419
		private readonly bool parsingFunctionParameters;

		// Token: 0x040001A4 RID: 420
		private int textPos;

		// Token: 0x040001A5 RID: 421
		private char? ch;

		// Token: 0x040001A6 RID: 422
		private ExpressionToken token;

		// Token: 0x040001A7 RID: 423
		private bool ignoreWhitespace;

		// Token: 0x020000C6 RID: 198
		private sealed class UnicodeCategoryEqualityComparer : IEqualityComparer<UnicodeCategory>
		{
			// Token: 0x060004DF RID: 1247 RVA: 0x000111B9 File Offset: 0x0000F3B9
			public bool Equals(UnicodeCategory x, UnicodeCategory y)
			{
				return x == y;
			}

			// Token: 0x060004E0 RID: 1248 RVA: 0x000111BF File Offset: 0x0000F3BF
			public int GetHashCode(UnicodeCategory obj)
			{
				return (int)obj;
			}
		}
	}
}
