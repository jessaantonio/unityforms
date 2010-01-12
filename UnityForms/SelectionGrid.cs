//-----------------------------------------------------------------------
// <copyright file="SelectionGrid.cs" company="Marcelo Roca">
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

    public class SelectionGrid : ContainerControl
    {
        private int selectedTool = 0;
        private GUIContent[] contents;
        private int columns = 1;

        public int Columns
        {
            get { return this.columns; }
            set { this.columns = value; }
        }

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
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

        //protected override void Initialize()
        //{
        //    this.tools.InitializeControl(this.ParentForm, null);
        //}

        protected override void DrawControl()
        {
            if (this.contents == null)
            {
                this.contents = this.GetTools();
            }

            int selected;

            if (Style != null)
            {
                selected = GUI.SelectionGrid(ControlRect, this.selectedTool, this.contents, this.columns, Style);
            }
            else
            {
                selected = GUI.SelectionGrid(ControlRect, this.selectedTool, this.contents, this.columns);
            }

            if (selected != this.selectedTool)
            {
                this.selectedTool = selected;
                ((ToolButton)Controls[this.selectedTool]).RaiseButtonClickEvent(this, (MouseButton)Event.current.button, this.selectedTool);
            }
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
