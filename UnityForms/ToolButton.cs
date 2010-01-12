//-----------------------------------------------------------------------
// <copyright file="ToolButton.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using UnityEngine;

    public class ToolButton : Control
    {
        // eliminar esto
        public event ToolClickEventHandler ButtonClick;

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        // eliminar esto
        public void RaiseButtonClickEvent(Control source, MouseButton button, int index)
        {
            if (this.ButtonClick != null)
            {
                this.ButtonClick(source, new ToolClickEventArgs(button, this, index));
            }
        }

        protected override void DrawControl()
        {
        }
    }
}
