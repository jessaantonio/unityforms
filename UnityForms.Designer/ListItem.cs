using System;
using System.ComponentModel;
using System.Drawing;


namespace UnityForms
{
    [TypeConverter(typeof(ListItemConverter)), DesignTimeVisible(false), ToolboxItem(false)]
    public class ListItem : Component
    {
        private string text = "";

        [UnityFormAttribute()]
        [Browsable(true)]
        public bool Selected
        {
            get; set;
        }

        [UnityFormAttribute(), Browsable(true)]
        public bool ShowToolTip
        {
            get; set;
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new event EventHandler Click;

        [UnityFormAttribute()]
        [Browsable(true)]
        public new event EventHandler DoubleClick;

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

        [UnityFormAttribute(), Browsable(true)]
        public string ToolTip
        {
            get; set;
        }

        internal ListItemCollectionControl Control = null;

        internal Rectangle Bounds;

        public ListItem()
        {
            this.ToolTip = string.Empty;
            this.ShowToolTip = true;
        }

        public void Move(ListBox listBox)
        {
            throw new NotImplementedException();
        }
    }
}
