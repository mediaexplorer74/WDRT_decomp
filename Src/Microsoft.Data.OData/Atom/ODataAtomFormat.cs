﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.Edm;

namespace Microsoft.Data.OData.Atom
{
	// Token: 0x020000F9 RID: 249
	internal sealed class ODataAtomFormat : ODataFormat
	{
		// Token: 0x06000660 RID: 1632 RVA: 0x000171AC File Offset: 0x000153AC
		public override string ToString()
		{
			return "Atom";
		}

		// Token: 0x06000661 RID: 1633 RVA: 0x000171B4 File Offset: 0x000153B4
		internal override IEnumerable<ODataPayloadKind> DetectPayloadKind(IODataResponseMessage responseMessage, ODataPayloadKindDetectionInfo detectionInfo)
		{
			ExceptionUtils.CheckArgumentNotNull<IODataResponseMessage>(responseMessage, "responseMessage");
			ExceptionUtils.CheckArgumentNotNull<ODataPayloadKindDetectionInfo>(detectionInfo, "detectionInfo");
			Stream stream = ((ODataMessage)responseMessage).GetStream();
			return this.DetectPayloadKindImplementation(stream, true, true, detectionInfo);
		}

		// Token: 0x06000662 RID: 1634 RVA: 0x000171F0 File Offset: 0x000153F0
		internal override IEnumerable<ODataPayloadKind> DetectPayloadKind(IODataRequestMessage requestMessage, ODataPayloadKindDetectionInfo detectionInfo)
		{
			ExceptionUtils.CheckArgumentNotNull<IODataRequestMessage>(requestMessage, "requestMessage");
			ExceptionUtils.CheckArgumentNotNull<ODataPayloadKindDetectionInfo>(detectionInfo, "detectionInfo");
			Stream stream = ((ODataMessage)requestMessage).GetStream();
			return this.DetectPayloadKindImplementation(stream, false, true, detectionInfo);
		}

		// Token: 0x06000663 RID: 1635 RVA: 0x0001722C File Offset: 0x0001542C
		internal override ODataInputContext CreateInputContext(ODataPayloadKind readerPayloadKind, ODataMessage message, MediaType contentType, Encoding encoding, ODataMessageReaderSettings messageReaderSettings, ODataVersion version, bool readingResponse, IEdmModel model, IODataUrlResolver urlResolver, object payloadKindDetectionFormatState)
		{
			ExceptionUtils.CheckArgumentNotNull<ODataMessage>(message, "message");
			ExceptionUtils.CheckArgumentNotNull<ODataMessageReaderSettings>(messageReaderSettings, "messageReaderSettings");
			Stream stream = message.GetStream();
			return new ODataAtomInputContext(this, stream, encoding, messageReaderSettings, version, readingResponse, true, model, urlResolver);
		}

		// Token: 0x06000664 RID: 1636 RVA: 0x0001726C File Offset: 0x0001546C
		internal override ODataOutputContext CreateOutputContext(ODataMessage message, MediaType mediaType, Encoding encoding, ODataMessageWriterSettings messageWriterSettings, bool writingResponse, IEdmModel model, IODataUrlResolver urlResolver)
		{
			ExceptionUtils.CheckArgumentNotNull<ODataMessage>(message, "message");
			ExceptionUtils.CheckArgumentNotNull<ODataMessageWriterSettings>(messageWriterSettings, "messageWriterSettings");
			Stream stream = message.GetStream();
			return new ODataAtomOutputContext(this, stream, encoding, messageWriterSettings, writingResponse, true, model, urlResolver);
		}

