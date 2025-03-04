﻿using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Edm.Expressions;
using Microsoft.Data.Edm.Internal;

namespace Microsoft.Data.Edm.Library
{
	// Token: 0x020001CD RID: 461
	public class EdmEntityContainer : EdmElement, IEdmEntityContainer, IEdmSchemaElement, IEdmNamedElement, IEdmVocabularyAnnotatable, IEdmElement
	{
		// Token: 0x06000AE2 RID: 2786 RVA: 0x000200B0 File Offset: 0x0001E2B0
		public EdmEntityContainer(string namespaceName, string name)
		{
			EdmUtil.CheckArgumentNull<string>(namespaceName, "namespaceName");
			EdmUtil.CheckArgumentNull<string>(name, "name");
			this.namespaceName = namespaceName;
			this.name = name;
		}

		// Token: 0x17000423 RID: 1059
		// (get) Token: 0x06000AE3 RID: 2787 RVA: 0x0002010A File Offset: 0x0001E30A
		public IEnumerable<IEdmEntityContainerElement> Elements
		{
			get
			{
				return this.containerElements;
			}
		}

		// Token: 0x17000424 RID: 1060
		// (get) Token: 0x06000AE4 RID: 2788 RVA: 0x00020112 File Offset: 0x0001E312
		public string Namespace
		{
			get
			{
				return this.namespaceName;
			}
		}

		// Token: 0x17000425 RID: 1061
		// (get) Token: 0x06000AE5 RID: 2789 RVA: 0x0002011A File Offset: 0x0001E31A
		public string Name
		{
			get
			{
				return this.name;
			}
		}

		// Token: 0x17000426 RID: 1062
		// (get) Token: 0x06000AE6 RID: 2790 RVA: 0x00020122 File Offset: 0x0001E322
		public EdmSchemaElementKind SchemaElementKind
		{
			get
			{
				return EdmSchemaElementKind.EntityContainer;
			}
		}

		// Token: 0x06000AE7 RID: 2791 RVA: 0x00020128 File Offset: 0x0001E328
		public void AddElement(IEdmEntityContainerElement element)
		{
			EdmUtil.CheckArgumentNull<IEdmEntityContainerElement>(element, "element");
			this.containerElements.Add(element);
			switch (element.ContainerElementKind)
			{
			case EdmContainerElementKind.None:
				throw new InvalidOperationException(Strings.EdmEntityContainer_CannotUseElementWithTypeNone);
			case EdmContainerElementKind.EntitySet:
				RegistrationHelper.AddElement<IEdmEntitySet>((IEdmEntitySet)element, element.Name, this.entitySetDictionary, new Func<IEdmEntitySet, IEdmEntitySet, IEdmEntitySet>(RegistrationHelper.CreateAmbiguousEntitySetBinding));
				return;
			case EdmContainerElementKind.FunctionImport:
				RegistrationHelper.AddFunction<IEdmFunctionImport>((IEdmFunctionImport)element, element.Name, this.functionImportDictionary);
				return;
			default:
				throw new InvalidOperationException(Strings.UnknownEnumVal_ContainerElementKind(element.ContainerElementKind));
			}
		}

		// Token: 0x06000AE8 RID: 2792 RVA: 0x000201C4 File Offset: 0x0001E3C4
		public virtual EdmEntitySet AddEntitySet(string name, IEdmEntityType elementType)
		{
			EdmEntitySet edmEntitySet = new EdmEntitySet(this, name, elementType);
			this.AddElement(edmEntitySet);
			return edmEntitySet;
		}

		// Token: 0x06000AE9 RID: 2793 RVA: 0x000201E4 File Offset: 0x0001E3E4
		public virtual EdmFunctionImport AddFunctionImport(string name, IEdmTypeReference returnType)
		{
			EdmFunctionImport edmFunctionImport = new EdmFunctionImport(this, name, returnType);
			this.AddElement(edmFunctionImport);
			return edmFunctionImport;
		}

		// Token: 0x06000AEA RID: 2794 RVA: 0x00020204 File Offset: 0x0001E404
		public virtual EdmFunctionImport AddFunctionImport(string name, IEdmTypeReference returnType, IEdmExpression entitySet)
		{
			EdmFunctionImport edmFunctionImport = new EdmFunctionImport(this, name, returnType, entitySet);
			this.AddElement(edmFunctionImport);
			return edmFunctionImport;
		}

		// Token: 0x06000AEB RID: 2795 RVA: 0x00020224 File Offset: 0x0001E424
		public virtual EdmFunctionImport AddFunctionImport(string name, IEdmTypeReference returnType, IEdmExpression entitySet, bool sideEffecting, bool composable, bool bindable)
		{
			EdmFunctionImport edmFunctionImport = new EdmFunctionImport(this, name, returnType, entitySet, sideEffecting, composable, bindable);
			this.AddElement(edmFunctionImport);
			return edmFunctionImport;
		}

		// Token: 0x06000AEC RID: 2796 RVA: 0x0002024C File Offset: 0x0001E44C
		public virtual IEdmEntitySet FindEntitySet(string setName)
		{
			IEdmEntitySet edmEntitySet;
			if (!this.entitySetDictionary.TryGetValue(setName, out edmEntitySet))
			{
				return null;
			}
			return edmEntitySet;
		}

		// Token: 0x06000AED RID: 2797 RVA: 0x0002026C File Offset: 0x0001E46C
		public IEnumerable<IEdmFunctionImport> FindFunctionImports(string functionName)
		{
			object obj;
			if (!this.functionImportDictionary.TryGetValue(functionName, out obj))
			{
				return Enumerable.Empty<IEdmFunctionImport>();
			}
			List<IEdmFunctionImport> list = obj as List<IEdmFunctionImport>;
			if (list != null)
			{
				return list;
			}
			return new IEdmFunctionImport[] { (IEdmFunctionImport)obj };
		}

		// Token: 0x04000522 RID: 1314
		private readonly string namespaceName;

		// Token: 0x04000523 RID: 1315
		private readonly string name;

		// Token: 0x04000524 RID: 1316
		private readonly List<IEdmEntityContainerElement> containerElements = new List<IEdmEntityContainerElement>();

		// Token: 0x04000525 RID: 1317
		private readonly Dictionary<string, IEdmEntitySet> entitySetDictionary = new Dictionary<string, IEdmEntitySet>();

		// Token: 0x04000526 RID: 1318
		private readonly Dictionary<string, object> functionImportDictionary = new Dictionary<string, object>();
	}
}
