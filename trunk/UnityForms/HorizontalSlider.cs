//-----------------------------------------------------------------------
// <copyright file="HorizontalSlider.cs" company="Marcelo Roca">
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

    public class HorizontalSlider : Control
    {
        private float value = 0;
        private ValueType valueType = ValueType.Float;
        private float max = 100;
        private float min = 0;
        private GUIStyle styleThumb;
        private string styleThumbName = null;

        public event EventHandler ValueChanged;

        public GUIStyle StyleThumb
        {
            get
            {
                if (this.styleThumb != null)
                {
                    return this.styleThumb;
                }

                return Skin.GetStyle(this.styleThumbName);
            }

            set 
            {
                this.styleThumb = value; 
            }
        }

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

            if (this.ValueType == ValueType.Float)
            {
                if (this.Style != null)
                {
                    val = GUI.HorizontalSlider(this.ControlRect, this.Value, this.Min, this.Max, this.Style, this.StyleThumb);
                }
                else
                {
                    val = GUI.HorizontalSlider(this.ControlRect, this.Value, this.Min, this.Max);
                }
            }
            else
            {
                if (this.Style != null)
                {
                    val = GUI.HorizontalSlider(this.ControlRect, (int)this.Value, this.Min, this.Max, this.Style, this.StyleThumb);
                }
                else
                {
                    val = GUI.HorizontalSlider(this.ControlRect, (int)this.Value, this.Min, this.Max);
                }
            }

            if (val != this.Value)
            {
                this.Value = val;
            }
        }
    }
}
