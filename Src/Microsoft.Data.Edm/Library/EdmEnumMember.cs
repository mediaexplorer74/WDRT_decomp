﻿using System;
using Microsoft.Data.Edm.Values;

namespace Microsoft.Data.Edm.Library
{
	// Token: 0x02000181 RID: 385
	public class EdmEnumMember : EdmNamedElement, IEdmEnumMember, IEdmNamedElement, IEdmElement
	{
		// Token: 0x06000880 RID: 2176 RVA: 0x00017EFF File Offset: 0x000160FF
		public EdmEnumMember(IEdmEnumType declaringType, string name, IEdmPrimitiveValue value)
			: base(name)
		{
			EdmUtil.CheckArgumentNull<IEdmEnumType>(declaringType, "declaringType");
			EdmUtil.CheckArgumentNull<IEdmPrimitiveValue>(value, "value");
			this.declaringType = declaringType;
			this.value = value;
		}

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x06000881 RID: 2177 RVA: 0x00017F2E File Offset: 0x0001612E
		public IEdmEnumType DeclaringType
		{
			get
			{
				return this.declaringType;
			}
		}

		// Token: 0x17000386 RID: 902
		// (get) Token: 0x06000882 RID: 2178 RVA: 0x00017F36 File Offset: 0x00016136
		public IEdmPrimitiveValue Value
		{
			get
			{
				return this.value;
			}
		}

		// Token: 0x0400043B RID: 1083
		private readonly IEdmEnumType declaringType;

		// Token: 0x0400043C RID: 1084
		private IEdmPrimitiveValue value;
	}
}
