﻿using System;
using System.ComponentModel;
using System.Runtime.InteropServices;

namespace System.Management
{
	/// <summary>Represents a scope (namespace) for management operations.</summary>
	// Token: 0x02000040 RID: 64
	[TypeConverter(typeof(ManagementScopeConverter))]
	public class ManagementScope : ICloneable
	{
		// Token: 0x1400000C RID: 12
		// (add) Token: 0x06000244 RID: 580 RVA: 0x0000CAD8 File Offset: 0x0000ACD8
		// (remove) Token: 0x06000245 RID: 581 RVA: 0x0000CB10 File Offset: 0x0000AD10
		internal event IdentifierChangedEventHandler IdentifierChanged;

		// Token: 0x06000246 RID: 582
		[DllImport("rpcrt4.dll")]
		private static extern int RpcMgmtEnableIdleCleanup();

		// Token: 0x06000247 RID: 583 RVA: 0x0000CB45 File Offset: 0x0000AD45
		private void FireIdentifierChanged()
		{
			if (this.IdentifierChanged != null)
			{
				this.IdentifierChanged(this, null);
			}
		}

		// Token: 0x06000248 RID: 584 RVA: 0x0000CB5C File Offset: 0x0000AD5C
		private void HandleIdentifierChange(object sender, IdentifierChangedEventArgs args)
		{
			this.wbemServices = null;
			this.FireIdentifierChanged();
		}

		// Token: 0x17000072 RID: 114
		// (get) Token: 0x06000249 RID: 585 RVA: 0x0000CB6B File Offset: 0x0000AD6B
		// (set) Token: 0x0600024A RID: 586 RVA: 0x0000CB74 File Offset: 0x0000AD74
		private ManagementPath prvpath
		{
			get
			{
				return this.validatedPath;
			}
			set
			{
				if (value != null)
				{
					string path = value.Path;
					if (!ManagementPath.IsValidNamespaceSyntax(path))
					{
						ManagementException.ThrowWithExtendedInfo(ManagementStatus.InvalidNamespace);
					}
				}
				this.validatedPath = value;
			}
		}

