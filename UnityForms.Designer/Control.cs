namespace UnityForms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [DesignTimeVisible(false), ToolboxItem(false)]
    [Designer(typeof(ControlDesginer))]
    public class Control : System.Windows.Forms.Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler MouseOver;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler MouseOut;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler Resize;

        public Control()
        {
            this.ShowToolTip = true;
            this.ToolTip = string.Empty;
            this.VerticalAlignment = VerticalAlignment.Manual;
            this.HorizontalAlignment = HorizontalAlignment.Manual;
        }

        [UnityFormAttribute(), Browsable(true)]
        public VerticalAlignment VerticalAlignment
        {
            get; set;
        }

        [UnityFormAttribute(), Browsable(true)]
        public HorizontalAlignment HorizontalAlignment
        {
            get; set;
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new string Name
        {
            get
            {
                return base.Name;
            }

            set
            {
                base.Name = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new string Text
        {
            get
            {
                return base.Text;
            }

            set
            {
                base.Text = value;
            }
        }

        [UnityFormAttribute(), Browsable(true)]
        public string ToolTip
        {
            get;
            set;
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new object Tag
        {
            get
            {
                return base.Tag;
            }

            set
            {
                base.Tag = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new Size Size
        {
            get
            {
                return base.Size;
            }

            set
            {
                base.Size = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new Point Location
        {
            get
            {
                return base.Location;
            }

            set
            {
                base.Location = value;
            }
        }

        [UnityFormAttribute(), Browsable(true)]
        public bool ShowToolTip
        {
            get;
            set;
        }

        public virtual void CalculateLayout()
        {
        }
    }
}
