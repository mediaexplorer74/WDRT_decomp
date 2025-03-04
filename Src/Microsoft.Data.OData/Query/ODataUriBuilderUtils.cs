﻿using System;
using System.Globalization;

namespace Microsoft.Data.OData.Query
{
	// Token: 0x020000B2 RID: 178
	internal static class ODataUriBuilderUtils
	{
		// Token: 0x0600042E RID: 1070 RVA: 0x0000E3D0 File Offset: 0x0000C5D0
		internal static string Escape(string text)
		{
			return text.Replace("'", "''");
		}

		// Token: 0x0600042F RID: 1071 RVA: 0x0000E3E4 File Offset: 0x0000C5E4
		internal static string ToText(this InlineCountKind inlineCount)
		{
			switch (inlineCount)
			{
			case InlineCountKind.None:
				return "none";
			case InlineCountKind.AllPages:
				return "allpages";
			default:
				throw new ODataException(Strings.General_InternalError(InternalErrorCodes.ODataUriBuilderUtils_ToText_InlineCountKind_UnreachableCodePath));
			}
		}

		// Token: 0x06000430 RID: 1072 RVA: 0x0000E420 File Offset: 0x0000C620
		internal static void NotSupportedQueryTokenKind(QueryTokenKind queryTokenKind)
		{
			throw new ODataException(Strings.UriBuilder_NotSupportedQueryToken(queryTokenKind));
		}

		// Token: 0x06000431 RID: 1073 RVA: 0x0000E432 File Offset: 0x0000C632
		internal static void NotSupported(Type type)
		{
			throw new ODataException(Strings.UriBuilder_NotSupportedClrLiteral(type.FullName));
		}

		// Token: 0x04000164 RID: 356
		internal const string IntegerFormat = "D";

		// Token: 0x04000165 RID: 357
		internal const string FloatFormat = "F";

		// Token: 0x04000166 RID: 358
		internal const string BinaryFormat = "X2";

		// Token: 0x04000167 RID: 359
		internal const string DoubleFormat = "R";

		// Token: 0x04000168 RID: 360
		internal const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFF";

		// Token: 0x04000169 RID: 361
		internal const string DateTimeOffsetFormat = "yyyy-MM-ddTHH:mm:ss.FFFFFFFzzzzzzz";

		// Token: 0x0400016A RID: 362
		internal static readonly NumberFormatInfo DecimalFormatInfo = new NumberFormatInfo
		{
			NumberDecimalDigits = 0
		};

		// Token: 0x0400016B RID: 363
		internal static readonly NumberFormatInfo DoubleFormatInfo = new NumberFormatInfo
		{
			NumberDecimalDigits = 0,
			PositiveSign = string.Empty
		};
	}
}
