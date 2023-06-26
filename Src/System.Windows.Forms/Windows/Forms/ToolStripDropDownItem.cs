﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Security.Permissions;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms
{
	/// <summary>Provides basic functionality for controls that display a <see cref="T:System.Windows.Forms.ToolStripDropDown" /> when a <see cref="T:System.Windows.Forms.ToolStripDropDownButton" />, <see cref="T:System.Windows.Forms.ToolStripMenuItem" />, or <see cref="T:System.Windows.Forms.ToolStripSplitButton" /> control is clicked.</summary>
	// Token: 0x020003BF RID: 959
	[Designer("System.Windows.Forms.Design.ToolStripMenuItemDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a")]
	[DefaultProperty("DropDownItems")]
	public abstract class ToolStripDropDownItem : ToolStripItem
	{
		/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> class.</summary>
		// Token: 0x060040E1 RID: 16609 RVA: 0x00114AA3 File Offset: 0x00112CA3
		protected ToolStripDropDownItem()
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> class with the specified display text, image, and action to take when the drop-down control is clicked.</summary>
		/// <param name="text">The display text of the drop-down control.</param>
		/// <param name="image">The <see cref="T:System.Drawing.Image" /> to be displayed on the control.</param>
		/// <param name="onClick">The action to take when the drop-down control is clicked.</param>
		// Token: 0x060040E2 RID: 16610 RVA: 0x00114AB2 File Offset: 0x00112CB2
		protected ToolStripDropDownItem(string text, Image image, EventHandler onClick)
			: base(text, image, onClick)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> class with the specified display text, image, action to take when the drop-down control is clicked, and control name.</summary>
		/// <param name="text">The display text of the drop-down control.</param>
		/// <param name="image">The <see cref="T:System.Drawing.Image" /> to be displayed on the control.</param>
		/// <param name="onClick">The action to take when the drop-down control is clicked.</param>
		/// <param name="name">The name of the control.</param>
		// Token: 0x060040E3 RID: 16611 RVA: 0x00114AC4 File Offset: 0x00112CC4
		protected ToolStripDropDownItem(string text, Image image, EventHandler onClick, string name)
			: base(text, image, onClick, name)
		{
		}

		/// <summary>Initializes a new instance of the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> class with the specified display text, image, and <see cref="T:System.Windows.Forms.ToolStripItem" /> collection that the drop-down control contains.</summary>
		/// <param name="text">The display text of the drop-down control.</param>
		/// <param name="image">The <see cref="T:System.Drawing.Image" /> to be displayed on the control.</param>
		/// <param name="dropDownItems">A <see cref="T:System.Windows.Forms.ToolStripItem" /> collection that the drop-down control contains.</param>
		// Token: 0x060040E4 RID: 16612 RVA: 0x00114AD8 File Offset: 0x00112CD8
		protected ToolStripDropDownItem(string text, Image image, params ToolStripItem[] dropDownItems)
			: this(text, image, null)
		{
			if (dropDownItems != null)
			{
				this.DropDownItems.AddRange(dropDownItems);
			}
		}

		/// <summary>Gets or sets the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> that will be displayed when this <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> is clicked.</summary>
		/// <returns>A <see cref="T:System.Windows.Forms.ToolStripDropDown" /> that is associated with the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" />.</returns>
		// Token: 0x17000FD4 RID: 4052
		// (get) Token: 0x060040E5 RID: 16613 RVA: 0x00114AF4 File Offset: 0x00112CF4
		// (set) Token: 0x060040E6 RID: 16614 RVA: 0x00114B50 File Offset: 0x00112D50
		[TypeConverter(typeof(ReferenceConverter))]
		[SRCategory("CatData")]
		[SRDescription("ToolStripDropDownDescr")]
		public ToolStripDropDown DropDown
		{
			get
			{
				if (this.dropDown == null)
				{
					this.DropDown = this.CreateDefaultDropDown();
					if (!(this is ToolStripOverflowButton))
					{
						this.dropDown.SetAutoGeneratedInternal(true);
					}
					if (base.ParentInternal != null)
					{
						this.dropDown.ShowItemToolTips = base.ParentInternal.ShowItemToolTips;
					}
				}
				return this.dropDown;
			}
			set
			{
				if (this.dropDown != value)
				{
					if (this.dropDown != null)
					{
						this.dropDown.Opened -= this.DropDown_Opened;
						this.dropDown.Closed -= this.DropDown_Closed;
						this.dropDown.ItemClicked -= this.DropDown_ItemClicked;
						this.dropDown.UnassignDropDownItem();
					}
					this.dropDown = value;
					if (this.dropDown != null)
					{
						this.dropDown.Opened += this.DropDown_Opened;
						this.dropDown.Closed += this.DropDown_Closed;
						this.dropDown.ItemClicked += this.DropDown_ItemClicked;
						this.dropDown.AssignToDropDownItem();
					}
				}
			}
		}

		// Token: 0x17000FD5 RID: 4053
		// (get) Token: 0x060040E7 RID: 16615 RVA: 0x00114C20 File Offset: 0x00112E20
		internal virtual Rectangle DropDownButtonArea
		{
			get
			{
				return this.Bounds;
			}
		}

		/// <summary>Gets or sets a value indicating the direction in which the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> emerges from its parent container.</summary>
		/// <returns>One of the <see cref="T:System.Windows.Forms.ToolStripDropDownDirection" /> values.</returns>
		/// <exception cref="T:System.ComponentModel.InvalidEnumArgumentException">The property is set to a value that is not one of the <see cref="T:System.Windows.Forms.ToolStripDropDownDirection" /> values.</exception>
		// Token: 0x17000FD6 RID: 4054
		// (get) Token: 0x060040E8 RID: 16616 RVA: 0x00114C28 File Offset: 0x00112E28
		// (set) Token: 0x060040E9 RID: 16617 RVA: 0x00114D08 File Offset: 0x00112F08
		[Browsable(false)]
		[SRDescription("ToolStripDropDownItemDropDownDirectionDescr")]
		[SRCategory("CatBehavior")]
		public ToolStripDropDownDirection DropDownDirection
		{
			get
			{
				if (this.toolStripDropDownDirection == ToolStripDropDownDirection.Default)
				{
					ToolStrip parentInternal = base.ParentInternal;
					if (parentInternal != null)
					{
						ToolStripDropDownDirection toolStripDropDownDirection = parentInternal.DefaultDropDownDirection;
						if (this.OppositeDropDownAlign || (this.RightToLeft != parentInternal.RightToLeft && this.RightToLeft != RightToLeft.Inherit))
						{
							toolStripDropDownDirection = this.RTLTranslateDropDownDirection(toolStripDropDownDirection, this.RightToLeft);
						}
						if (base.IsOnDropDown)
						{
							Rectangle dropDownBounds = this.GetDropDownBounds(toolStripDropDownDirection);
							Rectangle rectangle = new Rectangle(base.TranslatePoint(Point.Empty, ToolStripPointType.ToolStripItemCoords, ToolStripPointType.ScreenCoords), this.Size);
							Rectangle rectangle2 = Rectangle.Intersect(dropDownBounds, rectangle);
							if (rectangle2.Width >= 2)
							{
								RightToLeft rightToLeft = ((this.RightToLeft == RightToLeft.Yes) ? RightToLeft.No : RightToLeft.Yes);
								ToolStripDropDownDirection toolStripDropDownDirection2 = this.RTLTranslateDropDownDirection(toolStripDropDownDirection, rightToLeft);
								int width = Rectangle.Intersect(this.GetDropDownBounds(toolStripDropDownDirection2), rectangle).Width;
								if (width < rectangle2.Width)
								{
									toolStripDropDownDirection = toolStripDropDownDirection2;
								}
							}
						}
						return toolStripDropDownDirection;
					}
				}
				return this.toolStripDropDownDirection;
			}
			set
			{
				if (value > ToolStripDropDownDirection.Right && value != ToolStripDropDownDirection.Default)
				{
					throw new InvalidEnumArgumentException("value", (int)value, typeof(ToolStripDropDownDirection));
				}
				if (this.toolStripDropDownDirection != value)
				{
					this.toolStripDropDownDirection = value;
					if (this.HasDropDownItems && this.DropDown.Visible)
					{
						this.DropDown.Location = this.DropDownLocation;
					}
				}
			}
		}

		/// <summary>Occurs when the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> closes.</summary>
		// Token: 0x14000334 RID: 820
		// (add) Token: 0x060040EA RID: 16618 RVA: 0x00114D69 File Offset: 0x00112F69
		// (remove) Token: 0x060040EB RID: 16619 RVA: 0x00114D7C File Offset: 0x00112F7C
		[SRCategory("CatAction")]
		[SRDescription("ToolStripDropDownClosedDecr")]
		public event EventHandler DropDownClosed
		{
			add
			{
				base.Events.AddHandler(ToolStripDropDownItem.EventDropDownClosed, value);
			}
			remove
			{
				base.Events.RemoveHandler(ToolStripDropDownItem.EventDropDownClosed, value);
			}
		}

		/// <summary>Gets the screen coordinates, in pixels, of the upper-left corner of the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" />.</summary>
		/// <returns>A <see langword="Point" /> representing the x and y screen coordinates, in pixels.</returns>
		// Token: 0x17000FD7 RID: 4055
		// (get) Token: 0x060040EC RID: 16620 RVA: 0x00114D90 File Offset: 0x00112F90
		protected internal virtual Point DropDownLocation
		{
			get
			{
				if (base.ParentInternal == null || !this.HasDropDownItems)
				{
					return Point.Empty;
				}
				ToolStripDropDownDirection dropDownDirection = this.DropDownDirection;
				return this.GetDropDownBounds(dropDownDirection).Location;
			}
		}

		/// <summary>Occurs as the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> is opening.</summary>
		// Token: 0x14000335 RID: 821
		// (add) Token: 0x060040ED RID: 16621 RVA: 0x00114DC9 File Offset: 0x00112FC9
		// (remove) Token: 0x060040EE RID: 16622 RVA: 0x00114DDC File Offset: 0x00112FDC
		[SRCategory("CatAction")]
		[SRDescription("ToolStripDropDownOpeningDescr")]
		public event EventHandler DropDownOpening
		{
			add
			{
				base.Events.AddHandler(ToolStripDropDownItem.EventDropDownShow, value);
			}
			remove
			{
				base.Events.RemoveHandler(ToolStripDropDownItem.EventDropDownShow, value);
			}
		}

		/// <summary>Occurs when the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> has opened.</summary>
		// Token: 0x14000336 RID: 822
		// (add) Token: 0x060040EF RID: 16623 RVA: 0x00114DEF File Offset: 0x00112FEF
		// (remove) Token: 0x060040F0 RID: 16624 RVA: 0x00114E02 File Offset: 0x00113002
		[SRCategory("CatAction")]
		[SRDescription("ToolStripDropDownOpenedDescr")]
		public event EventHandler DropDownOpened
		{
			add
			{
				base.Events.AddHandler(ToolStripDropDownItem.EventDropDownOpened, value);
			}
			remove
			{
				base.Events.RemoveHandler(ToolStripDropDownItem.EventDropDownOpened, value);
			}
		}

		/// <summary>Gets the collection of items in the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> that is associated with this <see cref="T:System.Windows.Forms.ToolStripDropDownItem" />.</summary>
		/// <returns>A <see cref="T:System.Windows.Forms.ToolStripItemCollection" /> of controls.</returns>
		// Token: 0x17000FD8 RID: 4056
		// (get) Token: 0x060040F1 RID: 16625 RVA: 0x00114E15 File Offset: 0x00113015
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		[SRCategory("CatData")]
		[SRDescription("ToolStripDropDownItemsDescr")]
		public ToolStripItemCollection DropDownItems
		{
			get
			{
				return this.DropDown.Items;
			}
		}

		/// <summary>Occurs when the <see cref="T:System.Windows.Forms.ToolStripDropDown" /> is clicked.</summary>
		// Token: 0x14000337 RID: 823
		// (add) Token: 0x060040F2 RID: 16626 RVA: 0x00114E22 File Offset: 0x00113022
		// (remove) Token: 0x060040F3 RID: 16627 RVA: 0x00114E35 File Offset: 0x00113035
		[SRCategory("CatAction")]
		public event ToolStripItemClickedEventHandler DropDownItemClicked
		{
			add
			{
				base.Events.AddHandler(ToolStripDropDownItem.EventDropDownItemClicked, value);
			}
			remove
			{
				base.Events.RemoveHandler(ToolStripDropDownItem.EventDropDownItemClicked, value);
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> has <see cref="T:System.Windows.Forms.ToolStripDropDown" /> controls associated with it.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> has <see cref="T:System.Windows.Forms.ToolStripDropDown" /> controls; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000FD9 RID: 4057
		// (get) Token: 0x060040F4 RID: 16628 RVA: 0x00114E48 File Offset: 0x00113048
		[Browsable(false)]
		public virtual bool HasDropDownItems
		{
			get
			{
				return this.dropDown != null && this.dropDown.HasVisibleItems;
			}
		}

		/// <summary>Gets or sets a value that indicates whether the <see cref="P:System.Windows.Forms.ToolStripDropDownItem.DropDown" /> for the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> has been created.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="P:System.Windows.Forms.ToolStripDropDownItem.DropDown" /> for the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> has been created otherwise, <see langword="false" />.</returns>
		// Token: 0x17000FDA RID: 4058
		// (get) Token: 0x060040F5 RID: 16629 RVA: 0x00114E5F File Offset: 0x0011305F
		[Browsable(false)]
		public bool HasDropDown
		{
			get
			{
				return this.dropDown != null;
			}
		}

		/// <summary>Gets a value indicating whether the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> is in the pressed state.</summary>
		/// <returns>
		///   <see langword="true" /> if the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> is in the pressed state; otherwise, <see langword="false" />.</returns>
		// Token: 0x17000FDB RID: 4059
		// (get) Token: 0x060040F6 RID: 16630 RVA: 0x00114E6C File Offset: 0x0011306C
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public override bool Pressed
		{
			get
			{
				if (this.dropDown != null && (this.DropDown.AutoClose || !base.IsInDesignMode || (base.IsInDesignMode && !base.IsOnDropDown)))
				{
					return this.DropDown.OwnerItem == this && this.DropDown.Visible;
				}
				return base.Pressed;
			}
		}

		// Token: 0x17000FDC RID: 4060
		// (get) Token: 0x060040F7 RID: 16631 RVA: 0x0001180C File Offset: 0x0000FA0C
		internal virtual bool OppositeDropDownAlign
		{
			get
			{
				return false;
			}
		}

		// Token: 0x060040F8 RID: 16632 RVA: 0x00114EC8 File Offset: 0x001130C8
		internal virtual void AutoHide(ToolStripItem otherItemBeingSelected)
		{
			this.HideDropDown();
		}

		/// <summary>Creates a new accessibility object for the <see cref="T:System.Windows.Forms.ToolStripItem" />.</summary>
		/// <returns>A new <see cref="T:System.Windows.Forms.AccessibleObject" /> for the <see cref="T:System.Windows.Forms.ToolStripItem" />.</returns>
		// Token: 0x060040F9 RID: 16633 RVA: 0x00114ED0 File Offset: 0x001130D0
		protected override AccessibleObject CreateAccessibilityInstance()
		{
			return new ToolStripDropDownItemAccessibleObject(this);
		}

		/// <summary>Creates a generic <see cref="T:System.Windows.Forms.ToolStripDropDown" /> for which events can be defined.</summary>
		/// <returns>The created <see cref="T:System.Windows.Forms.ToolStripDropDown" /> object.</returns>
		// Token: 0x060040FA RID: 16634 RVA: 0x00114ED8 File Offset: 0x001130D8
		protected virtual ToolStripDropDown CreateDefaultDropDown()
		{
			return new ToolStripDropDown(this, true);
		}

		// Token: 0x060040FB RID: 16635 RVA: 0x00114EE4 File Offset: 0x001130E4
		private Rectangle DropDownDirectionToDropDownBounds(ToolStripDropDownDirection dropDownDirection, Rectangle dropDownBounds)
		{
			Point empty = Point.Empty;
			switch (dropDownDirection)
			{
			case ToolStripDropDownDirection.AboveLeft:
				empty.X = -dropDownBounds.Width + base.Width;
				empty.Y = -dropDownBounds.Height + 1;
				break;
			case ToolStripDropDownDirection.AboveRight:
				empty.Y = -dropDownBounds.Height + 1;
				break;
			case ToolStripDropDownDirection.BelowLeft:
				empty.X = -dropDownBounds.Width + base.Width;
				empty.Y = base.Height - 1;
				break;
			case ToolStripDropDownDirection.BelowRight:
				empty.Y = base.Height - 1;
				break;
			case ToolStripDropDownDirection.Left:
				empty.X = -dropDownBounds.Width;
				break;
			case ToolStripDropDownDirection.Right:
				empty.X = base.Width;
				if (!base.IsOnDropDown)
				{
					empty.X--;
				}
				break;
			}
			Point point = base.TranslatePoint(Point.Empty, ToolStripPointType.ToolStripItemCoords, ToolStripPointType.ScreenCoords);
			dropDownBounds.Location = new Point(point.X + empty.X, point.Y + empty.Y);
			dropDownBounds = WindowsFormsUtils.ConstrainToScreenWorkingAreaBounds(dropDownBounds);
			return dropDownBounds;
		}

		// Token: 0x060040FC RID: 16636 RVA: 0x00115007 File Offset: 0x00113207
		private void DropDown_Closed(object sender, ToolStripDropDownClosedEventArgs e)
		{
			this.OnDropDownClosed(EventArgs.Empty);
		}

		// Token: 0x060040FD RID: 16637 RVA: 0x00115014 File Offset: 0x00113214
		private void DropDown_Opened(object sender, EventArgs e)
		{
			this.OnDropDownOpened(EventArgs.Empty);
		}

		// Token: 0x060040FE RID: 16638 RVA: 0x00115021 File Offset: 0x00113221
		private void DropDown_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
		{
			this.OnDropDownItemClicked(e);
		}

		/// <summary>Releases the unmanaged resources used by the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> and optionally releases the managed resources.</summary>
		/// <param name="disposing">
		///   <see langword="true" /> to release both managed and unmanaged resources; <see langword="false" /> to release only unmanaged resources.</param>
		// Token: 0x060040FF RID: 16639 RVA: 0x0011502C File Offset: 0x0011322C
		protected override void Dispose(bool disposing)
		{
			if (this.dropDown != null)
			{
				this.dropDown.Opened -= this.DropDown_Opened;
				this.dropDown.Closed -= this.DropDown_Closed;
				this.dropDown.ItemClicked -= this.DropDown_ItemClicked;
				if (disposing && this.dropDown.IsAutoGenerated)
				{
					this.dropDown.Dispose();
					this.dropDown = null;
				}
			}
			base.Dispose(disposing);
		}

		// Token: 0x06004100 RID: 16640 RVA: 0x001150B0 File Offset: 0x001132B0
		private Rectangle GetDropDownBounds(ToolStripDropDownDirection dropDownDirection)
		{
			Rectangle rectangle = new Rectangle(Point.Empty, this.DropDown.GetSuggestedSize());
			rectangle = this.DropDownDirectionToDropDownBounds(dropDownDirection, rectangle);
			Rectangle rectangle2 = new Rectangle(base.TranslatePoint(Point.Empty, ToolStripPointType.ToolStripItemCoords, ToolStripPointType.ScreenCoords), this.Size);
			if (Rectangle.Intersect(rectangle, rectangle2).Height > 1)
			{
				bool flag = this.RightToLeft == RightToLeft.Yes;
				if (Rectangle.Intersect(rectangle, rectangle2).Width > 1)
				{
					rectangle = this.DropDownDirectionToDropDownBounds((!flag) ? ToolStripDropDownDirection.Right : ToolStripDropDownDirection.Left, rectangle);
				}
				if (Rectangle.Intersect(rectangle, rectangle2).Width > 1)
				{
					rectangle = this.DropDownDirectionToDropDownBounds((!flag) ? ToolStripDropDownDirection.Left : ToolStripDropDownDirection.Right, rectangle);
				}
			}
			return rectangle;
		}

		/// <summary>Makes a visible <see cref="T:System.Windows.Forms.ToolStripDropDown" /> hidden.</summary>
		// Token: 0x06004101 RID: 16641 RVA: 0x00115158 File Offset: 0x00113358
		public void HideDropDown()
		{
			this.OnDropDownHide(EventArgs.Empty);
			if (this.dropDown != null && this.dropDown.Visible)
			{
				this.DropDown.Visible = false;
				if (AccessibilityImprovements.Level1)
				{
					base.AccessibilityNotifyClients(AccessibleEvents.StateChange);
					base.AccessibilityNotifyClients(AccessibleEvents.NameChange);
				}
			}
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDown.FontChanged" /> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		// Token: 0x06004102 RID: 16642 RVA: 0x001151AE File Offset: 0x001133AE
		protected override void OnFontChanged(EventArgs e)
		{
			base.OnFontChanged(e);
			if (this.dropDown != null)
			{
				this.dropDown.OnOwnerItemFontChanged(EventArgs.Empty);
			}
		}

		/// <summary>Occurs when the <see cref="P:System.Windows.Forms.ToolStripItem.Bounds" /> property changes.</summary>
		// Token: 0x06004103 RID: 16643 RVA: 0x001151CF File Offset: 0x001133CF
		protected override void OnBoundsChanged()
		{
			base.OnBoundsChanged();
			if (this.dropDown != null && this.dropDown.Visible)
			{
				this.dropDown.Bounds = this.GetDropDownBounds(this.DropDownDirection);
			}
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.Control.RightToLeftChanged" /> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		// Token: 0x06004104 RID: 16644 RVA: 0x00115204 File Offset: 0x00113404
		protected override void OnRightToLeftChanged(EventArgs e)
		{
			base.OnRightToLeftChanged(e);
			if (this.HasDropDownItems)
			{
				if (this.DropDown.Visible)
				{
					LayoutTransaction.DoLayout(this.DropDown, this, PropertyNames.RightToLeft);
					return;
				}
				CommonProperties.xClearPreferredSizeCache(this.DropDown);
				this.DropDown.LayoutRequired = true;
			}
		}

		// Token: 0x06004105 RID: 16645 RVA: 0x00115256 File Offset: 0x00113456
		internal override void OnImageScalingSizeChanged(EventArgs e)
		{
			base.OnImageScalingSizeChanged(e);
			if (this.HasDropDown && this.DropDown.IsAutoGenerated)
			{
				this.DropDown.DoLayoutIfHandleCreated(new ToolStripItemEventArgs(this));
			}
		}

		/// <summary>Raised in response to the <see cref="M:System.Windows.Forms.ToolStripDropDownItem.HideDropDown" /> method.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		// Token: 0x06004106 RID: 16646 RVA: 0x00115288 File Offset: 0x00113488
		protected virtual void OnDropDownHide(EventArgs e)
		{
			base.Invalidate();
			EventHandler eventHandler = (EventHandler)base.Events[ToolStripDropDownItem.EventDropDownHide];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}

		/// <summary>Raised in response to the <see cref="M:System.Windows.Forms.ToolStripDropDownItem.ShowDropDown" /> method.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		// Token: 0x06004107 RID: 16647 RVA: 0x001152BC File Offset: 0x001134BC
		protected virtual void OnDropDownShow(EventArgs e)
		{
			EventHandler eventHandler = (EventHandler)base.Events[ToolStripDropDownItem.EventDropDownShow];
			if (eventHandler != null)
			{
				eventHandler(this, e);
			}
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownOpened" /> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		// Token: 0x06004108 RID: 16648 RVA: 0x001152EC File Offset: 0x001134EC
		protected internal virtual void OnDropDownOpened(EventArgs e)
		{
			if (this.DropDown.OwnerItem == this)
			{
				EventHandler eventHandler = (EventHandler)base.Events[ToolStripDropDownItem.EventDropDownOpened];
				if (eventHandler != null)
				{
					eventHandler(this, e);
				}
			}
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownClosed" /> event.</summary>
		/// <param name="e">An <see cref="T:System.EventArgs" /> that contains the event data.</param>
		// Token: 0x06004109 RID: 16649 RVA: 0x00115328 File Offset: 0x00113528
		protected internal virtual void OnDropDownClosed(EventArgs e)
		{
			base.Invalidate();
			if (this.DropDown.OwnerItem == this)
			{
				EventHandler eventHandler = (EventHandler)base.Events[ToolStripDropDownItem.EventDropDownClosed];
				if (eventHandler != null)
				{
					eventHandler(this, e);
				}
				if (!this.DropDown.IsAutoGenerated)
				{
					this.DropDown.OwnerItem = null;
				}
			}
		}

		/// <summary>Raises the <see cref="E:System.Windows.Forms.ToolStripDropDownItem.DropDownItemClicked" /> event.</summary>
		/// <param name="e">A <see cref="T:System.Windows.Forms.ToolStripItemClickedEventArgs" /> that contains the event data.</param>
		// Token: 0x0600410A RID: 16650 RVA: 0x00115384 File Offset: 0x00113584
		protected internal virtual void OnDropDownItemClicked(ToolStripItemClickedEventArgs e)
		{
			if (this.DropDown.OwnerItem == this)
			{
				ToolStripItemClickedEventHandler toolStripItemClickedEventHandler = (ToolStripItemClickedEventHandler)base.Events[ToolStripDropDownItem.EventDropDownItemClicked];
				if (toolStripItemClickedEventHandler != null)
				{
					toolStripItemClickedEventHandler(this, e);
				}
			}
		}

		/// <summary>Processes a command key.</summary>
		/// <param name="m">A <see cref="T:System.Windows.Forms.Message" />, passed by reference, that represents the window message to process.</param>
		/// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
		/// <returns>
		///   <see langword="false" /> in all cases.</returns>
		// Token: 0x0600410B RID: 16651 RVA: 0x001153C0 File Offset: 0x001135C0
		[SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.UnmanagedCode)]
		protected internal override bool ProcessCmdKey(ref Message m, Keys keyData)
		{
			if (this.HasDropDownItems)
			{
				return this.DropDown.ProcessCmdKeyInternal(ref m, keyData);
			}
			return base.ProcessCmdKey(ref m, keyData);
		}

		/// <summary>Processes a dialog key.</summary>
		/// <param name="keyData">One of the <see cref="T:System.Windows.Forms.Keys" /> values that represents the key to process.</param>
		/// <returns>
		///   <see langword="true" /> if the key was processed by the item; otherwise, <see langword="false" />.</returns>
		// Token: 0x0600410C RID: 16652 RVA: 0x001153E0 File Offset: 0x001135E0
		[UIPermission(SecurityAction.LinkDemand, Window = UIPermissionWindow.AllWindows)]
		protected internal override bool ProcessDialogKey(Keys keyData)
		{
			Keys keys = keyData & Keys.KeyCode;
			if (this.HasDropDownItems)
			{
				bool flag = !base.IsOnDropDown || base.IsOnOverflow;
				if (flag && (keys == Keys.Down || keys == Keys.Up || keys == Keys.Return || (base.SupportsSpaceKey && keys == Keys.Space)))
				{
					if (this.Enabled || base.DesignMode)
					{
						this.ShowDropDown();
						if (!AccessibilityImprovements.UseLegacyToolTipDisplay)
						{
							KeyboardToolTipStateMachine.Instance.NotifyAboutLostFocus(this);
						}
						this.DropDown.SelectNextToolStripItem(null, true);
					}
					return true;
				}
				if (!flag)
				{
					bool flag2 = (this.DropDownDirection & ToolStripDropDownDirection.AboveRight) == ToolStripDropDownDirection.AboveLeft;
					bool flag3 = keys == Keys.Return || (base.SupportsSpaceKey && keys == Keys.Space) || (flag2 && keys == Keys.Left) || (!flag2 && keys == Keys.Right);
					if (flag3)
					{
						if (this.Enabled || base.DesignMode)
						{
							this.ShowDropDown();
							if (!AccessibilityImprovements.UseLegacyToolTipDisplay)
							{
								KeyboardToolTipStateMachine.Instance.NotifyAboutLostFocus(this);
							}
							this.DropDown.SelectNextToolStripItem(null, true);
						}
						return true;
					}
				}
			}
			if (base.IsOnDropDown)
			{
				bool flag4 = (this.DropDownDirection & ToolStripDropDownDirection.AboveRight) == ToolStripDropDownDirection.AboveLeft;
				bool flag5 = (flag4 && keys == Keys.Right) || (!flag4 && keys == Keys.Left);
				if (flag5)
				{
					ToolStripDropDown currentParentDropDown = base.GetCurrentParentDropDown();
					if (currentParentDropDown != null && !currentParentDropDown.IsFirstDropDown)
					{
						currentParentDropDown.SetCloseReason(ToolStripDropDownCloseReason.Keyboard);
						if (!AccessibilityImprovements.UseLegacyToolTipDisplay)
						{
							KeyboardToolTipStateMachine.Instance.NotifyAboutLostFocus(this);
						}
						currentParentDropDown.SelectPreviousToolStrip();
						return true;
					}
				}
			}
			return base.ProcessDialogKey(keyData);
		}

		// Token: 0x0600410D RID: 16653 RVA: 0x00115558 File Offset: 0x00113758
		private ToolStripDropDownDirection RTLTranslateDropDownDirection(ToolStripDropDownDirection dropDownDirection, RightToLeft rightToLeft)
		{
			switch (dropDownDirection)
			{
			case ToolStripDropDownDirection.AboveLeft:
				return ToolStripDropDownDirection.AboveRight;
			case ToolStripDropDownDirection.AboveRight:
				return ToolStripDropDownDirection.AboveLeft;
			case ToolStripDropDownDirection.BelowLeft:
				return ToolStripDropDownDirection.BelowRight;
			case ToolStripDropDownDirection.BelowRight:
				return ToolStripDropDownDirection.BelowLeft;
			case ToolStripDropDownDirection.Left:
				return ToolStripDropDownDirection.Right;
			case ToolStripDropDownDirection.Right:
				return ToolStripDropDownDirection.Left;
			default:
				if (base.IsOnDropDown)
				{
					if (rightToLeft != RightToLeft.Yes)
					{
						return ToolStripDropDownDirection.Right;
					}
					return ToolStripDropDownDirection.Left;
				}
				else
				{
					if (rightToLeft != RightToLeft.Yes)
					{
						return ToolStripDropDownDirection.BelowRight;
					}
					return ToolStripDropDownDirection.BelowLeft;
				}
				break;
			}
		}

		/// <summary>Displays the <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> control associated with this <see cref="T:System.Windows.Forms.ToolStripDropDownItem" />.</summary>
		/// <exception cref="T:System.InvalidOperationException">The <see cref="T:System.Windows.Forms.ToolStripDropDownItem" /> is the same as the parent <see cref="T:System.Windows.Forms.ToolStrip" />.</exception>
		// Token: 0x0600410E RID: 16654 RVA: 0x001155A8 File Offset: 0x001137A8
		public void ShowDropDown()
		{
			this.ShowDropDown(false);
		}

		// Token: 0x0600410F RID: 16655 RVA: 0x001155B4 File Offset: 0x001137B4
		internal void ShowDropDown(bool mousePush)
		{
			this.ShowDropDownInternal();
			ToolStripDropDownMenu toolStripDropDownMenu = this.dropDown as ToolStripDropDownMenu;
			if (toolStripDropDownMenu != null)
			{
				if (!mousePush)
				{
					toolStripDropDownMenu.ResetScrollPosition();
				}
				toolStripDropDownMenu.RestoreScrollPosition();
			}
		}

		// Token: 0x06004110 RID: 16656 RVA: 0x001155E8 File Offset: 0x001137E8
		private void ShowDropDownInternal()
		{
			if (this.dropDown == null || !this.dropDown.Visible)
			{
				this.OnDropDownShow(EventArgs.Empty);
			}
			if (this.dropDown != null && !this.dropDown.Visible)
			{
				if (this.dropDown.IsAutoGenerated && this.DropDownItems.Count <= 0)
				{
					return;
				}
				if (this.DropDown == base.ParentInternal)
				{
					throw new InvalidOperationException(SR.GetString("ToolStripShowDropDownInvalidOperation"));
				}
				this.dropDown.OwnerItem = this;
				this.dropDown.Location = this.DropDownLocation;
				this.dropDown.Show();
				base.Invalidate();
				if (AccessibilityImprovements.Level1)
				{
					base.AccessibilityNotifyClients(AccessibleEvents.StateChange);
					base.AccessibilityNotifyClients(AccessibleEvents.NameChange);
				}
			}
		}

		// Token: 0x06004111 RID: 16657 RVA: 0x001156B5 File Offset: 0x001138B5
		private bool ShouldSerializeDropDown()
		{
			return this.dropDown != null && !this.dropDown.IsAutoGenerated;
		}

		// Token: 0x06004112 RID: 16658 RVA: 0x001156CF File Offset: 0x001138CF
		private bool ShouldSerializeDropDownDirection()
		{
			return this.toolStripDropDownDirection != ToolStripDropDownDirection.Default;
		}

		// Token: 0x06004113 RID: 16659 RVA: 0x001156DD File Offset: 0x001138DD
		private bool ShouldSerializeDropDownItems()
		{
			return this.dropDown != null && this.dropDown.IsAutoGenerated;
		}

		// Token: 0x06004114 RID: 16660 RVA: 0x001156F4 File Offset: 0x001138F4
		internal override void OnKeyboardToolTipHook(ToolTip toolTip)
		{
			base.OnKeyboardToolTipHook(toolTip);
			KeyboardToolTipStateMachine.Instance.Hook(this.DropDown, toolTip);
		}

		// Token: 0x06004115 RID: 16661 RVA: 0x0011570E File Offset: 0x0011390E
		internal override void OnKeyboardToolTipUnhook(ToolTip toolTip)
		{
			base.OnKeyboardToolTipUnhook(toolTip);
			KeyboardToolTipStateMachine.Instance.Unhook(this.DropDown, toolTip);
		}

		// Token: 0x06004116 RID: 16662 RVA: 0x00115728 File Offset: 0x00113928
		internal override void ToolStrip_RescaleConstants(int oldDpi, int newDpi)
		{
			base.RescaleConstantsInternal(newDpi);
			Stack<ToolStripDropDownItem> stack = new Stack<ToolStripDropDownItem>();
			stack.Push(this);
			while (stack.Count > 0)
			{
				ToolStripDropDownItem toolStripDropDownItem = stack.Pop();
				if (toolStripDropDownItem.dropDown != null)
				{
					toolStripDropDownItem.dropDown.deviceDpi = newDpi;
					toolStripDropDownItem.dropDown.ResetScaling(newDpi);
					foreach (object obj in toolStripDropDownItem.DropDown.Items)
					{
						ToolStripItem toolStripItem = (ToolStripItem)obj;
						if (toolStripItem != null)
						{
							Font font = toolStripItem.Font;
							object obj2 = font;
							ToolStripItem ownerItem = toolStripItem.OwnerItem;
							if (!obj2.Equals((ownerItem != null) ? ownerItem.Font : null))
							{
								float num = (float)newDpi / (float)oldDpi;
								toolStripItem.Font = new Font(font.FontFamily, font.Size * num, font.Style, font.Unit, font.GdiCharSet, font.GdiVerticalFont);
							}
							toolStripItem.DeviceDpi = newDpi;
							if (typeof(ToolStripDropDownItem).IsAssignableFrom(toolStripItem.GetType()) && ((ToolStripDropDownItem)toolStripItem).dropDown != null)
							{
								stack.Push((ToolStripDropDownItem)toolStripItem);
							}
						}
					}
				}
			}
			base.ToolStrip_RescaleConstants(oldDpi, newDpi);
		}

		// Token: 0x040024DF RID: 9439
		private ToolStripDropDown dropDown;

		// Token: 0x040024E0 RID: 9440
		private ToolStripDropDownDirection toolStripDropDownDirection = ToolStripDropDownDirection.Default;

		// Token: 0x040024E1 RID: 9441
		private static readonly object EventDropDownShow = new object();

		// Token: 0x040024E2 RID: 9442
		private static readonly object EventDropDownHide = new object();

		// Token: 0x040024E3 RID: 9443
		private static readonly object EventDropDownOpened = new object();

		// Token: 0x040024E4 RID: 9444
		private static readonly object EventDropDownClosed = new object();

		// Token: 0x040024E5 RID: 9445
		private static readonly object EventDropDownItemClicked = new object();
	}
}
