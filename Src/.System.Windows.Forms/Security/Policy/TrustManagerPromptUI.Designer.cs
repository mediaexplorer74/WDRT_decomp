﻿namespace System.Security.Policy
{
	// Token: 0x02000105 RID: 261
	internal partial class TrustManagerPromptUI : global::System.Windows.Forms.Form
	{
		// Token: 0x06000444 RID: 1092 RVA: 0x0000DF9B File Offset: 0x0000C19B
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (this.components != null)
				{
					this.components.Dispose();
				}
				this.controlToolTip = false;
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000445 RID: 1093 RVA: 0x0000DFC4 File Offset: 0x0000C1C4
		private void InitializeComponent()
		{
			this.components = new global::System.ComponentModel.Container();
			global::System.ComponentModel.ComponentResourceManager componentResourceManager = new global::System.ComponentModel.ComponentResourceManager(typeof(global::System.Security.Policy.TrustManagerPromptUI));
			this.tableLayoutPanelOuter = new global::System.Windows.Forms.TableLayoutPanel();
			this.warningTextTableLayoutPanel = new global::System.Windows.Forms.TableLayoutPanel();
			this.pictureBoxWarning = new global::System.Windows.Forms.PictureBox();
			this.linkLblMoreInformation = new global::System.Windows.Forms.LinkLabel();
			this.tableLayoutPanelQuestion = new global::System.Windows.Forms.TableLayoutPanel();
			this.lblQuestion = new global::System.Windows.Forms.Label();
			this.pictureBoxQuestion = new global::System.Windows.Forms.PictureBox();
			this.tableLayoutPanelButtons = new global::System.Windows.Forms.TableLayoutPanel();
			this.btnInstall = new global::System.Windows.Forms.Button();
			this.btnCancel = new global::System.Windows.Forms.Button();
			this.tableLayoutPanelInfo = new global::System.Windows.Forms.TableLayoutPanel();
			this.lblName = new global::System.Windows.Forms.Label();
			this.lblFrom = new global::System.Windows.Forms.Label();
			this.lblPublisher = new global::System.Windows.Forms.Label();
			this.linkLblName = new global::System.Windows.Forms.LinkLabel();
			this.linkLblFromUrl = new global::System.Windows.Forms.LinkLabel();
			this.linkLblPublisher = new global::System.Windows.Forms.LinkLabel();
			this.lineLabel = new global::System.Windows.Forms.Label();
			this.toolTipFromUrl = new global::System.Windows.Forms.ToolTip(this.components);
			this.tableLayoutPanelOuter.SuspendLayout();
			this.warningTextTableLayoutPanel.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarning).BeginInit();
			this.tableLayoutPanelQuestion.SuspendLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxQuestion).BeginInit();
			this.tableLayoutPanelButtons.SuspendLayout();
			this.tableLayoutPanelInfo.SuspendLayout();
			base.SuspendLayout();
			componentResourceManager.ApplyResources(this.tableLayoutPanelOuter, "tableLayoutPanelOuter");
			this.tableLayoutPanelOuter.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelOuter.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 510f));
			this.tableLayoutPanelOuter.Controls.Add(this.warningTextTableLayoutPanel, 0, 4);
			this.tableLayoutPanelOuter.Controls.Add(this.tableLayoutPanelQuestion, 0, 0);
			this.tableLayoutPanelOuter.Controls.Add(this.tableLayoutPanelButtons, 0, 2);
			this.tableLayoutPanelOuter.Controls.Add(this.tableLayoutPanelInfo, 0, 1);
			this.tableLayoutPanelOuter.Controls.Add(this.lineLabel, 0, 3);
			this.tableLayoutPanelOuter.Margin = new global::System.Windows.Forms.Padding(0, 0, 0, 12);
			this.tableLayoutPanelOuter.Name = "tableLayoutPanelOuter";
			this.tableLayoutPanelOuter.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelOuter.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelOuter.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelOuter.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelOuter.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			componentResourceManager.ApplyResources(this.warningTextTableLayoutPanel, "warningTextTableLayoutPanel");
			this.warningTextTableLayoutPanel.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.warningTextTableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle());
			this.warningTextTableLayoutPanel.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.warningTextTableLayoutPanel.Controls.Add(this.pictureBoxWarning, 0, 0);
			this.warningTextTableLayoutPanel.Controls.Add(this.linkLblMoreInformation, 1, 0);
			this.warningTextTableLayoutPanel.Margin = new global::System.Windows.Forms.Padding(12, 6, 0, 0);
			this.warningTextTableLayoutPanel.Name = "warningTextTableLayoutPanel";
			this.warningTextTableLayoutPanel.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			componentResourceManager.ApplyResources(this.pictureBoxWarning, "pictureBoxWarning");
			this.pictureBoxWarning.Margin = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.pictureBoxWarning.Name = "pictureBoxWarning";
			this.pictureBoxWarning.TabStop = false;
			componentResourceManager.ApplyResources(this.linkLblMoreInformation, "linkLblMoreInformation");
			this.linkLblMoreInformation.Margin = new global::System.Windows.Forms.Padding(3, 0, 3, 0);
			this.linkLblMoreInformation.Name = "linkLblMoreInformation";
			this.linkLblMoreInformation.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TrustManagerPromptUI_ShowMoreInformation);
			componentResourceManager.ApplyResources(this.tableLayoutPanelQuestion, "tableLayoutPanelQuestion");
			this.tableLayoutPanelQuestion.BackColor = global::System.Drawing.SystemColors.Window;
			this.tableLayoutPanelQuestion.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanelQuestion.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Absolute, 58f));
			this.tableLayoutPanelQuestion.Controls.Add(this.lblQuestion, 0, 0);
			this.tableLayoutPanelQuestion.Controls.Add(this.pictureBoxQuestion, 1, 0);
			this.tableLayoutPanelQuestion.Margin = new global::System.Windows.Forms.Padding(0);
			this.tableLayoutPanelQuestion.Name = "tableLayoutPanelQuestion";
			this.tableLayoutPanelQuestion.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			componentResourceManager.ApplyResources(this.lblQuestion, "lblQuestion");
			this.lblQuestion.Margin = new global::System.Windows.Forms.Padding(12, 12, 12, 0);
			this.lblQuestion.Name = "lblQuestion";
			componentResourceManager.ApplyResources(this.pictureBoxQuestion, "pictureBoxQuestion");
			this.pictureBoxQuestion.Margin = new global::System.Windows.Forms.Padding(0);
			this.pictureBoxQuestion.Name = "pictureBoxQuestion";
			this.pictureBoxQuestion.TabStop = false;
			componentResourceManager.ApplyResources(this.tableLayoutPanelButtons, "tableLayoutPanelButtons");
			this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanelButtons.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 50f));
			this.tableLayoutPanelButtons.Controls.Add(this.btnInstall, 0, 0);
			this.tableLayoutPanelButtons.Controls.Add(this.btnCancel, 1, 0);
			this.tableLayoutPanelButtons.Margin = new global::System.Windows.Forms.Padding(0, 6, 12, 12);
			this.tableLayoutPanelButtons.Name = "tableLayoutPanelButtons";
			this.tableLayoutPanelButtons.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			componentResourceManager.ApplyResources(this.btnInstall, "btnInstall");
			this.btnInstall.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnInstall.Margin = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.btnInstall.MinimumSize = new global::System.Drawing.Size(75, 23);
			this.btnInstall.Name = "btnInstall";
			this.btnInstall.Padding = new global::System.Windows.Forms.Padding(10, 0, 10, 0);
			componentResourceManager.ApplyResources(this.btnCancel, "btnCancel");
			this.btnCancel.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnCancel.DialogResult = global::System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Margin = new global::System.Windows.Forms.Padding(3, 0, 0, 0);
			this.btnCancel.MinimumSize = new global::System.Drawing.Size(75, 23);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Padding = new global::System.Windows.Forms.Padding(10, 0, 10, 0);
			componentResourceManager.ApplyResources(this.tableLayoutPanelInfo, "tableLayoutPanelInfo");
			this.tableLayoutPanelInfo.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanelInfo.ColumnStyles.Add(new global::System.Windows.Forms.ColumnStyle(global::System.Windows.Forms.SizeType.Percent, 100f));
			this.tableLayoutPanelInfo.Controls.Add(this.lblName, 0, 0);
			this.tableLayoutPanelInfo.Controls.Add(this.linkLblName, 0, 1);
			this.tableLayoutPanelInfo.Controls.Add(this.lblFrom, 0, 2);
			this.tableLayoutPanelInfo.Controls.Add(this.linkLblFromUrl, 0, 3);
			this.tableLayoutPanelInfo.Controls.Add(this.lblPublisher, 0, 4);
			this.tableLayoutPanelInfo.Controls.Add(this.linkLblPublisher, 0, 5);
			this.tableLayoutPanelInfo.Margin = new global::System.Windows.Forms.Padding(30, 22, 12, 3);
			this.tableLayoutPanelInfo.Name = "tableLayoutPanelInfo";
			this.tableLayoutPanelInfo.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelInfo.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelInfo.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelInfo.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelInfo.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			this.tableLayoutPanelInfo.RowStyles.Add(new global::System.Windows.Forms.RowStyle());
			componentResourceManager.ApplyResources(this.lblName, "lblName");
			this.lblName.Margin = new global::System.Windows.Forms.Padding(0, 0, 3, 0);
			this.lblName.Name = "lblName";
			componentResourceManager.ApplyResources(this.lblFrom, "lblFrom");
			this.lblFrom.Margin = new global::System.Windows.Forms.Padding(0, 8, 3, 0);
			this.lblFrom.Name = "lblFrom";
			componentResourceManager.ApplyResources(this.lblPublisher, "lblPublisher");
			this.lblPublisher.Margin = new global::System.Windows.Forms.Padding(0, 8, 3, 0);
			this.lblPublisher.Name = "lblPublisher";
			componentResourceManager.ApplyResources(this.linkLblName, "linkLblName");
			this.linkLblName.AutoEllipsis = true;
			this.linkLblName.Margin = new global::System.Windows.Forms.Padding(3, 0, 3, 8);
			this.linkLblName.Name = "linkLblName";
			this.linkLblName.TabStop = true;
			this.linkLblName.UseMnemonic = false;
			this.linkLblName.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TrustManagerPromptUI_ShowSupportPage);
			componentResourceManager.ApplyResources(this.linkLblFromUrl, "linkLblFromUrl");
			this.linkLblFromUrl.AutoEllipsis = true;
			this.linkLblFromUrl.Margin = new global::System.Windows.Forms.Padding(3, 0, 3, 8);
			this.linkLblFromUrl.Name = "linkLblFromUrl";
			this.linkLblFromUrl.TabStop = true;
			this.linkLblFromUrl.UseMnemonic = false;
			this.linkLblFromUrl.MouseEnter += new global::System.EventHandler(this.linkLblFromUrl_MouseEnter);
			this.linkLblFromUrl.MouseLeave += new global::System.EventHandler(this.linkLblFromUrl_MouseLeave);
			componentResourceManager.ApplyResources(this.linkLblPublisher, "linkLblPublisher");
			this.linkLblPublisher.AutoEllipsis = true;
			this.linkLblPublisher.Margin = new global::System.Windows.Forms.Padding(3, 0, 3, 0);
			this.linkLblPublisher.Name = "linkLblPublisher";
			this.linkLblPublisher.TabStop = true;
			this.linkLblPublisher.UseMnemonic = false;
			this.linkLblPublisher.LinkClicked += new global::System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.TrustManagerPromptUI_ShowPublisherCertificate);
			componentResourceManager.ApplyResources(this.lineLabel, "lineLabel");
			this.lineLabel.BackColor = global::System.Drawing.SystemColors.ControlDark;
			this.lineLabel.Margin = new global::System.Windows.Forms.Padding(0);
			this.lineLabel.Name = "lineLabel";
			base.AcceptButton = this.btnCancel;
			componentResourceManager.ApplyResources(this, "$this");
			base.AutoScaleMode = global::System.Windows.Forms.AutoScaleMode.Font;
			base.AutoSizeMode = global::System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			base.CancelButton = this.btnCancel;
			base.Controls.Add(this.tableLayoutPanelOuter);
			base.FormBorderStyle = global::System.Windows.Forms.FormBorderStyle.FixedDialog;
			base.MaximizeBox = false;
			base.MinimizeBox = false;
			base.Name = "TrustManagerPromptUI";
			if (global::System.Windows.Forms.SR.GetString("RTL") != "RTL_False")
			{
				this.RightToLeft = global::System.Windows.Forms.RightToLeft.Yes;
				this.RightToLeftLayout = true;
			}
			base.VisibleChanged += new global::System.EventHandler(this.TrustManagerPromptUI_VisibleChanged);
			base.Load += new global::System.EventHandler(this.TrustManagerPromptUI_Load);
			this.tableLayoutPanelOuter.ResumeLayout(false);
			this.tableLayoutPanelOuter.PerformLayout();
			this.warningTextTableLayoutPanel.ResumeLayout(false);
			this.warningTextTableLayoutPanel.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxWarning).EndInit();
			this.tableLayoutPanelQuestion.ResumeLayout(false);
			this.tableLayoutPanelQuestion.PerformLayout();
			((global::System.ComponentModel.ISupportInitialize)this.pictureBoxQuestion).EndInit();
			this.tableLayoutPanelButtons.ResumeLayout(false);
			this.tableLayoutPanelButtons.PerformLayout();
			this.tableLayoutPanelInfo.ResumeLayout(false);
			this.tableLayoutPanelInfo.PerformLayout();
			base.ResumeLayout(false);
			base.PerformLayout();
		}

		// Token: 0x04000457 RID: 1111
		private global::System.ComponentModel.IContainer components;

		// Token: 0x04000458 RID: 1112
		private global::System.Windows.Forms.Button btnCancel;

		// Token: 0x04000459 RID: 1113
		private global::System.Windows.Forms.Button btnInstall;

		// Token: 0x0400045A RID: 1114
		private global::System.Windows.Forms.Label lblFrom;

		// Token: 0x0400045B RID: 1115
		private global::System.Windows.Forms.Label lblName;

		// Token: 0x0400045C RID: 1116
		private global::System.Windows.Forms.Label lblPublisher;

		// Token: 0x0400045D RID: 1117
		private global::System.Windows.Forms.Label lblQuestion;

		// Token: 0x0400045E RID: 1118
		private global::System.Windows.Forms.LinkLabel linkLblFromUrl;

		// Token: 0x0400045F RID: 1119
		private global::System.Windows.Forms.LinkLabel linkLblMoreInformation;

		// Token: 0x04000460 RID: 1120
		private global::System.Windows.Forms.LinkLabel linkLblName;

		// Token: 0x04000461 RID: 1121
		private global::System.Windows.Forms.LinkLabel linkLblPublisher;

		// Token: 0x04000462 RID: 1122
		private global::System.Windows.Forms.PictureBox pictureBoxQuestion;

		// Token: 0x04000463 RID: 1123
		private global::System.Windows.Forms.PictureBox pictureBoxWarning;

		// Token: 0x04000464 RID: 1124
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanelButtons;

		// Token: 0x04000465 RID: 1125
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanelInfo;

		// Token: 0x04000466 RID: 1126
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanelOuter;

		// Token: 0x04000467 RID: 1127
		private global::System.Windows.Forms.TableLayoutPanel tableLayoutPanelQuestion;

		// Token: 0x04000468 RID: 1128
		private global::System.Windows.Forms.ToolTip toolTipFromUrl;

		// Token: 0x04000470 RID: 1136
		private global::System.Windows.Forms.Label lineLabel;

		// Token: 0x04000471 RID: 1137
		private global::System.Windows.Forms.TableLayoutPanel warningTextTableLayoutPanel;

		// Token: 0x04000472 RID: 1138
		private bool controlToolTip;
	}
}
