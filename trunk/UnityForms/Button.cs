//-----------------------------------------------------------------------
// <copyright file="Button.cs" company="Marcelo Roca">
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

    /// <summary>
    /// Implements UnityEngine.GUI.Button
    /// </summary>
    public class Button : Control
    {
        /// <summary>
        /// Raise when user click the left mouse button
        /// </summary>
        public event EventHandler Click;

        /// <summary>
        /// Raise when user click any mouse button over control
        /// </summary>
        public event MouseEventHandler MouseClick;

        /// <summary>
        /// Gets or sets texture of the control
        /// </summary>
        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        /// <summary>
        /// Draw the control
        /// </summary>
        protected override void DrawControl()
        {
            bool button;

            if (Style != null)
            {
                button = GUI.Button(ControlRect, Content, Style);
            }
            else
            {
                button = GUI.Button(ControlRect, Content);
            }

            if (button)
            {
                if (Event.current.button == 0)
                {
                    if (this.Click != null)
                    {
                        this.Click(this, new EventArgs());
                        Event.current.Use(); 
                    }
                }
                else if (Event.current.type == EventType.mouseDown)
                {
                    if (this.MouseClick != null)
                    {
                        this.MouseClick(this, new MouseEventArgs((MouseButton)Event.current.button));
                        Event.current.Use();
                    }
                }
            }
        }
    }
}
