//-----------------------------------------------------------------------
// <copyright file="ToolClickEventArgs.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;

    public class ToolClickEventArgs : EventArgs
    {
        private MouseButton mouseButton;
        private ToolButton tool;
        private int index;

        public ToolClickEventArgs(MouseButton mouseButton, ToolButton tool, int index)
        {
            this.mouseButton = mouseButton;
            this.tool = tool;
            this.index = index;
        }

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
    }
}