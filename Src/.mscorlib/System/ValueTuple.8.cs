﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	/// <summary>Represents a value tuple with 7 components.</summary>
	/// <typeparam name="T1">The type of the value tuple's first element.</typeparam>
	/// <typeparam name="T2">The type of the value tuple's second element.</typeparam>
	/// <typeparam name="T3">The type of the value tuple's third element.</typeparam>
	/// <typeparam name="T4">The type of the value tuple's fourth element.</typeparam>
	/// <typeparam name="T5">The type of the value tuple's fifth element.</typeparam>
	/// <typeparam name="T6">The type of the value tuple's sixth element.</typeparam>
	/// <typeparam name="T7">The type of the value tuple's seventh element.</typeparam>
	// Token: 0x02000070 RID: 112
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7> : IEquatable<ValueTuple<T1, T2, T3, T4, T5, T6, T7>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple<T1, T2, T3, T4, T5, T6, T7>>, IValueTupleInternal, ITuple
	{
		/// <summary>Initializes a new <see cref="M:System.ValueTuple`7.#ctor(`0,`1,`2,`3,`4,`5,`6)" /> instance.</summary>
		/// <param name="item1">The value tuple's first element.</param>
		/// <param name="item2">The value tuple's second element.</param>
		/// <param name="item3">The value tuple's third element.</param>
		/// <param name="item4">The value tuple's fourth element.</param>
		/// <param name="item5">The value tuple's fifth element.</param>
		/// <param name="item6">The value tuple's sixth element.</param>
		/// <param name="item7">The value tuple's seventh element.</param>
		// Token: 0x06000454 RID: 1108 RVA: 0x0000C852 File Offset: 0x0000AA52
		public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7)
		{
			this.Item1 = item1;
			this.Item2 = item2;
			this.Item3 = item3;
			this.Item4 = item4;
			this.Item5 = item5;
			this.Item6 = item6;
			this.Item7 = item7;
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`7" /> instance is equal to a specified object.</summary>
		/// <param name="obj">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000455 RID: 1109 RVA: 0x0000C889 File Offset: 0x0000AA89
		public override bool Equals(object obj)
		{
			return obj is ValueTuple<T1, T2, T3, T4, T5, T6, T7> && this.Equals((ValueTuple<T1, T2, T3, T4, T5, T6, T7>)obj);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`7" /> instance is equal to a specified <see cref="T:System.ValueTuple`7" /> instance.</summary>
		/// <param name="other">The value tuple to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified tuple; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000456 RID: 1110 RVA: 0x0000C8A4 File Offset: 0x0000AAA4
		public bool Equals(ValueTuple<T1, T2, T3, T4, T5, T6, T7> other)
		{
			return EqualityComparer<T1>.Default.Equals(this.Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(this.Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(this.Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(this.Item4, other.Item4) && EqualityComparer<T5>.Default.Equals(this.Item5, other.Item5) && EqualityComparer<T6>.Default.Equals(this.Item6, other.Item6) && EqualityComparer<T7>.Default.Equals(this.Item7, other.Item7);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`7" /> instance is equal to a specified object based on a specified comparison method.</summary>
		/// <param name="other">The object to compare with this instance.</param>
		/// <param name="comparer">An object that defines the method to use to evaluate whether the two objects are equal.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified objects; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000457 RID: 1111 RVA: 0x0000C95C File Offset: 0x0000AB5C
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
		{
			if (other == null || !(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7>))
			{
				return false;
			}
			ValueTuple<T1, T2, T3, T4, T5, T6, T7> valueTuple = (ValueTuple<T1, T2, T3, T4, T5, T6, T7>)other;
			return comparer.Equals(this.Item1, valueTuple.Item1) && comparer.Equals(this.Item2, valueTuple.Item2) && comparer.Equals(this.Item3, valueTuple.Item3) && comparer.Equals(this.Item4, valueTuple.Item4) && comparer.Equals(this.Item5, valueTuple.Item5) && comparer.Equals(this.Item6, valueTuple.Item6) && comparer.Equals(this.Item7, valueTuple.Item7);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`7" /> instance to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="obj" /> in the sort order, as shown in the following table.  
		///   Value  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="other" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="other" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="other" />.</returns>
		// Token: 0x06000458 RID: 1112 RVA: 0x0000CA58 File Offset: 0x0000AC58
		int IComparable.CompareTo(object other)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7>))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleIncorrectType", new object[] { base.GetType().ToString() }), "other");
			}
			return this.CompareTo((ValueTuple<T1, T2, T3, T4, T5, T6, T7>)other);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`7" /> instance to a specified <see cref="T:System.ValueTuple`7" /> instance.</summary>
		/// <param name="other">The tuple to compare with this instance.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="other" /> in the sort order, as shown in the following table.  
		///   Value  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="other" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="other" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="other" />.</returns>
		// Token: 0x06000459 RID: 1113 RVA: 0x0000CAB4 File Offset: 0x0000ACB4
		public int CompareTo(ValueTuple<T1, T2, T3, T4, T5, T6, T7> other)
		{
			int num = Comparer<T1>.Default.Compare(this.Item1, other.Item1);
			if (num != 0)
			{
				return num;
			}
			num = Comparer<T2>.Default.Compare(this.Item2, other.Item2);
			if (num != 0)
			{
				return num;
			}
			num = Comparer<T3>.Default.Compare(this.Item3, other.Item3);
			if (num != 0)
			{
				return num;
			}
			num = Comparer<T4>.Default.Compare(this.Item4, other.Item4);
			if (num != 0)
			{
				return num;
			}
			num = Comparer<T5>.Default.Compare(this.Item5, other.Item5);
			if (num != 0)
			{
				return num;
			}
			num = Comparer<T6>.Default.Compare(this.Item6, other.Item6);
			if (num != 0)
			{
				return num;
			}
			return Comparer<T7>.Default.Compare(this.Item7, other.Item7);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`7" /> instance to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="other">The object to compare with the current instance.</param>
		/// <param name="comparer">An object that provides custom rules for comparison.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="other" /> in the sort order, as shown in the following table.  
		///   Value  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="other" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="other" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="other" />.</returns>
		// Token: 0x0600045A RID: 1114 RVA: 0x0000CB80 File Offset: 0x0000AD80
		int IStructuralComparable.CompareTo(object other, IComparer comparer)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7>))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleIncorrectType", new object[] { base.GetType().ToString() }), "other");
			}
			ValueTuple<T1, T2, T3, T4, T5, T6, T7> valueTuple = (ValueTuple<T1, T2, T3, T4, T5, T6, T7>)other;
			int num = comparer.Compare(this.Item1, valueTuple.Item1);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.Item2, valueTuple.Item2);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.Item3, valueTuple.Item3);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.Item4, valueTuple.Item4);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.Item5, valueTuple.Item5);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.Item6, valueTuple.Item6);
			if (num != 0)
			{
				return num;
			}
			return comparer.Compare(this.Item7, valueTuple.Item7);
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.ValueTuple`7" /> instance.</summary>
		/// <returns>The hash code for the current <see cref="T:System.ValueTuple`7" /> instance.</returns>
		// Token: 0x0600045B RID: 1115 RVA: 0x0000CCBC File Offset: 0x0000AEBC
		public override int GetHashCode()
		{
			return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(this.Item1), EqualityComparer<T2>.Default.GetHashCode(this.Item2), EqualityComparer<T3>.Default.GetHashCode(this.Item3), EqualityComparer<T4>.Default.GetHashCode(this.Item4), EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7));
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.ValueTuple`7" /> instance by using a specified computation method.</summary>
		/// <param name="comparer">An object whose <see cref="M:System.Collections.IEqualityComparer.GetHashCode(System.Object)" /> method calculates the hash code of the current <see cref="T:System.ValueTuple`7" /> instance.</param>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x0600045C RID: 1116 RVA: 0x0000CD3E File Offset: 0x0000AF3E
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
		{
			return this.GetHashCodeCore(comparer);
		}

		// Token: 0x0600045D RID: 1117 RVA: 0x0000CD48 File Offset: 0x0000AF48
		private int GetHashCodeCore(IEqualityComparer comparer)
		{
			return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item1), comparer.GetHashCode(this.Item2), comparer.GetHashCode(this.Item3), comparer.GetHashCode(this.Item4), comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7));
		}

		// Token: 0x0600045E RID: 1118 RVA: 0x0000CDD1 File Offset: 0x0000AFD1
		int IValueTupleInternal.GetHashCode(IEqualityComparer comparer)
		{
			return this.GetHashCodeCore(comparer);
		}

		/// <summary>Returns a string that represents the value of this <see cref="T:System.ValueTuple`7" /> instance.</summary>
		/// <returns>The string representation of this <see cref="T:System.ValueTuple`7" /> instance.</returns>
		// Token: 0x0600045F RID: 1119 RVA: 0x0000CDDC File Offset: 0x0000AFDC
		public override string ToString()
		{
			string[] array = new string[15];
			array[0] = "(";
			int num = 1;
			ref T1 ptr = ref this.Item1;
			T1 t = default(T1);
			string text;
			if (t == null)
			{
				t = this.Item1;
				ptr = ref t;
				if (t == null)
				{
					text = null;
					goto IL_46;
				}
			}
			text = ptr.ToString();
			IL_46:
			array[num] = text;
			array[2] = ", ";
			int num2 = 3;
			ref T2 ptr2 = ref this.Item2;
			T2 t2 = default(T2);
			string text2;
			if (t2 == null)
			{
				t2 = this.Item2;
				ptr2 = ref t2;
				if (t2 == null)
				{
					text2 = null;
					goto IL_86;
				}
			}
			text2 = ptr2.ToString();
			IL_86:
			array[num2] = text2;
			array[4] = ", ";
			int num3 = 5;
			ref T3 ptr3 = ref this.Item3;
			T3 t3 = default(T3);
			string text3;
			if (t3 == null)
			{
				t3 = this.Item3;
				ptr3 = ref t3;
				if (t3 == null)
				{
					text3 = null;
					goto IL_C6;
				}
			}
			text3 = ptr3.ToString();
			IL_C6:
			array[num3] = text3;
			array[6] = ", ";
			int num4 = 7;
			ref T4 ptr4 = ref this.Item4;
			T4 t4 = default(T4);
			string text4;
			if (t4 == null)
			{
				t4 = this.Item4;
				ptr4 = ref t4;
				if (t4 == null)
				{
					text4 = null;
					goto IL_106;
				}
			}
			text4 = ptr4.ToString();
			IL_106:
			array[num4] = text4;
			array[8] = ", ";
			int num5 = 9;
			ref T5 ptr5 = ref this.Item5;
			T5 t5 = default(T5);
			string text5;
			if (t5 == null)
			{
				t5 = this.Item5;
				ptr5 = ref t5;
				if (t5 == null)
				{
					text5 = null;
					goto IL_14A;
				}
			}
			text5 = ptr5.ToString();
			IL_14A:
			array[num5] = text5;
			array[10] = ", ";
			int num6 = 11;
			ref T6 ptr6 = ref this.Item6;
			T6 t6 = default(T6);
			string text6;
			if (t6 == null)
			{
				t6 = this.Item6;
				ptr6 = ref t6;
				if (t6 == null)
				{
					text6 = null;
					goto IL_18F;
				}
			}
			text6 = ptr6.ToString();
			IL_18F:
			array[num6] = text6;
			array[12] = ", ";
			int num7 = 13;
			ref T7 ptr7 = ref this.Item7;
			T7 t7 = default(T7);
			string text7;
			if (t7 == null)
			{
				t7 = this.Item7;
				ptr7 = ref t7;
				if (t7 == null)
				{
					text7 = null;
					goto IL_1D4;
				}
			}
			text7 = ptr7.ToString();
			IL_1D4:
			array[num7] = text7;
			array[14] = ")";
			return string.Concat(array);
		}

		// Token: 0x06000460 RID: 1120 RVA: 0x0000CFCC File Offset: 0x0000B1CC
		string IValueTupleInternal.ToStringEnd()
		{
			string[] array = new string[14];
			int num = 0;
			ref T1 ptr = ref this.Item1;
			T1 t = default(T1);
			string text;
			if (t == null)
			{
				t = this.Item1;
				ptr = ref t;
				if (t == null)
				{
					text = null;
					goto IL_3E;
				}
			}
			text = ptr.ToString();
			IL_3E:
			array[num] = text;
			array[1] = ", ";
			int num2 = 2;
			ref T2 ptr2 = ref this.Item2;
			T2 t2 = default(T2);
			string text2;
			if (t2 == null)
			{
				t2 = this.Item2;
				ptr2 = ref t2;
				if (t2 == null)
				{
					text2 = null;
					goto IL_7E;
				}
			}
			text2 = ptr2.ToString();
			IL_7E:
			array[num2] = text2;
			array[3] = ", ";
			int num3 = 4;
			ref T3 ptr3 = ref this.Item3;
			T3 t3 = default(T3);
			string text3;
			if (t3 == null)
			{
				t3 = this.Item3;
				ptr3 = ref t3;
				if (t3 == null)
				{
					text3 = null;
					goto IL_BE;
				}
			}
			text3 = ptr3.ToString();
			IL_BE:
			array[num3] = text3;
			array[5] = ", ";
			int num4 = 6;
			ref T4 ptr4 = ref this.Item4;
			T4 t4 = default(T4);
			string text4;
			if (t4 == null)
			{
				t4 = this.Item4;
				ptr4 = ref t4;
				if (t4 == null)
				{
					text4 = null;
					goto IL_FE;
				}
			}
			text4 = ptr4.ToString();
			IL_FE:
			array[num4] = text4;
			array[7] = ", ";
			int num5 = 8;
			ref T5 ptr5 = ref this.Item5;
			T5 t5 = default(T5);
			string text5;
			if (t5 == null)
			{
				t5 = this.Item5;
				ptr5 = ref t5;
				if (t5 == null)
				{
					text5 = null;
					goto IL_141;
				}
			}
			text5 = ptr5.ToString();
			IL_141:
			array[num5] = text5;
			array[9] = ", ";
			int num6 = 10;
			ref T6 ptr6 = ref this.Item6;
			T6 t6 = default(T6);
			string text6;
			if (t6 == null)
			{
				t6 = this.Item6;
				ptr6 = ref t6;
				if (t6 == null)
				{
					text6 = null;
					goto IL_186;
				}
			}
			text6 = ptr6.ToString();
			IL_186:
			array[num6] = text6;
			array[11] = ", ";
			int num7 = 12;
			ref T7 ptr7 = ref this.Item7;
			T7 t7 = default(T7);
			string text7;
			if (t7 == null)
			{
				t7 = this.Item7;
				ptr7 = ref t7;
				if (t7 == null)
				{
					text7 = null;
					goto IL_1CB;
				}
			}
			text7 = ptr7.ToString();
			IL_1CB:
			array[num7] = text7;
			array[13] = ")";
			return string.Concat(array);
		}

		/// <summary>Gets the number of elements in the <see langword="ValueTuple" />.</summary>
		/// <returns>7, the number of elements in a <see cref="T:System.ValueTuple`7" /> object.</returns>
		// Token: 0x17000080 RID: 128
		// (get) Token: 0x06000461 RID: 1121 RVA: 0x0000D1B3 File Offset: 0x0000B3B3
		int ITuple.Length
		{
			get
			{
				return 7;
			}
		}

		/// <summary>Gets the value of the specified <see langword="ValueTuple" /> element.</summary>
		/// <param name="index">The index of the specified <see langword="ValueTuple" /> element. <paramref name="index" /> can range from 0 (the index of <see cref="F:System.ValueTuple`7.Item1" />) to 6 (the index of  <see cref="F:System.ValueTuple`7.Item7" />).</param>
		/// <returns>The value of the <see langword="ValueTuple" /> element at the specified position.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="index" /> is less than 0 or greater than 6.</exception>
		// Token: 0x17000081 RID: 129
		object ITuple.this[int index]
		{
			get
			{
				switch (index)
				{
				case 0:
					return this.Item1;
				case 1:
					return this.Item2;
				case 2:
					return this.Item3;
				case 3:
					return this.Item4;
				case 4:
					return this.Item5;
				case 5:
					return this.Item6;
				case 6:
					return this.Item7;
				default:
					throw new IndexOutOfRangeException();
				}
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's first element.</summary>
		// Token: 0x04000274 RID: 628
		public T1 Item1;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's second element.</summary>
		// Token: 0x04000275 RID: 629
		public T2 Item2;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's third element.</summary>
		// Token: 0x04000276 RID: 630
		public T3 Item3;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's fourth element.</summary>
		// Token: 0x04000277 RID: 631
		public T4 Item4;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's fifth element.</summary>
		// Token: 0x04000278 RID: 632
		public T5 Item5;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's sixth element.</summary>
		// Token: 0x04000279 RID: 633
		public T6 Item6;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`7" /> instance's seventh element.</summary>
		// Token: 0x0400027A RID: 634
		public T7 Item7;
	}
}
