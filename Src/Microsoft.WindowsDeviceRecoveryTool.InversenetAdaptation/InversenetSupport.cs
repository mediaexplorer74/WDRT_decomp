﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.WindowsDeviceRecoveryTool.Common.Tracing;
using Microsoft.WindowsDeviceRecoveryTool.Core;
using Microsoft.WindowsDeviceRecoveryTool.InversenetAdaptation.Properties;
using Microsoft.WindowsDeviceRecoveryTool.Lucid.Mtp;
using Microsoft.WindowsDeviceRecoveryTool.OemAdaptation;
using Microsoft.WindowsDeviceRecoveryTool.OemAdaptation.Helpers;
using Microsoft.WindowsDeviceRecoveryTool.OemAdaptation.Primitives;

namespace Microsoft.WindowsDeviceRecoveryTool.InversenetAdaptation
{
	// Token: 0x02000004 RID: 4
	[Export(typeof(IDeviceSupport))]
	internal class InversenetSupport : IDeviceSupport
	{
		// Token: 0x06000004 RID: 4 RVA: 0x00002104 File Offset: 0x00000304
		[ImportingConstructor]
		public InversenetSupport(IMtpDeviceInfoProvider mtpDeviceInfoProvider)
		{
			this.mtpDeviceInfoProvider = mtpDeviceInfoProvider;
			this.catalog = new ManufacturerModelsCatalog(InversenetSupport.InversenetManufacturerInfo, new ModelInfo[] { InversenetModels.EveryPhone });
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000005 RID: 5 RVA: 0x00002131 File Offset: 0x00000331
		public Guid Id
		{
			get
			{
				return InversenetSupport.SupportGuid;
			}
		}

		// Token: 0x06000006 RID: 6 RVA: 0x00002138 File Offset: 0x00000338
		public DeviceDetectionInformation[] GetDeviceDetectionInformation()
		{
			return this.catalog.GetDeviceDetectionInformations();
		}

		// Token: 0x06000007 RID: 7 RVA: 0x00002148 File Offset: 0x00000348
		public async Task UpdateDeviceDetectionDataAsync(DeviceDetectionData detectionData, CancellationToken cancellationToken)
		{
			if (detectionData.IsDeviceSupported)
			{
				throw new InvalidOperationException("Device is already supported.");
			}
			cancellationToken.ThrowIfCancellationRequested();
			VidPidPair vidPidPair = detectionData.VidPidPair;
			string usbDeviceInterfaceDevicePath = detectionData.UsbDeviceInterfaceDevicePath;
			Func<DeviceDetectionInformation, bool> <>9__1;
			if (this.catalog.Models.FirstOrDefault(delegate(ModelInfo m)
			{
				IEnumerable<DeviceDetectionInformation> deviceDetectionInformations = m.DetectionInfo.DeviceDetectionInformations;
				Func<DeviceDetectionInformation, bool> func;
				if ((func = <>9__1) == null)
				{
					func = (<>9__1 = (DeviceDetectionInformation di) => di.VidPidPair == vidPidPair);
				}
				return deviceDetectionInformations.Any(func);
			}) == null)
			{
				Tracer<InversenetSupport>.WriteInformation("No Inversenet device detected. Path: {0}", new object[] { detectionData.UsbDeviceInterfaceDevicePath });
			}
			else
			{
				string description = (await this.mtpDeviceInfoProvider.ReadInformationAsync(usbDeviceInterfaceDevicePath, cancellationToken)).Description;
				ModelInfo modelInfo;
				if (this.catalog.TryGetModelInfo(description, out modelInfo))
				{
					string name = modelInfo.Name;
					detectionData.DeviceBitmapBytes = modelInfo.Bitmap.ToBytes();
					detectionData.DeviceSalesName = name;
					detectionData.IsDeviceSupported = true;
				}
			}
		}

		// Token: 0x04000003 RID: 3
		private static readonly Guid SupportGuid = new Guid("D6CAAC94-CC9E-4C20-AE94-104F3B705803");

		// Token: 0x04000004 RID: 4
		private static readonly ManufacturerInfo InversenetManufacturerInfo = new ManufacturerInfo(Resources.FriendlyName_Manufacturer, Resources.Everyphone_logo);

		// Token: 0x04000005 RID: 5
		private readonly IMtpDeviceInfoProvider mtpDeviceInfoProvider;

		// Token: 0x04000006 RID: 6
		private readonly ManufacturerModelsCatalog catalog;
	}
}
