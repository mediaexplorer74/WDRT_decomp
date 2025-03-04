﻿using System;

namespace System.Drawing.Printing
{
	/// <summary>Specifies print preview information for a single page. This class cannot be inherited.</summary>
	// Token: 0x0200005D RID: 93
	public sealed class PreviewPageInfo
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Drawing.Printing.PreviewPageInfo" /> class.</summary>
		/// <param name="image">The image of the printed page.</param>
		/// <param name="physicalSize">The size of the printed page, in hundredths of an inch.</param>
		// Token: 0x06000760 RID: 1888 RVA: 0x0001E037 File Offset: 0x0001C237
		public PreviewPageInfo(Image image, Size physicalSize)
		{
			this.image = image;
			this.physicalSize = physicalSize;
		}

		/// <summary>Gets the image of the printed page.</summary>
		/// <returns>An <see cref="T:System.Drawing.Image" /> representing the printed page.</returns>
		// Token: 0x170002E3 RID: 739
		// (get) Token: 0x06000761 RID: 1889 RVA: 0x0001E058 File Offset: 0x0001C258
		public Image Image
		{
			get
			{
				return this.image;
			}
		}

		/// <summary>Gets the size of the printed page, in hundredths of an inch.</summary>
		/// <returns>A <see cref="T:System.Drawing.Size" /> that specifies the size of the printed page, in hundredths of an inch.</returns>
		// Token: 0x170002E4 RID: 740
		// (get) Token: 0x06000762 RID: 1890 RVA: 0x0001E060 File Offset: 0x0001C260
		public Size PhysicalSize
		{
			get
			{
				return this.physicalSize;
			}
		}

		// Token: 0x040006B4 RID: 1716
		private Image image;

		// Token: 0x040006B5 RID: 1717
		private Size physicalSize = Size.Empty;
	}
}
