//-----------------------------------------------------------------------
// <copyright file="Toolbar.cs" company="Marcelo Roca">
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

    public class Toolbar : ToolContainerControl
    {
        private int selectedTool = 0;

        public Texture Image
        {
            get
            {
                return Content.image;
            }

            set
            {
                Content.image = value;
            }
        }

        protected override void DrawControl()
        {
            GUIContent[] contents = GetTools();
            
            int selected;

            if (Style != null)
            {
                selected = GUI.Toolbar(ControlRect, this.selectedTool, contents, Style);
            }
            else
            {
                selected = GUI.Toolbar(ControlRect, this.selectedTool, contents);
            }

            if (selected != this.selectedTool)
            {
                this.selectedTool = selected;
                ((ToolButton)Controls[this.selectedTool]).RaiseButtonClickEvent(this, (MouseButton)Event.current.button, this.selectedTool);
            }
        }

        public override void InitializeControl(Form parentForm, ContainerControl parent)
        {
            if (parent is ToolContainerControl)
            {
                base.InitializeControl(parentForm, parent);
            }

            throw new ArgumentException("El contenedor solo puede ser un ToolContainerControl", "parent");
        }
    }
}
