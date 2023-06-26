﻿using System;

namespace System.Runtime.InteropServices.ComTypes
{
	/// <summary>Provides the managed definition of the <see langword="IEnumSTATDATA" /> interface.</summary>
	// Token: 0x020003E4 RID: 996
	[Guid("00000103-0000-0000-C000-000000000046")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[ComImport]
	public interface IEnumSTATDATA
	{
		/// <summary>Retrieves a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of <see cref="T:System.Runtime.InteropServices.ComTypes.STATDATA" /> references to return in <paramref name="rgelt" />.</param>
		/// <param name="rgelt">When this method returns, contains a reference to the enumerated <see cref="T:System.Runtime.InteropServices.ComTypes.STATDATA" /> references. This parameter is passed uninitialized.</param>
		/// <param name="pceltFetched">When this parameter returns, contains a reference to the actual number of references enumerated in <paramref name="rgelt" />. This parameter is passed uninitialized.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the <paramref name="pceltFetched" /> parameter equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x06002608 RID: 9736
		[PreserveSig]
		int Next(int celt, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] [Out] STATDATA[] rgelt, [MarshalAs(UnmanagedType.LPArray, SizeConst = 1)] [Out] int[] pceltFetched);

		/// <summary>Skips a specified number of items in the enumeration sequence.</summary>
		/// <param name="celt">The number of elements to skip in the enumeration.</param>
		/// <returns>
		///   <see langword="S_OK" /> if the number of elements skipped equals the <paramref name="celt" /> parameter; otherwise, <see langword="S_FALSE" />.</returns>
		// Token: 0x06002609 RID: 9737
		[PreserveSig]
		int Skip(int celt);

		/// <summary>Resets the enumeration sequence to the beginning.</summary>
		/// <returns>An HRESULT with the value <see langword="S_OK" />.</returns>
		// Token: 0x0600260A RID: 9738
		[PreserveSig]
		int Reset();

		/// <summary>Creates a new enumerator that contains the same enumeration state as the current enumerator.</summary>
		/// <param name="newEnum">When this method returns, contains a reference to the newly created enumerator. This parameter is passed uninitialized.</param>
		// Token: 0x0600260B RID: 9739
		void Clone(out IEnumSTATDATA newEnum);
	}
}
