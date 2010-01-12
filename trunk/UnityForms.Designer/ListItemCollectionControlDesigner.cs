namespace UnityForms
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.Design;
    using System.Drawing;

    internal class ListItemCollectionControlDesigner : ControlDesginer
    {
        private ListItemCollectionControl MyControl;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Record instance of control we're designing
            this.MyControl = (ListItemCollectionControl)component;

            // Hook up events
            ISelectionService s = (ISelectionService)GetService(typeof(ISelectionService));
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            s.SelectionChanged += this.OnSelectionChanged;
            c.ComponentRemoving += this.OnComponentRemoving;
        }

        private void OnSelectionChanged(object sender, System.EventArgs e)
        {
            this.MyControl.OnSelectionChanged();
        }

        private void OnComponentRemoving(object sender, ComponentEventArgs e)
        {
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            ListItem item;
            IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));
            int i;

            // If the user is removing a button
            if (e.Component is ListItem)
            {
                item = (ListItem)e.Component;
                if (this.MyControl.Items.Contains(item))
                {
                    c.OnComponentChanging(this.MyControl, null);
                    this.MyControl.Items.Remove(item);
                    c.OnComponentChanged(this.MyControl, null, null, null);
                    return;
                }
            }

            // If the user is removing the control itself
            if (e.Component == this.MyControl)
            {
                for (i = this.MyControl.Items.Count - 1; i >= 0; i--)
                {
                    item = this.MyControl.Items[i];
                    c.OnComponentChanging(this.MyControl, null);
                    this.MyControl.Items.Remove(item);
                    h.DestroyComponent(item);
                    c.OnComponentChanged(this.MyControl, null, null, null);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            ISelectionService s = (ISelectionService)GetService(typeof(ISelectionService));
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            // Unhook events
            s.SelectionChanged -= this.OnSelectionChanged;
            c.ComponentRemoving -= this.OnComponentRemoving;

            base.Dispose(disposing);
        }

        public override System.Collections.ICollection AssociatedComponents
        {
            get
            {
                return this.MyControl.Items;
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection v = new DesignerVerbCollection();

                // Verb to add buttons
                v.Add(new DesignerVerb("&Add Item", this.OnAddItem));

                return v;
            }
        }

        private void OnAddItem(object sender, EventArgs e)
        {
            ListItem item;
            IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction dt;
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            // Add a new button to the collection
            dt = h.CreateTransaction("Add Item");
            item = (ListItem)h.CreateComponent(typeof(ListItem));
            c.OnComponentChanging(this.MyControl, null);
            item.Text = "new item";
            this.MyControl.Items.Add(item);
            c.OnComponentChanged(this.MyControl, null, null, null);
            dt.Commit();
        }

        protected override bool GetHitTest(Point point)
        {
            Rectangle wrct;

            point = this.MyControl.PointToClient(point);

            foreach (ListItem item in this.MyControl.Items)
            {
                wrct = item.Bounds;
                if (wrct.Contains(point))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
