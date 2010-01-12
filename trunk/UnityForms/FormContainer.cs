//-----------------------------------------------------------------------
// <copyright file="FormContainer.cs" company="Marcelo Roca">
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

    public class FormContainer : ContainerControl
    {
        #region Private variables

        private System.Drawing.Size size = System.Drawing.Size.Empty;
        private Rect clientRect;

        #endregion

        #region Public Properties

        public override System.Drawing.Size Size
        {
            get { return this.size; }
            set { }
        }

        #endregion

        #region Protected Methods

        protected override void DrawControl()
        {
            GUIClip.Push(this.clientRect);
            DrawInnerControls();
            GUIClip.Pop();
        }

        protected override void Initialize()
        {
            base.Initialize();

            this.Location = new System.Drawing.Point(0, 0);
            this.CalculateClientSize();
        }

        #endregion

        #region Private Methods

        private void CalculateClientSize()
        {
            if (this.ParentForm == null)
            {
                throw new ApplicationException("Tiene que ser parte de un formulario");
            }

            if (this.Parent != null)
            {
                throw new ApplicationException("No puede ser parte de otro contenedor");
            }

            RectOffset padding = this.ParentForm.Style.padding;
            System.Drawing.Size formSize = this.ParentForm.Size;

            this.size = new System.Drawing.Size(formSize.Width - padding.horizontal, formSize.Height - padding.vertical);
            this.clientRect = new Rect(padding.left, padding.top, formSize.Width - padding.right, formSize.Height - padding.bottom);
        }

        #endregion 
    }
}
