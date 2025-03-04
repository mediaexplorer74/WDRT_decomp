﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020000D2 RID: 210
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[Guid("8AD3FC86-AFD3-477a-8FD5-146C291195BD")]
	[ComImport]
	internal interface IEventTagEntry
	{
		// Token: 0x17000105 RID: 261
		// (get) Token: 0x060002F3 RID: 755
		EventTagEntry AllData
		{
			[SecurityCritical]
			get;
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x060002F4 RID: 756
		string TagData
		{
			[SecurityCritical]
			[return: MarshalAs(UnmanagedType.LPWStr)]
			get;
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x060002F5 RID: 757
		uint EventID
		{
			[SecurityCritical]
			get;
		}
	}
}
