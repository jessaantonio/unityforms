
using System;
using System.Drawing;
using System.ComponentModel;


namespace UnityForms
{
    [DesignTimeVisible(true), ToolboxItem(true)]
    public class Box : Control
    {

        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler MouseClick;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler DoubleClick;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
            PaintLibrary.Box(pe, this.Size, this.Text, false);
        }
    }
}
