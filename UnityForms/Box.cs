//-----------------------------------------------------------------------
// <copyright file="Box.cs" company="Marcelo Roca">
//     Copyright (c) 2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="mru@Marcelo Roca.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using UnityEngine;

    /// <summary>
    /// Despliega una caja (UnityEngine.GUI.Box)
    /// Es un contenedor simple
    /// </summary>
    public class Box : Control
    {
        /// <summary>
        /// Se ejecuta cuando el usuario ha presionado el botón del mouse sobre el control
        /// </summary>
        public event MouseEventHandler MouseClick;

        /// <summary>
        /// Se ejecuta cuando el usuario ha presionado dos veces (doble Click) el botón del mouse sobre el control
        /// </summary>
        public event MouseEventHandler DoubleClick;

        /// <summary>
        /// Gets or sets la imágen que se mostrará en la caja
        /// </summary>
        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        /// <summary>
        /// Pinta el control
        /// </summary>
        protected override void DrawControl()
        {
            if (Style != null)
            {
                GUI.Box(ControlRect, Content, Style);
            }
            else
            {
                GUI.Box(ControlRect, Content);
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
    }
}
