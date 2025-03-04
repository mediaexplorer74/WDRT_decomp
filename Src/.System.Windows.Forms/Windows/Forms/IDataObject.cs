﻿using System;
using System.Runtime.InteropServices;

namespace System.Windows.Forms
{
	/// <summary>Provides a format-independent mechanism for transferring data.</summary>
	// Token: 0x0200028C RID: 652
	[ComVisible(true)]
	public interface IDataObject
	{
		/// <summary>Retrieves the data associated with the specified data format, using a Boolean to determine whether to convert the data to the format.</summary>
		/// <param name="format">The format of the data to retrieve. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <param name="autoConvert">
		///   <see langword="true" /> to convert the data to the specified format; otherwise, <see langword="false" />.</param>
		/// <returns>The data associated with the specified format, or <see langword="null" />.</returns>
		// Token: 0x06002996 RID: 10646
		object GetData(string format, bool autoConvert);

		/// <summary>Retrieves the data associated with the specified data format.</summary>
		/// <param name="format">The format of the data to retrieve. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <returns>The data associated with the specified format, or <see langword="null" />.</returns>
		// Token: 0x06002997 RID: 10647
		object GetData(string format);

		/// <summary>Retrieves the data associated with the specified class type format.</summary>
		/// <param name="format">A <see cref="T:System.Type" /> representing the format of the data to retrieve. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <returns>The data associated with the specified format, or <see langword="null" />.</returns>
		// Token: 0x06002998 RID: 10648
		object GetData(Type format);

		/// <summary>Stores the specified data and its associated format in this instance, using a Boolean value to specify whether the data can be converted to another format.</summary>
		/// <param name="format">The format associated with the data. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <param name="autoConvert">
		///   <see langword="true" /> to allow the data to be converted to another format; otherwise, <see langword="false" />.</param>
		/// <param name="data">The data to store.</param>
		// Token: 0x06002999 RID: 10649
		void SetData(string format, bool autoConvert, object data);

		/// <summary>Stores the specified data and its associated format in this instance.</summary>
		/// <param name="format">The format associated with the data. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <param name="data">The data to store.</param>
		// Token: 0x0600299A RID: 10650
		void SetData(string format, object data);

		/// <summary>Stores the specified data and its associated class type in this instance.</summary>
		/// <param name="format">A <see cref="T:System.Type" /> representing the format associated with the data. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <param name="data">The data to store.</param>
		// Token: 0x0600299B RID: 10651
		void SetData(Type format, object data);

		/// <summary>Stores the specified data in this instance, using the class of the data for the format.</summary>
		/// <param name="data">The data to store.</param>
		// Token: 0x0600299C RID: 10652
		void SetData(object data);

		/// <summary>Determines whether data stored in this instance is associated with the specified format, using a Boolean value to determine whether to convert the data to the format.</summary>
		/// <param name="format">The format for which to check. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <param name="autoConvert">
		///   <see langword="true" /> to determine whether data stored in this instance can be converted to the specified format; <see langword="false" /> to check whether the data is in the specified format.</param>
		/// <returns>
		///   <see langword="true" /> if the data is in, or can be converted to, the specified format; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600299D RID: 10653
		bool GetDataPresent(string format, bool autoConvert);

		/// <summary>Determines whether data stored in this instance is associated with, or can be converted to, the specified format.</summary>
		/// <param name="format">The format for which to check. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <returns>
		///   <see langword="true" /> if data stored in this instance is associated with, or can be converted to, the specified format; otherwise <see langword="false" />.</returns>
		// Token: 0x0600299E RID: 10654
		bool GetDataPresent(string format);

		/// <summary>Determines whether data stored in this instance is associated with, or can be converted to, the specified format.</summary>
		/// <param name="format">A <see cref="T:System.Type" /> representing the format for which to check. See <see cref="T:System.Windows.Forms.DataFormats" /> for predefined formats.</param>
		/// <returns>
		///   <see langword="true" /> if data stored in this instance is associated with, or can be converted to, the specified format; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600299F RID: 10655
		bool GetDataPresent(Type format);

		/// <summary>Gets a list of all formats that data stored in this instance is associated with or can be converted to, using a Boolean value to determine whether to retrieve all formats that the data can be converted to or only native data formats.</summary>
		/// <param name="autoConvert">
		///   <see langword="true" /> to retrieve all formats that data stored in this instance is associated with or can be converted to; <see langword="false" /> to retrieve only native data formats.</param>
		/// <returns>An array of the names that represents a list of all formats that are supported by the data stored in this object.</returns>
		// Token: 0x060029A0 RID: 10656
		string[] GetFormats(bool autoConvert);

		/// <summary>Returns a list of all formats that data stored in this instance is associated with or can be converted to.</summary>
		/// <returns>An array of the names that represents a list of all formats that are supported by the data stored in this object.</returns>
		// Token: 0x060029A1 RID: 10657
		string[] GetFormats();
	}
}
