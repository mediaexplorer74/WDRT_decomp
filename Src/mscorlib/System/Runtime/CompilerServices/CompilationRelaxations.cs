﻿using System;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	/// <summary>Specifies parameters that control the strictness of the code generated by the common language runtime's just-in-time (JIT) compiler.</summary>
	// Token: 0x020008B1 RID: 2225
	[Flags]
	[ComVisible(true)]
	[Serializable]
	public enum CompilationRelaxations
	{
		/// <summary>Marks an assembly as not requiring string-literal interning.</summary>
		// Token: 0x04002A1C RID: 10780
		NoStringInterning = 8
	}
}
