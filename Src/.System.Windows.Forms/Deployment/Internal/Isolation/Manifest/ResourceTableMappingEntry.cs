﻿using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020000AF RID: 175
	[StructLayout(LayoutKind.Sequential)]
	internal class ResourceTableMappingEntry
	{
		// Token: 0x040002D2 RID: 722
		[MarshalAs(UnmanagedType.LPWStr)]
		public string id;

		// Token: 0x040002D3 RID: 723
		[MarshalAs(UnmanagedType.LPWStr)]
		public string FinalStringMapped;
	}
}
