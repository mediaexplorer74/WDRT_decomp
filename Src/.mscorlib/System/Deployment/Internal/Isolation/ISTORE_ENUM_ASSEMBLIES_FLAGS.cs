﻿using System;

namespace System.Deployment.Internal.Isolation
{
	// Token: 0x0200069C RID: 1692
	[Flags]
	internal enum ISTORE_ENUM_ASSEMBLIES_FLAGS
	{
		// Token: 0x04002225 RID: 8741
		ISTORE_ENUM_ASSEMBLIES_FLAG_LIMIT_TO_VISIBLE_ONLY = 1,
		// Token: 0x04002226 RID: 8742
		ISTORE_ENUM_ASSEMBLIES_FLAG_MATCH_SERVICING = 2,
		// Token: 0x04002227 RID: 8743
		ISTORE_ENUM_ASSEMBLIES_FLAG_FORCE_LIBRARY_SEMANTICS = 4
	}
}
