namespace UnityForms
{
    using System.ComponentModel;
    using System.Drawing;
    using UnityEngine;

    [DesignTimeVisible(false), ToolboxItem(false)]
    public class Form : System.Windows.Forms.UserControl
    {
        [Browsable(false)]
        public GameObject gameObject;

        [Browsable(false)]
        public GUISkin Skin;

        [UnityFormAttribute()]
        [Browsable(true)]
        public new string Name { get { return base.Name; } set { base.Name = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new string Text { get { return base.Text; } set { base.Text = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public string ToolTip { get; set; }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new object Tag { get { return base.Tag; } set { base.Tag = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new Size Size { get { return base.Size; } set { base.Size = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public new Point Location { get { return base.Location; } set { base.Location = value; } }

        [UnityFormAttribute()]
        [Browsable(true)]
        public bool Draggable
        {
            get;
            set; 
        }

        [UnityFormAttribute()]
        [Browsable(true)]
        public UnityForms.WindowMode WindowMode
        {
            get;
            set; 
        }

        public Form()
        {
            components = new System.ComponentModel.Container();

            InitializeComponent();
        }

        public virtual void Initialize()
        {
        }

        public virtual void InitializeControls()
        {
        }

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // Form
            // 
            this.Name = "Form";
            this.Size = new System.Drawing.Size(693, 459);
            this.ResumeLayout(false);
        }

        #endregion
    }
}
