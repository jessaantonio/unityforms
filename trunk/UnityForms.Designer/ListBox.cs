namespace UnityForms
{
    using System.ComponentModel;
    using System.Drawing;
    using WinForms = System.Windows.Forms;

    [DesignTimeVisible(true), ToolboxItem(true)]
    public class ListBox : ListItemCollectionControl
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public SelectionMode SelectionMode
        {
            get; set;
        }

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
            PaintLibrary.Box(pe, this.Size, string.Empty, true);
            base.OnPaint(pe);
        }

        public System.Collections.Generic.List<ListItem> SelectedItems()
        {
            throw new System.NotImplementedException();
        }
    }
}
