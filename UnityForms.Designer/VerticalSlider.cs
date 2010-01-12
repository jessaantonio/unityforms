using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;    
using System.ComponentModel.Design;

namespace UnityForms
{
    [DesignTimeVisible(true), ToolboxItem(true)]
    public class VerticalSlider  : Control
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

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
           

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.DarkGray, 7f), 
                new Point(7, 0), new Point(7, this.Size.Height - 1));

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(3, 0), new Point(3, this.Size.Height - 1));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(11, 0), new Point(11, this.Size.Height - 1));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(3, 0), new Point(11, 0));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(3, this.Size.Height - 1), new Point(11, this.Size.Height - 1));

            pe.Graphics.FillEllipse(new SolidBrush(Color.Black), 0, this.Size.Height - 16, 15, 15);
            pe.Graphics.FillEllipse(new SolidBrush(Color.Gray), 1, this.Size.Height - 15, 13, 13);
        }
    }

    
}
