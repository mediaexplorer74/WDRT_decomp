﻿using System;
using System.Security;
using System.Threading;

namespace System.Resources
{
	// Token: 0x020000E8 RID: 232
	internal static class MultitargetUtil
	{
		// Token: 0x0600032C RID: 812 RVA: 0x00008C4C File Offset: 0x00006E4C
		public static string GetAssemblyQualifiedName(Type type, Func<Type, string> typeNameConverter)
		{
			string text = null;
			if (type != null)
			{
				if (typeNameConverter != null)
				{
					try
					{
						text = typeNameConverter(type);
					}
					catch (Exception ex)
					{
						if (MultitargetUtil.IsSecurityOrCriticalException(ex))
						{
							throw;
						}
					}
				}
				if (string.IsNullOrEmpty(text))
				{
					text = type.AssemblyQualifiedName;
				}
			}
			return text;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x00008CA0 File Offset: 0x00006EA0
		private static bool IsSecurityOrCriticalException(Exception ex)
		{
			return ex is NullReferenceException || ex is StackOverflowException || ex is OutOfMemoryException || ex is ThreadAbortException || ex is ExecutionEngineException || ex is IndexOutOfRangeException || ex is AccessViolationException || ex is SecurityException;
		}
	}
}
