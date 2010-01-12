//-----------------------------------------------------------------------
// <copyright file="TabPanel.cs" company="Marcelo Roca">
//     Copyright (c) 2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="mru@Marcelo Roca.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

using System;

namespace UnityForms
{
    public class TabPanel : ContainerControl
    {
        protected override void DrawControl()
        {
            throw new System.NotImplementedException();
        }

        public override void InitializeControl(Form parentForm, ContainerControl parent)
        {
            if (parent is Tab)
            {
                base.InitializeControl(parentForm, parent);
            }

            throw new ArgumentException("El contenedor solo puede ser un Tab", "parent");
        }
    }
}
