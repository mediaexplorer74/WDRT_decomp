﻿using System;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000069 RID: 105
	internal enum CMSSECTIONID
	{
		// Token: 0x040001B3 RID: 435
		CMSSECTIONID_FILE_SECTION = 1,
		// Token: 0x040001B4 RID: 436
		CMSSECTIONID_CATEGORY_INSTANCE_SECTION,
		// Token: 0x040001B5 RID: 437
		CMSSECTIONID_COM_REDIRECTION_SECTION,
		// Token: 0x040001B6 RID: 438
		CMSSECTIONID_PROGID_REDIRECTION_SECTION,
		// Token: 0x040001B7 RID: 439
		CMSSECTIONID_CLR_SURROGATE_SECTION,
		// Token: 0x040001B8 RID: 440
		CMSSECTIONID_ASSEMBLY_REFERENCE_SECTION,
		// Token: 0x040001B9 RID: 441
		CMSSECTIONID_WINDOW_CLASS_SECTION = 8,
		// Token: 0x040001BA RID: 442
		CMSSECTIONID_STRING_SECTION,
		// Token: 0x040001BB RID: 443
		CMSSECTIONID_ENTRYPOINT_SECTION,
		// Token: 0x040001BC RID: 444
		CMSSECTIONID_PERMISSION_SET_SECTION,
		// Token: 0x040001BD RID: 445
		CMSSECTIONENTRYID_METADATA,
		// Token: 0x040001BE RID: 446
		CMSSECTIONID_ASSEMBLY_REQUEST_SECTION,
		// Token: 0x040001BF RID: 447
		CMSSECTIONID_REGISTRY_KEY_SECTION = 16,
		// Token: 0x040001C0 RID: 448
		CMSSECTIONID_DIRECTORY_SECTION,
		// Token: 0x040001C1 RID: 449
		CMSSECTIONID_FILE_ASSOCIATION_SECTION,
		// Token: 0x040001C2 RID: 450
		CMSSECTIONID_COMPATIBLE_FRAMEWORKS_SECTION,
		// Token: 0x040001C3 RID: 451
		CMSSECTIONID_EVENT_SECTION = 101,
		// Token: 0x040001C4 RID: 452
		CMSSECTIONID_EVENT_MAP_SECTION,
		// Token: 0x040001C5 RID: 453
		CMSSECTIONID_EVENT_TAG_SECTION,
		// Token: 0x040001C6 RID: 454
		CMSSECTIONID_COUNTERSET_SECTION = 110,
		// Token: 0x040001C7 RID: 455
		CMSSECTIONID_COUNTER_SECTION
	}
}
