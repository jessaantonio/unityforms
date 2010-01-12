//-----------------------------------------------------------------------
// <copyright file="Toggle.cs" company="Marcelo Roca">
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

    public class Toggle : Control
    {
        private bool value = false;

        public event EventHandler CheckedChanged;

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        public bool Value
        {
            get 
            { 
                return this.value; 
            }

            set 
            {
                this.value = value;
                if (this.CheckedChanged != null)
                {
                    this.CheckedChanged(this, new EventArgs());
                }
            }
        }

        protected override void DrawControl()
        {
            bool val;

            if (Style != null)
            {
                val = GUI.Toggle(ControlRect, this.value, Content, Style);
            }
            else
            {
                val = GUI.Toggle(ControlRect, this.value, Content);
            }

            if (val != this.value)
            {
                this.Value = val;
            }
        }
    }
}
