using System;
using System.Drawing;


namespace UnityForms
{
    class PaintLibrary
    {
        public static void Button(System.Windows.Forms.PaintEventArgs pe, Point location, Size size, string text, bool selected)
        {
            Point p00 = location;
            Point p01 = new Point(location.X, location.Y + size.Height - 1);
            Point p10 = new Point(location.X + size.Width - 1, location.Y);
            Point p11 = new Point(location.X + size.Width - 1, location.Y + size.Height - 1);
            
            Rectangle area = new Rectangle(location.X, location.Y, size.Width, size.Height);

            pe.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), area);

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Gray, 3f), p10, p11);
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Gray, 3f), p11, p01);
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.LightGray, 4f), p00, p10);
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.LightGray, 4f), p01, p00);

            Label(pe, area, text, new Font("Arial", 14), StringAlignment.Center, StringAlignment.Center, Color.Black, false);

            if (selected)
            {
                pe.Graphics.DrawRectangle(new System.Drawing.Pen(Color.Blue, 1f), area);
            }
        }

        public static void Box(System.Windows.Forms.PaintEventArgs pe, Size size, string text, bool fill)
        {
            if (fill)
            {
                pe.Graphics.FillRectangle(new SolidBrush(Color.DarkGray), new Rectangle(0, 0, size.Width, size.Height));
            }

            Rectangle area = new Rectangle(0, 0, size.Width - 1, size.Height-1);

            pe.Graphics.DrawRectangle(new System.Drawing.Pen(Color.Black, 1f), area);     

            Label(pe, area, text, new Font("Arial", 14), StringAlignment.Center, StringAlignment.Center, Color.Black, false);
        }

        public static void Label(System.Windows.Forms.PaintEventArgs pe, Rectangle area, string text, Font font, StringAlignment horizontalAlignment, StringAlignment verticalAlignment, Color color, bool selected)
        {
            StringFormat format = new StringFormat();
            format.Alignment = horizontalAlignment;
            format.LineAlignment = verticalAlignment;

            pe.Graphics.DrawString(text, font, new SolidBrush(color), area, format);

            if (selected)
            {
                pe.Graphics.DrawRectangle(new System.Drawing.Pen(Color.Blue, 1f), area);
            }
        }
    }
}
