﻿using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;
using System.Reflection;

namespace System.Drawing
{
	/// <summary>Converts colors from one data type to another. Access this class through the <see cref="T:System.ComponentModel.TypeDescriptor" />.</summary>
	// Token: 0x02000018 RID: 24
	public class ColorConverter : TypeConverter
	{
		// Token: 0x17000133 RID: 307
		// (get) Token: 0x060001C4 RID: 452 RVA: 0x00007BA8 File Offset: 0x00005DA8
		private static Hashtable Colors
		{
			get
			{
				if (ColorConverter.colorConstants == null)
				{
					string colorConstantsLock = ColorConverter.ColorConstantsLock;
					lock (colorConstantsLock)
					{
						if (ColorConverter.colorConstants == null)
						{
							Hashtable hashtable = new Hashtable(StringComparer.OrdinalIgnoreCase);
							ColorConverter.FillConstants(hashtable, typeof(Color));
							ColorConverter.colorConstants = hashtable;
						}
					}
				}
				return ColorConverter.colorConstants;
			}
		}

		// Token: 0x17000134 RID: 308
		// (get) Token: 0x060001C5 RID: 453 RVA: 0x00007C18 File Offset: 0x00005E18
		private static Hashtable SystemColors
		{
			get
			{
				if (ColorConverter.systemColorConstants == null)
				{
					string systemColorConstantsLock = ColorConverter.SystemColorConstantsLock;
					lock (systemColorConstantsLock)
					{
						if (ColorConverter.systemColorConstants == null)
						{
							Hashtable hashtable = new Hashtable(StringComparer.OrdinalIgnoreCase);
							ColorConverter.FillConstants(hashtable, typeof(SystemColors));
							ColorConverter.systemColorConstants = hashtable;
						}
					}
				}
				return ColorConverter.systemColorConstants;
			}
		}

		/// <summary>Determines if this converter can convert an object in the given source type to the native type of the converter.</summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context. You can use this object to get additional information about the environment from which this converter is being invoked.</param>
		/// <param name="sourceType">The type from which you want to convert.</param>
		/// <returns>
		///   <see langword="true" /> if this object can perform the conversion; otherwise, <see langword="false" />.</returns>
		// Token: 0x060001C6 RID: 454 RVA: 0x00007C88 File Offset: 0x00005E88
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		/// <summary>Returns a value indicating whether this converter can convert an object to the given destination type using the context.</summary>
		/// <param name="context">An <see cref="T:System.ComponentModel.ITypeDescriptorContext" /> that provides a format context.</param>
		/// <param name="destinationType">A <see cref="T:System.Type" /> that represents the type to which you want to convert.</param>
		/// <returns>
		///   <see langword="true" /> if this converter can perform the operation; otherwise, <see langword="false" />.</returns>
		// Token: 0x060001C7 RID: 455 RVA: 0x00007CA6 File Offset: 0x00005EA6
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x060001C8 RID: 456 RVA: 0x00007CC4 File Offset: 0x00005EC4
		internal static object GetNamedColor(string name)
		{
			object obj = ColorConverter.Colors[name];
			if (obj != null)
			{
				return obj;
			}
			return ColorConverter.SystemColors[name];
		}

