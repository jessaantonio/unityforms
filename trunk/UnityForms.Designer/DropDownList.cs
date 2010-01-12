namespace UnityForms
{
    using System.ComponentModel;
    using System.Drawing;
    using WinForms = System.Windows.Forms;

    [DesignTimeVisible(true), ToolboxItem(true)]
    public class DropDownList : ListItemCollectionControl
    {
        protected override void CalculateBounds(System.Windows.Forms.PaintEventArgs e)
        {
            if (items.Count > 0)
            {
                const int PADDING = 2;

                Size size = new Size(this.Width - 2, 20);
                Point location = new Point(1, 1);

                foreach (ListItem tool in items)
                {
                    tool.Bounds = new Rectangle(location, size);
                    location.Y += PADDING + 20;
                }
            }
        }

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            if (this.Size.Height != 22)
            {
                this.Size = new Size(this.Size.Width, 22);
            }
            
            PaintLibrary.Box(pe, this.Size, "", true);
        }
    }
}
