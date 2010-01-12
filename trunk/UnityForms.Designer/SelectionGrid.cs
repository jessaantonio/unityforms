using System;
using System.Drawing;
using System.ComponentModel;


namespace UnityForms
{
    public class SelectionGrid : ToolCollectionControl
    {
        private int _columns = 1;

        [UnityFormAttribute()]
        [Browsable(true)]
        public int Columns
        {
            get { return _columns; }
            set
            {
                _columns = value;
                Invalidate();
            }
        }


        protected override void CalculateBounds(System.Windows.Forms.PaintEventArgs e)
        {
            if (_tools.Count > 0)
            {
                const int PADDING = 4;
                int rows = (_tools.Count - 1) / Columns + 1;

                if (rows == 0)
                {
                    rows = 1;
                }

                Size size = new Size((Size.Width / Columns) - PADDING, (Size.Height / rows) - PADDING);
                Point location = new Point(0, 0);

                int i = 0;
                foreach (ToolButton tool in _tools)
                {
                    tool.Bounds = new Rectangle(location, size);
                    location.X += PADDING + size.Width;
                    if (++i >= Columns)
                    {
                        i = 0;
                        location.X = 0;
                        location.Y += PADDING + size.Height;
                    }
                }
            }
        }
    }
}
