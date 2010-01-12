using System;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;


namespace UnityForms
{
    internal class ListItemCollectionControlDesigner : ControlDesginer
    {
        private ListItemCollectionControl MyControl;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Record instance of control we're designing
            MyControl = (ListItemCollectionControl)component;

            // Hook up events
            ISelectionService s = (ISelectionService)GetService(typeof(ISelectionService));
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));
            s.SelectionChanged += new EventHandler(OnSelectionChanged);
            c.ComponentRemoving += new ComponentEventHandler(OnComponentRemoving);
        }

        private void OnSelectionChanged(object sender, System.EventArgs e)
        {
            MyControl.OnSelectionChanged();
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
                if (MyControl.Items.Contains(item))
                {
                    c.OnComponentChanging(MyControl, null);
                    MyControl.Items.Remove(item);
                    c.OnComponentChanged(MyControl, null, null, null);
                    return;
                }
            }

            // If the user is removing the control itself
            if (e.Component == MyControl)
            {
                for (i = MyControl.Items.Count - 1; i >= 0; i--)
                {
                    item = MyControl.Items[i];
                    c.OnComponentChanging(MyControl, null);
                    MyControl.Items.Remove(item);
                    h.DestroyComponent(item);
                    c.OnComponentChanged(MyControl, null, null, null);
                }
            }
        }

        protected override void Dispose(bool disposing)
        {
            ISelectionService s = (ISelectionService)GetService(typeof(ISelectionService));
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            // Unhook events
            s.SelectionChanged -= new EventHandler(OnSelectionChanged);
            c.ComponentRemoving -= new ComponentEventHandler(OnComponentRemoving);

            base.Dispose(disposing);
        }

        public override System.Collections.ICollection AssociatedComponents
        {
            get
            {
                return MyControl.Items;
            }
        }

        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection v = new DesignerVerbCollection();

                // Verb to add buttons
                v.Add(new DesignerVerb("&Add Item", new EventHandler(OnAddItem)));

                return v;
            }
        }

        private void OnAddItem(object sender, System.EventArgs e)
        {
            ListItem item;
            IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction dt;
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            // Add a new button to the collection
            dt = h.CreateTransaction("Add Item");
            item = (ListItem)h.CreateComponent(typeof(ListItem));
            c.OnComponentChanging(MyControl, null);
            item.Text = "new item";
            MyControl.Items.Add(item);
            c.OnComponentChanged(MyControl, null, null, null);
            dt.Commit();
        }

        protected override bool GetHitTest(System.Drawing.Point point)
        {
            Rectangle wrct;

            point = MyControl.PointToClient(point);

            foreach (ListItem item in MyControl.Items)
            {
                wrct = item.Bounds;
                if (wrct.Contains(point))
                    return true;
            }

            return false;
        }

    }
}
