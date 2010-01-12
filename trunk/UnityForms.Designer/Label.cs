namespace UnityForms
{
    using System.ComponentModel;
    using System.Drawing;
    using WinForms = System.Windows.Forms;

    [DesignTimeVisible(true), ToolboxItem(true)]
    public class Label : Control
    {
        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler MouseClick;

        [UnityFormAttribute()]
        [Browsable(true)]
        public event MouseEventHandler DoubleClick;

        protected override void OnPaint(WinForms.PaintEventArgs pe)
        {
            if (this.Size.Height != 22)
            {
                this.Size = new Size(this.Size.Width, 22);
            }

            base.OnPaint(pe);

            Rectangle area = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            PaintLibrary.Label(pe, area, this.Text, new Font("Arial", 14), StringAlignment.Center, StringAlignment.Center, Color.Black, false);
        }
    }
}
