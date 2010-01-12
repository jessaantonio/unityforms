using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using WinForms = System.Windows.Forms;
using System.ComponentModel;    
using System.ComponentModel.Design;

namespace UnityForms
{
    [DesignTimeVisible(true), ToolboxItem(true)]
    public class PasswordField : Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public char MaskChar
        {
            get;
            set;
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public int MaxLenght
        {
            get;
            set;
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler TextChanged;

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            if (this.Size.Height != 22)
            {
                this.Size = new Size(this.Size.Width, 22);
            }

            base.OnPaint(pe);
     

            Pen pen1 = new System.Drawing.Pen(Color.LightGray, 2f);
            Pen pen2 = new System.Drawing.Pen(Color.LightGray, 2f);
            Brush background = new SolidBrush(Color.DarkGray);
            Brush brushFont = new SolidBrush(Color.White);
            Font font = new Font("Arial", 14);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;

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
