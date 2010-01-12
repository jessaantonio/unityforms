//-----------------------------------------------------------------------
// <copyright file="SelectionChangeEventArgs.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;

    public class SelectionChangeEventArgs : EventArgs
    {
        private ListItem item;

        public SelectionChangeEventArgs(ListItem item)
        {
            this.item = item;
        }

        public ListItem Item
        {
            get
            {
                return this.item;
            }
        }
    }
}