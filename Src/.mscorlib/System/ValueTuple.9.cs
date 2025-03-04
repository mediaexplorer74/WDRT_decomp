﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace System
{
	/// <summary>Represents an n-value tuple, where n is 8 or greater.</summary>
	/// <typeparam name="T1">The type of the value tuple's first element.</typeparam>
	/// <typeparam name="T2">The type of the value tuple's second element.</typeparam>
	/// <typeparam name="T3">The type of the value tuple's third element.</typeparam>
	/// <typeparam name="T4">The type of the value tuple's fourth element.</typeparam>
	/// <typeparam name="T5">The type of the value tuple's fifth element.</typeparam>
	/// <typeparam name="T6">The type of the value tuple's sixth element.</typeparam>
	/// <typeparam name="T7">The type of the value tuple's seventh element.</typeparam>
	/// <typeparam name="TRest">Any generic value tuple instance that defines the types of the tuple's remaining elements.</typeparam>
	// Token: 0x02000071 RID: 113
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	public struct ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IEquatable<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, IStructuralEquatable, IStructuralComparable, IComparable, IComparable<ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>>, IValueTupleInternal, ITuple where TRest : struct
	{
		/// <summary>Initializes a new <see cref="T:System.ValueTuple`8" /> instance.</summary>
		/// <param name="item1">The value tuple's first element.</param>
		/// <param name="item2">The value tuple's second element.</param>
		/// <param name="item3">The value tuple's third element.</param>
		/// <param name="item4">The value tuple's fourth element.</param>
		/// <param name="item5">The value tuple's fifth element.</param>
		/// <param name="item6">The value tuple's sixth element.</param>
		/// <param name="item7">The value tuple's seventh element.</param>
		/// <param name="rest">An instance of any value tuple type that contains the values of the value's tuple's remaining elements.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="rest" /> is not a generic value tuple type.</exception>
		// Token: 0x06000463 RID: 1123 RVA: 0x0000D244 File Offset: 0x0000B444
		public ValueTuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
		{
			if (!(rest is IValueTupleInternal))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleLastArgumentNotAValueTuple"));
			}
			this.Item1 = item1;
			this.Item2 = item2;
			this.Item3 = item3;
			this.Item4 = item4;
			this.Item5 = item5;
			this.Item6 = item6;
			this.Item7 = item7;
			this.Rest = rest;
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`8" /> instance is equal to a specified object.</summary>
		/// <param name="obj">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000464 RID: 1124 RVA: 0x0000D2AC File Offset: 0x0000B4AC
		public override bool Equals(object obj)
		{
			return obj is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> && this.Equals((ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)obj);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`8" /> instance is equal to a specified <see cref="T:System.ValueTuple`8" /> instance.</summary>
		/// <param name="other">The value tuple to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified tuple; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000465 RID: 1125 RVA: 0x0000D2C4 File Offset: 0x0000B4C4
		public bool Equals(ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> other)
		{
			return EqualityComparer<T1>.Default.Equals(this.Item1, other.Item1) && EqualityComparer<T2>.Default.Equals(this.Item2, other.Item2) && EqualityComparer<T3>.Default.Equals(this.Item3, other.Item3) && EqualityComparer<T4>.Default.Equals(this.Item4, other.Item4) && EqualityComparer<T5>.Default.Equals(this.Item5, other.Item5) && EqualityComparer<T6>.Default.Equals(this.Item6, other.Item6) && EqualityComparer<T7>.Default.Equals(this.Item7, other.Item7) && EqualityComparer<TRest>.Default.Equals(this.Rest, other.Rest);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.ValueTuple`8" /> instance is equal to a specified object based on a specified comparison method.</summary>
		/// <param name="other">The object to compare with this instance.</param>
		/// <param name="comparer">An object that defines the method to use to evaluate whether the two objects are equal.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified objects; otherwise, <see langword="false" />.</returns>
		// Token: 0x06000466 RID: 1126 RVA: 0x0000D398 File Offset: 0x0000B598
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
		{
			if (other == null || !(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>))
			{
				return false;
			}
			ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> valueTuple = (ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)other;
			return comparer.Equals(this.Item1, valueTuple.Item1) && comparer.Equals(this.Item2, valueTuple.Item2) && comparer.Equals(this.Item3, valueTuple.Item3) && comparer.Equals(this.Item4, valueTuple.Item4) && comparer.Equals(this.Item5, valueTuple.Item5) && comparer.Equals(this.Item6, valueTuple.Item6) && comparer.Equals(this.Item7, valueTuple.Item7) && comparer.Equals(this.Rest, valueTuple.Rest);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`8" /> object to a specified object and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="other">An object to compare with the current instance.</param>
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
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="other" /> is not a <see cref="T:System.ValueTuple`8" /> object.</exception>
		// Token: 0x06000467 RID: 1127 RVA: 0x0000D4B4 File Offset: 0x0000B6B4
		int IComparable.CompareTo(object other)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleIncorrectType", new object[] { base.GetType().ToString() }), "other");
			}
			return this.CompareTo((ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)other);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`8" /> instance to a specified <see cref="T:System.ValueTuple`8" /> instance</summary>
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
		// Token: 0x06000468 RID: 1128 RVA: 0x0000D510 File Offset: 0x0000B710
		public int CompareTo(ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> other)
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
			num = Comparer<T7>.Default.Compare(this.Item7, other.Item7);
			if (num != 0)
			{
				return num;
			}
			return Comparer<TRest>.Default.Compare(this.Rest, other.Rest);
		}

		/// <summary>Compares the current <see cref="T:System.ValueTuple`8" /> instance to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
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
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="other" /> is not a <see cref="T:System.ValueTuple`8" /> object.</exception>
		// Token: 0x06000469 RID: 1129 RVA: 0x0000D5F8 File Offset: 0x0000B7F8
		int IStructuralComparable.CompareTo(object other, IComparer comparer)
		{
			if (other == null)
			{
				return 1;
			}
			if (!(other is ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_ValueTupleIncorrectType", new object[] { base.GetType().ToString() }), "other");
			}
			ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest> valueTuple = (ValueTuple<T1, T2, T3, T4, T5, T6, T7, TRest>)other;
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
			num = comparer.Compare(this.Item7, valueTuple.Item7);
			if (num != 0)
			{
				return num;
			}
			return comparer.Compare(this.Rest, valueTuple.Rest);
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.ValueTuple`8" /> instance.</summary>
		/// <returns>The hash code for the current <see cref="T:System.ValueTuple`8" /> instance.</returns>
		// Token: 0x0600046A RID: 1130 RVA: 0x0000D758 File Offset: 0x0000B958
		public override int GetHashCode()
		{
			IValueTupleInternal valueTupleInternal = this.Rest as IValueTupleInternal;
			if (valueTupleInternal == null)
			{
				return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(this.Item1), EqualityComparer<T2>.Default.GetHashCode(this.Item2), EqualityComparer<T3>.Default.GetHashCode(this.Item3), EqualityComparer<T4>.Default.GetHashCode(this.Item4), EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7));
			}
			int length = valueTupleInternal.Length;
			if (length >= 8)
			{
				return valueTupleInternal.GetHashCode();
			}
			switch (8 - length)
			{
			case 1:
				return ValueTuple.CombineHashCodes(EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			case 2:
				return ValueTuple.CombineHashCodes(EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			case 3:
				return ValueTuple.CombineHashCodes(EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			case 4:
				return ValueTuple.CombineHashCodes(EqualityComparer<T4>.Default.GetHashCode(this.Item4), EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			case 5:
				return ValueTuple.CombineHashCodes(EqualityComparer<T3>.Default.GetHashCode(this.Item3), EqualityComparer<T4>.Default.GetHashCode(this.Item4), EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			case 6:
				return ValueTuple.CombineHashCodes(EqualityComparer<T2>.Default.GetHashCode(this.Item2), EqualityComparer<T3>.Default.GetHashCode(this.Item3), EqualityComparer<T4>.Default.GetHashCode(this.Item4), EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			case 7:
			case 8:
				return ValueTuple.CombineHashCodes(EqualityComparer<T1>.Default.GetHashCode(this.Item1), EqualityComparer<T2>.Default.GetHashCode(this.Item2), EqualityComparer<T3>.Default.GetHashCode(this.Item3), EqualityComparer<T4>.Default.GetHashCode(this.Item4), EqualityComparer<T5>.Default.GetHashCode(this.Item5), EqualityComparer<T6>.Default.GetHashCode(this.Item6), EqualityComparer<T7>.Default.GetHashCode(this.Item7), valueTupleInternal.GetHashCode());
			default:
				return -1;
			}
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.ValueTuple`8" /> instance by using a specified computation method.</summary>
		/// <param name="comparer">An object whose <see cref="M:System.Collections.IEqualityComparer.GetHashCode(System.Object)" /> method calculates the hash code of the current <see cref="T:System.ValueTuple`8" /> instance.</param>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x0600046B RID: 1131 RVA: 0x0000DA47 File Offset: 0x0000BC47
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
		{
			return this.GetHashCodeCore(comparer);
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x0000DA50 File Offset: 0x0000BC50
		private int GetHashCodeCore(IEqualityComparer comparer)
		{
			IValueTupleInternal valueTupleInternal = this.Rest as IValueTupleInternal;
			if (valueTupleInternal == null)
			{
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item1), comparer.GetHashCode(this.Item2), comparer.GetHashCode(this.Item3), comparer.GetHashCode(this.Item4), comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7));
			}
			int length = valueTupleInternal.Length;
			if (length >= 8)
			{
				return valueTupleInternal.GetHashCode(comparer);
			}
			switch (8 - length)
			{
			case 1:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			case 2:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			case 3:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			case 4:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item4), comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			case 5:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item3), comparer.GetHashCode(this.Item4), comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			case 6:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item2), comparer.GetHashCode(this.Item3), comparer.GetHashCode(this.Item4), comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			case 7:
			case 8:
				return ValueTuple.CombineHashCodes(comparer.GetHashCode(this.Item1), comparer.GetHashCode(this.Item2), comparer.GetHashCode(this.Item3), comparer.GetHashCode(this.Item4), comparer.GetHashCode(this.Item5), comparer.GetHashCode(this.Item6), comparer.GetHashCode(this.Item7), valueTupleInternal.GetHashCode(comparer));
			default:
				return -1;
			}
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000DD6A File Offset: 0x0000BF6A
		int IValueTupleInternal.GetHashCode(IEqualityComparer comparer)
		{
			return this.GetHashCodeCore(comparer);
		}

		/// <summary>Returns a string that represents the value of this <see cref="T:System.ValueTuple`8" /> instance.</summary>
		/// <returns>The string representation of this <see cref="T:System.ValueTuple`8" /> instance.</returns>
		// Token: 0x0600046E RID: 1134 RVA: 0x0000DD74 File Offset: 0x0000BF74
		public override string ToString()
		{
			IValueTupleInternal valueTupleInternal = this.Rest as IValueTupleInternal;
			T1 t;
			T2 t2;
			T3 t3;
			T4 t4;
			T5 t5;
			T6 t6;
			T7 t7;
			if (valueTupleInternal == null)
			{
				string[] array = new string[17];
				array[0] = "(";
				int num = 1;
				ref T1 ptr = ref this.Item1;
				t = default(T1);
				string text;
				if (t == null)
				{
					t = this.Item1;
					ptr = ref t;
					if (t == null)
					{
						text = null;
						goto IL_5D;
					}
				}
				text = ptr.ToString();
				IL_5D:
				array[num] = text;
				array[2] = ", ";
				int num2 = 3;
				ref T2 ptr2 = ref this.Item2;
				t2 = default(T2);
				string text2;
				if (t2 == null)
				{
					t2 = this.Item2;
					ptr2 = ref t2;
					if (t2 == null)
					{
						text2 = null;
						goto IL_9D;
					}
				}
				text2 = ptr2.ToString();
				IL_9D:
				array[num2] = text2;
				array[4] = ", ";
				int num3 = 5;
				ref T3 ptr3 = ref this.Item3;
				t3 = default(T3);
				string text3;
				if (t3 == null)
				{
					t3 = this.Item3;
					ptr3 = ref t3;
					if (t3 == null)
					{
						text3 = null;
						goto IL_DD;
					}
				}
				text3 = ptr3.ToString();
				IL_DD:
				array[num3] = text3;
				array[6] = ", ";
				int num4 = 7;
				ref T4 ptr4 = ref this.Item4;
				t4 = default(T4);
				string text4;
				if (t4 == null)
				{
					t4 = this.Item4;
					ptr4 = ref t4;
					if (t4 == null)
					{
						text4 = null;
						goto IL_120;
					}
				}
				text4 = ptr4.ToString();
				IL_120:
				array[num4] = text4;
				array[8] = ", ";
				int num5 = 9;
				ref T5 ptr5 = ref this.Item5;
				t5 = default(T5);
				string text5;
				if (t5 == null)
				{
					t5 = this.Item5;
					ptr5 = ref t5;
					if (t5 == null)
					{
						text5 = null;
						goto IL_164;
					}
				}
				text5 = ptr5.ToString();
				IL_164:
				array[num5] = text5;
				array[10] = ", ";
				int num6 = 11;
				ref T6 ptr6 = ref this.Item6;
				t6 = default(T6);
				string text6;
				if (t6 == null)
				{
					t6 = this.Item6;
					ptr6 = ref t6;
					if (t6 == null)
					{
						text6 = null;
						goto IL_1A9;
					}
				}
				text6 = ptr6.ToString();
				IL_1A9:
				array[num6] = text6;
				array[12] = ", ";
				int num7 = 13;
				ref T7 ptr7 = ref this.Item7;
				t7 = default(T7);
				string text7;
				if (t7 == null)
				{
					t7 = this.Item7;
					ptr7 = ref t7;
					if (t7 == null)
					{
						text7 = null;
						goto IL_1EE;
					}
				}
				text7 = ptr7.ToString();
				IL_1EE:
				array[num7] = text7;
				array[14] = ", ";
				array[15] = this.Rest.ToString();
				array[16] = ")";
				return string.Concat(array);
			}
			string[] array2 = new string[16];
			array2[0] = "(";
			int num8 = 1;
			ref T1 ptr8 = ref this.Item1;
			t = default(T1);
			string text8;
			if (t == null)
			{
				t = this.Item1;
				ptr8 = ref t;
				if (t == null)
				{
					text8 = null;
					goto IL_262;
				}
			}
			text8 = ptr8.ToString();
			IL_262:
			array2[num8] = text8;
			array2[2] = ", ";
			int num9 = 3;
			ref T2 ptr9 = ref this.Item2;
			t2 = default(T2);
			string text9;
			if (t2 == null)
			{
				t2 = this.Item2;
				ptr9 = ref t2;
				if (t2 == null)
				{
					text9 = null;
					goto IL_2A2;
				}
			}
			text9 = ptr9.ToString();
			IL_2A2:
			array2[num9] = text9;
			array2[4] = ", ";
			int num10 = 5;
			ref T3 ptr10 = ref this.Item3;
			t3 = default(T3);
			string text10;
			if (t3 == null)
			{
				t3 = this.Item3;
				ptr10 = ref t3;
				if (t3 == null)
				{
					text10 = null;
					goto IL_2E2;
				}
			}
			text10 = ptr10.ToString();
			IL_2E2:
			array2[num10] = text10;
			array2[6] = ", ";
			int num11 = 7;
			ref T4 ptr11 = ref this.Item4;
			t4 = default(T4);
			string text11;
			if (t4 == null)
			{
				t4 = this.Item4;
				ptr11 = ref t4;
				if (t4 == null)
				{
					text11 = null;
					goto IL_325;
				}
			}
			text11 = ptr11.ToString();
			IL_325:
			array2[num11] = text11;
			array2[8] = ", ";
			int num12 = 9;
			ref T5 ptr12 = ref this.Item5;
			t5 = default(T5);
			string text12;
			if (t5 == null)
			{
				t5 = this.Item5;
				ptr12 = ref t5;
				if (t5 == null)
				{
					text12 = null;
					goto IL_369;
				}
			}
			text12 = ptr12.ToString();
			IL_369:
			array2[num12] = text12;
			array2[10] = ", ";
			int num13 = 11;
			ref T6 ptr13 = ref this.Item6;
			t6 = default(T6);
			string text13;
			if (t6 == null)
			{
				t6 = this.Item6;
				ptr13 = ref t6;
				if (t6 == null)
				{
					text13 = null;
					goto IL_3AE;
				}
			}
			text13 = ptr13.ToString();
			IL_3AE:
			array2[num13] = text13;
			array2[12] = ", ";
			int num14 = 13;
			ref T7 ptr14 = ref this.Item7;
			t7 = default(T7);
			string text14;
			if (t7 == null)
			{
				t7 = this.Item7;
				ptr14 = ref t7;
				if (t7 == null)
				{
					text14 = null;
					goto IL_3F3;
				}
			}
			text14 = ptr14.ToString();
			IL_3F3:
			array2[num14] = text14;
			array2[14] = ", ";
			array2[15] = valueTupleInternal.ToStringEnd();
			return string.Concat(array2);
		}

		// Token: 0x0600046F RID: 1135 RVA: 0x0000E190 File Offset: 0x0000C390
		string IValueTupleInternal.ToStringEnd()
		{
			IValueTupleInternal valueTupleInternal = this.Rest as IValueTupleInternal;
			T1 t;
			T2 t2;
			T3 t3;
			T4 t4;
			T5 t5;
			T6 t6;
			T7 t7;
			if (valueTupleInternal == null)
			{
				string[] array = new string[16];
				int num = 0;
				ref T1 ptr = ref this.Item1;
				t = default(T1);
				string text;
				if (t == null)
				{
					t = this.Item1;
					ptr = ref t;
					if (t == null)
					{
						text = null;
						goto IL_55;
					}
				}
				text = ptr.ToString();
				IL_55:
				array[num] = text;
				array[1] = ", ";
				int num2 = 2;
				ref T2 ptr2 = ref this.Item2;
				t2 = default(T2);
				string text2;
				if (t2 == null)
				{
					t2 = this.Item2;
					ptr2 = ref t2;
					if (t2 == null)
					{
						text2 = null;
						goto IL_95;
					}
				}
				text2 = ptr2.ToString();
				IL_95:
				array[num2] = text2;
				array[3] = ", ";
				int num3 = 4;
				ref T3 ptr3 = ref this.Item3;
				t3 = default(T3);
				string text3;
				if (t3 == null)
				{
					t3 = this.Item3;
					ptr3 = ref t3;
					if (t3 == null)
					{
						text3 = null;
						goto IL_D5;
					}
				}
				text3 = ptr3.ToString();
				IL_D5:
				array[num3] = text3;
				array[5] = ", ";
				int num4 = 6;
				ref T4 ptr4 = ref this.Item4;
				t4 = default(T4);
				string text4;
				if (t4 == null)
				{
					t4 = this.Item4;
					ptr4 = ref t4;
					if (t4 == null)
					{
						text4 = null;
						goto IL_118;
					}
				}
				text4 = ptr4.ToString();
				IL_118:
				array[num4] = text4;
				array[7] = ", ";
				int num5 = 8;
				ref T5 ptr5 = ref this.Item5;
				t5 = default(T5);
				string text5;
				if (t5 == null)
				{
					t5 = this.Item5;
					ptr5 = ref t5;
					if (t5 == null)
					{
						text5 = null;
						goto IL_15B;
					}
				}
				text5 = ptr5.ToString();
				IL_15B:
				array[num5] = text5;
				array[9] = ", ";
				int num6 = 10;
				ref T6 ptr6 = ref this.Item6;
				t6 = default(T6);
				string text6;
				if (t6 == null)
				{
					t6 = this.Item6;
					ptr6 = ref t6;
					if (t6 == null)
					{
						text6 = null;
						goto IL_1A0;
					}
				}
				text6 = ptr6.ToString();
				IL_1A0:
				array[num6] = text6;
				array[11] = ", ";
				int num7 = 12;
				ref T7 ptr7 = ref this.Item7;
				t7 = default(T7);
				string text7;
				if (t7 == null)
				{
					t7 = this.Item7;
					ptr7 = ref t7;
					if (t7 == null)
					{
						text7 = null;
						goto IL_1E5;
					}
				}
				text7 = ptr7.ToString();
				IL_1E5:
				array[num7] = text7;
				array[13] = ", ";
				array[14] = this.Rest.ToString();
				array[15] = ")";
				return string.Concat(array);
			}
			string[] array2 = new string[15];
			int num8 = 0;
			ref T1 ptr8 = ref this.Item1;
			t = default(T1);
			string text8;
			if (t == null)
			{
				t = this.Item1;
				ptr8 = ref t;
				if (t == null)
				{
					text8 = null;
					goto IL_251;
				}
			}
			text8 = ptr8.ToString();
			IL_251:
			array2[num8] = text8;
			array2[1] = ", ";
			int num9 = 2;
			ref T2 ptr9 = ref this.Item2;
			t2 = default(T2);
			string text9;
			if (t2 == null)
			{
				t2 = this.Item2;
				ptr9 = ref t2;
				if (t2 == null)
				{
					text9 = null;
					goto IL_291;
				}
			}
			text9 = ptr9.ToString();
			IL_291:
			array2[num9] = text9;
			array2[3] = ", ";
			int num10 = 4;
			ref T3 ptr10 = ref this.Item3;
			t3 = default(T3);
			string text10;
			if (t3 == null)
			{
				t3 = this.Item3;
				ptr10 = ref t3;
				if (t3 == null)
				{
					text10 = null;
					goto IL_2D1;
				}
			}
			text10 = ptr10.ToString();
			IL_2D1:
			array2[num10] = text10;
			array2[5] = ", ";
			int num11 = 6;
			ref T4 ptr11 = ref this.Item4;
			t4 = default(T4);
			string text11;
			if (t4 == null)
			{
				t4 = this.Item4;
				ptr11 = ref t4;
				if (t4 == null)
				{
					text11 = null;
					goto IL_314;
				}
			}
			text11 = ptr11.ToString();
			IL_314:
			array2[num11] = text11;
			array2[7] = ", ";
			int num12 = 8;
			ref T5 ptr12 = ref this.Item5;
			t5 = default(T5);
			string text12;
			if (t5 == null)
			{
				t5 = this.Item5;
				ptr12 = ref t5;
				if (t5 == null)
				{
					text12 = null;
					goto IL_357;
				}
			}
			text12 = ptr12.ToString();
			IL_357:
			array2[num12] = text12;
			array2[9] = ", ";
			int num13 = 10;
			ref T6 ptr13 = ref this.Item6;
			t6 = default(T6);
			string text13;
			if (t6 == null)
			{
				t6 = this.Item6;
				ptr13 = ref t6;
				if (t6 == null)
				{
					text13 = null;
					goto IL_39C;
				}
			}
			text13 = ptr13.ToString();
			IL_39C:
			array2[num13] = text13;
			array2[11] = ", ";
			int num14 = 12;
			ref T7 ptr14 = ref this.Item7;
			t7 = default(T7);
			string text14;
			if (t7 == null)
			{
				t7 = this.Item7;
				ptr14 = ref t7;
				if (t7 == null)
				{
					text14 = null;
					goto IL_3E1;
				}
			}
			text14 = ptr14.ToString();
			IL_3E1:
			array2[num14] = text14;
			array2[13] = ", ";
			array2[14] = valueTupleInternal.ToStringEnd();
			return string.Concat(array2);
		}

		/// <summary>Gets the number of elements in the <see langword="ValueTuple" />.</summary>
		/// <returns>The number of elements in the <see langword="ValueTuple" />.</returns>
		// Token: 0x17000082 RID: 130
		// (get) Token: 0x06000470 RID: 1136 RVA: 0x0000E598 File Offset: 0x0000C798
		int ITuple.Length
		{
			get
			{
				IValueTupleInternal valueTupleInternal = this.Rest as IValueTupleInternal;
				if (valueTupleInternal != null)
				{
					return 7 + valueTupleInternal.Length;
				}
				return 8;
			}
		}

		/// <summary>Gets the value of the specified <see langword="ValueTuple" /> element.</summary>
		/// <param name="index">The value of the specified <see langword="ValueTuple" /> element. <paramref name="index" /> can range from 0 for <see langword="Item1" /> to one less than the number of elements in the <see langword="ValueTuple" />.</param>
		/// <returns>The value of the <see langword="ValueTuple" /> element at the specified position.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="index" /> is less than 0.  
		/// -or-  
		/// <paramref name="index" /> is greater than or equal to <see cref="P:System.ValueTuple`8.System#Runtime#CompilerServices#ITuple#Length" />.</exception>
		// Token: 0x17000083 RID: 131
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
				{
					IValueTupleInternal valueTupleInternal = this.Rest as IValueTupleInternal;
					if (valueTupleInternal != null)
					{
						return valueTupleInternal[index - 7];
					}
					if (index == 7)
					{
						return this.Rest;
					}
					throw new IndexOutOfRangeException();
				}
				}
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's first element.</summary>
		// Token: 0x0400027B RID: 635
		public T1 Item1;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's second element.</summary>
		// Token: 0x0400027C RID: 636
		public T2 Item2;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's third element.</summary>
		// Token: 0x0400027D RID: 637
		public T3 Item3;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's fourth element.</summary>
		// Token: 0x0400027E RID: 638
		public T4 Item4;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's fifth element.</summary>
		// Token: 0x0400027F RID: 639
		public T5 Item5;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's sixth element.</summary>
		// Token: 0x04000280 RID: 640
		public T6 Item6;

		/// <summary>Gets the value of the current <see cref="T:System.ValueTuple`8" /> instance's seventh element.</summary>
		// Token: 0x04000281 RID: 641
		public T7 Item7;

		/// <summary>Gets the current <see cref="T:System.ValueTuple`8" /> instance's remaining elements.</summary>
		// Token: 0x04000282 RID: 642
		public TRest Rest;
	}
}
