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
    public class Toggle : Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler CheckedChanged;

        [UnityFormAttribute()]
        [Browsable(true)]
        public bool Value
        {
            get;
            set; 
        }

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
        

            Font font = new Font("Arial", 14);
            StringFormat format = new StringFormat();
            format.Alignment = StringAlignment.Near;
            format.LineAlignment = StringAlignment.Near;

            pe.Graphics.FillEllipse(new SolidBrush(Color.Gray), 0, Size.Height / 2 - 6, 13, 13 );
            pe.Graphics.FillEllipse(new SolidBrush(Color.White), 3, Size.Height / 2 - 3, 6, 6);

            Rectangle area = new Rectangle(new Point(12, 0), this.Size + new Size(1, 1));
            pe.Graphics.DrawString(Text, font, new SolidBrush(Color.White), area, format);
        }
    }

    
}
