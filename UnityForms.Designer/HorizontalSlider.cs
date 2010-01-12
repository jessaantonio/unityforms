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
    public class HorizontalSlider  : Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler ValueChanged;
        

        float _max = 100;
        float _min = 0;
        private ValueType _valueType = ValueType.Float;

        [UnityFormAttribute()]
        [Browsable(true)]
        public ValueType ValueType { get { return _valueType; } set { _valueType = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float Max { get { return _max; } set { _max = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float Min { get { return _min; } set { _min = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float Value { get; set; }

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
 

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.DarkGray, 7f), 
                new Point(0, 7), new Point(this.Size.Width - 1, 7));

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f), 
                new Point(0, 3), new Point(this.Size.Width - 1, 3));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, 11), new Point(this.Size.Width - 1, 11));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, 3), new Point(0, 11));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(this.Size.Width - 1, 3), new Point(this.Size.Width - 1, 11));

            pe.Graphics.FillEllipse(new SolidBrush(Color.Black), 2, 0, 15, 15);
            pe.Graphics.FillEllipse(new SolidBrush(Color.Gray), 3, 1, 13, 13);
        }
    }

    
}
