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
    using System;
    using UnityEngine;
    
    public class ScrollView : ContainerControl
    {
        #region Private Variables

        private Vector2 scrollPosition;
        private Rect viewRect;

        #endregion

        #region Public Properties

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

        #endregion

        #region Implements

        protected override void DrawControl()
        {
            if (Style != null)
            {
                UnityEngine.GUI.BeginScrollView(ControlRect, this.scrollPosition, this.viewRect, Style, Style);
            }
            else
            {
                UnityEngine.GUI.BeginScrollView(ControlRect, this.scrollPosition, this.viewRect);
            }

            if (Controls != null)
            {
                foreach (Control obj in Controls)
                {
                    obj.OnGUI();
                }
            }

            UnityEngine.GUI.EndScrollView();
        }

        #endregion
    }
}
