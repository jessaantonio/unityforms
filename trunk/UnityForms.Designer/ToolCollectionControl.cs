using System;
using System.Drawing;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;


namespace UnityForms
{
	[Designer(typeof(ToolCollectionControlDesigner))]
	public class ToolCollectionControl : Control
	{
		protected ToolButtonCollection _tools;
        protected ToolButton _highlightedButton;

		public ToolCollectionControl()
		{
			SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);
			SetStyle(System.Windows.Forms.ControlStyles.AllPaintingInWmPaint, true);

			_tools = new ToolButtonCollection(this);
		}

        [UnityFormAttribute()]
        [Browsable(true)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
		public ToolButtonCollection Tools
		{
			get
			{
				return _tools;
			}
		}
   
        protected override void OnResize(System.EventArgs e)
		{
			base.OnResize(e);
		}

        protected virtual void CalculateBounds(System.Windows.Forms.PaintEventArgs e)
        {
       

        }

		protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
		{
            CalculateBounds(e);

            foreach (ToolButton tool in _tools)
            {
                PaintLibrary.Button(e, tool.Bounds.Location, tool.Bounds.Size, tool.Text, _highlightedButton == tool);
            }

		}

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			Rectangle wrct;
			ISelectionService s;
			ArrayList a;

			if (DesignMode)
			{
				foreach (ToolButton button in Tools)
				{
					wrct = button.Bounds;
					if (wrct.Contains(e.X, e.Y))
					{
						s = (ISelectionService) GetService(typeof(ISelectionService));
						a = new ArrayList();
						a.Add(button);
						s.SetSelectedComponents(a);
						break;
					}
				}
			}

			base.OnMouseDown(e);
		}

        internal void OnSelectionChanged()
        {
            ToolButton newHighlightedButton = null;
            ISelectionService s = (ISelectionService)GetService(typeof(ISelectionService));

            // See if the primary selection is one of our buttons
            foreach (ToolButton button in Tools)
            {
                if (s.PrimarySelection == button)
                {
                    newHighlightedButton = button;
                    break;
                }
            }

            // Apply if necessary
            if (newHighlightedButton != _highlightedButton)
            {
                _highlightedButton = newHighlightedButton;
                Invalidate();
            }
        }

    }

	
}
