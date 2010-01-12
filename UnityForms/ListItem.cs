//-----------------------------------------------------------------------
// <copyright file="ListItem.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using UnityEngine;

    public class ListItem : Control
    {
        private object key;
        private bool selected;

        public object Key
        {
            get { return this.key; }
            set { this.key = value; }
        }

        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        public bool Selected
        {
            get { return this.selected; }
            set { this.selected = value; }
        }

        protected override void DrawControl()
        {
        }
    }
}
