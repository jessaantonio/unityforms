namespace UnityForms
{
    using System;

    public delegate void MouseEventHandler(object sender, MouseEventArgs e);
    public delegate void ToolClickEventHandler(object sender, ToolClickEventArgs e);
    public delegate void ValueChangedEventHandler(object sender, ValueChangedEventArgs e);

    public class MouseEventArgs : EventArgs
    {
        private MouseButton _mouseButton;

        public MouseButton MouseButton
        {
            get { return _mouseButton; }
        }

        public MouseEventArgs(MouseButton mouseButton)
        {
            _mouseButton = mouseButton;
        }
    }
  
    public class ToolClickEventArgs : EventArgs
    {
        private MouseButton mouseButton;
        private ToolButton tool;
        private int index;

        public MouseButton MouseButton
        {
            get
            {
                return this.mouseButton;
            }
        }

        public int Index
        {
            get
            {
                return this.index;
            }
        }

        public ToolButton Tool
        {
            get
            {
                return this.tool;
            }
        }

        public ToolClickEventArgs(MouseButton mouseButton, ToolButton tool, int index)
        {
            this.mouseButton = mouseButton;
            this.tool = tool;
            this.index = index;
        }
    }

    public class ValueChangedEventArgs : EventArgs
    {
        private object value;

        public object Value
        {
            get
            {
                return this.value;
            }
        }

        public ValueChangedEventArgs(object value)
        {
            this.value = value;
        }
    }
}
