using System;
using System.Drawing;
using System.Collections;

namespace UnityForms
{
	public class ListItemCollection: CollectionBase
    {
        #region Private variables

        private ListItemCollectionControl _control;

        #endregion

        internal ListItemCollection(ListItemCollectionControl control)
		{
			_control = control;
		}

        public ListItem this[int index]
		{
			get
			{
                return (ListItem)List[index];
			}
		}

        public bool Contains(ListItem item)
		{
			return List.Contains(item);
		}

		public int Add(ListItem item)
		{
			int i;

			i = List.Add(item);
			item.Control = _control;

            _control.Invalidate();
			return i;
		}

        public void Remove(ListItem item)
		{
			List.Remove(item);
			item.Control = null;
		}
	}
}
