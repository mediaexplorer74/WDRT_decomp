﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Runtime.InteropServices;

namespace System.Drawing
{
	/// <summary>Stores an ordered pair of integers, which specify a <see cref="P:System.Drawing.Size.Height" /> and <see cref="P:System.Drawing.Size.Width" />.</summary>
	// Token: 0x02000030 RID: 48
	[TypeConverter(typeof(SizeConverter))]
	[ComVisible(true)]
	[Serializable]
	public struct Size
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Drawing.Size" /> structure from the specified <see cref="T:System.Drawing.Point" /> structure.</summary>
		/// <param name="pt">The <see cref="T:System.Drawing.Point" /> structure from which to initialize this <see cref="T:System.Drawing.Size" /> structure.</param>
		// Token: 0x060004DD RID: 1245 RVA: 0x00016D58 File Offset: 0x00014F58
		public Size(Point pt)
		{
			this.width = pt.X;
			this.height = pt.Y;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Drawing.Size" /> structure from the specified dimensions.</summary>
		/// <param name="width">The width component of the new <see cref="T:System.Drawing.Size" />.</param>
		/// <param name="height">The height component of the new <see cref="T:System.Drawing.Size" />.</param>
		// Token: 0x060004DE RID: 1246 RVA: 0x00016D74 File Offset: 0x00014F74
		public Size(int width, int height)
		{
			this.width = width;
			this.height = height;
		}

		/// <summary>Converts the specified <see cref="T:System.Drawing.Size" /> structure to a <see cref="T:System.Drawing.SizeF" /> structure.</summary>
		/// <param name="p">The <see cref="T:System.Drawing.Size" /> structure to convert.</param>
		/// <returns>The <see cref="T:System.Drawing.SizeF" /> structure to which this operator converts.</returns>
		// Token: 0x060004DF RID: 1247 RVA: 0x00016D84 File Offset: 0x00014F84
		public static implicit operator SizeF(Size p)
		{
			return new SizeF((float)p.Width, (float)p.Height);
		}

		/// <summary>Adds the width and height of one <see cref="T:System.Drawing.Size" /> structure to the width and height of another <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <param name="sz1">The first <see cref="T:System.Drawing.Size" /> to add.</param>
		/// <param name="sz2">The second <see cref="T:System.Drawing.Size" /> to add.</param>
		/// <returns>A <see cref="T:System.Drawing.Size" /> structure that is the result of the addition operation.</returns>
		// Token: 0x060004E0 RID: 1248 RVA: 0x00016D9B File Offset: 0x00014F9B
		public static Size operator +(Size sz1, Size sz2)
		{
			return Size.Add(sz1, sz2);
		}

		/// <summary>Subtracts the width and height of one <see cref="T:System.Drawing.Size" /> structure from the width and height of another <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <param name="sz1">The <see cref="T:System.Drawing.Size" /> structure on the left side of the subtraction operator.</param>
		/// <param name="sz2">The <see cref="T:System.Drawing.Size" /> structure on the right side of the subtraction operator.</param>
		/// <returns>A <see cref="T:System.Drawing.Size" /> structure that is the result of the subtraction operation.</returns>
		// Token: 0x060004E1 RID: 1249 RVA: 0x00016DA4 File Offset: 0x00014FA4
		public static Size operator -(Size sz1, Size sz2)
		{
			return Size.Subtract(sz1, sz2);
		}

		/// <summary>Tests whether two <see cref="T:System.Drawing.Size" /> structures are equal.</summary>
		/// <param name="sz1">The <see cref="T:System.Drawing.Size" /> structure on the left side of the equality operator.</param>
		/// <param name="sz2">The <see cref="T:System.Drawing.Size" /> structure on the right of the equality operator.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="sz1" /> and <paramref name="sz2" /> have equal width and height; otherwise, <see langword="false" />.</returns>
		// Token: 0x060004E2 RID: 1250 RVA: 0x00016DAD File Offset: 0x00014FAD
		public static bool operator ==(Size sz1, Size sz2)
		{
			return sz1.Width == sz2.Width && sz1.Height == sz2.Height;
		}

		/// <summary>Tests whether two <see cref="T:System.Drawing.Size" /> structures are different.</summary>
		/// <param name="sz1">The <see cref="T:System.Drawing.Size" /> structure on the left of the inequality operator.</param>
		/// <param name="sz2">The <see cref="T:System.Drawing.Size" /> structure on the right of the inequality operator.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="sz1" /> and <paramref name="sz2" /> differ either in width or height; <see langword="false" /> if <paramref name="sz1" /> and <paramref name="sz2" /> are equal.</returns>
		// Token: 0x060004E3 RID: 1251 RVA: 0x00016DD1 File Offset: 0x00014FD1
		public static bool operator !=(Size sz1, Size sz2)
		{
			return !(sz1 == sz2);
		}

		/// <summary>Converts the specified <see cref="T:System.Drawing.Size" /> structure to a <see cref="T:System.Drawing.Point" /> structure.</summary>
		/// <param name="size">The <see cref="T:System.Drawing.Size" /> structure to convert.</param>
		/// <returns>The <see cref="T:System.Drawing.Point" /> structure to which this operator converts.</returns>
		// Token: 0x060004E4 RID: 1252 RVA: 0x00016DDD File Offset: 0x00014FDD
		public static explicit operator Point(Size size)
		{
			return new Point(size.Width, size.Height);
		}

		/// <summary>Tests whether this <see cref="T:System.Drawing.Size" /> structure has width and height of 0.</summary>
		/// <returns>This property returns <see langword="true" /> when this <see cref="T:System.Drawing.Size" /> structure has both a width and height of 0; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000213 RID: 531
		// (get) Token: 0x060004E5 RID: 1253 RVA: 0x00016DF2 File Offset: 0x00014FF2
		[Browsable(false)]
		public bool IsEmpty
		{
			get
			{
				return this.width == 0 && this.height == 0;
			}
		}

		/// <summary>Gets or sets the horizontal component of this <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <returns>The horizontal component of this <see cref="T:System.Drawing.Size" /> structure, typically measured in pixels.</returns>
		// Token: 0x17000214 RID: 532
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x00016E07 File Offset: 0x00015007
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x00016E0F File Offset: 0x0001500F
		public int Width
		{
			get
			{
				return this.width;
			}
			set
			{
				this.width = value;
			}
		}

		/// <summary>Gets or sets the vertical component of this <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <returns>The vertical component of this <see cref="T:System.Drawing.Size" /> structure, typically measured in pixels.</returns>
		// Token: 0x17000215 RID: 533
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x00016E18 File Offset: 0x00015018
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x00016E20 File Offset: 0x00015020
		public int Height
		{
			get
			{
				return this.height;
			}
			set
			{
				this.height = value;
			}
		}

		/// <summary>Adds the width and height of one <see cref="T:System.Drawing.Size" /> structure to the width and height of another <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <param name="sz1">The first <see cref="T:System.Drawing.Size" /> structure to add.</param>
		/// <param name="sz2">The second <see cref="T:System.Drawing.Size" /> structure to add.</param>
		/// <returns>A <see cref="T:System.Drawing.Size" /> structure that is the result of the addition operation.</returns>
		// Token: 0x060004EA RID: 1258 RVA: 0x00016E29 File Offset: 0x00015029
		public static Size Add(Size sz1, Size sz2)
		{
			return new Size(sz1.Width + sz2.Width, sz1.Height + sz2.Height);
		}

		/// <summary>Converts the specified <see cref="T:System.Drawing.SizeF" /> structure to a <see cref="T:System.Drawing.Size" /> structure by rounding the values of the <see cref="T:System.Drawing.Size" /> structure to the next higher integer values.</summary>
		/// <param name="value">The <see cref="T:System.Drawing.SizeF" /> structure to convert.</param>
		/// <returns>The <see cref="T:System.Drawing.Size" /> structure this method converts to.</returns>
		// Token: 0x060004EB RID: 1259 RVA: 0x00016E4E File Offset: 0x0001504E
		public static Size Ceiling(SizeF value)
		{
			return new Size((int)Math.Ceiling((double)value.Width), (int)Math.Ceiling((double)value.Height));
		}

		/// <summary>Subtracts the width and height of one <see cref="T:System.Drawing.Size" /> structure from the width and height of another <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <param name="sz1">The <see cref="T:System.Drawing.Size" /> structure on the left side of the subtraction operator.</param>
		/// <param name="sz2">The <see cref="T:System.Drawing.Size" /> structure on the right side of the subtraction operator.</param>
		/// <returns>A <see cref="T:System.Drawing.Size" /> structure that is a result of the subtraction operation.</returns>
		// Token: 0x060004EC RID: 1260 RVA: 0x00016E71 File Offset: 0x00015071
		public static Size Subtract(Size sz1, Size sz2)
		{
			return new Size(sz1.Width - sz2.Width, sz1.Height - sz2.Height);
		}

		/// <summary>Converts the specified <see cref="T:System.Drawing.SizeF" /> structure to a <see cref="T:System.Drawing.Size" /> structure by truncating the values of the <see cref="T:System.Drawing.SizeF" /> structure to the next lower integer values.</summary>
		/// <param name="value">The <see cref="T:System.Drawing.SizeF" /> structure to convert.</param>
		/// <returns>The <see cref="T:System.Drawing.Size" /> structure this method converts to.</returns>
		// Token: 0x060004ED RID: 1261 RVA: 0x00016E96 File Offset: 0x00015096
		public static Size Truncate(SizeF value)
		{
			return new Size((int)value.Width, (int)value.Height);
		}

		/// <summary>Converts the specified <see cref="T:System.Drawing.SizeF" /> structure to a <see cref="T:System.Drawing.Size" /> structure by rounding the values of the <see cref="T:System.Drawing.SizeF" /> structure to the nearest integer values.</summary>
		/// <param name="value">The <see cref="T:System.Drawing.SizeF" /> structure to convert.</param>
		/// <returns>The <see cref="T:System.Drawing.Size" /> structure this method converts to.</returns>
		// Token: 0x060004EE RID: 1262 RVA: 0x00016EAD File Offset: 0x000150AD
		public static Size Round(SizeF value)
		{
			return new Size((int)Math.Round((double)value.Width), (int)Math.Round((double)value.Height));
		}

		/// <summary>Tests to see whether the specified object is a <see cref="T:System.Drawing.Size" /> structure with the same dimensions as this <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <param name="obj">The <see cref="T:System.Object" /> to test.</param>
		/// <returns>
		///   <see langword="true" /> if <paramref name="obj" /> is a <see cref="T:System.Drawing.Size" /> and has the same width and height as this <see cref="T:System.Drawing.Size" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x060004EF RID: 1263 RVA: 0x00016ED0 File Offset: 0x000150D0
		public override bool Equals(object obj)
		{
			if (!(obj is Size))
			{
				return false;
			}
			Size size = (Size)obj;
			return size.width == this.width && size.height == this.height;
		}

		/// <summary>Returns a hash code for this <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <returns>An integer value that specifies a hash value for this <see cref="T:System.Drawing.Size" /> structure.</returns>
		// Token: 0x060004F0 RID: 1264 RVA: 0x00016F0C File Offset: 0x0001510C
		public override int GetHashCode()
		{
			return this.width ^ this.height;
		}

		/// <summary>Creates a human-readable string that represents this <see cref="T:System.Drawing.Size" /> structure.</summary>
		/// <returns>A string that represents this <see cref="T:System.Drawing.Size" />.</returns>
		// Token: 0x060004F1 RID: 1265 RVA: 0x00016F1C File Offset: 0x0001511C
		public override string ToString()
		{
			return string.Concat(new string[]
			{
				"{Width=",
				this.width.ToString(CultureInfo.CurrentCulture),
				", Height=",
				this.height.ToString(CultureInfo.CurrentCulture),
				"}"
			});
		}

		/// <summary>Gets a <see cref="T:System.Drawing.Size" /> structure that has a <see cref="P:System.Drawing.Size.Height" /> and <see cref="P:System.Drawing.Size.Width" /> value of 0.</summary>
		// Token: 0x04000316 RID: 790
		public static readonly Size Empty;

		// Token: 0x04000317 RID: 791
		private int width;

		// Token: 0x04000318 RID: 792
		private int height;
	}
}
