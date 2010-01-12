﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using WinForms = System.Windows.Forms;
using System.ComponentModel;    
using System.ComponentModel.Design;

namespace UnityForms
{
    [DesignTimeVisible(true), ToolboxItem(true)]
    public class RepeatButton : Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public new event EventHandler Click;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler MouseClick;

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Pen pen1 = new System.Drawing.Pen(Color.Gray,7f);
            Pen pen2 = new System.Drawing.Pen(Color.LightGray, 7f);
            Brush background = new SolidBrush(Color.DarkGray);
            Brush brushFont = new SolidBrush(Color.Black);
            Font font = new Font("Arial", 14);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;

            Point p00 = new Point(0, 0);
            Point p01 = new Point(0, this.Size.Height - 1);
            Point p10 = new Point(this.Size.Width - 1, 0);
            Point p11 = new Point(this.Size.Width - 1, this.Size.Height - 1);
            Rectangle area = new Rectangle(Point.Empty, this.Size - new Size(1, 1));

            pe.Graphics.FillRectangle(background, area);

            pe.Graphics.DrawLine(pen1, p10, p11);
            pe.Graphics.DrawLine(pen1, p11, p01);
            pe.Graphics.DrawLine(pen2, p00, p10);
            pe.Graphics.DrawLine(pen2, p01, p00);

            pe.Graphics.DrawString(Text, font, brushFont, area, format);
        }
    }

    
}
