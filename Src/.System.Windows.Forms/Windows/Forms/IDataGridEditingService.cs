﻿using System;

namespace System.Windows.Forms
{
	/// <summary>Represents methods that process editing requests.</summary>
	// Token: 0x0200028B RID: 651
	public interface IDataGridEditingService
	{
		/// <summary>Begins an edit operation.</summary>
		/// <param name="gridColumn">The <see cref="T:System.Windows.Forms.DataGridColumnStyle" /> to edit.</param>
		/// <param name="rowNumber">The index of the row to edit</param>
		/// <returns>
		///   <see langword="true" /> if the operation can be performed; otherwise <see langword="false" />.</returns>
		// Token: 0x06002994 RID: 10644
		bool BeginEdit(DataGridColumnStyle gridColumn, int rowNumber);

		/// <summary>Ends the edit operation.</summary>
		/// <param name="gridColumn">The <see cref="T:System.Windows.Forms.DataGridColumnStyle" /> to edit.</param>
		/// <param name="rowNumber">The number of the row to edit</param>
		/// <param name="shouldAbort">True if an abort operation is requested</param>
		/// <returns>
		///   <see langword="true" /> if value is commited; otherwise <see langword="false" />.</returns>
		// Token: 0x06002995 RID: 10645
		bool EndEdit(DataGridColumnStyle gridColumn, int rowNumber, bool shouldAbort);
	}
}
