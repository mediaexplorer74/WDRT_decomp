﻿using System;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x0200007A RID: 122
	internal enum CMS_SYSTEM_PROTECTION
	{
		// Token: 0x0400021C RID: 540
		CMS_SYSTEM_PROTECTION_READ_ONLY_IGNORE_WRITES = 1,
		// Token: 0x0400021D RID: 541
		CMS_SYSTEM_PROTECTION_READ_ONLY_FAIL_WRITES,
		// Token: 0x0400021E RID: 542
		CMS_SYSTEM_PROTECTION_OS_ONLY_IGNORE_WRITES,
		// Token: 0x0400021F RID: 543
		CMS_SYSTEM_PROTECTION_OS_ONLY_FAIL_WRITES,
		// Token: 0x04000220 RID: 544
		CMS_SYSTEM_PROTECTION_TRANSACTED,
		// Token: 0x04000221 RID: 545
		CMS_SYSTEM_PROTECTION_APPLICATION_VIRTUALIZED,
		// Token: 0x04000222 RID: 546
		CMS_SYSTEM_PROTECTION_USER_VIRTUALIZED,
		// Token: 0x04000223 RID: 547
		CMS_SYSTEM_PROTECTION_APPLICATION_AND_USER_VIRTUALIZED,
		// Token: 0x04000224 RID: 548
		CMS_SYSTEM_PROTECTION_INHERIT,
		// Token: 0x04000225 RID: 549
		CMS_SYSTEM_PROTECTION_NOT_PROTECTED
	}
}
