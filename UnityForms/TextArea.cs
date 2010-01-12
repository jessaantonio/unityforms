//-----------------------------------------------------------------------
// <copyright file="TextArea.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//---------

namespace UnityForms
{
    using System;
    using UnityEngine;

    public class TextArea : Control
    {
        private string text = string.Empty;
        private int maxLenght = -1;

        public event EventHandler TextChanged;

        public new string Text
        {
            get 
            { 
                return this.text; 
            }

            set 
            {
                this.text = value;
                if (this.TextChanged != null)
                {
                    this.TextChanged(this, new EventArgs());
                }
            }
        }

        public int MaxLenght
        {
            get { return this.maxLenght; }
            set { this.maxLenght = value; }
        }

        protected override void DrawControl()
        {
            string t;

            if (this.maxLenght < 0)
                {
                    if (Style != null)
                    {
                        t = GUI.TextArea(ControlRect, this.text, Style);
                    }
                    else
                    {
                        t = GUI.TextArea(ControlRect, this.text);
                    }
                }
                else
                {
                    if (Style != null)
                    {
                        t = GUI.TextArea(ControlRect, this.text, this.maxLenght, Style);
                    }
                    else
                    {
                        t = GUI.TextArea(ControlRect, this.text, this.maxLenght);
                    }
                }

            if (this.text != t)
            {
                this.Text = t;
            }
        }
    }
}
