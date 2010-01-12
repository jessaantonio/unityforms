namespace UnityForms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;
    using WinForms = System.Windows.Forms;

    [DesignTimeVisible(true), ToolboxItem(true)]
    public class HorizontalScrollbar  : Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler ValueChanged;
        
        float rightValue = 100;
        float leftValue = 0;
        private ValueType valueType = ValueType.Float;

        [UnityFormAttribute()]
        [Browsable(true)]
        public ValueType ValueType
        {
            get
            {
                return this.valueType;
            } 
            
            set
            {
                this.valueType = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float VisibleSize
        {
            get; set;
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float Max
        {
            get
            {
                return this.rightValue;
            } 
            
            set
            {
                this.rightValue = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float Min
        {
            get
            {
                return this.leftValue;
            } 
            
            set
            {
                this.leftValue = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public float Value
        {
            get; set;
        }

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            base.OnPaint(pe);

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.DarkGray, 20f), 
                new Point(0, 10), new Point(this.Size.Width - 1, 10));

            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f), 
                new Point(0, 0), new Point(this.Size.Width - 1, 0));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, 20), new Point(this.Size.Width - 1, 20));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(0, 0), new Point(0, 20));
            pe.Graphics.DrawLine(new System.Drawing.Pen(Color.Black, 1f),
                new Point(this.Size.Width - 1, 0), new Point(this.Size.Width - 1, 20));

            pe.Graphics.FillRectangle(new SolidBrush(Color.Black), new Rectangle(2, 2, 17, 17));
        }
    }
}
