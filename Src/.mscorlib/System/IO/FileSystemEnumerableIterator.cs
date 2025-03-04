﻿using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using Microsoft.Win32;
using Microsoft.Win32.SafeHandles;

namespace System.IO
{
	// Token: 0x0200018F RID: 399
	internal class FileSystemEnumerableIterator<TSource> : Iterator<TSource>
	{
		// Token: 0x06001898 RID: 6296 RVA: 0x000503F8 File Offset: 0x0004E5F8
		[SecuritySafeCritical]
		internal FileSystemEnumerableIterator(string path, string originalUserPath, string searchPattern, SearchOption searchOption, SearchResultHandler<TSource> resultHandler, bool checkHost)
		{
			this.oldMode = Win32Native.SetErrorMode(1);
			this.searchStack = new List<Directory.SearchData>();
			string text = FileSystemEnumerableIterator<TSource>.NormalizeSearchPattern(searchPattern);
			if (text.Length == 0)
			{
				this.empty = true;
				return;
			}
			this._resultHandler = resultHandler;
			this.searchOption = searchOption;
			this.fullPath = Path.GetFullPathInternal(path);
			string fullSearchString = FileSystemEnumerableIterator<TSource>.GetFullSearchString(this.fullPath, text);
			this.normalizedSearchPath = Path.GetDirectoryName(fullSearchString);
			if (CodeAccessSecurityEngine.QuickCheckForAllDemands())
			{
				FileIOPermission.EmulateFileIOPermissionChecks(this.fullPath);
				FileIOPermission.EmulateFileIOPermissionChecks(this.normalizedSearchPath);
			}
			else
			{
				new FileIOPermission(FileIOPermissionAccess.PathDiscovery, new string[]
				{
					Directory.GetDemandDir(this.fullPath, true),
					Directory.GetDemandDir(this.normalizedSearchPath, true)
				}, false, false).Demand();
			}
			this._checkHost = checkHost;
			this.searchCriteria = FileSystemEnumerableIterator<TSource>.GetNormalizedSearchCriteria(fullSearchString, this.normalizedSearchPath);
			string directoryName = Path.GetDirectoryName(text);
			string text2 = originalUserPath;
			if (directoryName != null && directoryName.Length != 0)
			{
				text2 = Path.CombineNoChecks(text2, directoryName);
			}
			this.userPath = text2;
			this.searchData = new Directory.SearchData(this.normalizedSearchPath, this.userPath, searchOption);
			this.CommonInit();
		}

		// Token: 0x06001899 RID: 6297 RVA: 0x00050520 File Offset: 0x0004E720
		[SecurityCritical]
		private void CommonInit()
		{
			string text = Path.InternalCombine(this.searchData.fullPath, this.searchCriteria);
			Win32Native.WIN32_FIND_DATA win32_FIND_DATA = default(Win32Native.WIN32_FIND_DATA);
			this._hnd = Win32Native.FindFirstFile(text, ref win32_FIND_DATA);
			if (this._hnd.IsInvalid)
			{
				int lastWin32Error = Marshal.GetLastWin32Error();
				if (lastWin32Error != 2 && lastWin32Error != 18)
				{
					this.HandleError(lastWin32Error, this.searchData.fullPath);
				}
				else
				{
					this.empty = this.searchData.searchOption == SearchOption.TopDirectoryOnly;
				}
			}
			if (this.searchData.searchOption == SearchOption.TopDirectoryOnly)
			{
				if (this.empty)
				{
					this._hnd.Dispose();
					return;
				}
				if (this._resultHandler.IsResultIncluded(ref win32_FIND_DATA))
				{
					this.current = this._resultHandler.CreateObject(this.searchData, ref win32_FIND_DATA);
					return;
				}
			}
			else
			{
				this._hnd.Dispose();
				this.searchStack.Add(this.searchData);
			}
		}

		// Token: 0x0600189A RID: 6298 RVA: 0x00050604 File Offset: 0x0004E804
		[SecuritySafeCritical]
		private FileSystemEnumerableIterator(string fullPath, string normalizedSearchPath, string searchCriteria, string userPath, SearchOption searchOption, SearchResultHandler<TSource> resultHandler, bool checkHost)
		{
			this.fullPath = fullPath;
			this.normalizedSearchPath = normalizedSearchPath;
			this.searchCriteria = searchCriteria;
			this._resultHandler = resultHandler;
			this.userPath = userPath;
			this.searchOption = searchOption;
			this._checkHost = checkHost;
			this.searchStack = new List<Directory.SearchData>();
			if (searchCriteria != null)
			{
				if (CodeAccessSecurityEngine.QuickCheckForAllDemands())
				{
					FileIOPermission.EmulateFileIOPermissionChecks(fullPath);
					FileIOPermission.EmulateFileIOPermissionChecks(normalizedSearchPath);
				}
				else
				{
					new FileIOPermission(FileIOPermissionAccess.PathDiscovery, new string[]
					{
						Directory.GetDemandDir(fullPath, true),
						Directory.GetDemandDir(normalizedSearchPath, true)
					}, false, false).Demand();
				}
				this.searchData = new Directory.SearchData(normalizedSearchPath, userPath, searchOption);
				this.CommonInit();
				return;
			}
			this.empty = true;
		}

