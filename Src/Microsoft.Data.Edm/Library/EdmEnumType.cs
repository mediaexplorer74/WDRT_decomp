﻿using System;
using System.Collections.Generic;
using Microsoft.Data.Edm.Values;

namespace Microsoft.Data.Edm.Library
{
	// Token: 0x02000183 RID: 387
	public class EdmEnumType : EdmType, IEdmEnumType, IEdmSchemaType, IEdmSchemaElement, IEdmNamedElement, IEdmVocabularyAnnotatable, IEdmType, IEdmElement
	{
		// Token: 0x06000886 RID: 2182 RVA: 0x00017F4E File Offset: 0x0001614E
		public EdmEnumType(string namespaceName, string name)
			: this(namespaceName, name, false)
		{
		}

		// Token: 0x06000887 RID: 2183 RVA: 0x00017F59 File Offset: 0x00016159
		public EdmEnumType(string namespaceName, string name, bool isFlags)
			: this(namespaceName, name, EdmPrimitiveTypeKind.Int32, isFlags)
		{
		}

		// Token: 0x06000888 RID: 2184 RVA: 0x00017F66 File Offset: 0x00016166
		public EdmEnumType(string namespaceName, string name, EdmPrimitiveTypeKind underlyingType, bool isFlags)
			: this(namespaceName, name, EdmCoreModel.Instance.GetPrimitiveType(underlyingType), isFlags)
		{
		}

		// Token: 0x06000889 RID: 2185 RVA: 0x00017F80 File Offset: 0x00016180
		public EdmEnumType(string namespaceName, string name, IEdmPrimitiveType underlyingType, bool isFlags)
		{
			EdmUtil.CheckArgumentNull<IEdmPrimitiveType>(underlyingType, "underlyingType");
			EdmUtil.CheckArgumentNull<string>(namespaceName, "namespaceName");
			EdmUtil.CheckArgumentNull<string>(name, "name");
			this.underlyingType = underlyingType;
			this.name = name;
			this.namespaceName = namespaceName;
			this.isFlags = isFlags;
		}

		// Token: 0x17000388 RID: 904
		// (get) Token: 0x0600088A RID: 2186 RVA: 0x00017FDF File Offset: 0x000161DF
		public override EdmTypeKind TypeKind
		{
			get
			{
				return EdmTypeKind.Enum;
			}
		}

		// Token: 0x17000389 RID: 905
		// (get) Token: 0x0600088B RID: 2187 RVA: 0x00017FE2 File Offset: 0x000161E2
		public EdmSchemaElementKind SchemaElementKind
		{
			get
			{
				return EdmSchemaElementKind.TypeDefinition;
			}
		}

		// Token: 0x1700038A RID: 906
		// (get) Token: 0x0600088C RID: 2188 RVA: 0x00017FE5 File Offset: 0x000161E5
		public string Namespace
		{
			get
			{
				return this.namespaceName;
			}
		}

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x0600088D RID: 2189 RVA: 0x00017FED File Offset: 0x000161ED
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x1700038C RID: 908
		// (get) Token: 0x0600088E RID: 2190 RVA: 0x00017FF5 File Offset: 0x000161F5
		public IEdmPrimitiveType UnderlyingType
		{
			get
			{
				return this.underlyingType;
			}
		}

		// Token: 0x1700038D RID: 909
		// (get) Token: 0x0600088F RID: 2191 RVA: 0x00017FFD File Offset: 0x000161FD
		public IEnumerable<IEdmEnumMember> Members
		{
			get
			{
				return this.members;
			}
		}

		// Token: 0x1700038E RID: 910
		// (get) Token: 0x06000890 RID: 2192 RVA: 0x00018005 File Offset: 0x00016205
		public bool IsFlags
		{
			get
			{
				return this.isFlags;
			}
		}

		// Token: 0x06000891 RID: 2193 RVA: 0x0001800D File Offset: 0x0001620D
		public void AddMember(IEdmEnumMember member)
		{
			this.members.Add(member);
		}

		// Token: 0x06000892 RID: 2194 RVA: 0x0001801C File Offset: 0x0001621C
		public EdmEnumMember AddMember(string name, IEdmPrimitiveValue value)
		{
			EdmEnumMember edmEnumMember = new EdmEnumMember(this, name, value);
			this.AddMember(edmEnumMember);
			return edmEnumMember;
		}

		// Token: 0x0400043D RID: 1085
		private readonly IEdmPrimitiveType underlyingType;

		// Token: 0x0400043E RID: 1086
		private readonly string namespaceName;

		// Token: 0x0400043F RID: 1087
		private readonly string name;

		// Token: 0x04000440 RID: 1088
		private readonly bool isFlags;

		// Token: 0x04000441 RID: 1089
		private readonly List<IEdmEnumMember> members = new List<IEdmEnumMember>();
	}
}
