﻿using System;
using System.ComponentModel.Composition;
using Microsoft.WindowsDeviceRecoveryTool.Model.DataPackage;

namespace Microsoft.WindowsDeviceRecoveryTool.HtcAdaptation
{
	// Token: 0x02000004 RID: 4
	[Export]
	internal static class HtcMsrQuery
	{
		// Token: 0x0600000D RID: 13 RVA: 0x00002220 File Offset: 0x00000420
		public static QueryParameters CreateQueryParameters(string mid, string cid)
		{
			return new QueryParameters
			{
				ManufacturerProductLine = "WindowsPhone",
				PackageType = "VariantSoftware",
				PackageClass = "Public",
				ManufacturerName = "HTC",
				ManufacturerHardwareModel = mid,
				ManufacturerHardwareVariant = cid
			};
		}

		// Token: 0x04000007 RID: 7
		private const string ManufacturerProductLine = "WindowsPhone";

		// Token: 0x04000008 RID: 8
		private const string PackageType = "VariantSoftware";

		// Token: 0x04000009 RID: 9
		private const string PackageClass = "Public";

		// Token: 0x0400000A RID: 10
		private const string ManufacturerName = "HTC";
	}
}
