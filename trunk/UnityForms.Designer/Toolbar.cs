using System;
using System.Drawing;
using System.ComponentModel;

namespace UnityForms
{
    [DesignTimeVisible(true), ToolboxItem(true)]
    public class Toolbar : ToolCollectionControl
    {
        protected override void CalculateBounds(System.Windows.Forms.PaintEventArgs e)
        {
            if (tools.Count == 1)
            {
                PaintLibrary.Button(e, new Point(0, 0), Size, this.Text, highlightedButton == tools[0]);
            }
            else if (tools.Count > 1)
            {
                const int PADDING = 4;

                Size size = new Size((Size.Width / tools.Count) - PADDING, Size.Height);
                Point location = new Point(0, 0);

                foreach (ToolButton tool in tools)
                {
                    tool.Bounds = new Rectangle(location, size);
                    location.X += PADDING + size.Width;
                }
            }

        }
    }
}
