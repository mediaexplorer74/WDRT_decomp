﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020000C6 RID: 198
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("4A33D662-2210-463A-BE9F-FBDF1AA554E3")]
	[ComImport]
	internal interface ICompatibleFrameworksMetadataEntry
	{
		// Token: 0x170000E0 RID: 224
		// (get) Token: 0x060002C7 RID: 711
		CompatibleFrameworksMetadataEntry AllData
		{
			[SecurityCritical]
			get;
		}

		// Token: 0x170000E1 RID: 225
		// (get) Token: 0x060002C8 RID: 712
		string SupportUrl
		{
			[SecurityCritical]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			get;
		}
	}
}
