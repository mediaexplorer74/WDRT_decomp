﻿using System;

namespace System.Security.Cryptography.X509Certificates
{
	/// <summary>Specifies the location of the X.509 certificate store.</summary>
	// Token: 0x0200047D RID: 1149
	public enum StoreLocation
	{
		/// <summary>The X.509 certificate store used by the current user.</summary>
		// Token: 0x04002630 RID: 9776
		CurrentUser = 1,
		/// <summary>The X.509 certificate store assigned to the local machine.</summary>
		// Token: 0x04002631 RID: 9777
		LocalMachine
	}
}
