﻿using System;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006BA RID: 1722
	internal enum CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG
	{
		// Token: 0x040022B6 RID: 8886
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_OPTIONAL = 1,
		// Token: 0x040022B7 RID: 8887
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_VISIBLE,
		// Token: 0x040022B8 RID: 8888
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_PREREQUISITE = 4,
		// Token: 0x040022B9 RID: 8889
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_RESOURCE_FALLBACK_CULTURE_INTERNAL = 8,
		// Token: 0x040022BA RID: 8890
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_INSTALL = 16,
		// Token: 0x040022BB RID: 8891
		CMS_ASSEMBLY_REFERENCE_DEPENDENT_ASSEMBLY_FLAG_ALLOW_DELAYED_BINDING = 32
	}
}
