﻿using System;

namespace System.Management
{
	// Token: 0x0200007E RID: 126
	internal enum tag_WBEM_COMPARISON_FLAG
	{
		// Token: 0x040002A3 RID: 675
		WBEM_COMPARISON_INCLUDE_ALL,
		// Token: 0x040002A4 RID: 676
		WBEM_FLAG_IGNORE_QUALIFIERS,
		// Token: 0x040002A5 RID: 677
		WBEM_FLAG_IGNORE_OBJECT_SOURCE,
		// Token: 0x040002A6 RID: 678
		WBEM_FLAG_IGNORE_DEFAULT_VALUES = 4,
		// Token: 0x040002A7 RID: 679
		WBEM_FLAG_IGNORE_CLASS = 8,
		// Token: 0x040002A8 RID: 680
		WBEM_FLAG_IGNORE_CASE = 16,
		// Token: 0x040002A9 RID: 681
		WBEM_FLAG_IGNORE_FLAVOR = 32
	}
}
