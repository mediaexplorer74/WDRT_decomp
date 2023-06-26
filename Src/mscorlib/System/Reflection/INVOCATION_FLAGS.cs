﻿using System;

namespace System.Reflection
{
	// Token: 0x02000603 RID: 1539
	[Flags]
	internal enum INVOCATION_FLAGS : uint
	{
		// Token: 0x04001D89 RID: 7561
		INVOCATION_FLAGS_UNKNOWN = 0U,
		// Token: 0x04001D8A RID: 7562
		INVOCATION_FLAGS_INITIALIZED = 1U,
		// Token: 0x04001D8B RID: 7563
		INVOCATION_FLAGS_NO_INVOKE = 2U,
		// Token: 0x04001D8C RID: 7564
		INVOCATION_FLAGS_NEED_SECURITY = 4U,
		// Token: 0x04001D8D RID: 7565
		INVOCATION_FLAGS_NO_CTOR_INVOKE = 8U,
		// Token: 0x04001D8E RID: 7566
		INVOCATION_FLAGS_IS_CTOR = 16U,
		// Token: 0x04001D8F RID: 7567
		INVOCATION_FLAGS_RISKY_METHOD = 32U,
		// Token: 0x04001D90 RID: 7568
		INVOCATION_FLAGS_NON_W8P_FX_API = 64U,
		// Token: 0x04001D91 RID: 7569
		INVOCATION_FLAGS_IS_DELEGATE_CTOR = 128U,
		// Token: 0x04001D92 RID: 7570
		INVOCATION_FLAGS_CONTAINS_STACK_POINTERS = 256U,
		// Token: 0x04001D93 RID: 7571
		INVOCATION_FLAGS_SPECIAL_FIELD = 16U,
		// Token: 0x04001D94 RID: 7572
		INVOCATION_FLAGS_FIELD_SPECIAL_CAST = 32U,
		// Token: 0x04001D95 RID: 7573
		INVOCATION_FLAGS_CONSTRUCTOR_INVOKE = 268435456U
	}
}
