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
    using UnityEngine;

    public class SelectionGrid : ToolContainerControl
    {
        private int selectedTool = 0;
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

        protected override void DrawControl()
        {
            GUIContent[] contents = GetTools();

            int selected;

            if (Style != null)
            {
                selected = GUI.SelectionGrid(ControlRect, this.selectedTool, contents, this.columns, Style);
            }
            else
            {
                selected = GUI.SelectionGrid(ControlRect, this.selectedTool, contents, this.columns);
            }

            if (selected != this.selectedTool)
            {
                this.selectedTool = selected;
                ((ToolButton)Controls[this.selectedTool]).RaiseButtonClickEvent(this, (MouseButton)Event.current.button, this.selectedTool);
            }
        }
    }
}
