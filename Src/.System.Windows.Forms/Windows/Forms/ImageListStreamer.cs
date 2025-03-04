﻿using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Security.Permissions;

namespace System.Windows.Forms
{
	/// <summary>Provides the data portion of an <see cref="T:System.Windows.Forms.ImageList" />.</summary>
	// Token: 0x02000295 RID: 661
	[Serializable]
	public sealed class ImageListStreamer : ISerializable, IDisposable
	{
		// Token: 0x060029F3 RID: 10739 RVA: 0x000BEEBD File Offset: 0x000BD0BD
		internal ImageListStreamer(ImageList il)
		{
			this.imageList = il;
		}

		// Token: 0x060029F4 RID: 10740 RVA: 0x000BEECC File Offset: 0x000BD0CC
		private ImageListStreamer(SerializationInfo info, StreamingContext context)
		{
			SerializationInfoEnumerator enumerator = info.GetEnumerator();
			if (enumerator == null)
			{
				return;
			}
			while (enumerator.MoveNext())
			{
				if (string.Equals(enumerator.Name, "Data", StringComparison.OrdinalIgnoreCase))
				{
					byte[] array = (byte[])enumerator.Value;
					if (array != null)
					{
						IntPtr intPtr = UnsafeNativeMethods.ThemingScope.Activate();
						try
						{
							MemoryStream memoryStream = new MemoryStream(this.Decompress(array));
							object obj = ImageListStreamer.internalSyncObject;
							lock (obj)
							{
								SafeNativeMethods.InitCommonControls();
								this.nativeImageList = new ImageList.NativeImageList(SafeNativeMethods.ImageList_Read(new UnsafeNativeMethods.ComStreamFromDataStream(memoryStream)));
							}
						}
						finally
						{
							UnsafeNativeMethods.ThemingScope.Deactivate(intPtr);
						}
						if (this.nativeImageList.Handle == IntPtr.Zero)
						{
							throw new InvalidOperationException(SR.GetString("ImageListStreamerLoadFailed"));
						}
					}
				}
			}
		}

		// Token: 0x060029F5 RID: 10741 RVA: 0x000BEFB8 File Offset: 0x000BD1B8
		private byte[] Compress(byte[] input)
		{
			int num = 0;
			int i = 0;
			int num2 = 0;
			while (i < input.Length)
			{
				byte b = input[i++];
				byte b2 = 1;
				while (i < input.Length && input[i] == b && b2 < 255)
				{
					b2 += 1;
					i++;
				}
				num += 2;
			}
			byte[] array = new byte[num + ImageListStreamer.HEADER_MAGIC.Length];
			Buffer.BlockCopy(ImageListStreamer.HEADER_MAGIC, 0, array, 0, ImageListStreamer.HEADER_MAGIC.Length);
			int num3 = ImageListStreamer.HEADER_MAGIC.Length;
			i = 0;
			while (i < input.Length)
			{
				byte b3 = input[i++];
				byte b4 = 1;
				while (i < input.Length && input[i] == b3 && b4 < 255)
				{
					b4 += 1;
					i++;
				}
				array[num3 + num2++] = b4;
				array[num3 + num2++] = b3;
			}
			return array;
		}

		// Token: 0x060029F6 RID: 10742 RVA: 0x000BF084 File Offset: 0x000BD284
		private byte[] Decompress(byte[] input)
		{
			int num = 0;
			int num2 = 0;
			if (input.Length < ImageListStreamer.HEADER_MAGIC.Length)
			{
				return input;
			}
			int i;
			for (i = 0; i < ImageListStreamer.HEADER_MAGIC.Length; i++)
			{
				if (input[i] != ImageListStreamer.HEADER_MAGIC[i])
				{
					return input;
				}
			}
			for (i = ImageListStreamer.HEADER_MAGIC.Length; i < input.Length; i += 2)
			{
				num += (int)input[i];
			}
			byte[] array = new byte[num];
			i = ImageListStreamer.HEADER_MAGIC.Length;
			while (i < input.Length)
			{
				byte b = input[i++];
				byte b2 = input[i++];
				int j = num2;
				int num3 = num2 + (int)b;
				while (j < num3)
				{
					array[j++] = b2;
				}
				num2 += (int)b;
			}
			return array;
		}

		/// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.</summary>
		/// <param name="si">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
		/// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that is the destination for this serialization.</param>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> cannot be populated with data because no data exists, or it is not in the correct format.</exception>
		// Token: 0x060029F7 RID: 10743 RVA: 0x000BF12C File Offset: 0x000BD32C
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
		public void GetObjectData(SerializationInfo si, StreamingContext context)
		{
			MemoryStream memoryStream = new MemoryStream();
			IntPtr intPtr = IntPtr.Zero;
			if (this.imageList != null)
			{
				intPtr = this.imageList.Handle;
			}
			else if (this.nativeImageList != null)
			{
				intPtr = this.nativeImageList.Handle;
			}
			if (intPtr == IntPtr.Zero || !this.WriteImageList(intPtr, memoryStream))
			{
				throw new InvalidOperationException(SR.GetString("ImageListStreamerSaveFailed"));
			}
			si.AddValue("Data", this.Compress(memoryStream.ToArray()));
		}

		// Token: 0x060029F8 RID: 10744 RVA: 0x000BF1AD File Offset: 0x000BD3AD
		internal ImageList.NativeImageList GetNativeImageList()
		{
			return this.nativeImageList;
		}

		// Token: 0x060029F9 RID: 10745 RVA: 0x000BF1B8 File Offset: 0x000BD3B8
		private bool WriteImageList(IntPtr imagelistHandle, Stream stream)
		{
			try
			{
				int num = SafeNativeMethods.ImageList_WriteEx(new HandleRef(this, imagelistHandle), 1, new UnsafeNativeMethods.ComStreamFromDataStream(stream));
				return num == 0;
			}
			catch (EntryPointNotFoundException)
			{
			}
			return SafeNativeMethods.ImageList_Write(new HandleRef(this, imagelistHandle), new UnsafeNativeMethods.ComStreamFromDataStream(stream));
		}

		/// <summary>Releases all resources used by the current instance of the <see cref="T:System.Windows.Forms.ImageListStreamer" /> class.</summary>
		// Token: 0x060029FA RID: 10746 RVA: 0x000BF208 File Offset: 0x000BD408
		public void Dispose()
		{
			this.Dispose(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x060029FB RID: 10747 RVA: 0x000BF217 File Offset: 0x000BD417
		private void Dispose(bool disposing)
		{
			if (disposing && this.nativeImageList != null)
			{
				this.nativeImageList.Dispose();
				this.nativeImageList = null;
			}
		}

		// Token: 0x040010FB RID: 4347
		private static readonly byte[] HEADER_MAGIC = new byte[] { 77, 83, 70, 116 };

		// Token: 0x040010FC RID: 4348
		private static object internalSyncObject = new object();

		// Token: 0x040010FD RID: 4349
		private ImageList imageList;

		// Token: 0x040010FE RID: 4350
		private ImageList.NativeImageList nativeImageList;
	}
}
