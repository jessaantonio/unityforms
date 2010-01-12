namespace UnityForms
{
    using System.Collections;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;

    [Designer(typeof(ListItemCollectionControlDesigner))]
    public class ListItemCollectionControl : Control
    {
        protected ListItemCollection items;
        protected ListItem highlightedItem;

        public ListItemCollectionControl()
        {
            SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
            SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);

            this.items = new ListItemCollection(this);
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public new ListItemCollection Items
        {
            get
            {
                return this.items;
            }
        }

        protected virtual void CalculateBounds(System.Windows.Forms.PaintEventArgs e)
        {
        }

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            this.CalculateBounds(e);

            foreach (ListItem item in this.items)
            {
                Rectangle area = new Rectangle(item.Bounds.Location, item.Bounds.Size);
                PaintLibrary.Label(e, area, item.Text, new Font("Arial", 14), StringAlignment.Near, StringAlignment.Center, Color.Black, this.highlightedItem == item);
            }
        }

        protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
        {
            Rectangle wrct;
            ISelectionService s;

            if (DesignMode)
            {
                foreach (ListItem item in this.Items)
                {
                    wrct = item.Bounds;

                    if (wrct.Contains(e.X, e.Y))
                    {
                        s = (ISelectionService)GetService(typeof(ISelectionService));
                        ArrayList a = new ArrayList { item };
                        s.SetSelectedComponents(a);
                        break;
                    }
                }
            }

            base.OnMouseDown(e);
        }

        internal void OnSelectionChanged()
        {
            ListItem newHighlightedItem = null;
            ISelectionService s = (ISelectionService)GetService(typeof(ISelectionService));

            // See if the primary selection is one of our buttons
            foreach (ListItem item in this.items)
            {
                if (s.PrimarySelection == item)
                {
                    newHighlightedItem = item;
                    break;
                }
            }

            // Apply if necessary
            if (newHighlightedItem != this.highlightedItem)
            {
                this.highlightedItem = newHighlightedItem;
                Invalidate();
            }
        }
    }
}
