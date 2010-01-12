using System;
using System.ComponentModel;
using System.Drawing;


namespace UnityForms
{
    [TypeConverter(typeof(ListItemConverter)), DesignTimeVisible(false), ToolboxItem(false)]
    public class ListItem : Component
    {
        private string _text = "";
        private string _toolTip = "";
        private bool _showToolTip = true; 


        [UnityFormAttribute()]
        [Browsable(true)]
        public bool ShowToolTip { get { return _showToolTip; } set { _showToolTip = value; } }


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
            get { return _text; }
            set
            {
                _text = value;
                if (Control != null)
                {
                    Control.Invalidate();
                }
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public string ToolTip
        {
            get { return _toolTip; }
            set { _toolTip = value; }
        }

        internal ListItemCollectionControl Control = null;

        internal Rectangle Bounds;


    }


}
