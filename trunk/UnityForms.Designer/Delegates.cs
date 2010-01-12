using System;
using System.Collections.Generic;

namespace UnityForms
{
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
        private MouseButton _mouseButton;
        private ToolButton _tool;
        private int _index;

        public MouseButton MouseButton
        {
            get { return _mouseButton; }
        }

        public int Index
        {
            get { return _index; }
        }

        public ToolButton Tool
        {
            get { return _tool; }
        }

        public ToolClickEventArgs(MouseButton mouseButton, ToolButton tool, int index)
        {
            _mouseButton = mouseButton;
            _tool = tool;
            _index = index;
        }
    }

    public class ValueChangedEventArgs : EventArgs
    {
        private object _value;

        public object Value
        {
            get { return _value; }
        }

        public ValueChangedEventArgs(object value)
        {
            _value = value;
        }
    }

    
}
