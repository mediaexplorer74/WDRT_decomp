﻿using System;
using System.Collections.Generic;
using Microsoft.Data.Edm.Annotations;

namespace Microsoft.Data.Edm.Library.Annotations
{
	// Token: 0x0200017E RID: 382
	public class EdmTypeAnnotation : EdmVocabularyAnnotation, IEdmTypeAnnotation, IEdmVocabularyAnnotation, IEdmElement
	{
		// Token: 0x06000873 RID: 2163 RVA: 0x00017E24 File Offset: 0x00016024
		public EdmTypeAnnotation(IEdmVocabularyAnnotatable target, IEdmTerm term, params IEdmPropertyValueBinding[] propertyValueBindings)
			: this(target, term, null, propertyValueBindings)
		{
		}

		// Token: 0x06000874 RID: 2164 RVA: 0x00017E30 File Offset: 0x00016030
		public EdmTypeAnnotation(IEdmVocabularyAnnotatable target, IEdmTerm term, string qualifier, params IEdmPropertyValueBinding[] propertyValueBindings)
			: this(target, term, qualifier, (IEnumerable<IEdmPropertyValueBinding>)propertyValueBindings)
		{
		}

		// Token: 0x06000875 RID: 2165 RVA: 0x00017E42 File Offset: 0x00016042
		public EdmTypeAnnotation(IEdmVocabularyAnnotatable target, IEdmTerm term, string qualifier, IEnumerable<IEdmPropertyValueBinding> propertyValueBindings)
			: base(target, term, qualifier)
		{
			EdmUtil.CheckArgumentNull<IEnumerable<IEdmPropertyValueBinding>>(propertyValueBindings, "propertyValueBindings");
			this.propertyValueBindings = propertyValueBindings;
		}

		// Token: 0x1700037E RID: 894
		// (get) Token: 0x06000876 RID: 2166 RVA: 0x00017E62 File Offset: 0x00016062
		public IEnumerable<IEdmPropertyValueBinding> PropertyValueBindings
		{
			get
			{
				return this.propertyValueBindings;
			}
		}

		// Token: 0x04000437 RID: 1079
		private readonly IEnumerable<IEdmPropertyValueBinding> propertyValueBindings;
	}
}
