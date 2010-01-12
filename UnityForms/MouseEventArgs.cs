//-----------------------------------------------------------------------
// <copyright file="MouseEventArgs.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;

    public class MouseEventArgs : EventArgs
    {
        private MouseButton mouseButton;

        public MouseEventArgs(MouseButton mouseButton)
        {
            this.mouseButton = mouseButton;
        }

        public MouseButton MouseButton
        {
            get
            {
                return this.mouseButton;
            }
        }
    }
}