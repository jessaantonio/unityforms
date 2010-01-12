//-----------------------------------------------------------------------
// <copyright file="Tab.cs" company="Marcelo Roca">
//     Copyright (c) 2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="mru@Marcelo Roca.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace UnityForms
{
    public class Tab : ContainerControl
    {
        public List<Control> Tabs
        {
            get
            {
                return Controls;
            }
        }

        protected override void DrawControl()
        {
            throw new System.NotImplementedException();
        }

        public override Control Add(Control control)
        {
            if (control is TabPanel)
            {
                return base.Add(control);
            }

            throw new ArgumentException("the control must be a TabPanel", "control");
        }

        public TabPanel Add(TabPanel control)
        {
            return (TabPanel)base.Add(control);
        }
    }
}