		// Token: 0x06000665 RID: 1637 RVA: 0x000172CC File Offset: 0x000154CC
		internal override Task<IEnumerable<ODataPayloadKind>> DetectPayloadKindAsync(IODataResponseMessageAsync responseMessage, ODataPayloadKindDetectionInfo detectionInfo)
		{
			ExceptionUtils.CheckArgumentNotNull<IODataResponseMessageAsync>(responseMessage, "responseMessage");
			ExceptionUtils.CheckArgumentNotNull<ODataPayloadKindDetectionInfo>(detectionInfo, "detectionInfo");
			return ((ODataMessage)responseMessage).GetStreamAsync().FollowOnSuccessWith((Task<Stream> streamTask) => this.DetectPayloadKindImplementation(streamTask.Result, true, false, detectionInfo));
		}

		// Token: 0x06000666 RID: 1638 RVA: 0x00017348 File Offset: 0x00015548
		internal override Task<IEnumerable<ODataPayloadKind>> DetectPayloadKindAsync(IODataRequestMessageAsync requestMessage, ODataPayloadKindDetectionInfo detectionInfo)
		{
			ExceptionUtils.CheckArgumentNotNull<IODataRequestMessageAsync>(requestMessage, "requestMessage");
			ExceptionUtils.CheckArgumentNotNull<ODataPayloadKindDetectionInfo>(detectionInfo, "detectionInfo");
			return ((ODataMessage)requestMessage).GetStreamAsync().FollowOnSuccessWith((Task<Stream> streamTask) => this.DetectPayloadKindImplementation(streamTask.Result, false, false, detectionInfo));
		}

		// Token: 0x06000667 RID: 1639 RVA: 0x000173EC File Offset: 0x000155EC
		internal override Task<ODataInputContext> CreateInputContextAsync(ODataPayloadKind readerPayloadKind, ODataMessage message, MediaType contentType, Encoding encoding, ODataMessageReaderSettings messageReaderSettings, ODataVersion version, bool readingResponse, IEdmModel model, IODataUrlResolver urlResolver, object payloadKindDetectionFormatState)
		{
			ExceptionUtils.CheckArgumentNotNull<ODataMessage>(message, "message");
			ExceptionUtils.CheckArgumentNotNull<ODataMessageReaderSettings>(messageReaderSettings, "messageReaderSettings");
			return message.GetStreamAsync().FollowOnSuccessWith((Task<Stream> streamTask) => new ODataAtomInputContext(this, streamTask.Result, encoding, messageReaderSettings, version, readingResponse, false, model, urlResolver));
		}

		// Token: 0x06000668 RID: 1640 RVA: 0x000174A4 File Offset: 0x000156A4
		internal override Task<ODataOutputContext> CreateOutputContextAsync(ODataMessage message, MediaType mediaType, Encoding encoding, ODataMessageWriterSettings messageWriterSettings, bool writingResponse, IEdmModel model, IODataUrlResolver urlResolver)
		{
			ExceptionUtils.CheckArgumentNotNull<ODataMessage>(message, "message");
			ExceptionUtils.CheckArgumentNotNull<ODataMessageWriterSettings>(messageWriterSettings, "messageWriterSettings");
			return message.GetStreamAsync().FollowOnSuccessWith((Task<Stream> streamTask) => new ODataAtomOutputContext(this, streamTask.Result, encoding, messageWriterSettings, writingResponse, false, model, urlResolver));
		}

		// Token: 0x06000669 RID: 1641 RVA: 0x00017518 File Offset: 0x00015718
		private IEnumerable<ODataPayloadKind> DetectPayloadKindImplementation(Stream messageStream, bool readingResponse, bool synchronous, ODataPayloadKindDetectionInfo detectionInfo)
		{
			IEnumerable<ODataPayloadKind> enumerable;
			using (ODataAtomInputContext odataAtomInputContext = new ODataAtomInputContext(this, messageStream, detectionInfo.GetEncoding(), detectionInfo.MessageReaderSettings, ODataVersion.V3, readingResponse, synchronous, detectionInfo.Model, null))
			{
				enumerable = odataAtomInputContext.DetectPayloadKind(detectionInfo);
			}
			return enumerable;
		}
	}
}
