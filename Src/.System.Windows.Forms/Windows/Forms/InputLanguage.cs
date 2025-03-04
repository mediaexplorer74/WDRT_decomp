﻿using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using Microsoft.Win32;

namespace System.Windows.Forms
{
	/// <summary>Provides methods and fields to manage the input language. This class cannot be inherited.</summary>
	// Token: 0x0200029D RID: 669
	public sealed class InputLanguage
	{
		// Token: 0x06002A10 RID: 10768 RVA: 0x000BF31E File Offset: 0x000BD51E
		internal InputLanguage(IntPtr handle)
		{
			this.handle = handle;
		}

		/// <summary>Gets the culture of the current input language.</summary>
		/// <returns>A <see cref="T:System.Globalization.CultureInfo" /> that represents the culture of the current input language.</returns>
		// Token: 0x170009D4 RID: 2516
		// (get) Token: 0x06002A11 RID: 10769 RVA: 0x000BF32D File Offset: 0x000BD52D
		public CultureInfo Culture
		{
			get
			{
				return new CultureInfo((int)(long)this.handle & 65535);
			}
		}

		/// <summary>Gets or sets the input language for the current thread.</summary>
		/// <returns>An <see cref="T:System.Windows.Forms.InputLanguage" /> that represents the input language for the current thread.</returns>
		/// <exception cref="T:System.ArgumentException">The input language is not recognized by the system.</exception>
		// Token: 0x170009D5 RID: 2517
		// (get) Token: 0x06002A12 RID: 10770 RVA: 0x000BF346 File Offset: 0x000BD546
		// (set) Token: 0x06002A13 RID: 10771 RVA: 0x000BF35C File Offset: 0x000BD55C
		public static InputLanguage CurrentInputLanguage
		{
			get
			{
				Application.OleRequired();
				return new InputLanguage(SafeNativeMethods.GetKeyboardLayout(0));
			}
			set
			{
				IntSecurity.AffectThreadBehavior.Demand();
				Application.OleRequired();
				if (value == null)
				{
					value = InputLanguage.DefaultInputLanguage;
				}
				IntPtr intPtr = SafeNativeMethods.ActivateKeyboardLayout(new HandleRef(value, value.handle), 0);
				if (intPtr == IntPtr.Zero)
				{
					throw new ArgumentException(SR.GetString("ErrorBadInputLanguage"), "value");
				}
			}
		}

		/// <summary>Gets the default input language for the system.</summary>
		/// <returns>An <see cref="T:System.Windows.Forms.InputLanguage" /> representing the default input language for the system.</returns>
		// Token: 0x170009D6 RID: 2518
		// (get) Token: 0x06002A14 RID: 10772 RVA: 0x000BF3B8 File Offset: 0x000BD5B8
		public static InputLanguage DefaultInputLanguage
		{
			get
			{
				IntPtr[] array = new IntPtr[1];
				UnsafeNativeMethods.SystemParametersInfo(89, 0, array, 0);
				return new InputLanguage(array[0]);
			}
		}

		/// <summary>Gets the handle for the input language.</summary>
		/// <returns>An <see cref="T:System.IntPtr" /> that represents the handle of this input language.</returns>
		// Token: 0x170009D7 RID: 2519
		// (get) Token: 0x06002A15 RID: 10773 RVA: 0x000BF3DF File Offset: 0x000BD5DF
		public IntPtr Handle
		{
			get
			{
				return this.handle;
			}
		}

		/// <summary>Gets a list of all installed input languages.</summary>
		/// <returns>An array of <see cref="T:System.Windows.Forms.InputLanguage" /> objects that represent the input languages installed on the computer.</returns>
		// Token: 0x170009D8 RID: 2520
		// (get) Token: 0x06002A16 RID: 10774 RVA: 0x000BF3E8 File Offset: 0x000BD5E8
		public static InputLanguageCollection InstalledInputLanguages
		{
			get
			{
				int keyboardLayoutList = SafeNativeMethods.GetKeyboardLayoutList(0, null);
				IntPtr[] array = new IntPtr[keyboardLayoutList];
				SafeNativeMethods.GetKeyboardLayoutList(keyboardLayoutList, array);
				InputLanguage[] array2 = new InputLanguage[keyboardLayoutList];
				for (int i = 0; i < keyboardLayoutList; i++)
				{
					array2[i] = new InputLanguage(array[i]);
				}
				return new InputLanguageCollection(array2);
			}
		}

