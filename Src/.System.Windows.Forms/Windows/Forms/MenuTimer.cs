﻿using System;

namespace System.Windows.Forms
{
	// Token: 0x020003E6 RID: 998
	internal class MenuTimer
	{
		// Token: 0x06004423 RID: 17443 RVA: 0x00120620 File Offset: 0x0011E820
		public MenuTimer()
		{
			this.autoMenuExpandTimer.Tick += this.OnTick;
			this.slowShow = Math.Max(this.quickShow, SystemInformation.MenuShowDelay);
		}

		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06004424 RID: 17444 RVA: 0x00120672 File Offset: 0x0011E872
		// (set) Token: 0x06004425 RID: 17445 RVA: 0x0012067A File Offset: 0x0011E87A
		private ToolStripMenuItem CurrentItem
		{
			get
			{
				return this.currentItem;
			}
			set
			{
				this.currentItem = value;
			}
		}

		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x06004426 RID: 17446 RVA: 0x00120683 File Offset: 0x0011E883
		// (set) Token: 0x06004427 RID: 17447 RVA: 0x0012068B File Offset: 0x0011E88B
		public bool InTransition
		{
			get
			{
				return this.inTransition;
			}
			set
			{
				this.inTransition = value;
			}
		}

		// Token: 0x06004428 RID: 17448 RVA: 0x00120694 File Offset: 0x0011E894
		public void Start(ToolStripMenuItem item)
		{
			if (this.InTransition)
			{
				return;
			}
			this.StartCore(item);
		}

		// Token: 0x06004429 RID: 17449 RVA: 0x001206A8 File Offset: 0x0011E8A8
		private void StartCore(ToolStripMenuItem item)
		{
			if (item != this.CurrentItem)
			{
				this.Cancel(this.CurrentItem);
			}
			this.CurrentItem = item;
			if (item != null)
			{
				this.CurrentItem = item;
				this.autoMenuExpandTimer.Interval = (item.IsOnDropDown ? this.slowShow : this.quickShow);
				this.autoMenuExpandTimer.Enabled = true;
			}
		}

		// Token: 0x0600442A RID: 17450 RVA: 0x00120708 File Offset: 0x0011E908
		public void Transition(ToolStripMenuItem fromItem, ToolStripMenuItem toItem)
		{
			if (toItem == null && this.InTransition)
			{
				this.Cancel();
				this.EndTransition(true);
				return;
			}
			if (this.fromItem != fromItem)
			{
				this.fromItem = fromItem;
				this.CancelCore();
				this.StartCore(toItem);
			}
			this.CurrentItem = toItem;
			this.InTransition = true;
		}

		// Token: 0x0600442B RID: 17451 RVA: 0x00120759 File Offset: 0x0011E959
		public void Cancel()
		{
			if (this.InTransition)
			{
				return;
			}
			this.CancelCore();
		}

		// Token: 0x0600442C RID: 17452 RVA: 0x0012076A File Offset: 0x0011E96A
		public void Cancel(ToolStripMenuItem item)
		{
			if (this.InTransition)
			{
				return;
			}
			if (item == this.CurrentItem)
			{
				this.CancelCore();
			}
		}

		// Token: 0x0600442D RID: 17453 RVA: 0x00120784 File Offset: 0x0011E984
		private void CancelCore()
		{
			this.autoMenuExpandTimer.Enabled = false;
			this.CurrentItem = null;
		}

		// Token: 0x0600442E RID: 17454 RVA: 0x0012079C File Offset: 0x0011E99C
		private void EndTransition(bool forceClose)
		{
			ToolStripMenuItem toolStripMenuItem = this.fromItem;
			this.fromItem = null;
			if (this.InTransition)
			{
				this.InTransition = false;
				bool flag = forceClose || (this.CurrentItem != null && this.CurrentItem != toolStripMenuItem && this.CurrentItem.Selected);
				if (flag && toolStripMenuItem != null && toolStripMenuItem.HasDropDownItems)
				{
					toolStripMenuItem.HideDropDown();
				}
			}
		}

		// Token: 0x0600442F RID: 17455 RVA: 0x00120800 File Offset: 0x0011EA00
		internal void HandleToolStripMouseLeave(ToolStrip toolStrip)
		{
			if (this.InTransition && toolStrip == this.fromItem.ParentInternal)
			{
				if (this.CurrentItem != null)
				{
					this.CurrentItem.Select();
					return;
				}
			}
			else if (toolStrip.IsDropDown && toolStrip.ActiveDropDowns.Count > 0)
			{
				ToolStripDropDown toolStripDropDown = toolStrip.ActiveDropDowns[0] as ToolStripDropDown;
				ToolStripMenuItem toolStripMenuItem = ((toolStripDropDown == null) ? null : (toolStripDropDown.OwnerItem as ToolStripMenuItem));
				if (toolStripMenuItem != null && toolStripMenuItem.Pressed)
				{
					toolStripMenuItem.Select();
				}
			}
		}

		// Token: 0x06004430 RID: 17456 RVA: 0x00120884 File Offset: 0x0011EA84
		private void OnTick(object sender, EventArgs e)
		{
			this.autoMenuExpandTimer.Enabled = false;
			if (this.CurrentItem == null)
			{
				return;
			}
			this.EndTransition(false);
			if (this.CurrentItem != null && !this.CurrentItem.IsDisposed && this.CurrentItem.Selected && this.CurrentItem.Enabled && ToolStripManager.ModalMenuFilter.InMenuMode)
			{
				this.CurrentItem.OnMenuAutoExpand();
			}
		}

		// Token: 0x0400260B RID: 9739
		private Timer autoMenuExpandTimer = new Timer();

		// Token: 0x0400260C RID: 9740
		private ToolStripMenuItem currentItem;

		// Token: 0x0400260D RID: 9741
		private ToolStripMenuItem fromItem;

		// Token: 0x0400260E RID: 9742
		private bool inTransition;

		// Token: 0x0400260F RID: 9743
		private int quickShow = 1;

		// Token: 0x04002610 RID: 9744
		private int slowShow;
	}
}