		// Token: 0x0600024B RID: 587 RVA: 0x0000CBA4 File Offset: 0x0000ADA4
		internal IWbemServices GetIWbemServices()
		{
			IWbemServices wbemServices = this.wbemServices;
			if (CompatSwitches.AllowIManagementObjectQI)
			{
				IntPtr iunknownForObject = Marshal.GetIUnknownForObject(this.wbemServices);
				object objectForIUnknown = Marshal.GetObjectForIUnknown(iunknownForObject);
				Marshal.Release(iunknownForObject);
				if (objectForIUnknown != this.wbemServices)
				{
					SecurityHandler securityHandler = this.GetSecurityHandler();
					securityHandler.SecureIUnknown(objectForIUnknown);
					wbemServices = (IWbemServices)objectForIUnknown;
					securityHandler.Secure(wbemServices);
				}
			}
			return wbemServices;
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Management.ManagementScope" /> is currently bound to a WMI server and namespace.</summary>
		/// <returns>Returns a <see cref="T:System.Boolean" /> value indicating whether the scope is currently bound to a WMI server and namespace.</returns>
		// Token: 0x17000073 RID: 115
		// (get) Token: 0x0600024C RID: 588 RVA: 0x0000CBFF File Offset: 0x0000ADFF
		public bool IsConnected
		{
			get
			{
				return this.wbemServices != null;
			}
		}

		// Token: 0x0600024D RID: 589 RVA: 0x0000CC0A File Offset: 0x0000AE0A
		internal ManagementScope(ManagementPath path, IWbemServices wbemServices, ConnectionOptions options)
		{
			if (path != null)
			{
				this.Path = path;
			}
			if (options != null)
			{
				this.Options = options;
			}
			this.wbemServices = wbemServices;
		}

		// Token: 0x0600024E RID: 590 RVA: 0x0000CC2D File Offset: 0x0000AE2D
		internal ManagementScope(ManagementPath path, ManagementScope scope)
			: this(path, (scope != null) ? scope.options : null)
		{
		}

		// Token: 0x0600024F RID: 591 RVA: 0x0000CC42 File Offset: 0x0000AE42
		internal static ManagementScope _Clone(ManagementScope scope)
		{
			return ManagementScope._Clone(scope, null);
		}

		// Token: 0x06000250 RID: 592 RVA: 0x0000CC4C File Offset: 0x0000AE4C
		internal static ManagementScope _Clone(ManagementScope scope, IdentifierChangedEventHandler handler)
		{
			ManagementScope managementScope = new ManagementScope(null, null, null);
			if (handler != null)
			{
				managementScope.IdentifierChanged = handler;
			}
			else if (scope != null)
			{
				managementScope.IdentifierChanged = new IdentifierChangedEventHandler(scope.HandleIdentifierChange);
			}
			if (scope == null)
			{
				managementScope.prvpath = ManagementPath._Clone(ManagementPath.DefaultPath, new IdentifierChangedEventHandler(managementScope.HandleIdentifierChange));
				managementScope.IsDefaulted = true;
				managementScope.wbemServices = null;
				managementScope.options = null;
			}
			else
			{
				if (scope.prvpath == null)
				{
					managementScope.prvpath = ManagementPath._Clone(ManagementPath.DefaultPath, new IdentifierChangedEventHandler(managementScope.HandleIdentifierChange));
					managementScope.IsDefaulted = true;
				}
				else
				{
					managementScope.prvpath = ManagementPath._Clone(scope.prvpath, new IdentifierChangedEventHandler(managementScope.HandleIdentifierChange));
					managementScope.IsDefaulted = scope.IsDefaulted;
				}
				managementScope.wbemServices = scope.wbemServices;
				if (scope.options != null)
				{
					managementScope.options = ConnectionOptions._Clone(scope.options, new IdentifierChangedEventHandler(managementScope.HandleIdentifierChange));
				}
			}
			return managementScope;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class, with default values. This is the default constructor.</summary>
		// Token: 0x06000251 RID: 593 RVA: 0x0000CD44 File Offset: 0x0000AF44
		public ManagementScope()
			: this(new ManagementPath(ManagementPath.DefaultPath.Path))
		{
			this.IsDefaulted = true;
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path.</summary>
		/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> containing the path to a server and namespace for the <see cref="T:System.Management.ManagementScope" />.</param>
		// Token: 0x06000252 RID: 594 RVA: 0x0000CD62 File Offset: 0x0000AF62
		public ManagementScope(ManagementPath path)
			: this(path, null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path.</summary>
		/// <param name="path">The server and namespace path for the <see cref="T:System.Management.ManagementScope" />.</param>
		// Token: 0x06000253 RID: 595 RVA: 0x0000CD6C File Offset: 0x0000AF6C
		public ManagementScope(string path)
			: this(new ManagementPath(path), null)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path, with the specified options.</summary>
		/// <param name="path">The server and namespace for the <see cref="T:System.Management.ManagementScope" />.</param>
		/// <param name="options">A <see cref="T:System.Management.ConnectionOptions" /> containing options for the connection.</param>
		// Token: 0x06000254 RID: 596 RVA: 0x0000CD7B File Offset: 0x0000AF7B
		public ManagementScope(string path, ConnectionOptions options)
			: this(new ManagementPath(path), options)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Management.ManagementScope" /> class representing the specified scope path, with the specified options.</summary>
		/// <param name="path">A <see cref="T:System.Management.ManagementPath" /> containing the path to the server and namespace for the <see cref="T:System.Management.ManagementScope" />.</param>
		/// <param name="options">The <see cref="T:System.Management.ConnectionOptions" /> containing options for the connection.</param>
		// Token: 0x06000255 RID: 597 RVA: 0x0000CD8C File Offset: 0x0000AF8C
		public ManagementScope(ManagementPath path, ConnectionOptions options)
		{
			if (path != null)
			{
				this.prvpath = ManagementPath._Clone(path, new IdentifierChangedEventHandler(this.HandleIdentifierChange));
			}
			else
			{
				this.prvpath = ManagementPath._Clone(null);
			}
			if (options != null)
			{
				this.options = ConnectionOptions._Clone(options, new IdentifierChangedEventHandler(this.HandleIdentifierChange));
			}
			else
			{
				this.options = null;
			}
			this.IsDefaulted = false;
		}

		/// <summary>Gets or sets options for making the WMI connection.</summary>
		/// <returns>Returns a <see cref="T:System.Management.ConnectionOptions" /> that contains the options for making a WMI connection.</returns>
		// Token: 0x17000074 RID: 116
		// (get) Token: 0x06000256 RID: 598 RVA: 0x0000CDF4 File Offset: 0x0000AFF4
		// (set) Token: 0x06000257 RID: 599 RVA: 0x0000CE2C File Offset: 0x0000B02C
		public ConnectionOptions Options
		{
			get
			{
				if (this.options == null)
				{
					return this.options = ConnectionOptions._Clone(null, new IdentifierChangedEventHandler(this.HandleIdentifierChange));
				}
				return this.options;
			}
			set
			{
				if (value != null)
				{
					if (this.options != null)
					{
						this.options.IdentifierChanged -= this.HandleIdentifierChange;
					}
					this.options = ConnectionOptions._Clone(value, new IdentifierChangedEventHandler(this.HandleIdentifierChange));
					this.HandleIdentifierChange(this, null);
					return;
				}
				throw new ArgumentNullException("value");
			}
		}

		/// <summary>Gets or sets the path for the <see cref="T:System.Management.ManagementScope" />.</summary>
		/// <returns>Returns a <see cref="T:System.Management.ManagementPath" /> containing the path to the scope (namespace).</returns>
		// Token: 0x17000075 RID: 117
		// (get) Token: 0x06000258 RID: 600 RVA: 0x0000CE88 File Offset: 0x0000B088
		// (set) Token: 0x06000259 RID: 601 RVA: 0x0000CEB4 File Offset: 0x0000B0B4
		public ManagementPath Path
		{
			get
			{
				if (this.prvpath == null)
				{
					return this.prvpath = ManagementPath._Clone(null);
				}
				return this.prvpath;
			}
			set
			{
				if (value != null)
				{
					if (this.prvpath != null)
					{
						this.prvpath.IdentifierChanged -= this.HandleIdentifierChange;
					}
					this.IsDefaulted = false;
					this.prvpath = ManagementPath._Clone(value, new IdentifierChangedEventHandler(this.HandleIdentifierChange));
					this.HandleIdentifierChange(this, null);
					return;
				}
				throw new ArgumentNullException("value");
			}
		}

		/// <summary>Returns a copy of the object.</summary>
		/// <returns>A new copy of the <see cref="T:System.Management.ManagementScope" />.</returns>
		// Token: 0x0600025A RID: 602 RVA: 0x0000CF15 File Offset: 0x0000B115
		public ManagementScope Clone()
		{
			return ManagementScope._Clone(this);
		}

		/// <summary>Creates a new object that is a copy of the current instance.</summary>
		/// <returns>A new object that is a copy of this instance.</returns>
		// Token: 0x0600025B RID: 603 RVA: 0x0000CF1D File Offset: 0x0000B11D
		object ICloneable.Clone()
		{
			return this.Clone();
		}

		/// <summary>Connects this <see cref="T:System.Management.ManagementScope" /> to the actual WMI scope.</summary>
		// Token: 0x0600025C RID: 604 RVA: 0x0000CF25 File Offset: 0x0000B125
		public void Connect()
		{
			this.Initialize();
		}

		// Token: 0x0600025D RID: 605 RVA: 0x0000CF30 File Offset: 0x0000B130
		internal void Initialize()
		{
			if (this.prvpath == null)
			{
				throw new InvalidOperationException();
			}
			if (!this.IsConnected)
			{
				lock (this)
				{
					if (!this.IsConnected)
					{
						if (!MTAHelper.IsNoContextMTA())
						{
							new ThreadDispatch(new ThreadDispatch.ThreadWorkerMethodWithParam(this.InitializeGuts))
							{
								Parameter = this
							}.Start();
						}
						else
						{
							this.InitializeGuts(this);
						}
					}
				}
			}
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0000CFB4 File Offset: 0x0000B1B4
		private void InitializeGuts(object o)
		{
			ManagementScope managementScope = (ManagementScope)o;
			IWbemLocator wbemLocator = (IWbemLocator)new WbemLocator();
			IntPtr zero = IntPtr.Zero;
			if (managementScope.options == null)
			{
				managementScope.Options = new ConnectionOptions();
			}
			string text = managementScope.prvpath.GetNamespacePath(8);
			if (text == null || text.Length == 0)
			{
				bool flag;
				text = managementScope.prvpath.SetNamespacePath(ManagementPath.DefaultPath.Path, out flag);
			}
			int num = 0;
			managementScope.wbemServices = null;
			if (Environment.OSVersion.Platform == PlatformID.Win32NT && ((Environment.OSVersion.Version.Major == 5 && Environment.OSVersion.Version.Minor >= 1) || Environment.OSVersion.Version.Major >= 6))
			{
				managementScope.options.Flags |= 128;
			}
			try
			{
				num = this.GetSecuredConnectHandler().ConnectNSecureIWbemServices(text, ref managementScope.wbemServices);
			}
			catch (COMException ex)
			{
				ManagementException.ThrowWithExtendedInfo(ex);
			}
			if (((long)num & (long)((ulong)(-4096))) == (long)((ulong)(-2147217408)))
			{
				ManagementException.ThrowWithExtendedInfo((ManagementStatus)num);
				return;
			}
			if (((long)num & (long)((ulong)(-2147483648))) != 0L)
			{
				Marshal.ThrowExceptionForHR(num, WmiNetUtilsHelper.GetErrorInfo_f());
			}
		}

		// Token: 0x0600025F RID: 607 RVA: 0x0000D0EC File Offset: 0x0000B2EC
		internal SecurityHandler GetSecurityHandler()
		{
			return new SecurityHandler(this);
		}

		// Token: 0x06000260 RID: 608 RVA: 0x0000D0F4 File Offset: 0x0000B2F4
		internal SecuredConnectHandler GetSecuredConnectHandler()
		{
			return new SecuredConnectHandler(this);
		}

		// Token: 0x06000261 RID: 609 RVA: 0x0000D0FC File Offset: 0x0000B2FC
		internal SecuredIEnumWbemClassObjectHandler GetSecuredIEnumWbemClassObjectHandler(IEnumWbemClassObject pEnumWbemClassObject)
		{
			return new SecuredIEnumWbemClassObjectHandler(this, pEnumWbemClassObject);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x0000D105 File Offset: 0x0000B305
		internal SecuredIWbemServicesHandler GetSecuredIWbemServicesHandler(IWbemServices pWbemServiecs)
		{
			return new SecuredIWbemServicesHandler(this, pWbemServiecs);
		}

		// Token: 0x040001B7 RID: 439
		private ManagementPath validatedPath;

		// Token: 0x040001B8 RID: 440
		private IWbemServices wbemServices;

		// Token: 0x040001B9 RID: 441
		private ConnectionOptions options;

		// Token: 0x040001BB RID: 443
		internal bool IsDefaulted;
	}
}
