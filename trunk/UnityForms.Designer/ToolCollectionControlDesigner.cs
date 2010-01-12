using System;

using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;


namespace UnityForms
{
    internal class ToolCollectionControlDesigner : ControlDesginer
    {
        private ToolCollectionControl MyControl;

        public override void Initialize(IComponent component)
        {
            base.Initialize(component);

            // Record instance of control we're designing
            MyControl = (ToolCollectionControl)component;

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
            ToolButton button;
            IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));
            int i;

            // If the user is removing a button
            if (e.Component is ToolButton)
            {
                button = (ToolButton)e.Component;
                if (MyControl.Tools.Contains(button))
                {
                    c.OnComponentChanging(MyControl, null);
                    MyControl.Tools.Remove(button);
                    c.OnComponentChanged(MyControl, null, null, null);
                    return;
                }
            }

            // If the user is removing the control itself
            if (e.Component == MyControl)
            {
                for (i = MyControl.Tools.Count - 1; i >= 0; i--)
                {
                    button = MyControl.Tools[i];
                    c.OnComponentChanging(MyControl, null);
                    MyControl.Tools.Remove(button);
                    h.DestroyComponent(button);
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
                return MyControl.Tools;
            }
        }

        public override System.ComponentModel.Design.DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection v = new DesignerVerbCollection();

                // Verb to add buttons
                v.Add(new DesignerVerb("&Add Button", new EventHandler(OnAddButton)));

                return v;
            }
        }

        private void OnAddButton(object sender, System.EventArgs e)
        {
            ToolButton button;
            IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction dt;
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            // Add a new button to the collection
            dt = h.CreateTransaction("Add Button");
            button = (ToolButton)h.CreateComponent(typeof(ToolButton));
            c.OnComponentChanging(MyControl, null);
            button.Text = "button";
            MyControl.Tools.Add(button);
            c.OnComponentChanged(MyControl, null, null, null);
            dt.Commit();
        }

        protected override bool GetHitTest(System.Drawing.Point point)
        {
            Rectangle wrct;

            point = MyControl.PointToClient(point);

            foreach (ToolButton button in MyControl.Tools)
            {
                wrct = button.Bounds;
                if (wrct.Contains(point))
                    return true;
            }

            return false;
        }

    }
}
