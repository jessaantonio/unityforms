//-----------------------------------------------------------------------
// <copyright file="Delegates.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;

    public delegate void MouseEventHandler(object sender, MouseEventArgs e);

    public delegate void ToolClickEventHandler(object sender, ToolClickEventArgs e);

    public delegate void SelectionChangeEventHandler(object sender, SelectionChangeEventArgs e);
}