		// Token: 0x0600189B RID: 6299 RVA: 0x000506B6 File Offset: 0x0004E8B6
		protected override Iterator<TSource> Clone()
		{
			return new FileSystemEnumerableIterator<TSource>(this.fullPath, this.normalizedSearchPath, this.searchCriteria, this.userPath, this.searchOption, this._resultHandler, this._checkHost);
		}

		// Token: 0x0600189C RID: 6300 RVA: 0x000506E8 File Offset: 0x0004E8E8
		[SecuritySafeCritical]
		protected override void Dispose(bool disposing)
		{
			try
			{
				if (this._hnd != null)
				{
					this._hnd.Dispose();
				}
			}
			finally
			{
				Win32Native.SetErrorMode(this.oldMode);
				base.Dispose(disposing);
			}
		}

		// Token: 0x0600189D RID: 6301 RVA: 0x00050730 File Offset: 0x0004E930
		[SecuritySafeCritical]
		public override bool MoveNext()
		{
			Win32Native.WIN32_FIND_DATA win32_FIND_DATA = default(Win32Native.WIN32_FIND_DATA);
			switch (this.state)
			{
			case 1:
				if (this.empty)
				{
					this.state = 4;
					goto IL_242;
				}
				if (this.searchData.searchOption == SearchOption.TopDirectoryOnly)
				{
					this.state = 3;
					if (this.current != null)
					{
						return true;
					}
					goto IL_173;
				}
				else
				{
					this.state = 2;
				}
				break;
			case 2:
				break;
			case 3:
				goto IL_173;
			case 4:
				goto IL_242;
			default:
				return false;
			}
			IL_156:
			while (this.searchStack.Count > 0)
			{
				this.searchData = this.searchStack[0];
				this.searchStack.RemoveAt(0);
				this.AddSearchableDirsToStack(this.searchData);
				string text = Path.InternalCombine(this.searchData.fullPath, this.searchCriteria);
				this._hnd = Win32Native.FindFirstFile(text, ref win32_FIND_DATA);
				if (this._hnd.IsInvalid)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 2 || lastWin32Error == 18 || lastWin32Error == 3)
					{
						continue;
					}
					this._hnd.Dispose();
					this.HandleError(lastWin32Error, this.searchData.fullPath);
				}
				this.state = 3;
				this.needsParentPathDiscoveryDemand = true;
				if (this._resultHandler.IsResultIncluded(ref win32_FIND_DATA))
				{
					if (this.needsParentPathDiscoveryDemand)
					{
						this.DoDemand(this.searchData.fullPath);
						this.needsParentPathDiscoveryDemand = false;
					}
					this.current = this._resultHandler.CreateObject(this.searchData, ref win32_FIND_DATA);
					return true;
				}
				goto IL_173;
			}
			this.state = 4;
			goto IL_242;
			IL_173:
			if (this.searchData != null && this._hnd != null)
			{
				while (Win32Native.FindNextFile(this._hnd, ref win32_FIND_DATA))
				{
					if (this._resultHandler.IsResultIncluded(ref win32_FIND_DATA))
					{
						if (this.needsParentPathDiscoveryDemand)
						{
							this.DoDemand(this.searchData.fullPath);
							this.needsParentPathDiscoveryDemand = false;
						}
						this.current = this._resultHandler.CreateObject(this.searchData, ref win32_FIND_DATA);
						return true;
					}
				}
				int lastWin32Error2 = Marshal.GetLastWin32Error();
				if (this._hnd != null)
				{
					this._hnd.Dispose();
				}
				if (lastWin32Error2 != 0 && lastWin32Error2 != 18 && lastWin32Error2 != 2)
				{
					this.HandleError(lastWin32Error2, this.searchData.fullPath);
				}
			}
			if (this.searchData.searchOption != SearchOption.TopDirectoryOnly)
			{
				this.state = 2;
				goto IL_156;
			}
			this.state = 4;
			IL_242:
			base.Dispose();
			return false;
		}

		// Token: 0x0600189E RID: 6302 RVA: 0x00050986 File Offset: 0x0004EB86
		[SecurityCritical]
		private void HandleError(int hr, string path)
		{
			base.Dispose();
			__Error.WinIOError(hr, path);
		}

		// Token: 0x0600189F RID: 6303 RVA: 0x00050998 File Offset: 0x0004EB98
		[SecurityCritical]
		private void AddSearchableDirsToStack(Directory.SearchData localSearchData)
		{
			string text = Path.InternalCombine(localSearchData.fullPath, "*");
			SafeFindHandle safeFindHandle = null;
			Win32Native.WIN32_FIND_DATA win32_FIND_DATA = default(Win32Native.WIN32_FIND_DATA);
			try
			{
				safeFindHandle = Win32Native.FindFirstFile(text, ref win32_FIND_DATA);
				if (safeFindHandle.IsInvalid)
				{
					int lastWin32Error = Marshal.GetLastWin32Error();
					if (lastWin32Error == 2 || lastWin32Error == 18 || lastWin32Error == 3)
					{
						return;
					}
					this.HandleError(lastWin32Error, localSearchData.fullPath);
				}
				int num = 0;
				do
				{
					if (win32_FIND_DATA.IsNormalDirectory)
					{
						string cFileName = win32_FIND_DATA.cFileName;
						string text2 = Path.CombineNoChecks(localSearchData.fullPath, cFileName);
						string text3 = Path.CombineNoChecks(localSearchData.userPath, cFileName);
						SearchOption searchOption = localSearchData.searchOption;
						Directory.SearchData searchData = new Directory.SearchData(text2, text3, searchOption);
						this.searchStack.Insert(num++, searchData);
					}
				}
				while (Win32Native.FindNextFile(safeFindHandle, ref win32_FIND_DATA));
			}
			finally
			{
				if (safeFindHandle != null)
				{
					safeFindHandle.Dispose();
				}
			}
		}

		// Token: 0x060018A0 RID: 6304 RVA: 0x00050A78 File Offset: 0x0004EC78
		[SecurityCritical]
		internal void DoDemand(string fullPathToDemand)
		{
			string demandDir = Directory.GetDemandDir(fullPathToDemand, true);
			FileIOPermission.QuickDemand(FileIOPermissionAccess.PathDiscovery, demandDir, false, false);
		}

		// Token: 0x060018A1 RID: 6305 RVA: 0x00050A98 File Offset: 0x0004EC98
		private static string NormalizeSearchPattern(string searchPattern)
		{
			string text = searchPattern.TrimEnd(Path.TrimEndChars);
			if (text.Equals("."))
			{
				text = "*";
			}
			Path.CheckSearchPattern(text);
			return text;
		}

		// Token: 0x060018A2 RID: 6306 RVA: 0x00050ACC File Offset: 0x0004ECCC
		private static string GetNormalizedSearchCriteria(string fullSearchString, string fullPathMod)
		{
			char c = fullPathMod[fullPathMod.Length - 1];
			string text;
			if (Path.IsDirectorySeparator(c))
			{
				text = fullSearchString.Substring(fullPathMod.Length);
			}
			else
			{
				text = fullSearchString.Substring(fullPathMod.Length + 1);
			}
			return text;
		}

		// Token: 0x060018A3 RID: 6307 RVA: 0x00050B14 File Offset: 0x0004ED14
		private static string GetFullSearchString(string fullPath, string searchPattern)
		{
			string text = Path.InternalCombine(fullPath, searchPattern);
			char c = text[text.Length - 1];
			if (Path.IsDirectorySeparator(c) || c == Path.VolumeSeparatorChar)
			{
				text += "*";
			}
			return text;
		}

		// Token: 0x04000888 RID: 2184
		private const int STATE_INIT = 1;

		// Token: 0x04000889 RID: 2185
		private const int STATE_SEARCH_NEXT_DIR = 2;

		// Token: 0x0400088A RID: 2186
		private const int STATE_FIND_NEXT_FILE = 3;

		// Token: 0x0400088B RID: 2187
		private const int STATE_FINISH = 4;

		// Token: 0x0400088C RID: 2188
		private SearchResultHandler<TSource> _resultHandler;

		// Token: 0x0400088D RID: 2189
		private List<Directory.SearchData> searchStack;

		// Token: 0x0400088E RID: 2190
		private Directory.SearchData searchData;

		// Token: 0x0400088F RID: 2191
		private string searchCriteria;

		// Token: 0x04000890 RID: 2192
		[SecurityCritical]
		private SafeFindHandle _hnd;

		// Token: 0x04000891 RID: 2193
		private bool needsParentPathDiscoveryDemand;

		// Token: 0x04000892 RID: 2194
		private bool empty;

		// Token: 0x04000893 RID: 2195
		private string userPath;

		// Token: 0x04000894 RID: 2196
		private SearchOption searchOption;

		// Token: 0x04000895 RID: 2197
		private string fullPath;

		// Token: 0x04000896 RID: 2198
		private string normalizedSearchPath;

		// Token: 0x04000897 RID: 2199
		private int oldMode;

		// Token: 0x04000898 RID: 2200
		private bool _checkHost;
	}
}