		/// <summary>Gets the name of the current keyboard layout as it appears in the regional settings of the operating system on the computer.</summary>
		/// <returns>The name of the layout.</returns>
		// Token: 0x170009D9 RID: 2521
		// (get) Token: 0x06002A17 RID: 10775 RVA: 0x000BF430 File Offset: 0x000BD630
		public string LayoutName
		{
			get
			{
				string text = null;
				IntPtr intPtr = this.handle;
				int num = (int)(long)intPtr & 65535;
				int num2 = ((int)(long)intPtr >> 16) & 4095;
				new RegistryPermission(PermissionState.Unrestricted).Assert();
				try
				{
					if (num2 == num || num2 == 0)
					{
						string text2 = Convert.ToString(num, 16);
						text2 = InputLanguage.PadWithZeroes(text2, 8);
						RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts\\" + text2);
						text = InputLanguage.GetLocalizedKeyboardLayoutName(registryKey.GetValue("Layout Display Name") as string);
						if (text == null)
						{
							text = (string)registryKey.GetValue("Layout Text");
						}
						registryKey.Close();
					}
					else
					{
						RegistryKey registryKey2 = Registry.CurrentUser.OpenSubKey("Keyboard Layout\\Substitutes");
						string[] array = null;
						if (registryKey2 != null)
						{
							array = registryKey2.GetValueNames();
							foreach (string text3 in array)
							{
								int num3 = Convert.ToInt32(text3, 16);
								if (num3 == (int)(long)intPtr || (num3 & 268435455) == ((int)(long)intPtr & 268435455) || (num3 & 65535) == num)
								{
									intPtr = (IntPtr)Convert.ToInt32((string)registryKey2.GetValue(text3), 16);
									num = (int)(long)intPtr & 65535;
									num2 = ((int)(long)intPtr >> 16) & 4095;
									break;
								}
							}
							registryKey2.Close();
						}
						RegistryKey registryKey3 = Registry.LocalMachine.OpenSubKey("SYSTEM\\CurrentControlSet\\Control\\Keyboard Layouts");
						if (registryKey3 != null)
						{
							array = registryKey3.GetSubKeyNames();
							foreach (string text4 in array)
							{
								if (intPtr == (IntPtr)Convert.ToInt32(text4, 16))
								{
									RegistryKey registryKey4 = registryKey3.OpenSubKey(text4);
									text = InputLanguage.GetLocalizedKeyboardLayoutName(registryKey4.GetValue("Layout Display Name") as string);
									if (text == null)
									{
										text = (string)registryKey4.GetValue("Layout Text");
									}
									registryKey4.Close();
									break;
								}
							}
						}
						if (text == null)
						{
							foreach (string text5 in array)
							{
								if (num == (65535 & Convert.ToInt32(text5.Substring(4, 4), 16)))
								{
									RegistryKey registryKey5 = registryKey3.OpenSubKey(text5);
									string text6 = (string)registryKey5.GetValue("Layout Id");
									if (text6 != null)
									{
										int num4 = Convert.ToInt32(text6, 16);
										if (num4 == num2)
										{
											text = InputLanguage.GetLocalizedKeyboardLayoutName(registryKey5.GetValue("Layout Display Name") as string);
											if (text == null)
											{
												text = (string)registryKey5.GetValue("Layout Text");
											}
										}
									}
									registryKey5.Close();
									if (text != null)
									{
										break;
									}
								}
							}
						}
						registryKey3.Close();
					}
				}
				finally
				{
					CodeAccessPermission.RevertAssert();
				}
				if (text == null)
				{
					text = SR.GetString("UnknownInputLanguageLayout");
				}
				return text;
			}
		}

		// Token: 0x06002A18 RID: 10776 RVA: 0x000BF718 File Offset: 0x000BD918
		private static string GetLocalizedKeyboardLayoutName(string layoutDisplayName)
		{
			if (layoutDisplayName != null && Environment.OSVersion.Version.Major >= 5)
			{
				StringBuilder stringBuilder = new StringBuilder(512);
				if (UnsafeNativeMethods.SHLoadIndirectString(layoutDisplayName, stringBuilder, (uint)stringBuilder.Capacity, IntPtr.Zero) == 0U)
				{
					return stringBuilder.ToString();
				}
			}
			return null;
		}

		// Token: 0x06002A19 RID: 10777 RVA: 0x000BF763 File Offset: 0x000BD963
		internal static InputLanguageChangedEventArgs CreateInputLanguageChangedEventArgs(Message m)
		{
			return new InputLanguageChangedEventArgs(new InputLanguage(m.LParam), (byte)(long)m.WParam);
		}

		// Token: 0x06002A1A RID: 10778 RVA: 0x000BF784 File Offset: 0x000BD984
		internal static InputLanguageChangingEventArgs CreateInputLanguageChangingEventArgs(Message m)
		{
			InputLanguage inputLanguage = new InputLanguage(m.LParam);
			bool flag = !(m.WParam == IntPtr.Zero);
			return new InputLanguageChangingEventArgs(inputLanguage, flag);
		}

		/// <summary>Specifies whether two input languages are equal.</summary>
		/// <param name="value">The language to test for equality.</param>
		/// <returns>
		///   <see langword="true" /> if the two languages are equal; otherwise, <see langword="false" />.</returns>
		// Token: 0x06002A1B RID: 10779 RVA: 0x000BF7BA File Offset: 0x000BD9BA
		public override bool Equals(object value)
		{
			return value is InputLanguage && this.handle == ((InputLanguage)value).handle;
		}

		/// <summary>Returns the input language associated with the specified culture.</summary>
		/// <param name="culture">The <see cref="T:System.Globalization.CultureInfo" /> that specifies the culture to convert from.</param>
		/// <returns>An <see cref="T:System.Windows.Forms.InputLanguage" /> that represents the previously selected input language.</returns>
		// Token: 0x06002A1C RID: 10780 RVA: 0x000BF7DC File Offset: 0x000BD9DC
		public static InputLanguage FromCulture(CultureInfo culture)
		{
			int keyboardLayoutId = culture.KeyboardLayoutId;
			foreach (object obj in InputLanguage.InstalledInputLanguages)
			{
				InputLanguage inputLanguage = (InputLanguage)obj;
				if (((int)(long)inputLanguage.handle & 65535) == keyboardLayoutId)
				{
					return inputLanguage;
				}
			}
			return null;
		}

		/// <summary>Returns the hash code for this input language.</summary>
		/// <returns>The hash code for this input language.</returns>
		// Token: 0x06002A1D RID: 10781 RVA: 0x000BF854 File Offset: 0x000BDA54
		public override int GetHashCode()
		{
			return (int)(long)this.handle;
		}

		// Token: 0x06002A1E RID: 10782 RVA: 0x000BF862 File Offset: 0x000BDA62
		private static string PadWithZeroes(string input, int length)
		{
			return "0000000000000000".Substring(0, length - input.Length) + input;
		}

		// Token: 0x04001114 RID: 4372
		private readonly IntPtr handle;
	}
}
