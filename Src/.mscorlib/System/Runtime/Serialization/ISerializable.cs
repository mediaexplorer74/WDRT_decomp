﻿using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization
{
	/// <summary>Allows an object to control its own serialization and deserialization.</summary>
	// Token: 0x02000733 RID: 1843
	[ComVisible(true)]
	public interface ISerializable
	{
		/// <summary>Populates a <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with the data needed to serialize the target object.</summary>
		/// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> to populate with data.</param>
		/// <param name="context">The destination (see <see cref="T:System.Runtime.Serialization.StreamingContext" />) for this serialization.</param>
		/// <exception cref="T:System.Security.SecurityException">The caller does not have the required permission.</exception>
		// Token: 0x060051D8 RID: 20952
		[SecurityCritical]
		void GetObjectData(SerializationInfo info, StreamingContext context);
	}
}
