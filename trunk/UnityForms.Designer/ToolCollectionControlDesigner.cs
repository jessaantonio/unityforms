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

            // If the user is removing a button
            if (e.Component is ToolButton)
            {
                button = (ToolButton)e.Component;
                if (this.MyControl.Tools.Contains(button))
                {
                    c.OnComponentChanging(this.MyControl, null);
                    this.MyControl.Tools.Remove(button);
                    c.OnComponentChanged(this.MyControl, null, null, null);
                    return;
                }
            }

            // If the user is removing the control itself
            if (e.Component == this.MyControl)
            {
                for (int i = this.MyControl.Tools.Count - 1; i >= 0; i--)
                {
                    button = this.MyControl.Tools[i];
                    c.OnComponentChanging(this.MyControl, null);
                    this.MyControl.Tools.Remove(button);
                    h.DestroyComponent(button);
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
                return MyControl.Tools;
            }
        }

        public override DesignerVerbCollection Verbs
        {
            get
            {
                DesignerVerbCollection v = new DesignerVerbCollection
                                               {
                                                   new DesignerVerb("&Add Button", OnAddButton)
                                               };

                // Verb to add buttons
                return v;
            }
        }

        private void OnAddButton(object sender, EventArgs e)
        {
            ToolButton button;
            IDesignerHost h = (IDesignerHost)GetService(typeof(IDesignerHost));
            DesignerTransaction dt;
            IComponentChangeService c = (IComponentChangeService)GetService(typeof(IComponentChangeService));

            // Add a new button to the collection
            dt = h.CreateTransaction("Add Button");
            button = (ToolButton)h.CreateComponent(typeof(ToolButton));
            c.OnComponentChanging(this.MyControl, null);
            button.Text = "button";
            this.MyControl.Tools.Add(button);
            c.OnComponentChanged(this.MyControl, null, null, null);
            dt.Commit();
        }

        protected override bool GetHitTest(System.Drawing.Point point)
        {
            Rectangle wrct;

            point = this.MyControl.PointToClient(point);

            foreach (ToolButton button in this.MyControl.Tools)
            {
                wrct = button.Bounds;
                if (wrct.Contains(point))
                {
                    return true;
                }
            }

            return false;
        }

    }
}
