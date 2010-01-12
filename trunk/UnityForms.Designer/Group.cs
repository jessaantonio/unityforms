namespace UnityForms
{
    using System.ComponentModel;
    using System.Drawing;

    //[Designer(typeof(ControlDesginer))]
    public class Group : System.Windows.Forms.ScrollableControl, System.Windows.Forms.IContainerControl
    {
        private System.Windows.Forms.Control activeControl;

        private string toolTip = "";
        private bool showToolTip = true;

        [UnityFormAttribute()]
        [Browsable(true)]
        public new string Name
        {
            get
            {
                return base.Name;
            } 

            set
            {
                base.Name = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new string Text
        {
            get
            {
                return base.Text;
            }
            
            set
            {
                base.Text = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public string ToolTip
        {
            get
            {
                return this.toolTip;
            } 
            
            set
            {
                this.toolTip = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new object Tag
        {
            get
            {
                return base.Tag;
            } 
            
            set
            {
                base.Tag = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new Size Size
        {
            get
            {
                return base.Size;
            } 
            
            set
            {
                base.Size = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new Point Location
        {
            get
            {
                return base.Location;
            } 
            
            set
            {
                base.Location = value;
            }
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public bool ShowToolTip
        {
            get
            {
                return this.showToolTip;
            } 
            
            set
            {
                this.showToolTip = value;
            }
        }


        protected override void OnPaint(System.Windows.Forms.PaintEventArgs pe)
        {
            base.OnPaint(pe);

            Font font = new Font("Arial", 14);
            StringFormat format = new StringFormat
                                      {
                                          Alignment = StringAlignment.Near,
                                          LineAlignment = StringAlignment.Near
                                      };

            pe.Graphics.DrawString(this.Text, font, new SolidBrush(Color.White), new Rectangle(0, 0, Size.Width, 20), format);
        }

        #region IContainerControl Members

        public bool ActivateControl(System.Windows.Forms.Control active)
        {
            if (this.Controls.Contains(active))
            {
                // Select the control and scroll the control into view if needed.
                active.Select();
                this.ScrollControlIntoView(active);
                this.activeControl = active;
                return true;
            }

            return false;
        }

        System.Windows.Forms.Control System.Windows.Forms.IContainerControl.ActiveControl
        {
            get
            {
                return this.activeControl;
            }

            set
            {
                // Make sure the control is a member of the ControlCollection.
                if (this.Controls.Contains(value))
                {
                    this.activeControl = value;
                }

            }
        }

        #endregion
    }
}
