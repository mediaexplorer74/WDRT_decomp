﻿using System;
using Microsoft.Data.Edm.Expressions;

namespace Microsoft.Data.Edm.Library.Expressions
{
	// Token: 0x0200019C RID: 412
	public class EdmFunctionReferenceExpression : EdmElement, IEdmFunctionReferenceExpression, IEdmExpression, IEdmElement
	{
		// Token: 0x060008FE RID: 2302 RVA: 0x00018654 File Offset: 0x00016854
		public EdmFunctionReferenceExpression(IEdmFunction referencedFunction)
		{
			EdmUtil.CheckArgumentNull<IEdmFunction>(referencedFunction, "referencedFunction");
			this.referencedFunction = referencedFunction;
		}

		// Token: 0x170003CE RID: 974
		// (get) Token: 0x060008FF RID: 2303 RVA: 0x0001866F File Offset: 0x0001686F
		public IEdmFunction ReferencedFunction
		{
			get
			{
				return this.referencedFunction;
			}
		}

		// Token: 0x170003CF RID: 975
		// (get) Token: 0x06000900 RID: 2304 RVA: 0x00018677 File Offset: 0x00016877
		public EdmExpressionKind ExpressionKind
		{
			get
			{
				return EdmExpressionKind.FunctionReference;
			}
		}

		// Token: 0x04000469 RID: 1129
		private readonly IEdmFunction referencedFunction;
	}
}
