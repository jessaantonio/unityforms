//-----------------------------------------------------------------------
// <copyright file="DrawTexture.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using UnityEngine;

    public class DrawTexture : Control
    {
        private Texture image;
        private ScaleMode scaleMode = ScaleMode.StretchToFill;
        private bool alphaBlend = true;
        private float imageAspect = 0;
      
        public Texture Image
        {
            get
            {
                return this.image;
            }

            set
            {
                this.image = value;
            }
        }

        public ScaleMode ScaleMode
        {
            get
            {
                return this.scaleMode;
            }

            set
            {
                this.scaleMode = value;
            }
        }

        public bool AlphaBlend
        {
            get
            {
                return this.alphaBlend;
            }

            set
            {
                this.alphaBlend = value;
            }
        }

        public float ImageAspect
        {
            get
            {
                return this.imageAspect;
            }

            set
            {
                this.imageAspect = value;
            }
        }

        protected override void DrawControl()
        {
            GUI.DrawTexture(this.ControlRect, this.Image, this.ScaleMode, this.AlphaBlend, this.ImageAspect);
        }
    }
}
