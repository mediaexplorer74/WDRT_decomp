﻿using System;

namespace System.Windows.Forms.Design
{
	/// <summary>Provides an interface for a <see cref="T:System.Drawing.Design.UITypeEditor" /> to display Windows Forms or to display a control in a drop-down area from a property grid control in design mode.</summary>
	// Token: 0x0200048A RID: 1162
	public interface IWindowsFormsEditorService
	{
		/// <summary>Closes any previously opened drop down control area.</summary>
		// Token: 0x06004E26 RID: 20006
		void CloseDropDown();

		/// <summary>Displays the specified control in a drop down area below a value field of the property grid that provides this service.</summary>
		/// <param name="control">The drop down list <see cref="T:System.Windows.Forms.Control" /> to open.</param>
		// Token: 0x06004E27 RID: 20007
		void DropDownControl(Control control);

		/// <summary>Shows the specified <see cref="T:System.Windows.Forms.Form" />.</summary>
		/// <param name="dialog">The <see cref="T:System.Windows.Forms.Form" /> to display.</param>
		/// <returns>A <see cref="T:System.Windows.Forms.DialogResult" /> indicating the result code returned by the <see cref="T:System.Windows.Forms.Form" />.</returns>
		// Token: 0x06004E28 RID: 20008
		DialogResult ShowDialog(Form dialog);
	}
}
