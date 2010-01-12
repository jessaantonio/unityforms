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

    public class Toolbar : ContainerControl
    {
        private int selectedTool = 0;
        private GUIContent[] contents;

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        protected override void DrawControl()
        {
            if (this.contents == null)
            {
                this.contents = this.GetTools();
            }

            int selected;

            if (Style != null)
            {
                selected = GUI.Toolbar(ControlRect, this.selectedTool, this.contents, Style);
            }
            else
            {
                selected = GUI.Toolbar(ControlRect, this.selectedTool, this.contents);
            }

            if (selected != this.selectedTool)
            {
                this.selectedTool = selected;
                ((ToolButton)Controls[this.selectedTool]).RaiseButtonClickEvent(this, (MouseButton)Event.current.button, this.selectedTool);
            }
        }

        //protected override void Initialize()
        //{
        //    this.tools.InitializeControl(this.ParentForm, null);
        //}

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

        private GUIContent[] GetTools()
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
