//-----------------------------------------------------------------------
// <copyright file="ToolTip.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using UnityEngine;

    public class ToolTip : MonoBehaviour
    {
        private Rect position;
        private Control control;
        private bool visible = false;
        private float showTime;
        private GUISkin skin;
        private float delaySeconds = 3;
        private Vector2 labelSize;
        private int minWidth = 100;

        public GUISkin Skin
        {
            get 
            {
                if (this.skin == null)
                {
                    this.skin = GUIUtility.GetBuiltinSkin(0);
                }

                return this.skin; 
            }

            set 
            {
                this.skin = value; 
            }
        }

        public void OnGUI()
        {
            if (this.visible)
            {
                GUI.depth = 0;

                this.position = new Rect(Input.mousePosition.x + 5, Screen.height - Input.mousePosition.y + 5, this.labelSize.x, this.labelSize.y);

                GUI.Label(this.position, this.control.ToolTip, this.Skin.box);

                if (Time.time - this.showTime > this.delaySeconds)
                {
                    this.visible = false; 
                }
            }
        }

        public void ShowToolTip(Control control)
        {
            if (control != null && this.control != control)
            {
                this.control = control;
                this.visible = control.ShowToolTip && !string.IsNullOrEmpty(control.ToolTip);
                this.showTime = Time.time;
                this.labelSize = this.Skin.box.CalcSize(new GUIContent(control.ToolTip));

                if (this.labelSize.x < this.minWidth)
                {
                    this.labelSize.x = this.minWidth;
                }
            }
        }

        public void ClearToolTip()
        {
            this.visible = false;
            this.control = null;
        }
    }
}
