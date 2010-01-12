//-----------------------------------------------------------------------
// <copyright file="RepeatButton.cs" company="Marcelo Roca">
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

    public class RepeatButton : Control
    {
        #region Events

        public event EventHandler Click;

        public event MouseEventHandler MouseClick;

        #endregion

        #region Public Properties

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        #endregion

        #region Implements Control

        protected override void DrawControl()
        {
            bool button = false;

            if (Style == null)
            {
                button = UnityEngine.GUI.RepeatButton(ControlRect, Content);
            }
            else
            {
                button = UnityEngine.GUI.RepeatButton(ControlRect, Content, Style);
            }

            if (button)
            {
                if (Event.current.button == 0)
                {
                    if (this.Click != null)
                    {
                        this.Click(this, new EventArgs());
                    }
                }
                else if (Event.current.type == EventType.mouseDown)
                {
                    if (this.MouseClick != null)
                    {
                        this.MouseClick(this, new MouseEventArgs((MouseButton)Event.current.button));
                    }
                }
            }
        }

        #endregion
    }
}
