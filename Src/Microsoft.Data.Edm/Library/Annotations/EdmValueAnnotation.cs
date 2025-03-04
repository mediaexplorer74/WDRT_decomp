﻿using System;
using Microsoft.Data.Edm.Annotations;
using Microsoft.Data.Edm.Expressions;

namespace Microsoft.Data.Edm.Library.Annotations
{
	// Token: 0x0200017F RID: 383
	public class EdmValueAnnotation : EdmVocabularyAnnotation, IEdmValueAnnotation, IEdmVocabularyAnnotation, IEdmElement
	{
		// Token: 0x06000877 RID: 2167 RVA: 0x00017E6A File Offset: 0x0001606A
		public EdmValueAnnotation(IEdmVocabularyAnnotatable target, IEdmTerm term, IEdmExpression value)
			: this(target, term, null, value)
		{
		}

		// Token: 0x06000878 RID: 2168 RVA: 0x00017E76 File Offset: 0x00016076
		public EdmValueAnnotation(IEdmVocabularyAnnotatable target, IEdmTerm term, string qualifier, IEdmExpression value)
			: base(target, term, qualifier)
		{
			EdmUtil.CheckArgumentNull<IEdmExpression>(value, "value");
			this.value = value;
		}

		// Token: 0x1700037F RID: 895
		// (get) Token: 0x06000879 RID: 2169 RVA: 0x00017E96 File Offset: 0x00016096
		public IEdmExpression Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x04000438 RID: 1080
		private readonly IEdmExpression value;
	}
}