		/// <summary>Converts the given object to the converter's native type.</summary>
		/// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor" /> that provides a format context. You can use this object to get additional information about the environment from which this converter is being invoked.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> that specifies the culture to represent the color.</param>
		/// <param name="value">The object to convert.</param>
		/// <returns>An <see cref="T:System.Object" /> representing the converted value.</returns>
		/// <exception cref="T:System.ArgumentException">The conversion cannot be performed.</exception>
		// Token: 0x060001C9 RID: 457 RVA: 0x00007CF4 File Offset: 0x00005EF4
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			string text = value as string;
			if (text != null)
			{
				object obj = null;
				string text2 = text.Trim();
				if (text2.Length == 0)
				{
					obj = Color.Empty;
				}
				else
				{
					obj = ColorConverter.GetNamedColor(text2);
					if (obj == null)
					{
						if (culture == null)
						{
							culture = CultureInfo.CurrentCulture;
						}
						char c = culture.TextInfo.ListSeparator[0];
						bool flag = true;
						TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
						if (text2.IndexOf(c) == -1)
						{
							if (text2.Length >= 2 && (text2[0] == '\'' || text2[0] == '"') && text2[0] == text2[text2.Length - 1])
							{
								string text3 = text2.Substring(1, text2.Length - 2);
								obj = Color.FromName(text3);
								flag = false;
							}
							else if ((text2.Length == 7 && text2[0] == '#') || (text2.Length == 8 && (text2.StartsWith("0x") || text2.StartsWith("0X"))) || (text2.Length == 8 && (text2.StartsWith("&h") || text2.StartsWith("&H"))))
							{
								obj = Color.FromArgb(-16777216 | (int)converter.ConvertFromString(context, culture, text2));
							}
						}
						if (obj == null)
						{
							string[] array = text2.Split(new char[] { c });
							int[] array2 = new int[array.Length];
							for (int i = 0; i < array2.Length; i++)
							{
								array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
							}
							switch (array2.Length)
							{
							case 1:
								obj = Color.FromArgb(array2[0]);
								break;
							case 3:
								obj = Color.FromArgb(array2[0], array2[1], array2[2]);
								break;
							case 4:
								obj = Color.FromArgb(array2[0], array2[1], array2[2], array2[3]);
								break;
							}
							flag = true;
						}
						if (obj != null && flag)
						{
							int num = ((Color)obj).ToArgb();
							foreach (object obj2 in ColorConverter.Colors.Values)
							{
								Color color = (Color)obj2;
								if (color.ToArgb() == num)
								{
									obj = color;
									break;
								}
							}
						}
					}
					if (obj == null)
					{
						throw new ArgumentException(SR.GetString("InvalidColor", new object[] { text2 }));
					}
				}
				return obj;
			}
			return base.ConvertFrom(context, culture, value);
		}

