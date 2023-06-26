﻿using System;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020006B9 RID: 1721
	internal enum CMS_ASSEMBLY_REFERENCE_FLAG
	{
		// Token: 0x040022AE RID: 8878
		CMS_ASSEMBLY_REFERENCE_FLAG_OPTIONAL = 1,
		// Token: 0x040022AF RID: 8879
		CMS_ASSEMBLY_REFERENCE_FLAG_VISIBLE,
		// Token: 0x040022B0 RID: 8880
		CMS_ASSEMBLY_REFERENCE_FLAG_FOLLOW = 4,
		// Token: 0x040022B1 RID: 8881
		CMS_ASSEMBLY_REFERENCE_FLAG_IS_PLATFORM = 8,
		// Token: 0x040022B2 RID: 8882
		CMS_ASSEMBLY_REFERENCE_FLAG_CULTURE_WILDCARDED = 16,
		// Token: 0x040022B3 RID: 8883
		CMS_ASSEMBLY_REFERENCE_FLAG_PROCESSOR_ARCHITECTURE_WILDCARDED = 32,
		// Token: 0x040022B4 RID: 8884
		CMS_ASSEMBLY_REFERENCE_FLAG_PREREQUISITE = 128
	}
}
