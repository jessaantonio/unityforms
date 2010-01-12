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
    public class VerticalScrollbar  : Control
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
        public float VisibleSize { get; set; }

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
            

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.DarkGray, 20f),
                new Point(10, 0), new Point(10, this.Size.Height - 1));

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, 0), new Point(0, this.Size.Height - 1));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(20, 0), new Point(20, this.Size.Height - 1));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, 0), new Point(20, 0));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, this.Size.Height - 1), new Point(20, this.Size.Height - 1));

            pe.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(2, 2, 17, 17));

        }
    }

    
}
