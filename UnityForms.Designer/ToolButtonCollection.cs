using System;
using System.Drawing;
using System.Collections;

namespace UnityForms
{
	public class ToolButtonCollection : CollectionBase
    {
        #region Private variables

        private ToolCollectionControl _control;

        #endregion

        internal ToolButtonCollection(ToolCollectionControl Control)
		{
			_control = Control;
		}

		public ToolButton this[int Index]
		{
			get
			{
				return (ToolButton) List[Index];
			}
		}

		public bool Contains(ToolButton Button)
		{
			return List.Contains(Button);
		}

		public int Add(ToolButton Button)
		{
			int i;

			i = List.Add(Button);
			Button.Control = _control;

            _control.Invalidate();
			return i;
		}

		public void Remove(ToolButton Button)
		{
			List.Remove(Button);
			Button.Control = null;
		}
	}
}
