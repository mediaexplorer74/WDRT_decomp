﻿using System;
using System.Drawing;

namespace System.Windows.Forms
{
	// Token: 0x02000421 RID: 1057
	internal static class Triangle
	{
		// Token: 0x060049D3 RID: 18899 RVA: 0x00136F48 File Offset: 0x00135148
		public static void Paint(Graphics g, Rectangle bounds, TriangleDirection dir, Brush backBr, Pen backPen1, Pen backPen2, Pen backPen3, bool opaque)
		{
			Point[] array = Triangle.BuildTrianglePoints(dir, bounds);
			if (opaque)
			{
				g.FillPolygon(backBr, array);
			}
			g.DrawLine(backPen1, array[0], array[1]);
			g.DrawLine(backPen2, array[1], array[2]);
			g.DrawLine(backPen3, array[2], array[0]);
		}

		// Token: 0x060049D4 RID: 18900 RVA: 0x00136FAC File Offset: 0x001351AC
		private static Point[] BuildTrianglePoints(TriangleDirection dir, Rectangle bounds)
		{
			Point[] array = new Point[3];
			int num = (int)((double)bounds.Width * 0.8);
			if (num % 2 == 1)
			{
				num++;
			}
			int num2 = (int)Math.Ceiling((double)(num / 2) * 2.5);
			int num3 = (int)((double)bounds.Height * 0.8);
			if (num3 % 2 == 0)
			{
				num3++;
			}
			int num4 = (int)Math.Ceiling((double)(num3 / 2) * 2.5);
			switch (dir)
			{
			case TriangleDirection.Up:
				array[0] = new Point(0, num2);
				array[1] = new Point(num, num2);
				array[2] = new Point(num / 2, 0);
				break;
			case TriangleDirection.Down:
				array[0] = new Point(0, 0);
				array[1] = new Point(num, 0);
				array[2] = new Point(num / 2, num2);
				break;
			case TriangleDirection.Left:
				array[0] = new Point(num3, 0);
				array[1] = new Point(num3, num4);
				array[2] = new Point(0, num4 / 2);
				break;
			case TriangleDirection.Right:
				array[0] = new Point(0, 0);
				array[1] = new Point(0, num4);
				array[2] = new Point(num3, num4 / 2);
				break;
			}
			if (dir > TriangleDirection.Down)
			{
				if (dir - TriangleDirection.Left <= 1)
				{
					Triangle.OffsetPoints(array, bounds.X + (bounds.Width - num3) / 2, bounds.Y + (bounds.Height - num4) / 2);
				}
			}
			else
			{
				Triangle.OffsetPoints(array, bounds.X + (bounds.Width - num2) / 2, bounds.Y + (bounds.Height - num) / 2);
			}
			return array;
		}

		// Token: 0x060049D5 RID: 18901 RVA: 0x00137168 File Offset: 0x00135368
		private static void OffsetPoints(Point[] points, int xOffset, int yOffset)
		{
			for (int i = 0; i < points.Length; i++)
			{
				int num = i;
				points[num].X = points[num].X + xOffset;
				int num2 = i;
				points[num2].Y = points[num2].Y + yOffset;
			}
		}

		// Token: 0x040027A4 RID: 10148
		private const double TRI_HEIGHT_RATIO = 2.5;

		// Token: 0x040027A5 RID: 10149
		private const double TRI_WIDTH_RATIO = 0.8;
	}
}
