﻿using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Globalization;

namespace System.Windows.Forms
{
	// Token: 0x02000390 RID: 912
	internal class TableLayoutPanelCellPositionTypeConverter : TypeConverter
	{
		// Token: 0x06003BE7 RID: 15335 RVA: 0x0002792C File Offset: 0x00025B2C
		public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
		{
			return destinationType == typeof(InstanceDescriptor) || base.CanConvertTo(context, destinationType);
		}

		// Token: 0x06003BE8 RID: 15336 RVA: 0x000C223C File Offset: 0x000C043C
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
		}

		// Token: 0x06003BE9 RID: 15337 RVA: 0x00105F68 File Offset: 0x00104168
		public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
		{
			if (!(value is string))
			{
				return base.ConvertFrom(context, culture, value);
			}
			string text = ((string)value).Trim();
			if (text.Length == 0)
			{
				return null;
			}
			if (culture == null)
			{
				culture = CultureInfo.CurrentCulture;
			}
			char c = culture.TextInfo.ListSeparator[0];
			string[] array = text.Split(new char[] { c });
			int[] array2 = new int[array.Length];
			TypeConverter converter = TypeDescriptor.GetConverter(typeof(int));
			for (int i = 0; i < array2.Length; i++)
			{
				array2[i] = (int)converter.ConvertFromString(context, culture, array[i]);
			}
			if (array2.Length == 2)
			{
				return new TableLayoutPanelCellPosition(array2[0], array2[1]);
			}
			throw new ArgumentException(SR.GetString("TextParseFailedFormat", new object[] { text, "column, row" }));
		}

		// Token: 0x06003BEA RID: 15338 RVA: 0x00106048 File Offset: 0x00104248
		public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
		{
			if (destinationType == null)
			{
				throw new ArgumentNullException("destinationType");
			}
			if (destinationType == typeof(InstanceDescriptor) && value is TableLayoutPanelCellPosition)
			{
				TableLayoutPanelCellPosition tableLayoutPanelCellPosition = (TableLayoutPanelCellPosition)value;
				return new InstanceDescriptor(typeof(TableLayoutPanelCellPosition).GetConstructor(new Type[]
				{
					typeof(int),
					typeof(int)
				}), new object[] { tableLayoutPanelCellPosition.Column, tableLayoutPanelCellPosition.Row });
			}
			return base.ConvertTo(context, culture, value, destinationType);
		}

		// Token: 0x06003BEB RID: 15339 RVA: 0x001060F0 File Offset: 0x001042F0
		public override object CreateInstance(ITypeDescriptorContext context, IDictionary propertyValues)
		{
			return new TableLayoutPanelCellPosition((int)propertyValues["Column"], (int)propertyValues["Row"]);
		}

		// Token: 0x06003BEC RID: 15340 RVA: 0x00012E4E File Offset: 0x0001104E
		public override bool GetCreateInstanceSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		// Token: 0x06003BED RID: 15341 RVA: 0x0010611C File Offset: 0x0010431C
		public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value, Attribute[] attributes)
		{
			PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(TableLayoutPanelCellPosition), attributes);
			return properties.Sort(new string[] { "Column", "Row" });
		}

		// Token: 0x06003BEE RID: 15342 RVA: 0x00012E4E File Offset: 0x0001104E
		public override bool GetPropertiesSupported(ITypeDescriptorContext context)
		{
			return true;
		}
	}
}
