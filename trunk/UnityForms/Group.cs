//-----------------------------------------------------------------------
// <copyright file="Group.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using UnityEngine;

    public class Group : ContainerControl
    {
        public Texture Image
        {
            get { return Content.image; }
            set { Content.image = value; }
        }

        protected override void DrawControl()
        {
            if (Style != null)
            {
                GUI.BeginGroup(ControlRect, Content, Style);
            }
            else
            {
                GUI.BeginGroup(ControlRect, Content);
            }

            if (Controls != null)
            {
                foreach (Control obj in Controls)
                {
                    obj.OnGUI();
                }
            }

            GUI.EndGroup();
        }
    }
}
