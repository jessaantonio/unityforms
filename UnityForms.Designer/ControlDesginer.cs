namespace UnityForms
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;

    class ControlDesginer : System.Windows.Forms.Design.ControlDesigner
    {
        protected override void PreFilterProperties(System.Collections.IDictionary properties)
        {
            base.PreFilterProperties(properties);

            object[] list = new string[properties.Keys.Count];

            int i = 0;
            foreach (object key in properties.Keys)
            {
                list[i++] = key;
            }

            foreach (object key in list)
            {
                PropertyDescriptor old = (PropertyDescriptor)properties[key];

                if (old != null && !old.Attributes.Contains(new UnityFormAttribute()))
                {
                    List<Attribute> copiedAtts = CopyAttributes(old, typeof(BrowsableAttribute));
                    copiedAtts.Add(BrowsableAttribute.No);
                    properties[key] = TypeDescriptor.CreateProperty(old.ComponentType, old, copiedAtts.ToArray());
                }
            }
        }

        protected override void PreFilterEvents(System.Collections.IDictionary events)
        {
            base.PreFilterEvents(events);

            object[] list = new string[events.Keys.Count];

            int i = 0;
            foreach (object key in events.Keys)
            {
                list[i++] = key;
            }

            foreach (object key in list)
            {
                EventDescriptor old = (EventDescriptor)events[key];

                if (old != null && !old.Attributes.Contains(new UnityFormAttribute()))
                {
                    List<Attribute> copiedAtts = CopyAttributes(old, typeof(BrowsableAttribute));
                    copiedAtts.Add(BrowsableAttribute.No);
                    events[key] = TypeDescriptor.CreateEvent(old.ComponentType, old, copiedAtts.ToArray());
                }
            }
        }

        private List<Attribute> CopyAttributes(EventDescriptor descriptor, params Type[] exclusions)
        {
            List<Attribute> ret = new List<Attribute>();
            List<Type> exclusionList = new List<Type>(exclusions);

            foreach (Attribute att in descriptor.Attributes)
            {
                if (!exclusionList.Contains(att.GetType()))
                {
                    ret.Add(att);
                }
            }
            return ret;
        }

        private List<Attribute> CopyAttributes(PropertyDescriptor descriptor, params Type[] exclusions)
        {
            List<Attribute> ret = new List<Attribute>();
            List<Type> exclusionList = new List<Type>(exclusions);

            foreach (Attribute att in descriptor.Attributes)
            {
                if (!exclusionList.Contains(att.GetType()))
                {
                    ret.Add(att);
                }
            }
            return ret;
        }
    }
}
