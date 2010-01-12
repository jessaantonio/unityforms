//-----------------------------------------------------------------------
// <copyright file="ToolContainerControl.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using System.Collections.Generic;
    using UnityEngine;

    public abstract class ToolContainerControl : ContainerControl
    {
        private GUIContent[] contents;

        public List<Control> Tools
        {
            get
            {
                return Controls;
            }
        }

        public override Control Add(Control control)
        {
            if (control is ToolButton)
            {
                return base.Add(control);
            }

            throw new ArgumentException("the control must be a ToolButton", "control");
        }

        public Control Add(ToolButton control)
        {
            return base.Add(control);
        }

        protected GUIContent[] GetTools()
        {
            GUIContent[] tools = new GUIContent[Controls.Count];
            int i = 0;

            foreach (ToolButton button in Controls)
            {
                tools[i++] = button.Content;
            }

            return tools;
        }
    }
}
