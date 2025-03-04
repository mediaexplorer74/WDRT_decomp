﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace System
{
	/// <summary>Represents an n-tuple, where n is 8 or greater.</summary>
	/// <typeparam name="T1">The type of the tuple's first component.</typeparam>
	/// <typeparam name="T2">The type of the tuple's second component.</typeparam>
	/// <typeparam name="T3">The type of the tuple's third component.</typeparam>
	/// <typeparam name="T4">The type of the tuple's fourth component.</typeparam>
	/// <typeparam name="T5">The type of the tuple's fifth component.</typeparam>
	/// <typeparam name="T6">The type of the tuple's sixth component.</typeparam>
	/// <typeparam name="T7">The type of the tuple's seventh component.</typeparam>
	/// <typeparam name="TRest">Any generic <see langword="Tuple" /> object that defines the types of the tuple's remaining components.</typeparam>
	// Token: 0x02000067 RID: 103
	[__DynamicallyInvokable]
	[Serializable]
	public class Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> : IStructuralEquatable, IStructuralComparable, IComparable, ITupleInternal, ITuple
	{
		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's first component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's first component.</returns>
		// Token: 0x17000068 RID: 104
		// (get) Token: 0x060003C8 RID: 968 RVA: 0x00009D56 File Offset: 0x00007F56
		[__DynamicallyInvokable]
		public T1 Item1
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item1;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's second component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's second component.</returns>
		// Token: 0x17000069 RID: 105
		// (get) Token: 0x060003C9 RID: 969 RVA: 0x00009D5E File Offset: 0x00007F5E
		[__DynamicallyInvokable]
		public T2 Item2
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item2;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's third component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's third component.</returns>
		// Token: 0x1700006A RID: 106
		// (get) Token: 0x060003CA RID: 970 RVA: 0x00009D66 File Offset: 0x00007F66
		[__DynamicallyInvokable]
		public T3 Item3
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item3;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's fourth component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's fourth component.</returns>
		// Token: 0x1700006B RID: 107
		// (get) Token: 0x060003CB RID: 971 RVA: 0x00009D6E File Offset: 0x00007F6E
		[__DynamicallyInvokable]
		public T4 Item4
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item4;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's fifth component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's fifth component.</returns>
		// Token: 0x1700006C RID: 108
		// (get) Token: 0x060003CC RID: 972 RVA: 0x00009D76 File Offset: 0x00007F76
		[__DynamicallyInvokable]
		public T5 Item5
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item5;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's sixth component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's sixth component.</returns>
		// Token: 0x1700006D RID: 109
		// (get) Token: 0x060003CD RID: 973 RVA: 0x00009D7E File Offset: 0x00007F7E
		[__DynamicallyInvokable]
		public T6 Item6
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item6;
			}
		}

		/// <summary>Gets the value of the current <see cref="T:System.Tuple`8" /> object's seventh component.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's seventh component.</returns>
		// Token: 0x1700006E RID: 110
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00009D86 File Offset: 0x00007F86
		[__DynamicallyInvokable]
		public T7 Item7
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Item7;
			}
		}

		/// <summary>Gets the current <see cref="T:System.Tuple`8" /> object's remaining components.</summary>
		/// <returns>The value of the current <see cref="T:System.Tuple`8" /> object's remaining components.</returns>
		// Token: 0x1700006F RID: 111
		// (get) Token: 0x060003CF RID: 975 RVA: 0x00009D8E File Offset: 0x00007F8E
		[__DynamicallyInvokable]
		public TRest Rest
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_Rest;
			}
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Tuple`8" /> class.</summary>
		/// <param name="item1">The value of the tuple's first component.</param>
		/// <param name="item2">The value of the tuple's second component.</param>
		/// <param name="item3">The value of the tuple's third component.</param>
		/// <param name="item4">The value of the tuple's fourth component</param>
		/// <param name="item5">The value of the tuple's fifth component.</param>
		/// <param name="item6">The value of the tuple's sixth component.</param>
		/// <param name="item7">The value of the tuple's seventh component.</param>
		/// <param name="rest">Any generic <see langword="Tuple" /> object that contains the values of the tuple's remaining components.</param>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="rest" /> is not a generic <see langword="Tuple" /> object.</exception>
		// Token: 0x060003D0 RID: 976 RVA: 0x00009D98 File Offset: 0x00007F98
		[__DynamicallyInvokable]
		public Tuple(T1 item1, T2 item2, T3 item3, T4 item4, T5 item5, T6 item6, T7 item7, TRest rest)
		{
			if (!(rest is ITupleInternal))
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleLastArgumentNotATuple"));
			}
			this.m_Item1 = item1;
			this.m_Item2 = item2;
			this.m_Item3 = item3;
			this.m_Item4 = item4;
			this.m_Item5 = item5;
			this.m_Item6 = item6;
			this.m_Item7 = item7;
			this.m_Rest = rest;
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.Tuple`8" /> object is equal to a specified object.</summary>
		/// <param name="obj">The object to compare with this instance.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060003D1 RID: 977 RVA: 0x00009E06 File Offset: 0x00008006
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return ((IStructuralEquatable)this).Equals(obj, EqualityComparer<object>.Default);
		}

		/// <summary>Returns a value that indicates whether the current <see cref="T:System.Tuple`8" /> object is equal to a specified object based on a specified comparison method.</summary>
		/// <param name="other">The object to compare with this instance.</param>
		/// <param name="comparer">An object that defines the method to use to evaluate whether the two objects are equal.</param>
		/// <returns>
		///   <see langword="true" /> if the current instance is equal to the specified object; otherwise, <see langword="false" />.</returns>
		// Token: 0x060003D2 RID: 978 RVA: 0x00009E14 File Offset: 0x00008014
		[__DynamicallyInvokable]
		bool IStructuralEquatable.Equals(object other, IEqualityComparer comparer)
		{
			if (other == null)
			{
				return false;
			}
			Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
			return tuple != null && (comparer.Equals(this.m_Item1, tuple.m_Item1) && comparer.Equals(this.m_Item2, tuple.m_Item2) && comparer.Equals(this.m_Item3, tuple.m_Item3) && comparer.Equals(this.m_Item4, tuple.m_Item4) && comparer.Equals(this.m_Item5, tuple.m_Item5) && comparer.Equals(this.m_Item6, tuple.m_Item6) && comparer.Equals(this.m_Item7, tuple.m_Item7)) && comparer.Equals(this.m_Rest, tuple.m_Rest);
		}

		/// <summary>Compares the current <see cref="T:System.Tuple`8" /> object to a specified object and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="obj">An object to compare with the current instance.</param>
		/// <returns>A signed integer that indicates the relative position of this instance and <paramref name="obj" /> in the sort order, as shown in the following table.  
		///   Value  
		///
		///   Description  
		///
		///   A negative integer  
		///
		///   This instance precedes <paramref name="obj" />.  
		///
		///   Zero  
		///
		///   This instance and <paramref name="obj" /> have the same position in the sort order.  
		///
		///   A positive integer  
		///
		///   This instance follows <paramref name="obj" />.</returns>
		/// <exception cref="T:System.ArgumentException">
		///   <paramref name="obj" /> is not a <see cref="T:System.Tuple`8" /> object.</exception>
		// Token: 0x060003D3 RID: 979 RVA: 0x00009F2B File Offset: 0x0000812B
		[__DynamicallyInvokable]
		int IComparable.CompareTo(object obj)
		{
			return ((IStructuralComparable)this).CompareTo(obj, Comparer<object>.Default);
		}

		/// <summary>Compares the current <see cref="T:System.Tuple`8" /> object to a specified object by using a specified comparer and returns an integer that indicates whether the current object is before, after, or in the same position as the specified object in the sort order.</summary>
		/// <param name="other">An object to compare with the current instance.</param>
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
		///   <paramref name="other" /> is not a <see cref="T:System.Tuple`8" /> object.</exception>
		// Token: 0x060003D4 RID: 980 RVA: 0x00009F3C File Offset: 0x0000813C
		[__DynamicallyInvokable]
		int IStructuralComparable.CompareTo(object other, IComparer comparer)
		{
			if (other == null)
			{
				return 1;
			}
			Tuple<T1, T2, T3, T4, T5, T6, T7, TRest> tuple = other as Tuple<T1, T2, T3, T4, T5, T6, T7, TRest>;
			if (tuple == null)
			{
				throw new ArgumentException(Environment.GetResourceString("ArgumentException_TupleIncorrectType", new object[] { base.GetType().ToString() }), "other");
			}
			int num = comparer.Compare(this.m_Item1, tuple.m_Item1);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.m_Item2, tuple.m_Item2);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.m_Item3, tuple.m_Item3);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.m_Item4, tuple.m_Item4);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.m_Item5, tuple.m_Item5);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.m_Item6, tuple.m_Item6);
			if (num != 0)
			{
				return num;
			}
			num = comparer.Compare(this.m_Item7, tuple.m_Item7);
			if (num != 0)
			{
				return num;
			}
			return comparer.Compare(this.m_Rest, tuple.m_Rest);
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.Tuple`8" /> object.</summary>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060003D5 RID: 981 RVA: 0x0000A08D File Offset: 0x0000828D
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return ((IStructuralEquatable)this).GetHashCode(EqualityComparer<object>.Default);
		}

		/// <summary>Calculates the hash code for the current <see cref="T:System.Tuple`8" /> object by using a specified computation method.</summary>
		/// <param name="comparer">An object whose <see cref="M:System.Collections.IEqualityComparer.GetHashCode(System.Object)" /> method calculates the hash code of the current <see cref="T:System.Tuple`8" /> object.</param>
		/// <returns>A 32-bit signed integer hash code.</returns>
		// Token: 0x060003D6 RID: 982 RVA: 0x0000A09C File Offset: 0x0000829C
		[__DynamicallyInvokable]
		int IStructuralEquatable.GetHashCode(IEqualityComparer comparer)
		{
			ITupleInternal tupleInternal = (ITupleInternal)((object)this.m_Rest);
			if (tupleInternal.Length >= 8)
			{
				return tupleInternal.GetHashCode(comparer);
			}
			switch (8 - tupleInternal.Length)
			{
			case 1:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			case 2:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item6), comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			case 3:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item5), comparer.GetHashCode(this.m_Item6), comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			case 4:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item4), comparer.GetHashCode(this.m_Item5), comparer.GetHashCode(this.m_Item6), comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			case 5:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item3), comparer.GetHashCode(this.m_Item4), comparer.GetHashCode(this.m_Item5), comparer.GetHashCode(this.m_Item6), comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			case 6:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item2), comparer.GetHashCode(this.m_Item3), comparer.GetHashCode(this.m_Item4), comparer.GetHashCode(this.m_Item5), comparer.GetHashCode(this.m_Item6), comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			case 7:
				return Tuple.CombineHashCodes(comparer.GetHashCode(this.m_Item1), comparer.GetHashCode(this.m_Item2), comparer.GetHashCode(this.m_Item3), comparer.GetHashCode(this.m_Item4), comparer.GetHashCode(this.m_Item5), comparer.GetHashCode(this.m_Item6), comparer.GetHashCode(this.m_Item7), tupleInternal.GetHashCode(comparer));
			default:
				return -1;
			}
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x0000A335 File Offset: 0x00008535
		int ITupleInternal.GetHashCode(IEqualityComparer comparer)
		{
			return ((IStructuralEquatable)this).GetHashCode(comparer);
		}

		/// <summary>Returns a string that represents the value of this <see cref="T:System.Tuple`8" /> instance.</summary>
		/// <returns>The string representation of this <see cref="T:System.Tuple`8" /> object.</returns>
		// Token: 0x060003D8 RID: 984 RVA: 0x0000A340 File Offset: 0x00008540
		[__DynamicallyInvokable]
		public override string ToString()
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("(");
			return ((ITupleInternal)this).ToString(stringBuilder);
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x0000A368 File Offset: 0x00008568
		string ITupleInternal.ToString(StringBuilder sb)
		{
			sb.Append(this.m_Item1);
			sb.Append(", ");
			sb.Append(this.m_Item2);
			sb.Append(", ");
			sb.Append(this.m_Item3);
			sb.Append(", ");
			sb.Append(this.m_Item4);
			sb.Append(", ");
			sb.Append(this.m_Item5);
			sb.Append(", ");
			sb.Append(this.m_Item6);
			sb.Append(", ");
			sb.Append(this.m_Item7);
			sb.Append(", ");
			return ((ITupleInternal)((object)this.m_Rest)).ToString(sb);
		}

		/// <summary>Gets the number of elements in the <see langword="Tuple" />.</summary>
		/// <returns>The number of elements in the <see langword="Tuple" />.</returns>
		// Token: 0x17000070 RID: 112
		// (get) Token: 0x060003DA RID: 986 RVA: 0x0000A45D File Offset: 0x0000865D
		int ITuple.Length
		{
			get
			{
				return 7 + ((ITupleInternal)((object)this.Rest)).Length;
			}
		}

		/// <summary>Gets the value of the specified <see langword="Tuple" /> element.</summary>
		/// <param name="index">The index of the specified <see langword="Tuple" /> element. <paramref name="index" /> can range from 0 for <see langword="Item1" /> to one less than the number of elements in the <see langword="Tuple" />.</param>
		/// <returns>The value of the <see langword="Tuple" /> element at the specified position.</returns>
		/// <exception cref="T:System.IndexOutOfRangeException">
		///   <paramref name="index" /> is less than 0.  
		/// -or-  
		/// <paramref name="index" /> is greater than or equal to <see cref="P:System.Tuple`8.System#Runtime#CompilerServices#ITuple#Length" />.</exception>
		// Token: 0x17000071 RID: 113
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
					return ((ITupleInternal)((object)this.Rest))[index - 7];
				}
			}
		}

		// Token: 0x04000257 RID: 599
		private readonly T1 m_Item1;

		// Token: 0x04000258 RID: 600
		private readonly T2 m_Item2;

		// Token: 0x04000259 RID: 601
		private readonly T3 m_Item3;

		// Token: 0x0400025A RID: 602
		private readonly T4 m_Item4;

		// Token: 0x0400025B RID: 603
		private readonly T5 m_Item5;

		// Token: 0x0400025C RID: 604
		private readonly T6 m_Item6;

		// Token: 0x0400025D RID: 605
		private readonly T7 m_Item7;

		// Token: 0x0400025E RID: 606
		private readonly TRest m_Rest;
	}
}
