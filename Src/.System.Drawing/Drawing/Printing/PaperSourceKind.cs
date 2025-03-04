﻿using System;

namespace System.Drawing.Printing
{
	/// <summary>Standard paper sources.</summary>
	// Token: 0x0200005C RID: 92
	[Serializable]
	public enum PaperSourceKind
	{
		/// <summary>The upper bin of a printer (or the default bin, if the printer only has one bin).</summary>
		// Token: 0x040006A6 RID: 1702
		Upper = 1,
		/// <summary>The lower bin of a printer.</summary>
		// Token: 0x040006A7 RID: 1703
		Lower,
		/// <summary>The middle bin of a printer.</summary>
		// Token: 0x040006A8 RID: 1704
		Middle,
		/// <summary>Manually fed paper.</summary>
		// Token: 0x040006A9 RID: 1705
		Manual,
		/// <summary>An envelope.</summary>
		// Token: 0x040006AA RID: 1706
		Envelope,
		/// <summary>Manually fed envelope.</summary>
		// Token: 0x040006AB RID: 1707
		ManualFeed,
		/// <summary>Automatically fed paper.</summary>
		// Token: 0x040006AC RID: 1708
		AutomaticFeed,
		/// <summary>A tractor feed.</summary>
		// Token: 0x040006AD RID: 1709
		TractorFeed,
		/// <summary>Small-format paper.</summary>
		// Token: 0x040006AE RID: 1710
		SmallFormat,
		/// <summary>Large-format paper.</summary>
		// Token: 0x040006AF RID: 1711
		LargeFormat,
		/// <summary>The printer's large-capacity bin.</summary>
		// Token: 0x040006B0 RID: 1712
		LargeCapacity,
		/// <summary>A paper cassette.</summary>
		// Token: 0x040006B1 RID: 1713
		Cassette = 14,
		/// <summary>The printer's default input bin.</summary>
		// Token: 0x040006B2 RID: 1714
		FormSource,
		/// <summary>A printer-specific paper source.</summary>
		// Token: 0x040006B3 RID: 1715
		Custom = 257
	}
}
