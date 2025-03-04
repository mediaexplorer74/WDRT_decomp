﻿using System;

namespace Microsoft.Data.OData.Json
{
	// Token: 0x02000143 RID: 323
	internal interface IJsonWriter
	{
		// Token: 0x06000899 RID: 2201
		void StartPaddingFunctionScope();

		// Token: 0x0600089A RID: 2202
		void EndPaddingFunctionScope();

		// Token: 0x0600089B RID: 2203
		void StartObjectScope();

		// Token: 0x0600089C RID: 2204
		void EndObjectScope();

		// Token: 0x0600089D RID: 2205
		void StartArrayScope();

		// Token: 0x0600089E RID: 2206
		void EndArrayScope();

		// Token: 0x0600089F RID: 2207
		void WriteDataWrapper();

		// Token: 0x060008A0 RID: 2208
		void WriteDataArrayName();

		// Token: 0x060008A1 RID: 2209
		void WriteName(string name);

		// Token: 0x060008A2 RID: 2210
		void WritePaddingFunctionName(string functionName);

		// Token: 0x060008A3 RID: 2211
		void WriteValue(bool value);

		// Token: 0x060008A4 RID: 2212
		void WriteValue(int value);

		// Token: 0x060008A5 RID: 2213
		void WriteValue(float value);

		// Token: 0x060008A6 RID: 2214
		void WriteValue(short value);

		// Token: 0x060008A7 RID: 2215
		void WriteValue(long value);

		// Token: 0x060008A8 RID: 2216
		void WriteValue(double value);

		// Token: 0x060008A9 RID: 2217
		void WriteValue(Guid value);

		// Token: 0x060008AA RID: 2218
		void WriteValue(decimal value);

		// Token: 0x060008AB RID: 2219
		void WriteValue(DateTime value, ODataVersion odataVersion);

		// Token: 0x060008AC RID: 2220
		void WriteValue(DateTimeOffset value, ODataVersion odataVersion);

		// Token: 0x060008AD RID: 2221
		void WriteValue(TimeSpan value);

		// Token: 0x060008AE RID: 2222
		void WriteValue(byte value);

		// Token: 0x060008AF RID: 2223
		void WriteValue(sbyte value);

		// Token: 0x060008B0 RID: 2224
		void WriteValue(string value);

		// Token: 0x060008B1 RID: 2225
		void WriteRawString(string value);

		// Token: 0x060008B2 RID: 2226
		void Flush();

		// Token: 0x060008B3 RID: 2227
		void WriteValueSeparator();

		// Token: 0x060008B4 RID: 2228
		void StartScope(JsonWriter.ScopeType type);
	}
}
