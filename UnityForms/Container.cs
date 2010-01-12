//-----------------------------------------------------------------------
// <copyright file="Container.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using System.Text;

    /// <summary>
    /// Implements ContainerControl
    /// </summary>
    public class Container : ContainerControl
    {
        /// <summary>
        /// Draw the control
        /// </summary>
        protected override void DrawControl()
        {
            DrawInnerControls();
        }
    }
}
