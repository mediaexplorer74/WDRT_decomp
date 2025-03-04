﻿using System;
using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Library;
using Microsoft.Data.OData.Metadata;
using Microsoft.Data.OData.Query.SemanticAst;

namespace Microsoft.Data.OData.Query
{
	// Token: 0x020000C4 RID: 196
	internal static class QueryNodeUtils
	{
		// Token: 0x060004BF RID: 1215 RVA: 0x0000FFB0 File Offset: 0x0000E1B0
		internal static EntityCollectionNode AsEntityCollectionNode(this QueryNode query)
		{
			EntityCollectionNode entityCollectionNode = query as EntityCollectionNode;
			if (entityCollectionNode != null && entityCollectionNode.ItemType != null && entityCollectionNode.ItemType.IsODataEntityTypeKind())
			{
				return entityCollectionNode;
			}
			return null;
		}

		// Token: 0x060004C0 RID: 1216 RVA: 0x0000FFE0 File Offset: 0x0000E1E0
		internal static CollectionNode AsCollectionNode(this QueryNode query)
		{
			CollectionNode collectionNode = query as CollectionNode;
			if (collectionNode != null && collectionNode.ItemType != null)
			{
				return collectionNode;
			}
			return null;
		}

		// Token: 0x060004C1 RID: 1217 RVA: 0x00010004 File Offset: 0x0000E204
		internal static IEdmPrimitiveTypeReference GetBinaryOperatorResultType(IEdmPrimitiveTypeReference typeReference, BinaryOperatorKind operatorKind)
		{
			switch (operatorKind)
			{
			case BinaryOperatorKind.Or:
			case BinaryOperatorKind.And:
			case BinaryOperatorKind.Equal:
			case BinaryOperatorKind.NotEqual:
			case BinaryOperatorKind.GreaterThan:
			case BinaryOperatorKind.GreaterThanOrEqual:
			case BinaryOperatorKind.LessThan:
			case BinaryOperatorKind.LessThanOrEqual:
				return EdmCoreModel.Instance.GetBoolean(typeReference.IsNullable);
			case BinaryOperatorKind.Add:
			case BinaryOperatorKind.Subtract:
			case BinaryOperatorKind.Multiply:
			case BinaryOperatorKind.Divide:
			case BinaryOperatorKind.Modulo:
				return typeReference;
			default:
				throw new ODataException(Strings.General_InternalError(InternalErrorCodes.QueryNodeUtils_BinaryOperatorResultType_UnreachableCodepath));
			}
		}
	}
}
