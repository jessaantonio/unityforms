namespace UnityForms
{
    using System;
    using System.ComponentModel;
    using System.Drawing;

    [DesignTimeVisible(true), ToolboxItem(true)]
    public class Button : Control 
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public new event EventHandler Click;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler MouseClick;

        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);
            PaintLibrary.Button(pe, new Point(0,0), this.Size, this.Text, false);
        }
    }
}
