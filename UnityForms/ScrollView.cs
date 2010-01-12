//-----------------------------------------------------------------------
// <copyright file="ScrollView.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using UnityEngine;
    
    public class ScrollView : ContainerControl
    {
        private Vector2 scrollPosition;
        private Rect viewRect;

        public Vector2 ScrollPosition
        {
            get { return this.scrollPosition; }
            set { this.scrollPosition = value; }
        }

        public Rect ViewRect
        {
            get { return this.viewRect; }
            set { this.viewRect = value; }
        }

        protected override void DrawControl()
        {
            if (Style != null)
            {
                GUI.BeginScrollView(ControlRect, this.scrollPosition, this.viewRect, Style, Style);
            }
            else
            {
                GUI.BeginScrollView(ControlRect, this.scrollPosition, this.viewRect);
            }

            if (Controls != null)
            {
                foreach (Control obj in Controls)
                {
                    obj.OnGUI();
                }
            }

            GUI.EndScrollView();
        }
    }
}