		/// <summary>Converts the specified object to another type.</summary>
		/// <param name="context">A formatter context. Use this object to extract additional information about the environment from which this converter is being invoked. Always check whether this value is <see langword="null" />. Also, properties on the context object may return <see langword="null" />.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> that specifies the culture to represent the color.</param>
		/// <param name="value">The object to convert.</param>
		/// <param name="destinationType">The type to convert the object to.</param>
		/// <returns>An <see cref="T:System.Object" /> representing the converted value.</returns>
		/// <exception cref="T:System.ArgumentNullException">
		///   <paramref name="destinationtype" /> is <see langword="null" />.</exception>
		/// <exception cref="T:System.NotSupportedException">The conversion cannot be performed.</exception>
		// Token: 0x060001CA RID: 458 RVA: 0x00007FAC File Offset: 0x000061AC
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (value is Color)
			{
				if (destinationType == typeof(string))
				{
					Color color = (Color)value;
					if (color == Color.Empty)
					{
						return string.Empty;
					}
					if (color.IsKnownColor)
					{
						return color.Name;
					}
					if (color.IsNamedColor)
					{
						return "'" + color.Name + "'";
					}
					if (culture == null)
					{
						culture = CultureInfo.CurrentCulture;
					}
					string text = culture.TextInfo.ListSeparator + " ";
					TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
					int num = 0;
					string[] array;
					if (color.A < 255)
					{
						array = new string[4];
						array[num++] = converter.ConvertToString(context, culture, color.A);
					}
					else
					{
						array = new string[3];
					}
					array[num++] = converter.ConvertToString(context, culture, color.R);
					array[num++] = converter.ConvertToString(context, culture, color.G);
					array[num++] = converter.ConvertToString(context, culture, color.B);
					return string.Join(text, array);
				}
				else if (destinationType == typeof(InstanceDescriptor))
				{
					object[] array2 = null;
					Color color2 = (Color)value;
					MemberInfo memberInfo;
					if (color2.IsEmpty)
					{
						memberInfo = typeof(Color).GetField("Empty");
					}
					else if (color2.IsSystemColor)
					{
						memberInfo = typeof(SystemColors).GetProperty(color2.Name);
					}
					else if (color2.IsKnownColor)
					{
						memberInfo = typeof(Color).GetProperty(color2.Name);
					}
					else if (color2.A != 255)
					{
						memberInfo = typeof(Color).GetMethod("FromArgb", new Type[]
						{
							typeof(int),
							typeof(int),
							typeof(int),
							typeof(int)
						});
						array2 = new object[] { color2.A, color2.R, color2.G, color2.B };
					}
					else if (color2.IsNamedColor)
					{
						memberInfo = typeof(Color).GetMethod("FromName", new Type[] { typeof(string) });
						array2 = new object[] { color2.Name };
					}
					else
					{
						memberInfo = typeof(Color).GetMethod("FromArgb", new Type[]
						{
							typeof(int),
							typeof(int),
							typeof(int)
						});
						array2 = new object[] { color2.R, color2.G, color2.B };
					}
					if (memberInfo != null)
					{
						return new InstanceDescriptor(memberInfo, array2);
					}
					return null;
				}
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		// Token: 0x060001CB RID: 459 RVA: 0x00008324 File Offset: 0x00006524
		private static void FillConstants(Hashtable hash, Type enumType)
		{
			MethodAttributes methodAttributes = MethodAttributes.FamANDAssem | MethodAttributes.Family | MethodAttributes.Static;
			foreach (PropertyInfo propertyInfo in enumType.GetProperties())
			{
				if (propertyInfo.PropertyType == typeof(Color))
				{
					MethodInfo getMethod = propertyInfo.GetGetMethod();
					if (getMethod != null && (getMethod.Attributes & methodAttributes) == methodAttributes)
					{
						object[] array = null;
						hash[propertyInfo.Name] = propertyInfo.GetValue(null, array);
					}
				}
			}
		}

		/// <summary>Retrieves a collection containing a set of standard values for the data type for which this validator is designed. This will return <see langword="null" /> if the data type does not support a standard set of values.</summary>
		/// <param name="context">A formatter context. Use this object to extract additional information about the environment from which this converter is being invoked. Always check whether this value is <see langword="null" />. Also, properties on the context object may return <see langword="null" />.</param>
		/// <returns>A collection containing <see langword="null" /> or a standard set of valid values. The default implementation always returns <see langword="null" />.</returns>
		// Token: 0x060001CC RID: 460 RVA: 0x0000839C File Offset: 0x0000659C
		public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			if (ColorConverter.values == null)
			{
				string valuesLock = ColorConverter.ValuesLock;
				lock (valuesLock)
				{
					if (ColorConverter.values == null)
					{
						ArrayList arrayList = new ArrayList();
						arrayList.AddRange(ColorConverter.Colors.Values);
						arrayList.AddRange(ColorConverter.SystemColors.Values);
						int num = arrayList.Count;
						for (int i = 0; i < num - 1; i++)
						{
							for (int j = i + 1; j < num; j++)
							{
								if (arrayList[i].Equals(arrayList[j]))
								{
									arrayList.RemoveAt(j);
									num--;
									j--;
								}
							}
						}
						arrayList.Sort(0, arrayList.Count, new ColorConverter.ColorComparer());
						ColorConverter.values = new TypeConverter.StandardValuesCollection(arrayList.ToArray());
					}
				}
			}
			return ColorConverter.values;
		}

		/// <summary>Determines if this object supports a standard set of values that can be chosen from a list.</summary>
		/// <param name="context">A <see cref="T:System.ComponentModel.TypeDescriptor" /> through which additional context can be provided.</param>
		/// <returns>
		///   <see langword="true" /> if <see cref="Overload:System.Drawing.ColorConverter.GetStandardValues" /> must be called to find a common set of values the object supports; otherwise, <see langword="false" />.</returns>
		// Token: 0x060001CD RID: 461 RVA: 0x0000848C File Offset: 0x0000668C
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x04000152 RID: 338
		private static string ColorConstantsLock = "colorConstants";

		// Token: 0x04000153 RID: 339
		private static Hashtable colorConstants;

		// Token: 0x04000154 RID: 340
		private static string SystemColorConstantsLock = "systemColorConstants";

		// Token: 0x04000155 RID: 341
		private static Hashtable systemColorConstants;

		// Token: 0x04000156 RID: 342
		private static string ValuesLock = "values";

		// Token: 0x04000157 RID: 343
		private static TypeConverter.StandardValuesCollection values;

		// Token: 0x020000F4 RID: 244
		private class ColorComparer : IComparer
		{
			// Token: 0x06000C90 RID: 3216 RVA: 0x0002C490 File Offset: 0x0002A690
			public int Compare(object left, object right)
			{
				Color color = (Color)left;
				Color color2 = (Color)right;
				return string.Compare(color.Name, color2.Name, false, CultureInfo.InvariantCulture);
			}
		}
	}
}
