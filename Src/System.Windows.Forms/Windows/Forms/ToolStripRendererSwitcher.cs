﻿using System;
using System.Collections.Specialized;
using System.ComponentModel;

namespace System.Windows.Forms
{
	// Token: 0x020003F8 RID: 1016
	internal class ToolStripRendererSwitcher
	{
		// Token: 0x06004659 RID: 18009 RVA: 0x00128098 File Offset: 0x00126298
		public ToolStripRendererSwitcher(Control owner, ToolStripRenderMode defaultRenderMode)
			: this(owner)
		{
			this.defaultRenderMode = defaultRenderMode;
			this.RenderMode = defaultRenderMode;
		}

		// Token: 0x0600465A RID: 18010 RVA: 0x001280B0 File Offset: 0x001262B0
		public ToolStripRendererSwitcher(Control owner)
		{
			this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer] = true;
			this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged] = false;
			owner.Disposed += this.OnControlDisposed;
			owner.VisibleChanged += this.OnControlVisibleChanged;
			if (owner.Visible)
			{
				this.OnControlVisibleChanged(owner, EventArgs.Empty);
			}
		}

		// Token: 0x17001139 RID: 4409
		// (get) Token: 0x0600465B RID: 18011 RVA: 0x00128134 File Offset: 0x00126334
		// (set) Token: 0x0600465C RID: 18012 RVA: 0x00128180 File Offset: 0x00126380
		public ToolStripRenderer Renderer
		{
			get
			{
				if (this.RenderMode == ToolStripRenderMode.ManagerRenderMode)
				{
					return ToolStripManager.Renderer;
				}
				this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer] = false;
				if (this.renderer == null)
				{
					this.Renderer = ToolStripManager.CreateRenderer(this.RenderMode);
				}
				return this.renderer;
			}
			set
			{
				if (this.renderer != value)
				{
					this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer] = value == null;
					this.renderer = value;
					this.currentRendererType = ((this.renderer != null) ? this.renderer.GetType() : typeof(Type));
					this.OnRendererChanged(EventArgs.Empty);
				}
			}
		}

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x0600465D RID: 18013 RVA: 0x001281E4 File Offset: 0x001263E4
		// (set) Token: 0x0600465E RID: 18014 RVA: 0x00128248 File Offset: 0x00126448
		public ToolStripRenderMode RenderMode
		{
			get
			{
				if (this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer])
				{
					return ToolStripRenderMode.ManagerRenderMode;
				}
				if (this.renderer != null && !this.renderer.IsAutoGenerated)
				{
					return ToolStripRenderMode.Custom;
				}
				if (this.currentRendererType == ToolStripManager.ProfessionalRendererType)
				{
					return ToolStripRenderMode.Professional;
				}
				if (this.currentRendererType == ToolStripManager.SystemRendererType)
				{
					return ToolStripRenderMode.System;
				}
				return ToolStripRenderMode.Custom;
			}
			set
			{
				if (!ClientUtils.IsEnumValid(value, (int)value, 0, 3))
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripRenderMode));
				}
				if (value == ToolStripRenderMode.Custom)
				{
					throw new NotSupportedException(SR.GetString("ToolStripRenderModeUseRendererPropertyInstead"));
				}
				if (value == ToolStripRenderMode.ManagerRenderMode)
				{
					if (!this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer])
					{
						this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer] = true;
						this.OnRendererChanged(EventArgs.Empty);
						return;
					}
				}
				else
				{
					this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer] = false;
					this.Renderer = ToolStripManager.CreateRenderer(value);
				}
			}
		}

		// Token: 0x14000387 RID: 903
		// (add) Token: 0x0600465F RID: 18015 RVA: 0x001282E0 File Offset: 0x001264E0
		// (remove) Token: 0x06004660 RID: 18016 RVA: 0x00128318 File Offset: 0x00126518
		public event EventHandler RendererChanged;

		// Token: 0x06004661 RID: 18017 RVA: 0x0012834D File Offset: 0x0012654D
		private void OnRendererChanged(EventArgs e)
		{
			if (this.RendererChanged != null)
			{
				this.RendererChanged(this, e);
			}
		}

		// Token: 0x06004662 RID: 18018 RVA: 0x00128364 File Offset: 0x00126564
		private void OnDefaultRendererChanged(object sender, EventArgs e)
		{
			if (this.state[ToolStripRendererSwitcher.stateUseDefaultRenderer])
			{
				this.OnRendererChanged(e);
			}
		}

		// Token: 0x06004663 RID: 18019 RVA: 0x0012837F File Offset: 0x0012657F
		private void OnControlDisposed(object sender, EventArgs e)
		{
			if (this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged])
			{
				ToolStripManager.RendererChanged -= this.OnDefaultRendererChanged;
				this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged] = false;
			}
		}

		// Token: 0x06004664 RID: 18020 RVA: 0x001283B8 File Offset: 0x001265B8
		private void OnControlVisibleChanged(object sender, EventArgs e)
		{
			Control control = sender as Control;
			if (control != null)
			{
				if (control.Visible)
				{
					if (!this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged])
					{
						ToolStripManager.RendererChanged += this.OnDefaultRendererChanged;
						this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged] = true;
						return;
					}
				}
				else if (this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged])
				{
					ToolStripManager.RendererChanged -= this.OnDefaultRendererChanged;
					this.state[ToolStripRendererSwitcher.stateAttachedRendererChanged] = false;
				}
			}
		}

		// Token: 0x06004665 RID: 18021 RVA: 0x00128440 File Offset: 0x00126640
		public bool ShouldSerializeRenderMode()
		{
			return this.RenderMode != this.defaultRenderMode && this.RenderMode > ToolStripRenderMode.Custom;
		}

		// Token: 0x06004666 RID: 18022 RVA: 0x0012845B File Offset: 0x0012665B
		public void ResetRenderMode()
		{
			this.RenderMode = this.defaultRenderMode;
		}

		// Token: 0x04002696 RID: 9878
		private static readonly int stateUseDefaultRenderer = BitVector32.CreateMask();

		// Token: 0x04002697 RID: 9879
		private static readonly int stateAttachedRendererChanged = BitVector32.CreateMask(ToolStripRendererSwitcher.stateUseDefaultRenderer);

		// Token: 0x04002698 RID: 9880
		private ToolStripRenderer renderer;

		// Token: 0x04002699 RID: 9881
		private Type currentRendererType = typeof(Type);

		// Token: 0x0400269A RID: 9882
		private BitVector32 state;

		// Token: 0x0400269B RID: 9883
		private ToolStripRenderMode defaultRenderMode = ToolStripRenderMode.ManagerRenderMode;
	}
}
