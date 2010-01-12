namespace UnityForms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [TypeConverter(typeof(ToolButtonConverter)), DesignTimeVisible(false), ToolboxItem(false)]
    public class ToolButton : Component
    {
        private string text = "";
        private string toolTip = "";
        private bool showToolTip = true; 

        [UnityFormAttribute()]
        [Browsable(true)]
        public bool ShowToolTip
        {
            get
            {
                return this.showToolTip;
            } 
            
            set
            {
                this.showToolTip = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new event EventHandler Click;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler MouseClick;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler MouseOver;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event EventHandler MouseOut;

        [UnityFormAttribute()]
        [Browsable(true)]
        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                this.text = value;

                if (this.Control != null)
                {
                    this.Control.Invalidate();
                }
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public string ToolTip
        {
            get
            {
                return this.toolTip;
            }

            set
            {
                this.toolTip = value;
            }
        }

        internal ToolCollectionControl Control = null;

        internal Rectangle Bounds;


    }


}
