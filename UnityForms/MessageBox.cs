//-----------------------------------------------------------------------
// <copyright file="MessageBox.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using System.Drawing;
    using UnityEngine;

    public class MessageBox : Form
    {
        #region Private Variables

        private readonly System.Drawing.Size DEFAUTFORMLSIZE = new System.Drawing.Size(400, 300);

        private Button buttonAccept;
        private Label labelMessage;

        #endregion

        #region Public Properties

        public Label LabelMessage
        {
            get { return this.labelMessage; }
            set { this.labelMessage = value; }
        }

        #endregion

        #region Public Methods

        public static void Show(GameObject gameObject, string title, string message, GUISkin skin)
        {
            if (gameObject == null)
            {
                throw new ApplicationException("GameObject cannot be null");
            }

            MessageBox form = (MessageBox)FormsManager.LoadForm(gameObject, typeof(UnityForms_MessageBox), skin);

            form.LabelMessage.Text = message;
            form.Text = title;

            form.ShowModal();
        }

        #endregion

        #region Implements Form

        public override void Initialize()
        {
            this.InitializeComponent();
        }

        #endregion

        #region Private Methods

        private void InitializeComponent()
        {
            SuspendLayout();

            this.Size = this.DEFAUTFORMLSIZE;
            this.Location = Point.Empty;
            this.StartPosition = StartPosition.Center;
            this.Draggable = true;

            this.buttonAccept = (Button)this.Controls.Add(new Button());
            this.buttonAccept.Text = "Accept";
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.ToolTip = "Press to close";
            this.buttonAccept.Click += this.ButtonAccept_OnClick;
            this.buttonAccept.Size = new System.Drawing.Size(100, 20);
            this.buttonAccept.HorizontalAlignment = HorizontalAlignment.Center;
            this.buttonAccept.VerticalAlignment = VerticalAlignment.Botton;
            this.buttonAccept.Location = Point.Empty;

            this.labelMessage = (Label)this.Controls.Add(new Label());
            this.labelMessage.Text = string.Empty;
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(100, 20);
            this.labelMessage.Location = new Point(5, 5);

            ResumeLayout(false);
        }

        private void ButtonAccept_OnClick(object source, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}