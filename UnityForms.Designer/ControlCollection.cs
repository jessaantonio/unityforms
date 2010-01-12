using System;
using System.Collections.Generic;
using System.Text;

namespace UnityForms
{
    class ControlCollection : System.Windows.Forms.Control.ControlCollection
    {
        public ControlCollection(System.Windows.Forms.Control owner)
            : base(owner)
        {
        }
    }
}
