//-----------------------------------------------------------------------
// <copyright file="VerticalScrollbar.cs" company="Marcelo Roca">
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

    public class VerticalScrollbar : Control
    {
        private float value = 0;
        private ValueType valueType = ValueType.Float;
        private float visibleSize = 0;
        private float max = 100;
        private float min = 0;

        public event EventHandler ValueChanged;

        public float Value
        {
            get 
            { 
                return this.value; 
            }

            set 
            {
                this.value = value;
                if (this.ValueChanged != null)
                {
                    this.ValueChanged(this, new EventArgs());
                }
            }
        }

        public ValueType ValueType
        {
            get { return this.valueType; }
            set { this.valueType = value; }
        }

        public float VisibleSize
        {
            get { return this.visibleSize; }
            set { this.visibleSize = value; }
        }

        public float Max
        {
            get { return this.max; }
            set { this.max = value; }
        }

        public float Min
        {
            get { return this.min; }
            set { this.min = value; }
        }

        protected override void DrawControl()
        {
            float val;

            if (ValueType == ValueType.Float)
            {
                if (Style != null)
                {
                    val = UnityEngine.GUI.VerticalScrollbar(ControlRect, this.value, this.visibleSize, this.max, this.min, Style);
                }
                else
                {
                    val = UnityEngine.GUI.VerticalScrollbar(ControlRect, this.value, this.visibleSize, this.max, this.min);
                }
            }
            else
            {
                if (Style != null)
                {
                    val = UnityEngine.GUI.VerticalScrollbar(ControlRect, (int)this.value, this.visibleSize, this.max, this.min, Style);
                }
                else
                {
                    val = UnityEngine.GUI.VerticalScrollbar(ControlRect, (int)this.value, this.visibleSize, this.max, this.min);
                }
            }

            if (val != this.value)
            {
                this.Value = val;
            }
        }
    }
}
