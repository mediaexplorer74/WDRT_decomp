﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Edm;
using Microsoft.Data.OData.Evaluation;
using Microsoft.Data.OData.Query.SemanticAst;

namespace Microsoft.Data.OData.Query
{
	// Token: 0x0200005C RID: 92
	internal static class SegmentKeyHandler
	{
		// Token: 0x0600025F RID: 607 RVA: 0x000098C0 File Offset: 0x00007AC0
		internal static bool TryCreateKeySegmentFromParentheses(ODataPathSegment previous, string parenthesisExpression, out ODataPathSegment keySegment)
		{
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(!previous.SingleResult);
			SegmentArgumentParser segmentArgumentParser;
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(SegmentArgumentParser.TryParseKeysFromUri(parenthesisExpression, out segmentArgumentParser));
			if (segmentArgumentParser.IsEmpty)
			{
				keySegment = null;
				return false;
			}
			keySegment = SegmentKeyHandler.CreateKeySegment(previous, segmentArgumentParser);
			return true;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00009900 File Offset: 0x00007B00
		internal static bool TryHandleSegmentAsKey(string segmentText, ODataPathSegment previous, UrlConvention urlConvention, out KeySegment keySegment)
		{
			keySegment = null;
			if (!urlConvention.GenerateKeyAsSegment)
			{
				return false;
			}
			if (previous.SingleResult)
			{
				return false;
			}
			if (SegmentKeyHandler.IsSystemSegment(segmentText))
			{
				return false;
			}
			IEdmEntityType edmEntityType;
			if (previous.TargetEdmType == null || !previous.TargetEdmType.IsEntityOrEntityCollectionType(out edmEntityType))
			{
				return false;
			}
			List<IEdmStructuralProperty> list = edmEntityType.Key().ToList<IEdmStructuralProperty>();
			if (list.Count > 1)
			{
				return false;
			}
			keySegment = SegmentKeyHandler.CreateKeySegment(previous, SegmentArgumentParser.FromSegment(segmentText));
			return true;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000996D File Offset: 0x00007B6D
		private static bool IsSystemSegment(string segmentText)
		{
			return segmentText[0] == '$' && (segmentText.Length < 2 || segmentText[1] != '$');
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00009998 File Offset: 0x00007B98
		private static KeySegment CreateKeySegment(ODataPathSegment segment, SegmentArgumentParser key)
		{
			IEdmEntityType edmEntityType = null;
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(segment.TargetEdmType != null && segment.TargetEdmType.IsEntityOrEntityCollectionType(out edmEntityType));
			List<IEdmStructuralProperty> list = edmEntityType.Key().ToList<IEdmStructuralProperty>();
			if (list.Count != key.ValueCount)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.BadRequest_KeyCountMismatch(edmEntityType.FullName()));
			}
			if (!key.AreValuesNamed && key.ValueCount > 1)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_KeysMustBeNamed);
			}
			IEnumerable<KeyValuePair<string, object>> enumerable;
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(key.TryConvertValues(list, out enumerable));
			IEdmEntityType edmEntityType2;
			segment.TargetEdmType.IsEntityOrEntityCollectionType(out edmEntityType2);
			KeySegment keySegment = new KeySegment(enumerable, edmEntityType2, segment.TargetEdmEntitySet);
			keySegment.CopyValuesFrom(segment);
			keySegment.SingleResult = true;
			return keySegment;
		}
	}
}
