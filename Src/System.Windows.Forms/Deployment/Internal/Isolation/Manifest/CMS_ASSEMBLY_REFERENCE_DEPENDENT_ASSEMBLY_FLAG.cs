﻿using System;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x0200006C RID: 108
	internal enum CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG
	{
		// Token: 0x040001D9 RID: 473
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_OPTIONAL = 1,
		// Token: 0x040001DA RID: 474
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_VISIBLE,
		// Token: 0x040001DB RID: 475
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_PREREQUISITE = 4,
		// Token: 0x040001DC RID: 476
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_RESOURCE_FALLBACK_CULTURE_INTERNAL = 8,
		// Token: 0x040001DD RID: 477
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_INSTALL = 16,
		// Token: 0x040001DE RID: 478
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_ALLOW_DELAYED_BINDING = 32
	}
}
