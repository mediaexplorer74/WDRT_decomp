﻿using System;
using System.Runtime.InteropServices;

namespace System.Security.Cryptography
{
	/// <summary>Computes the <see cref="T:System.Security.Cryptography.SHA256" /> hash for the input data using the managed library.</summary>
	// Token: 0x02000293 RID: 659
	[ComVisible(true)]
	public class SHA256Managed : SHA256
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Security.Cryptography.SHA256Managed" /> class using the managed library.</summary>
		/// <exception cref="T:System.InvalidOperationException">The Federal Information Processing Standards (FIPS) security setting is enabled. This implementation is not part of the Windows Platform FIPS-validated cryptographic algorithms.</exception>
		// Token: 0x06002354 RID: 9044 RVA: 0x00080624 File Offset: 0x0007E824
		public SHA256Managed()
		{
			if (CryptoConfig.AllowOnlyFipsAlgorithms && AppContextSwitches.UseLegacyFipsThrow)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Cryptography_NonCompliantFIPSAlgorithm"));
			}
			if (CryptoConfig.AllowOnlyFipsAlgorithms)
			{
				this._impl = SHA256.Create();
				return;
			}
			this._stateSHA256 = new uint[8];
			this._buffer = new byte[64];
			this._W = new uint[64];
			this.InitializeState();
		}

		/// <summary>Initializes an instance of <see cref="T:System.Security.Cryptography.SHA256Managed" />.</summary>
		// Token: 0x06002355 RID: 9045 RVA: 0x00080694 File Offset: 0x0007E894
		public override void Initialize()
		{
			if (this._impl != null)
			{
				this._impl.Initialize();
				return;
			}
			this.InitializeState();
			Array.Clear(this._buffer, 0, this._buffer.Length);
			Array.Clear(this._W, 0, this._W.Length);
		}

		/// <summary>When overridden in a derived class, routes data written to the object into the <see cref="T:System.Security.Cryptography.SHA256" /> hash algorithm for computing the hash.</summary>
		/// <param name="rgb">The input data.</param>
		/// <param name="ibStart">The offset into the byte array from which to begin using data.</param>
		/// <param name="cbSize">The number of bytes in the array to use as data.</param>
		// Token: 0x06002356 RID: 9046 RVA: 0x000806E3 File Offset: 0x0007E8E3
		protected override void HashCore(byte[] rgb, int ibStart, int cbSize)
		{
			if (this._impl != null)
			{
				this._impl.TransformBlock(rgb, ibStart, cbSize, null, 0);
				return;
			}
			this._HashData(rgb, ibStart, cbSize);
		}

		/// <summary>When overridden in a derived class, finalizes the hash computation after the last data is processed by the cryptographic stream object.</summary>
		/// <returns>The computed hash code.</returns>
		// Token: 0x06002357 RID: 9047 RVA: 0x00080708 File Offset: 0x0007E908
		protected override byte[] HashFinal()
		{
			if (this._impl != null)
			{
				this._impl.TransformFinalBlock(Array.Empty<byte>(), 0, 0);
				return this._impl.Hash;
			}
			return this._EndHash();
		}

		/// <summary>Releases unmanaged resources used by the <see cref="T:System.Security.Cryptography.SHA256Managed" /> object and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x06002358 RID: 9048 RVA: 0x00080737 File Offset: 0x0007E937
		protected override void Dispose(bool disposing)
		{
			if (disposing && this._impl != null)
			{
				this._impl.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06002359 RID: 9049 RVA: 0x00080758 File Offset: 0x0007E958
		private void InitializeState()
		{
			this._count = 0L;
			this._stateSHA256[0] = 1779033703U;
			this._stateSHA256[1] = 3144134277U;
			this._stateSHA256[2] = 1013904242U;
			this._stateSHA256[3] = 2773480762U;
			this._stateSHA256[4] = 1359893119U;
			this._stateSHA256[5] = 2600822924U;
			this._stateSHA256[6] = 528734635U;
			this._stateSHA256[7] = 1541459225U;
		}

		// Token: 0x0600235A RID: 9050 RVA: 0x000807D8 File Offset: 0x0007E9D8
		[SecuritySafeCritical]
		private unsafe void _HashData(byte[] partIn, int ibStart, int cbSize)
		{
			int i = cbSize;
			int num = ibStart;
			int num2 = (int)(this._count & 63L);
			this._count += (long)i;
			uint[] array;
			uint* ptr;
			if ((array = this._stateSHA256) == null || array.Length == 0)
			{
				ptr = null;
			}
			else
			{
				ptr = &array[0];
			}
			byte[] array2;
			byte* ptr2;
			if ((array2 = this._buffer) == null || array2.Length == 0)
			{
				ptr2 = null;
			}
			else
			{
				ptr2 = &array2[0];
			}
			uint[] array3;
			uint* ptr3;
			if ((array3 = this._W) == null || array3.Length == 0)
			{
				ptr3 = null;
			}
			else
			{
				ptr3 = &array3[0];
			}
			if (num2 > 0 && num2 + i >= 64)
			{
				Buffer.InternalBlockCopy(partIn, num, this._buffer, num2, 64 - num2);
				num += 64 - num2;
				i -= 64 - num2;
				SHA256Managed.SHATransform(ptr3, ptr, ptr2);
				num2 = 0;
			}
			while (i >= 64)
			{
				Buffer.InternalBlockCopy(partIn, num, this._buffer, 0, 64);
				num += 64;
				i -= 64;
				SHA256Managed.SHATransform(ptr3, ptr, ptr2);
			}
			if (i > 0)
			{
				Buffer.InternalBlockCopy(partIn, num, this._buffer, num2, i);
			}
			array3 = null;
			array2 = null;
			array = null;
		}

		// Token: 0x0600235B RID: 9051 RVA: 0x000808E8 File Offset: 0x0007EAE8
		private byte[] _EndHash()
		{
			byte[] array = new byte[32];
			int num = 64 - (int)(this._count & 63L);
			if (num <= 8)
			{
				num += 64;
			}
			byte[] array2 = new byte[num];
			array2[0] = 128;
			long num2 = this._count * 8L;
			array2[num - 8] = (byte)((num2 >> 56) & 255L);
			array2[num - 7] = (byte)((num2 >> 48) & 255L);
			array2[num - 6] = (byte)((num2 >> 40) & 255L);
			array2[num - 5] = (byte)((num2 >> 32) & 255L);
			array2[num - 4] = (byte)((num2 >> 24) & 255L);
			array2[num - 3] = (byte)((num2 >> 16) & 255L);
			array2[num - 2] = (byte)((num2 >> 8) & 255L);
			array2[num - 1] = (byte)(num2 & 255L);
			this._HashData(array2, 0, array2.Length);
			Utils.DWORDToBigEndian(array, this._stateSHA256, 8);
			this.HashValue = array;
			return array;
		}

		// Token: 0x0600235C RID: 9052 RVA: 0x000809D4 File Offset: 0x0007EBD4
		[SecurityCritical]
		private unsafe static void SHATransform(uint* expandedBuffer, uint* state, byte* block)
		{
			uint num = *state;
			uint num2 = state[1];
			uint num3 = state[2];
			uint num4 = state[3];
			uint num5 = state[4];
			uint num6 = state[5];
			uint num7 = state[6];
			uint num8 = state[7];
			Utils.DWORDFromBigEndian(expandedBuffer, 16, block);
			SHA256Managed.SHA256Expand(expandedBuffer);
			for (int i = 0; i < 64; i++)
			{
				uint num9 = num8 + SHA256Managed.Sigma_1(num5) + SHA256Managed.Ch(num5, num6, num7) + SHA256Managed._K[i] + expandedBuffer[i];
				uint num10 = num4 + num9;
				uint num11 = num9 + SHA256Managed.Sigma_0(num) + SHA256Managed.Maj(num, num2, num3);
				i++;
				num9 = num7 + SHA256Managed.Sigma_1(num10) + SHA256Managed.Ch(num10, num5, num6) + SHA256Managed._K[i] + expandedBuffer[i];
				uint num12 = num3 + num9;
				uint num13 = num9 + SHA256Managed.Sigma_0(num11) + SHA256Managed.Maj(num11, num, num2);
				i++;
				num9 = num6 + SHA256Managed.Sigma_1(num12) + SHA256Managed.Ch(num12, num10, num5) + SHA256Managed._K[i] + expandedBuffer[i];
				uint num14 = num2 + num9;
				uint num15 = num9 + SHA256Managed.Sigma_0(num13) + SHA256Managed.Maj(num13, num11, num);
				i++;
				num9 = num5 + SHA256Managed.Sigma_1(num14) + SHA256Managed.Ch(num14, num12, num10) + SHA256Managed._K[i] + expandedBuffer[i];
				uint num16 = num + num9;
				uint num17 = num9 + SHA256Managed.Sigma_0(num15) + SHA256Managed.Maj(num15, num13, num11);
				i++;
				num9 = num10 + SHA256Managed.Sigma_1(num16) + SHA256Managed.Ch(num16, num14, num12) + SHA256Managed._K[i] + expandedBuffer[i];
				num8 = num11 + num9;
				num4 = num9 + SHA256Managed.Sigma_0(num17) + SHA256Managed.Maj(num17, num15, num13);
				i++;
				num9 = num12 + SHA256Managed.Sigma_1(num8) + SHA256Managed.Ch(num8, num16, num14) + SHA256Managed._K[i] + expandedBuffer[i];
				num7 = num13 + num9;
				num3 = num9 + SHA256Managed.Sigma_0(num4) + SHA256Managed.Maj(num4, num17, num15);
				i++;
				num9 = num14 + SHA256Managed.Sigma_1(num7) + SHA256Managed.Ch(num7, num8, num16) + SHA256Managed._K[i] + expandedBuffer[i];
				num6 = num15 + num9;
				num2 = num9 + SHA256Managed.Sigma_0(num3) + SHA256Managed.Maj(num3, num4, num17);
				i++;
				num9 = num16 + SHA256Managed.Sigma_1(num6) + SHA256Managed.Ch(num6, num7, num8) + SHA256Managed._K[i] + expandedBuffer[i];
				num5 = num17 + num9;
				num = num9 + SHA256Managed.Sigma_0(num2) + SHA256Managed.Maj(num2, num3, num4);
			}
			*state += num;
			state[1] += num2;
			state[2] += num3;
			state[3] += num4;
			state[4] += num5;
			state[5] += num6;
			state[6] += num7;
			state[7] += num8;
		}

		// Token: 0x0600235D RID: 9053 RVA: 0x00080CF1 File Offset: 0x0007EEF1
		private static uint RotateRight(uint x, int n)
		{
			return (x >> n) | (x << 32 - n);
		}

		// Token: 0x0600235E RID: 9054 RVA: 0x00080D03 File Offset: 0x0007EF03
		private static uint Ch(uint x, uint y, uint z)
		{
			return (x & y) ^ ((x ^ uint.MaxValue) & z);
		}

		// Token: 0x0600235F RID: 9055 RVA: 0x00080D0E File Offset: 0x0007EF0E
		private static uint Maj(uint x, uint y, uint z)
		{
			return (x & y) ^ (x & z) ^ (y & z);
		}

		// Token: 0x06002360 RID: 9056 RVA: 0x00080D1B File Offset: 0x0007EF1B
		private static uint sigma_0(uint x)
		{
			return SHA256Managed.RotateRight(x, 7) ^ SHA256Managed.RotateRight(x, 18) ^ (x >> 3);
		}

		// Token: 0x06002361 RID: 9057 RVA: 0x00080D31 File Offset: 0x0007EF31
		private static uint sigma_1(uint x)
		{
			return SHA256Managed.RotateRight(x, 17) ^ SHA256Managed.RotateRight(x, 19) ^ (x >> 10);
		}

		// Token: 0x06002362 RID: 9058 RVA: 0x00080D49 File Offset: 0x0007EF49
		private static uint Sigma_0(uint x)
		{
			return SHA256Managed.RotateRight(x, 2) ^ SHA256Managed.RotateRight(x, 13) ^ SHA256Managed.RotateRight(x, 22);
		}

		// Token: 0x06002363 RID: 9059 RVA: 0x00080D64 File Offset: 0x0007EF64
		private static uint Sigma_1(uint x)
		{
			return SHA256Managed.RotateRight(x, 6) ^ SHA256Managed.RotateRight(x, 11) ^ SHA256Managed.RotateRight(x, 25);
		}

		// Token: 0x06002364 RID: 9060 RVA: 0x00080D80 File Offset: 0x0007EF80
		[SecurityCritical]
		private unsafe static void SHA256Expand(uint* x)
		{
			for (int i = 16; i < 64; i++)
			{
				x[i] = SHA256Managed.sigma_1(x[i - 2]) + x[i - 7] + SHA256Managed.sigma_0(x[i - 15]) + x[i - 16];
			}
		}

		// Token: 0x04000CE0 RID: 3296
		private SHA256 _impl;

		// Token: 0x04000CE1 RID: 3297
		private byte[] _buffer;

		// Token: 0x04000CE2 RID: 3298
		private long _count;

		// Token: 0x04000CE3 RID: 3299
		private uint[] _stateSHA256;

		// Token: 0x04000CE4 RID: 3300
		private uint[] _W;

		// Token: 0x04000CE5 RID: 3301
		private static readonly uint[] _K = new uint[]
		{
			1116352408U, 1899447441U, 3049323471U, 3921009573U, 961987163U, 1508970993U, 2453635748U, 2870763221U, 3624381080U, 310598401U,
			607225278U, 1426881987U, 1925078388U, 2162078206U, 2614888103U, 3248222580U, 3835390401U, 4022224774U, 264347078U, 604807628U,
			770255983U, 1249150122U, 1555081692U, 1996064986U, 2554220882U, 2821834349U, 2952996808U, 3210313671U, 3336571891U, 3584528711U,
			113926993U, 338241895U, 666307205U, 773529912U, 1294757372U, 1396182291U, 1695183700U, 1986661051U, 2177026350U, 2456956037U,
			2730485921U, 2820302411U, 3259730800U, 3345764771U, 3516065817U, 3600352804U, 4094571909U, 275423344U, 430227734U, 506948616U,
			659060556U, 883997877U, 958139571U, 1322822218U, 1537002063U, 1747873779U, 1955562222U, 2024104815U, 2227730452U, 2361852424U,
			2428436474U, 2756734187U, 3204031479U, 3329325298U
		};
	}
}
