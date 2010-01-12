using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using WinForms = System.Windows.Forms;
using System.ComponentModel;    
using System.ComponentModel.Design;

namespace UnityForms
{
    [DesignTimeVisible(true), ToolboxItem(true)]
    public class ListBox : ListItemCollectionControl
    {
        protected override void CalculateBounds(System.Windows.Forms.PaintEventArgs e)
        {
            if (_items.Count > 0)
            {
                const int PADDING = 2;

                Size size = new Size(this.Width - 2, 20);
                Point location = new Point(1, 1);

                foreach (ListItem tool in _items)
                {
                    tool.Bounds = new Rectangle(location, size);
                    location.Y += PADDING + 20;
                }
            }

        }

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            PaintLibrary.Box(pe, this.Size, "", true);
            base.OnPaint(pe);
        }
    }
}
