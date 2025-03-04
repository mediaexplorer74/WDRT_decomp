﻿using System;
using System.Collections.Generic;
using Microsoft.Data.Edm.Expressions;

namespace Microsoft.Data.Edm.Library.Expressions
{
	// Token: 0x0200019D RID: 413
	public class EdmApplyExpression : EdmElement, IEdmApplyExpression, IEdmExpression, IEdmElement
	{
		// Token: 0x06000901 RID: 2305 RVA: 0x0001867B File Offset: 0x0001687B
		public EdmApplyExpression(IEdmFunction appliedFunction, params IEdmExpression[] arguments)
			: this(appliedFunction, (IEnumerable<IEdmExpression>)arguments)
		{
		}

		// Token: 0x06000902 RID: 2306 RVA: 0x0001868A File Offset: 0x0001688A
		public EdmApplyExpression(IEdmFunction appliedFunction, IEnumerable<IEdmExpression> arguments)
			: this(new EdmFunctionReferenceExpression(EdmUtil.CheckArgumentNull<IEdmFunction>(appliedFunction, "appliedFunction")), arguments)
		{
		}

		// Token: 0x06000903 RID: 2307 RVA: 0x000186A3 File Offset: 0x000168A3
		public EdmApplyExpression(IEdmExpression appliedFunction, IEnumerable<IEdmExpression> arguments)
		{
			EdmUtil.CheckArgumentNull<IEdmExpression>(appliedFunction, "appliedFunction");
			EdmUtil.CheckArgumentNull<IEnumerable<IEdmExpression>>(arguments, "arguments");
			this.appliedFunction = appliedFunction;
			this.arguments = arguments;
		}

		// Token: 0x170003D0 RID: 976
		// (get) Token: 0x06000904 RID: 2308 RVA: 0x000186D1 File Offset: 0x000168D1
		public IEdmExpression AppliedFunction
		{
			get
			{
				return this.appliedFunction;
			}
		}

		// Token: 0x170003D1 RID: 977
		// (get) Token: 0x06000905 RID: 2309 RVA: 0x000186D9 File Offset: 0x000168D9
		public IEnumerable<IEdmExpression> Arguments
		{
			get
			{
				return this.arguments;
			}
		}

		// Token: 0x170003D2 RID: 978
		// (get) Token: 0x06000906 RID: 2310 RVA: 0x000186E1 File Offset: 0x000168E1
		public EdmExpressionKind ExpressionKind
		{
			get
			{
				return EdmExpressionKind.FunctionApplication;
			}
		}

		// Token: 0x0400046A RID: 1130
		private readonly IEdmExpression appliedFunction;

		// Token: 0x0400046B RID: 1131
		private readonly IEnumerable<IEdmExpression> arguments;
	}
}
