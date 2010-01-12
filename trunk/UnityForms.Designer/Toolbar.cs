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
            if (_tools.Count == 1)
            {
                PaintLibrary.Button(e, new Point(0, 0), Size, this.Text, _highlightedButton == _tools[0]);
            }
            else if (_tools.Count > 1)
            {
                const int PADDING = 4;

                Size size = new Size((Size.Width / _tools.Count) - PADDING, Size.Height);
                Point location = new Point(0, 0);

                foreach (ToolButton tool in _tools)
                {
                    tool.Bounds = new Rectangle(location, size);
                    location.X += PADDING + size.Width;
                }
            }

        }
    }
}
