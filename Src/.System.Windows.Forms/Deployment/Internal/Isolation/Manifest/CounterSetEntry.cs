﻿using System;
using System.Runtime.InteropServices;

namespace System.Deployment.Internal.Isolation.Manifest
{
	// Token: 0x020000DF RID: 223
	[StructLayout(LayoutKind.Sequential)]
	internal class CounterSetEntry
	{
		// Token: 0x04000389 RID: 905
		public Guid CounterSetGuid;

		// Token: 0x0400038A RID: 906
		public Guid ProviderGuid;

		// Token: 0x0400038B RID: 907
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Name;

		// Token: 0x0400038C RID: 908
		[MarshalAs(UnmanagedType.LPWStr)]
		public string Description;

		// Token: 0x0400038D RID: 909
		public bool InstanceType;
	}
}
