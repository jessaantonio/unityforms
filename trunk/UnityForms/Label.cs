//-----------------------------------------------------------------------
// <copyright file="Label.cs" company="Marcelo Roca">
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

    public class Label : Control
    {
        #region Public Events

        public event MouseEventHandler MouseClick;

        public event MouseEventHandler DoubleClick;
        
        #endregion

        #region Protected Properties

        public new bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        #endregion

        #region Implements Control

        protected override void DrawControl()
        {
            if (Style != null)
            {
                GUI.Label(ControlRect, Content, Style);
            }
            else
            {
                GUI.Label(ControlRect, Content);
            }

            // detectar si es doble click
            if ((Event.current.type == EventType.mouseDown) && this.ControlRect.Contains(Event.current.mousePosition))
            {
                if (Event.current.clickCount == 2)
                {
                    if (this.DoubleClick != null)
                    {
                        this.DoubleClick(this, new MouseEventArgs((MouseButton)Event.current.button));
                        Event.current.Use();
                    }
                }
                else
                {
                    if (this.MouseClick != null)
                    {
                        this.MouseClick(this, new MouseEventArgs((MouseButton)Event.current.button));
                    }
                }

                Event.current.Use();
            }
        }

        protected override void ResizeControl()
        {
            if (this.AutoSize)
            {
                try
                {
                    Vector2 size = Style.CalcSize(Content);
                    __Size = new System.Drawing.Size((int)size.x, (int)size.y);
                }
                catch
                {
                }
            }
        }

        #endregion
    }
}
