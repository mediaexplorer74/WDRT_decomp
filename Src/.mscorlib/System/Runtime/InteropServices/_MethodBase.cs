﻿using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	/// <summary>Exposes the public members of the <see cref="T:System.Reflection.MethodBase" /> class to unmanaged code.</summary>
	// Token: 0x02000903 RID: 2307
	[Guid("6240837A-707F-3181-8E98-A36AE086766B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(MethodBase))]
	[ComVisible(true)]
	public interface _MethodBase
	{
		/// <summary>Retrieves the number of type information interfaces that an object provides (either 0 or 1).</summary>
		/// <param name="pcTInfo">When this method returns, contains a pointer to a location that receives the number of type information interfaces provided by the object. This parameter is passed uninitialized.</param>
		// Token: 0x06005F25 RID: 24357
		void GetTypeInfoCount(out uint pcTInfo);

		/// <summary>Retrieves the type information for an object, which can be used to get the type information for an interface.</summary>
		/// <param name="iTInfo">The type information to return.</param>
		/// <param name="lcid">The locale identifier for the type information.</param>
		/// <param name="ppTInfo">A pointer to the requested type information object.</param>
		// Token: 0x06005F26 RID: 24358
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		/// <summary>Maps a set of names to a corresponding set of dispatch identifiers.</summary>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="rgszNames">An array of names to be mapped.</param>
		/// <param name="cNames">The count of the names to be mapped.</param>
		/// <param name="lcid">The locale context in which to interpret the names.</param>
		/// <param name="rgDispId">An array allocated by the caller that receives the identifiers corresponding to the names.</param>
		// Token: 0x06005F27 RID: 24359
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		/// <summary>Provides access to properties and methods exposed by an object.</summary>
		/// <param name="dispIdMember">An identifier for the member.</param>
		/// <param name="riid">Reserved for future use. Must be IID_NULL.</param>
		/// <param name="lcid">The locale context in which to interpret arguments.</param>
		/// <param name="wFlags">Flags describing the context of the call.</param>
		/// <param name="pDispParams">A pointer to a structure containing an array of arguments, an array of argument DISPIDs for named arguments, and counts for the number of elements in the arrays.</param>
		/// <param name="pVarResult">A pointer to the location where the result will be stored.</param>
		/// <param name="pExcepInfo">A pointer to a structure that contains exception information.</param>
		/// <param name="puArgErr">The index of the first argument that has an error.</param>
		// Token: 0x06005F28 RID: 24360
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.ToString" /> method.</summary>
		/// <returns>A string that represents the current <see cref="T:System.Object" />.</returns>
		// Token: 0x06005F29 RID: 24361
		string ToString();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.Equals(System.Object)" /> method.</summary>
		/// <param name="other">The <see cref="T:System.Object" /> to compare with the current <see cref="T:System.Object" />.</param>
		/// <returns>
		///   <see langword="true" /> if the specified <see cref="T:System.Object" /> is equal to the current <see cref="T:System.Object" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005F2A RID: 24362
		bool Equals(object other);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Object.GetHashCode" /> method.</summary>
		/// <returns>The hash code for the current instance.</returns>
		// Token: 0x06005F2B RID: 24363
		int GetHashCode();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Type.GetType" /> method.</summary>
		/// <returns>A <see cref="T:System.Type" /> object.</returns>
		// Token: 0x06005F2C RID: 24364
		Type GetType();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.MemberType" /> property.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.MemberTypes" /> values indicating the type of member.</returns>
		// Token: 0x1700106C RID: 4204
		// (get) Token: 0x06005F2D RID: 24365
		MemberTypes MemberType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.Name" /> property.</summary>
		/// <returns>A <see cref="T:System.String" /> object containing the name of this member.</returns>
		// Token: 0x1700106D RID: 4205
		// (get) Token: 0x06005F2E RID: 24366
		string Name { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.DeclaringType" /> property.</summary>
		/// <returns>The <see langword="Type" /> object for the class that declares this member.</returns>
		// Token: 0x1700106E RID: 4206
		// (get) Token: 0x06005F2F RID: 24367
		Type DeclaringType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MemberInfo.ReflectedType" /> property.</summary>
		/// <returns>The <see langword="Type" /> object that was used to obtain this <see langword="MemberInfo" /> object.</returns>
		// Token: 0x1700106F RID: 4207
		// (get) Token: 0x06005F30 RID: 24368
		Type ReflectedType { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The type of attribute to search for. Only attributes that are assignable to this type are returned.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />.</param>
		/// <returns>An array of custom attributes applied to this member, or an array with zero (0) elements if no attributes have been applied.</returns>
		// Token: 0x06005F31 RID: 24369
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.GetCustomAttributes(System.Boolean)" /> method.</summary>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />.</param>
		/// <returns>An array that contains all the custom attributes, or an array with zero (0) elements if no attributes are defined.</returns>
		// Token: 0x06005F32 RID: 24370
		object[] GetCustomAttributes(bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MemberInfo.IsDefined(System.Type,System.Boolean)" /> method.</summary>
		/// <param name="attributeType">The <see langword="Type" /> object to which the custom attributes are applied.</param>
		/// <param name="inherit">
		///   <see langword="true" /> to search this member's inheritance chain to find the attributes; otherwise, <see langword="false" />.</param>
		/// <returns>
		///   <see langword="true" /> if one or more instance of the <paramref name="attributeType" /> parameter is applied to this member; otherwise, <see langword="false" />.</returns>
		// Token: 0x06005F33 RID: 24371
		bool IsDefined(Type attributeType, bool inherit);

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MethodBase.GetParameters" /> method.</summary>
		/// <returns>An array of type <see cref="T:System.Reflection.ParameterInfo" /> containing information that matches the signature of the method (or constructor) reflected by this instance.</returns>
		// Token: 0x06005F34 RID: 24372
		ParameterInfo[] GetParameters();

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MethodBase.GetMethodImplementationFlags" /> method.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.MethodImplAttributes" /> values.</returns>
		// Token: 0x06005F35 RID: 24373
		MethodImplAttributes GetMethodImplementationFlags();

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.MethodHandle" /> property.</summary>
		/// <returns>A <see cref="T:System.RuntimeMethodHandle" /> object.</returns>
		// Token: 0x17001070 RID: 4208
		// (get) Token: 0x06005F36 RID: 24374
		RuntimeMethodHandle MethodHandle { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.Attributes" /> property.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.MethodAttributes" /> values.</returns>
		// Token: 0x17001071 RID: 4209
		// (get) Token: 0x06005F37 RID: 24375
		MethodAttributes Attributes { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.CallingConvention" /> property.</summary>
		/// <returns>One of the <see cref="T:System.Reflection.CallingConventions" /> values.</returns>
		// Token: 0x17001072 RID: 4210
		// (get) Token: 0x06005F38 RID: 24376
		CallingConventions CallingConvention { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MethodBase.Invoke(System.Object,System.Reflection.BindingFlags,System.Reflection.Binder,System.Object[],System.Globalization.CultureInfo)" /> method.</summary>
		/// <param name="obj">The instance that created this method.</param>
		/// <param name="invokeAttr">One of the <see langword="BindingFlags" /> values that specifies the type of binding.</param>
		/// <param name="binder">A <see langword="Binder" /> that defines a set of properties and enables the binding, coercion of argument types, and invocation of members using reflection. If <paramref name="binder" /> is <see langword="null" />, then <see langword="Binder.DefaultBinding" /> is used.</param>
		/// <param name="parameters">An array of type <see langword="Object" /> used to match the number, order, and type of the parameters for this constructor, under the constraints of <paramref name="binder" />. If this constructor does not require parameters, pass an array with zero elements, as in Object[] parameters = new Object[0]. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference type elements, this value is <see langword="null" />. For value type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <param name="culture">A <see cref="T:System.Globalization.CultureInfo" /> object used to govern the coercion of types. If this is <see langword="null" />, the <see cref="T:System.Globalization.CultureInfo" /> for the current thread is used.</param>
		/// <returns>An instance of the class associated with the constructor.</returns>
		// Token: 0x06005F39 RID: 24377
		object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsPublic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is public; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001073 RID: 4211
		// (get) Token: 0x06005F3A RID: 24378
		bool IsPublic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsPrivate" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method is restricted to other members of the class itself; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001074 RID: 4212
		// (get) Token: 0x06005F3B RID: 24379
		bool IsPrivate { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsFamily" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if access to the class is restricted to members of the class itself and to members of its derived classes; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001075 RID: 4213
		// (get) Token: 0x06005F3C RID: 24380
		bool IsFamily { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method can be called by other classes in the same assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001076 RID: 4214
		// (get) Token: 0x06005F3D RID: 24381
		bool IsAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsFamilyAndAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method is restricted to members of the class itself and to members of derived classes that are in the same assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001077 RID: 4215
		// (get) Token: 0x06005F3E RID: 24382
		bool IsFamilyAndAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsFamilyOrAssembly" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if access to this method is restricted to members of the class itself, members of derived classes wherever they are, and members of other classes in the same assembly; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001078 RID: 4216
		// (get) Token: 0x06005F3F RID: 24383
		bool IsFamilyOrAssembly { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsStatic" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is <see langword="static" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x17001079 RID: 4217
		// (get) Token: 0x06005F40 RID: 24384
		bool IsStatic { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsFinal" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is <see langword="final" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700107A RID: 4218
		// (get) Token: 0x06005F41 RID: 24385
		bool IsFinal { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsVirtual" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is <see langword="virtual" />; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700107B RID: 4219
		// (get) Token: 0x06005F42 RID: 24386
		bool IsVirtual { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsHideBySig" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the member is hidden by signature; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700107C RID: 4220
		// (get) Token: 0x06005F43 RID: 24387
		bool IsHideBySig { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsAbstract" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if the method is abstract; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700107D RID: 4221
		// (get) Token: 0x06005F44 RID: 24388
		bool IsAbstract { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsSpecialName" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method has a special name; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700107E RID: 4222
		// (get) Token: 0x06005F45 RID: 24389
		bool IsSpecialName { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="P:System.Reflection.MethodBase.IsConstructor" /> property.</summary>
		/// <returns>
		///   <see langword="true" /> if this method is a constructor; otherwise, <see langword="false" />.</returns>
		// Token: 0x1700107F RID: 4223
		// (get) Token: 0x06005F46 RID: 24390
		bool IsConstructor { get; }

		/// <summary>Provides COM objects with version-independent access to the <see cref="M:System.Reflection.MethodBase.Invoke(System.Object,System.Object[])" /> method.</summary>
		/// <param name="obj">The instance that created this method.</param>
		/// <param name="parameters">An argument list for the invoked method or constructor. This is an array of objects with the same number, order, and type as the parameters of the method or constructor to be invoked. If there are no parameters, <paramref name="parameters" /> should be <see langword="null" />.  
		///  If the method or constructor represented by this instance takes a <see langword="ref" /> parameter (<see langword="ByRef" /> in Visual Basic), no special attribute is required for that parameter to invoke the method or constructor using this function. Any object in this array that is not explicitly initialized with a value will contain the default value for that object type. For reference type elements, this value is <see langword="null" />. For value type elements, this value is 0, 0.0, or <see langword="false" />, depending on the specific element type.</param>
		/// <returns>An instance of the class associated with the constructor.</returns>
		// Token: 0x06005F47 RID: 24391
		object Invoke(object obj, object[] parameters);
	}
}
