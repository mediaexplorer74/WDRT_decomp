﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x02000099 RID: 153
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("5A7A54D7-5AD5-418e-AB7A-CF823A8D48D0")]
	[ComImport]
	internal interface ISubcategoryMembershipEntry
	{
		// Token: 0x17000093 RID: 147
		// (get) Token: 0x06000268 RID: 616
		SubcategoryMembershipEntry AllData
		{
			[SecurityCritical]
			get;
		}

		// Token: 0x17000094 RID: 148
		// (get) Token: 0x06000269 RID: 617
		string Subcategory
		{
			[SecurityCritical]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			get;
		}

		// Token: 0x17000095 RID: 149
		// (get) Token: 0x0600026A RID: 618
		ISection CategoryMembershipData
		{
			[SecurityCritical]
			get;
		}
	}
}
