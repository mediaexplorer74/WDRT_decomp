﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.Data.Edm;
using Microsoft.Data.Edm.Library;
using Microsoft.Data.OData.Metadata;
using Microsoft.Data.OData.Query.Metadata;
using Microsoft.Data.OData.Query.SemanticAst;
using Microsoft.Data.OData.Query.SyntacticAst;

namespace Microsoft.Data.OData.Query
{
	// Token: 0x0200005B RID: 91
	internal sealed class ODataPathParser
	{
		// Token: 0x06000245 RID: 581 RVA: 0x0000891A File Offset: 0x00006B1A
		internal ODataPathParser(ODataUriParserConfiguration configuration)
		{
			this.configuration = configuration;
		}

		// Token: 0x06000246 RID: 582 RVA: 0x00008940 File Offset: 0x00006B40
		internal static void ExtractSegmentIdentifierAndParenthesisExpression(string segmentText, out string identifier, out string parenthesisExpression)
		{
			int num = segmentText.IndexOf('(');
			if (num < 0)
			{
				identifier = segmentText;
				parenthesisExpression = null;
			}
			else
			{
				ExceptionUtil.ThrowSyntaxErrorIfNotValid(segmentText[segmentText.Length - 1] == ')');
				identifier = segmentText.Substring(0, num);
				parenthesisExpression = segmentText.Substring(num + 1, segmentText.Length - identifier.Length - 2);
			}
			if (identifier.Length == 0)
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_EmptySegmentInRequestUrl);
			}
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000089B4 File Offset: 0x00006BB4
		internal IList<ODataPathSegment> ParsePath(ICollection<string> segments)
		{
			using (IEnumerator<string> enumerator = segments.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					string text = enumerator.Current;
					this.segmentQueue.Enqueue(text);
				}
				goto IL_52;
			}
			IL_35:
			string text2;
			if (this.parsedSegments.Count == 0)
			{
				this.CreateFirstSegment(text2);
			}
			else
			{
				this.CreateNextSegment(text2);
			}
			IL_52:
			if (!this.TryGetNextSegmentText(out text2))
			{
				List<ODataPathSegment> list = new List<ODataPathSegment>(this.parsedSegments.Count);
				foreach (ODataPathSegment odataPathSegment in this.parsedSegments)
				{
					list.Add(odataPathSegment);
				}
				this.parsedSegments.Clear();
				return list;
			}
			goto IL_35;
		}

		// Token: 0x06000248 RID: 584 RVA: 0x00008A98 File Offset: 0x00006C98
		private static bool TryBindingParametersAndMatchingOperation(string identifier, string parenthesisExpression, IEdmType bindingType, ODataUriParserConfiguration configuration, out ICollection<OperationSegmentParameter> parsedParameters, out IEdmFunctionImport matchingFunctionImport)
		{
			matchingFunctionImport = null;
			ICollection<FunctionParameterToken> collection;
			if (!string.IsNullOrEmpty(parenthesisExpression))
			{
				if (!FunctionParameterParser.TrySplitFunctionParameters(identifier, parenthesisExpression, out collection))
				{
					IODataUriParserModelExtensions iodataUriParserModelExtensions = configuration.Model as IODataUriParserModelExtensions;
					if (iodataUriParserModelExtensions != null && configuration.Settings.UseWcfDataServicesServerBehavior)
					{
						IEdmFunctionImport edmFunctionImport = iodataUriParserModelExtensions.FindFunctionImportByBindingParameterType(bindingType, identifier, Enumerable.Empty<string>());
						if (edmFunctionImport != null)
						{
							throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_SegmentDoesNotSupportKeyPredicates(identifier));
						}
					}
					parsedParameters = null;
					return false;
				}
			}
			else
			{
				collection = new Collection<FunctionParameterToken>();
			}
			if (FunctionOverloadResolver.ResolveFunctionsFromList(identifier, collection.Select((FunctionParameterToken k) => k.ParameterName).ToList<string>(), bindingType, configuration.Model, out matchingFunctionImport) && FunctionParameterParser.TryParseFunctionParameters(collection, configuration, matchingFunctionImport, out parsedParameters))
			{
				return true;
			}
			parsedParameters = null;
			return false;
		}

		// Token: 0x06000249 RID: 585 RVA: 0x00008B50 File Offset: 0x00006D50
		private static RequestTargetKind TargetKindFromType(IEdmType type)
		{
			switch (type.TypeKind)
			{
			case EdmTypeKind.Entity:
				return RequestTargetKind.Resource;
			case EdmTypeKind.Complex:
				return RequestTargetKind.ComplexObject;
			case EdmTypeKind.Collection:
				if (type.IsEntityOrEntityCollectionType())
				{
					return RequestTargetKind.Resource;
				}
				return RequestTargetKind.Collection;
			}
			return RequestTargetKind.Primitive;
		}

		// Token: 0x0600024A RID: 586 RVA: 0x00008B90 File Offset: 0x00006D90
		private static void CheckSingleResult(bool isSingleResult, string identifier)
		{
			if (!isSingleResult)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_CannotQueryCollections(identifier));
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x00008BA1 File Offset: 0x00006DA1
		private bool TryGetNextSegmentText(out string segmentText)
		{
			return this.TryGetNextSegmentText(false, out segmentText);
		}

		// Token: 0x0600024C RID: 588 RVA: 0x00008BAC File Offset: 0x00006DAC
		private bool TryGetNextSegmentText(bool previousSegmentWasEscapeMarker, out string segmentText)
		{
			if (this.segmentQueue.Count == 0)
			{
				segmentText = null;
				return false;
			}
			segmentText = this.segmentQueue.Dequeue();
			if (segmentText == "$")
			{
				this.nextSegmentMustReferToMetadata = true;
				return this.TryGetNextSegmentText(true, out segmentText);
			}
			if (!previousSegmentWasEscapeMarker)
			{
				this.nextSegmentMustReferToMetadata = false;
			}
			if (this.parsedSegments.Count > 0)
			{
				this.ThrowIfMustBeLeafSegment(this.parsedSegments[this.parsedSegments.Count - 1]);
			}
			return true;
		}

		// Token: 0x0600024D RID: 589 RVA: 0x00008C30 File Offset: 0x00006E30
		private bool TryHandleAsKeySegment(string segmentText)
		{
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			KeySegment keySegment;
			if (!this.nextSegmentMustReferToMetadata && SegmentKeyHandler.TryHandleSegmentAsKey(segmentText, odataPathSegment, this.configuration.UrlConventions.UrlConvention, out keySegment))
			{
				this.parsedSegments.Add(keySegment);
				return true;
			}
			return false;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x00008C88 File Offset: 0x00006E88
		private void ThrowIfMustBeLeafSegment(ODataPathSegment previous)
		{
			OperationSegment operationSegment = previous as OperationSegment;
			if (operationSegment != null)
			{
				foreach (IEdmFunctionImport edmFunctionImport in operationSegment.Operations)
				{
					bool flag = this.configuration.Model.IsAction(edmFunctionImport);
					if (flag)
					{
						throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_MustBeLeafSegment(previous.Identifier));
					}
				}
			}
			if (previous.TargetKind == RequestTargetKind.Batch || previous.TargetKind == RequestTargetKind.Metadata || previous.TargetKind == RequestTargetKind.PrimitiveValue || previous.TargetKind == RequestTargetKind.VoidOperation || previous.TargetKind == RequestTargetKind.OpenPropertyValue || previous.TargetKind == RequestTargetKind.MediaResource || (previous.TargetKind == RequestTargetKind.Collection && operationSegment == null))
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_MustBeLeafSegment(previous.Identifier));
			}
		}

		// Token: 0x0600024F RID: 591 RVA: 0x00008D54 File Offset: 0x00006F54
		private bool TryCreateCountSegment(string segmentText)
		{
			string text;
			string text2;
			ODataPathParser.ExtractSegmentIdentifierAndParenthesisExpression(segmentText, out text, out text2);
			if (text != "$count")
			{
				return false;
			}
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(text2 == null || this.configuration.Settings.UseWcfDataServicesServerBehavior);
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			if (odataPathSegment.TargetKind != RequestTargetKind.Resource)
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_CountNotSupported(odataPathSegment.Identifier));
			}
			if (odataPathSegment.SingleResult)
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_CannotQuerySingletons(odataPathSegment.Identifier, "$count"));
			}
			this.parsedSegments.Add(CountSegment.Instance);
			return true;
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00008DF8 File Offset: 0x00006FF8
		private bool TryCreateLinksSegment(string text)
		{
			string text2;
			string text3;
			ODataPathParser.ExtractSegmentIdentifierAndParenthesisExpression(text, out text2, out text3);
			if (text2 != "$links")
			{
				return false;
			}
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(text3 == null);
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			if (odataPathSegment.TargetKind != RequestTargetKind.Resource)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.PathParser_LinksNotSupported(odataPathSegment.Identifier));
			}
			ODataPathParser.CheckSingleResult(odataPathSegment.SingleResult, odataPathSegment.Identifier);
			string text4;
			if (!this.TryGetNextSegmentText(out text4))
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_MissingSegmentAfterLink("$links"));
			}
			ODataPathParser.ExtractSegmentIdentifierAndParenthesisExpression(text4, out text2, out text3);
			IEdmProperty edmProperty;
			if (!this.TryBindProperty(text2, out edmProperty))
			{
				ExceptionUtil.ThrowIfResourceDoesNotExist(odataPathSegment.TargetEdmType.IsOpenType(), text2);
				throw ExceptionUtil.CreateBadRequestError(Strings.OpenNavigationPropertiesNotSupportedOnOpenTypes(text2));
			}
			IEdmNavigationProperty edmNavigationProperty = edmProperty as IEdmNavigationProperty;
			if (edmNavigationProperty == null)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_LinkSegmentMustBeFollowedByEntitySegment(edmProperty.Name, "$links"));
			}
			IEdmEntitySet edmEntitySet = odataPathSegment.TargetEdmEntitySet.FindNavigationTarget(edmNavigationProperty);
			if (edmEntitySet == null)
			{
				throw ExceptionUtil.CreateResourceNotFound(edmProperty.Name);
			}
			this.parsedSegments.Add(new NavigationPropertyLinkSegment(edmNavigationProperty, edmEntitySet));
			this.TryBindKeyFromParentheses(text3);
			if (this.TryGetNextSegmentText(out text4) && !this.TryHandleAsKeySegment(text4) && !this.TryCreateCountSegment(text4))
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_CannotSpecifyAfterPostLinkSegment(text4, "$links"));
			}
			if (this.TryGetNextSegmentText(out text4))
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_CannotSpecifyAfterPostLinkSegment(text4, "$links"));
			}
			return true;
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00008F60 File Offset: 0x00007160
		private void TryBindKeyFromParentheses(string parenthesesSection)
		{
			if (parenthesesSection == null)
			{
				return;
			}
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			ODataPathSegment odataPathSegment2;
			if (!SegmentKeyHandler.TryCreateKeySegmentFromParentheses(odataPathSegment, parenthesesSection, out odataPathSegment2))
			{
				return;
			}
			this.parsedSegments.Add(odataPathSegment2);
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00008FA4 File Offset: 0x000071A4
		private bool TryCreateValueSegment(string text)
		{
			string text2;
			string text3;
			ODataPathParser.ExtractSegmentIdentifierAndParenthesisExpression(text, out text2, out text3);
			if (text2 != "$value")
			{
				return false;
			}
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(text3 == null);
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			ODataPathSegment odataPathSegment2 = new ValueSegment(odataPathSegment.EdmType);
			if (odataPathSegment.TargetKind == RequestTargetKind.Primitive)
			{
				odataPathSegment2.CopyValuesFrom(odataPathSegment);
			}
			else
			{
				odataPathSegment2.TargetEdmType = odataPathSegment.TargetEdmType;
			}
			odataPathSegment2.Identifier = "$value";
			odataPathSegment2.SingleResult = true;
			ODataPathParser.CheckSingleResult(odataPathSegment.SingleResult, odataPathSegment.Identifier);
			if (odataPathSegment.TargetKind == RequestTargetKind.Primitive)
			{
				odataPathSegment2.TargetKind = RequestTargetKind.PrimitiveValue;
				if (odataPathSegment.TargetEdmType.IsSpatial())
				{
					throw ExceptionUtil.CreateBadRequestError(Strings.BadRequest_ValuesCannotBeReturnedForSpatialTypes);
				}
			}
			else if (odataPathSegment.TargetKind == RequestTargetKind.OpenProperty)
			{
				odataPathSegment2.TargetKind = RequestTargetKind.OpenPropertyValue;
			}
			else
			{
				odataPathSegment2.TargetKind = RequestTargetKind.MediaResource;
			}
			this.parsedSegments.Add(odataPathSegment2);
			return true;
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0000908C File Offset: 0x0000728C
		private void CreateOpenPropertySegment(ODataPathSegment previous, string identifier, string parenthesisExpression)
		{
			ODataPathSegment odataPathSegment = new OpenPropertySegment(identifier);
			if (previous.TargetEdmType != null)
			{
				ExceptionUtil.ThrowIfResourceDoesNotExist(previous.TargetEdmType.IsOpenType(), odataPathSegment.Identifier);
			}
			if (parenthesisExpression != null)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.OpenNavigationPropertiesNotSupportedOnOpenTypes(odataPathSegment.Identifier));
			}
			this.parsedSegments.Add(odataPathSegment);
		}

		// Token: 0x06000254 RID: 596 RVA: 0x000090E0 File Offset: 0x000072E0
		private void CreateNamedStreamSegment(ODataPathSegment previous, IEdmProperty streamProperty)
		{
			ODataPathSegment odataPathSegment = new PropertySegment((IEdmStructuralProperty)streamProperty);
			odataPathSegment.TargetKind = RequestTargetKind.MediaResource;
			odataPathSegment.SingleResult = true;
			odataPathSegment.TargetEdmType = previous.TargetEdmType;
			this.parsedSegments.Add(odataPathSegment);
		}

		// Token: 0x06000255 RID: 597 RVA: 0x00009120 File Offset: 0x00007320
		private void CreateFirstSegment(string segmentText)
		{
			string text;
			string text2;
			ODataPathParser.ExtractSegmentIdentifierAndParenthesisExpression(segmentText, out text, out text2);
			if (text == "$metadata")
			{
				ExceptionUtil.ThrowSyntaxErrorIfNotValid(text2 == null);
				this.parsedSegments.Add(MetadataSegment.Instance);
				return;
			}
			if (text == "$batch")
			{
				ExceptionUtil.ThrowSyntaxErrorIfNotValid(text2 == null);
				this.parsedSegments.Add(BatchSegment.Instance);
				return;
			}
			if (text == "$count")
			{
				throw ExceptionUtil.CreateResourceNotFound(Strings.RequestUriProcessor_CountOnRoot);
			}
			if (this.TryCreateSegmentForServiceOperation(text, text2))
			{
				return;
			}
			if (this.configuration.BatchReferenceCallback != null && ODataPathParser.ContentIdRegex.IsMatch(text))
			{
				ExceptionUtil.ThrowSyntaxErrorIfNotValid(text2 == null);
				BatchReferenceSegment batchReferenceSegment = this.configuration.BatchReferenceCallback(text);
				if (batchReferenceSegment != null)
				{
					this.parsedSegments.Add(batchReferenceSegment);
					return;
				}
			}
			IODataUriParserModelExtensions iodataUriParserModelExtensions = this.configuration.Model as IODataUriParserModelExtensions;
			IEdmEntitySet edmEntitySet;
			if (iodataUriParserModelExtensions != null)
			{
				edmEntitySet = iodataUriParserModelExtensions.FindEntitySetFromContainerQualifiedName(text);
			}
			else
			{
				edmEntitySet = this.configuration.Model.ResolveEntitySet(text);
			}
			if (edmEntitySet != null)
			{
				ODataPathSegment odataPathSegment = new EntitySetSegment(edmEntitySet)
				{
					Identifier = text
				};
				this.parsedSegments.Add(odataPathSegment);
				this.TryBindKeyFromParentheses(text2);
				return;
			}
			ExceptionUtil.ThrowIfResourceDoesNotExist(this.TryCreateSegmentForOperation(null, text, text2), text);
		}

		// Token: 0x06000256 RID: 598 RVA: 0x00009270 File Offset: 0x00007470
		private bool TryCreateSegmentForServiceOperation(string identifier, string queryPortion)
		{
			IODataUriParserModelExtensions iodataUriParserModelExtensions = this.configuration.Model as IODataUriParserModelExtensions;
			IEdmFunctionImport edmFunctionImport;
			if (iodataUriParserModelExtensions == null)
			{
				List<IEdmFunctionImport> list = (from f in this.configuration.Model.ResolveFunctionImports(identifier)
					where this.configuration.Model.IsServiceOperation(f)
					select f).ToList<IEdmFunctionImport>();
				if (list.Count == 0)
				{
					return false;
				}
				if (list.Count != 1)
				{
					throw ExceptionUtil.CreateBadRequestError(Strings.PathParser_ServiceOperationsWithSameName(identifier));
				}
				edmFunctionImport = list.Single<IEdmFunctionImport>();
			}
			else
			{
				edmFunctionImport = iodataUriParserModelExtensions.FindServiceOperation(identifier);
				if (edmFunctionImport == null)
				{
					return false;
				}
			}
			IEdmEntitySet targetEntitySet = edmFunctionImport.GetTargetEntitySet(null, this.configuration.Model);
			if (targetEntitySet == null && edmFunctionImport.ReturnType != null && edmFunctionImport.ReturnType.Definition.IsEntityOrEntityCollectionType())
			{
				throw new ODataException(Strings.RequestUriProcessor_EntitySetNotSpecified(edmFunctionImport.Name));
			}
			ODataPathSegment odataPathSegment = new OperationSegment(edmFunctionImport, targetEntitySet)
			{
				Identifier = identifier
			};
			odataPathSegment.TargetEdmEntitySet = targetEntitySet;
			if (edmFunctionImport.ReturnType != null)
			{
				odataPathSegment.TargetEdmType = edmFunctionImport.ReturnType.Definition;
				odataPathSegment.TargetKind = ODataPathParser.TargetKindFromType(odataPathSegment.TargetEdmType);
				odataPathSegment.SingleResult = !edmFunctionImport.ReturnType.IsCollection();
				if (odataPathSegment.SingleResult && !string.IsNullOrEmpty(queryPortion))
				{
					throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_SegmentDoesNotSupportKeyPredicates(odataPathSegment.Identifier));
				}
				this.parsedSegments.Add(odataPathSegment);
				if (!string.IsNullOrEmpty(queryPortion))
				{
					this.TryBindKeyFromParentheses(queryPortion);
				}
			}
			else
			{
				if (!string.IsNullOrEmpty(queryPortion) && !this.configuration.Settings.UseWcfDataServicesServerBehavior)
				{
					throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_SegmentDoesNotSupportKeyPredicates(odataPathSegment.Identifier));
				}
				odataPathSegment.TargetEdmType = null;
				odataPathSegment.TargetKind = RequestTargetKind.VoidOperation;
				this.parsedSegments.Add(odataPathSegment);
			}
			return true;
		}

		// Token: 0x06000257 RID: 599 RVA: 0x00009424 File Offset: 0x00007624
		private bool TryCreateSegmentForOperation(ODataPathSegment previousSegment, string identifier, string parenthesisExpression)
		{
			IEdmType edmType = ((previousSegment == null) ? null : previousSegment.EdmType);
			ICollection<OperationSegmentParameter> collection;
			IEdmFunctionImport edmFunctionImport;
			if (!ODataPathParser.TryBindingParametersAndMatchingOperation(identifier, parenthesisExpression, edmType, this.configuration, out collection, out edmFunctionImport))
			{
				return false;
			}
			if (!UriEdmHelpers.IsBindingTypeValid(edmType))
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_OperationSegmentBoundToANonEntityType);
			}
			if (previousSegment != null && edmType == null)
			{
				throw new ODataException(Strings.FunctionCallBinder_CallingFunctionOnOpenProperty(identifier));
			}
			IEdmTypeReference returnType = edmFunctionImport.ReturnType;
			IEdmEntitySet edmEntitySet = null;
			if (returnType != null)
			{
				IEdmEntitySet edmEntitySet2 = ((previousSegment == null) ? null : previousSegment.TargetEdmEntitySet);
				edmEntitySet = edmFunctionImport.GetTargetEntitySet(edmEntitySet2, this.configuration.Model);
			}
			if (previousSegment is BatchReferenceSegment)
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_BatchedActionOnEntityCreatedInSameChangeset(identifier));
			}
			ODataPathSegment odataPathSegment = new OperationSegment(new IEdmFunctionImport[] { edmFunctionImport }, collection, edmEntitySet)
			{
				Identifier = identifier
			};
			if (returnType != null)
			{
				odataPathSegment.TargetEdmEntitySet = edmEntitySet;
				odataPathSegment.TargetEdmType = returnType.Definition;
				odataPathSegment.TargetKind = ODataPathParser.TargetKindFromType(odataPathSegment.TargetEdmType);
				if (odataPathSegment.TargetEdmType.IsEntityOrEntityCollectionType() && odataPathSegment.TargetEdmEntitySet == null)
				{
					throw new ODataException(Strings.RequestUriProcessor_EntitySetNotSpecified(identifier));
				}
				odataPathSegment.SingleResult = !edmFunctionImport.ReturnType.IsCollection();
			}
			else
			{
				odataPathSegment.TargetEdmEntitySet = null;
				odataPathSegment.TargetEdmType = null;
				odataPathSegment.TargetKind = RequestTargetKind.VoidOperation;
			}
			this.parsedSegments.Add(odataPathSegment);
			return true;
		}

		// Token: 0x06000258 RID: 600 RVA: 0x00009570 File Offset: 0x00007770
		private void CreateNextSegment(string text)
		{
			if (this.TryHandleAsKeySegment(text))
			{
				return;
			}
			if (this.TryCreateValueSegment(text))
			{
				return;
			}
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			if (odataPathSegment.TargetKind == RequestTargetKind.Primitive)
			{
				throw ExceptionUtil.ResourceNotFoundError(Strings.RequestUriProcessor_ValueSegmentAfterScalarPropertySegment(odataPathSegment.Identifier, text));
			}
			if (this.TryCreateLinksSegment(text))
			{
				return;
			}
			if (this.TryCreateCountSegment(text))
			{
				return;
			}
			string text2;
			string text3;
			ODataPathParser.ExtractSegmentIdentifierAndParenthesisExpression(text, out text2, out text3);
			IEdmProperty edmProperty;
			if (odataPathSegment.SingleResult && odataPathSegment.TargetEdmType != null && this.TryBindProperty(text2, out edmProperty))
			{
				ODataPathParser.CheckSingleResult(odataPathSegment.SingleResult, odataPathSegment.Identifier);
				this.CreatePropertySegment(odataPathSegment, edmProperty, text3);
				return;
			}
			if (this.TryCreateTypeNameSegment(odataPathSegment, text2, text3))
			{
				return;
			}
			if (this.TryCreateSegmentForOperation(odataPathSegment, text2, text3))
			{
				return;
			}
			ODataPathParser.CheckSingleResult(odataPathSegment.SingleResult, odataPathSegment.Identifier);
			this.CreateOpenPropertySegment(odataPathSegment, text2, text3);
		}

		// Token: 0x06000259 RID: 601 RVA: 0x0000964C File Offset: 0x0000784C
		private bool TryBindProperty(string identifier, out IEdmProperty projectedProperty)
		{
			ODataPathSegment odataPathSegment = this.parsedSegments[this.parsedSegments.Count - 1];
			projectedProperty = null;
			IEdmStructuredType edmStructuredType = odataPathSegment.TargetEdmType as IEdmStructuredType;
			if (edmStructuredType == null)
			{
				IEdmCollectionType edmCollectionType = odataPathSegment.TargetEdmType as IEdmCollectionType;
				if (edmCollectionType != null)
				{
					edmStructuredType = edmCollectionType.ElementType.Definition as IEdmStructuredType;
				}
			}
			if (edmStructuredType == null)
			{
				return false;
			}
			projectedProperty = edmStructuredType.FindProperty(identifier);
			return projectedProperty != null;
		}

		// Token: 0x0600025A RID: 602 RVA: 0x000096BC File Offset: 0x000078BC
		private bool TryCreateTypeNameSegment(ODataPathSegment previous, string identifier, string parenthesisExpression)
		{
			IEdmType edmType;
			if (previous.TargetEdmType == null || (edmType = this.configuration.Model.FindType(identifier)) == null)
			{
				return false;
			}
			IEdmType edmType2 = previous.TargetEdmType;
			if (edmType2.TypeKind == EdmTypeKind.Collection)
			{
				edmType2 = ((IEdmCollectionType)edmType2).ElementType.Definition;
			}
			if (!edmType.IsOrInheritsFrom(edmType2) && !edmType2.IsOrInheritsFrom(edmType))
			{
				throw ExceptionUtil.CreateBadRequestError(Strings.RequestUriProcessor_InvalidTypeIdentifier_UnrelatedType(edmType.ODataFullName(), edmType2.ODataFullName()));
			}
			IEdmType edmType3 = edmType;
			if (previous.EdmType.TypeKind == EdmTypeKind.Collection)
			{
				edmType3 = new EdmCollectionType(new EdmEntityTypeReference((IEdmEntityType)edmType3, false));
			}
			ODataPathSegment odataPathSegment = new TypeSegment(edmType3, previous.TargetEdmEntitySet)
			{
				Identifier = identifier,
				TargetKind = previous.TargetKind,
				SingleResult = previous.SingleResult,
				TargetEdmType = edmType
			};
			this.parsedSegments.Add(odataPathSegment);
			this.TryBindKeyFromParentheses(parenthesisExpression);
			return true;
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000097A4 File Offset: 0x000079A4
		private void CreatePropertySegment(ODataPathSegment previous, IEdmProperty property, string queryPortion)
		{
			if (property.Type.IsStream())
			{
				ExceptionUtil.ThrowSyntaxErrorIfNotValid(queryPortion == null || this.configuration.Settings.UseWcfDataServicesServerBehavior);
				this.CreateNamedStreamSegment(previous, property);
				return;
			}
			ODataPathSegment odataPathSegment;
			if (property.PropertyKind == EdmPropertyKind.Navigation)
			{
				IEdmNavigationProperty edmNavigationProperty = (IEdmNavigationProperty)property;
				IEdmEntitySet edmEntitySet = previous.TargetEdmEntitySet.FindNavigationTarget(edmNavigationProperty);
				if (edmEntitySet == null)
				{
					throw new ODataException(Strings.RequestUriProcessor_TargetEntitySetNotFound(property.Name));
				}
				odataPathSegment = new NavigationPropertySegment(edmNavigationProperty, edmEntitySet);
			}
			else
			{
				odataPathSegment = new PropertySegment((IEdmStructuralProperty)property);
				switch (property.Type.TypeKind())
				{
				case EdmTypeKind.Complex:
					odataPathSegment.TargetKind = RequestTargetKind.ComplexObject;
					goto IL_B6;
				case EdmTypeKind.Collection:
					odataPathSegment.TargetKind = RequestTargetKind.Collection;
					goto IL_B6;
				}
				odataPathSegment.TargetKind = RequestTargetKind.Primitive;
			}
			IL_B6:
			this.parsedSegments.Add(odataPathSegment);
			ExceptionUtil.ThrowSyntaxErrorIfNotValid(queryPortion == null || (property.Type.IsCollection() && property.Type.AsCollection().ElementType().IsEntity()));
			this.TryBindKeyFromParentheses(queryPortion);
		}

		// Token: 0x0400009A RID: 154
		internal static readonly Regex ContentIdRegex = new Regex("^\\$[0-9]+$", RegexOptions.Compiled | RegexOptions.Singleline);

		// Token: 0x0400009B RID: 155
		private readonly Queue<string> segmentQueue = new Queue<string>();

		// Token: 0x0400009C RID: 156
		private readonly List<ODataPathSegment> parsedSegments = new List<ODataPathSegment>();

		// Token: 0x0400009D RID: 157
		private readonly ODataUriParserConfiguration configuration;

		// Token: 0x0400009E RID: 158
		private bool nextSegmentMustReferToMetadata;
	}
}
