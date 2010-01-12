//-----------------------------------------------------------------------
// <copyright file="PasswordField.cs" company="Marcelo Roca">
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

    public class PasswordField : Control
    {
        private string text = string.Empty;
        private int maxLenght = -1;
        private char maskChar = '*';

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

        public char MaskChar
        {
            get { return this.maskChar; }
            set { this.maskChar = value; }
        }

        protected override void DrawControl()
        {
            string t;

            if (Style != null)
            {
                if (this.MaxLenght == -1)
                {
                    t = GUI.PasswordField(ControlRect, this.text, this.maskChar, Style);
                }
                else
                {
                    t = GUI.PasswordField(ControlRect, this.text, this.maskChar, this.maxLenght, Style);
                }
            }
            else
            {
                if (this.MaxLenght == -1)
                {
                    t = GUI.PasswordField(ControlRect, this.text, this.maskChar);
                }
                else
                {
                    t = GUI.PasswordField(ControlRect, this.text, this.maskChar, this.maxLenght);
                }
            }

            if (this.Text != t)
            {
                this.Text = t;
            }
        }
    }
}
