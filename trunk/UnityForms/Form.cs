//-----------------------------------------------------------------------
// <copyright file="Form.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using UnityEngine;

    public abstract class Form : MonoBehaviour
    {
        private SizeF autoScaleDimensions;
        private int windowID = FormsManager.NewWindowID();
        private Dictionary<string, Control> controlDictionary = new Dictionary<string, Control>();
        private string lastTooltip = string.Empty;
        private string id = Guid.NewGuid().ToString();
        private FormMode formMode;
        private WindowMode formBorderStyle = WindowMode.Window;
        private bool visible = false;
        private bool draggable = false;
        private GUIContent content = new GUIContent();
        private Rect positionRect;
        private GUIStyle style;
        private DisableMode disabled = DisableMode.None;
        private bool focus = false;
        private bool showToolTips = true;
        private System.Windows.Forms.AutoScaleMode autoScaleMode;
        private Size clientSize;
        private GUISkin skin;
        private FormContainer controls = new FormContainer();
        private StartPosition startPosition = StartPosition.Manual;
        private bool layoutChanged;
        private bool layoutSuspended;
        private ToolTip toolTip;

        public System.Windows.Forms.AutoScaleMode AutoScaleMode
        {
            get { return this.autoScaleMode; }
            set { this.autoScaleMode = value; }
        }

        public StartPosition StartPosition
        {
            get { return this.startPosition; }
            set { this.startPosition = value; }
        }

        public FormContainer Controls
        {
            get { return this.controls; }
        }

        public SizeF AutoScaleDimensions
        {
            get { return this.autoScaleDimensions; }
            set { this.autoScaleDimensions = value; }
        }

        public Size ClientSize
        {
            get { return this.clientSize; }
            set { this.clientSize = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public bool ShowToolTips
        {
            get { return this.showToolTips; }
            set { this.showToolTips = value; }
        }

        public GUIStyle Style
        {
            get
            {
                if (this.style == null)
                {
                    this.style = this.Skin.window;
                }

                return this.style;
            }

            set
            {
                this.style = value;
            }
        }

        public string Text
        {
            get { return this.Content.text; }
            set { this.Content.text = value; }
        }

        public Texture Image
        {
            get { return this.Content.image; }
            set { this.Content.image = value; }
        }

        public bool Draggable
        {
            get { return this.draggable; }
            set { this.draggable = value; }
        }

        public int WindowID
        {
            get { return this.windowID; }
            set { this.windowID = value; }
        }

        public string ID
        {
            get { return this.id; }
        }

        public string Tag
        {
            get { return tag; }
            set { tag = value; }
        }

        public WindowMode WindowMode
        {
            get { return this.formBorderStyle; }
            set { this.formBorderStyle = value; }
        }

        public FormMode FormMode
        {
            get { return this.formMode; }
            private set { this.formMode = value; }
        }

        /// <summary>
        /// Gets or sets Size of the form.
        /// </summary>
        public Size Size
        {
            get
            {
                return new Size((int)this.positionRect.width, (int)this.positionRect.height);
            }

            set
            {
                this.positionRect.width = value.Width;
                this.positionRect.height = value.Height;
            }
        }

        /// <summary>
        /// Gets or sets Location of the form in the screen.
        /// </summary>
        public Point Location
        {
            get
            {
                return new Point((int)this.positionRect.x, (int)this.positionRect.y);
            }

            set
            {
                this.positionRect.x = value.X;
                this.positionRect.y = value.Y;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the form is Enabled.
        /// </summary>
        public bool Enabled
        {
            get
            {
                return this.disabled == DisableMode.Form ? false : enabled;
            }

            set
            {
                enabled = value;
            }
        }

        /// <summary>
        /// Gets or sets if the form is Disabled.
        /// </summary>
        /// <remarks>
        /// Es utilizada internamente pos el FormsManager para hacer ventanas
        /// modales o modeless
        /// </remarks>
        public DisableMode Disabled
        {
            get { return this.disabled; }
            set { this.disabled = value; }
        }

        /// <summary>
        /// Gets a value indicating whether the form is Visible.
        /// </summary>
        public bool Visible
        {
            get { return this.visible; }
            private set { this.visible = value; }
        }

        /// <summary>
        /// Gets or sets the Skin of the control.
        /// </summary>
        public GUISkin Skin
        {
            get
            {
                try
                {
                    if (this.skin == null)
                    {
                        this.skin = GUIUtility.GetBuiltinSkin(0);
                    }
                }
                catch 
                {
                    this.skin = null;
                }

                return this.skin;
            }

            set
            {
                if (value == null)
                {
                    this.skin = GUIUtility.GetBuiltinSkin(0);
                }
                else if (this.skin != value)
                {
                    this.skin = value;
                }
            }
        }

        protected bool LayoutChanged
        {
            get { return this.layoutChanged; }
            set { this.layoutChanged = value; }
        }

        protected bool LayoutSuspended
        {
            get { return this.layoutSuspended; }
            set { this.layoutSuspended = value; }
        }

        protected bool Focus
        {
            get
            {
                bool f = this.focus;
                this.focus = false;
                return f;
            }

            set
            {
                this.focus = value;
            }
        }

        protected GUIContent Content
        {
            get
            {
                this.content.tooltip = this.id;
                return this.content;
            }
        }

        public void OnGUI()
        {
            if (this.visible)
            {
                this.BeforeOnGUI();
                this.toolTip.Skin = this.Skin;

                GUI.skin = this.Skin;
                GUI.enabled = this.Enabled;
                GUI.SetNextControlName(this.ID);

                if (this.WindowMode == WindowMode.Window)
                {
                    if (this.style != null)
                    {
                        this.positionRect = UnityEngine.GUI.Window(this.windowID, this.positionRect, this.DoWindow, this.Content, this.style);
                    }
                    else
                    {
                        this.positionRect = UnityEngine.GUI.Window(this.windowID, this.positionRect, this.DoWindow, this.Content);
                    }

                    if (this.Enabled)
                    {
                        if (this.FormMode == FormMode.Modal || this.Focus)
                        {
                            GUI.FocusWindow(this.windowID);
                            GUI.BringWindowToFront(this.windowID);
                        }
                    }
                }
                else
                {
                    this.DoWindowLess();
                }

                this.AfterOnGUI();
            }
        }

        public abstract void Initialize();

        public virtual void OnLoad()
        {
        }

        public virtual void OnClose()
        {
        }

        public void SetFocus()
        {
            this.Focus = true;
        }

        public void ShowModal()
        {
            FormMode = FormMode.Modal;
            FormsManager.PushModal(this);
            this.visible = true;
            this.SetFocus();
        }

        public void Show()
        {
            this.FormMode = FormMode.Modeless;
            this.visible = true;
            this.SetFocus();
        }

        public void Close()
        {
            if (FormMode == FormMode.Modal)
            {
                FormsManager.PopModal();
            }

            FormsManager.CloseForm(this);
            Destroy(this);
        }

        public void Hide()
        {
            this.visible = false;
        }

        public void InitializeForm()
        {
            this.Initialize();

            if (this.startPosition == StartPosition.Center)
            {
                this.Location = new Point((Screen.width / 2) - (this.Size.Width / 2), (Screen.height / 2) - (this.Size.Height / 2));
            }

            this.controls.InitializeControl(this, null);

            this.toolTip = (ToolTip)gameObject.AddComponent(typeof(UnityForms_ToolTip));
        }

        internal void AddDictionaryControl(Control source)
        {
            this.controlDictionary.Add(source.ID, source);
        }

        internal void RemoveDictionaryControl(Control source)
        {
            string id = source.ID;

            if (this.controlDictionary.ContainsKey(id))
            {
                this.controlDictionary.Remove(id);
            }
        }

        protected virtual void BeforeOnGUI()
        {
        }

        protected virtual void AfterOnGUI()
        {
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        protected void ChangeLayout()
        {
            this.layoutChanged = true;
        }

        protected void SuspendLayout()
        {
            this.layoutSuspended = true;
        }

        protected void ResumeLayout(bool b)
        {
            this.layoutSuspended = false;
        }

        private void DoWindow(int w)
        {
            // mostramos los controles internos
            this.controls.OnGUI();

            // si no está habilitado
            if (!this.Enabled)
            {
                // la ventana para atras
                GUI.BringWindowToBack(this.WindowID);

                // no se muestran los tooltips
                this.toolTip.ClearToolTip();
            }
            else
            {
                // hacemos que la ventana sea o no dragable
                if (this.Draggable)
                {
                    GUI.DragWindow();
                }

                // manejamos el tooltip
                Control ctrl;

                if (Event.current.type == EventType.repaint && GUI.tooltip != this.lastTooltip)
                {
                    if (this.lastTooltip != string.Empty && this.controlDictionary.ContainsKey(this.lastTooltip))
                    {
                        ctrl = this.controlDictionary[this.lastTooltip];
                        ctrl.RaiseEventMouseOut();
                        this.toolTip.ClearToolTip();
                    }

                    if (GUI.tooltip != string.Empty && this.controlDictionary.ContainsKey(GUI.tooltip))
                    {
                        ctrl = this.controlDictionary[GUI.tooltip];
                        ctrl.RaiseEventMouseOver();

                        if (this.showToolTips)
                        {
                            this.toolTip.ShowToolTip(ctrl);
                        }
                    }

                    this.lastTooltip = GUI.tooltip;
                }
            }
        }

        private void DoWindowLess()
        {
            // mostramos los controles internos
            this.controls.OnGUI();

            // si no está habilitada
            if (!this.Enabled)
            {
                // no mostramos los tooltips
                this.toolTip.ClearToolTip();
            }
            else
            {
                // hacemos el manejo del tooltip
                if (Event.current.type == EventType.repaint && GUI.tooltip != this.lastTooltip)
                {
                    if (this.lastTooltip != string.Empty && this.controlDictionary.ContainsKey(this.lastTooltip))
                    {
                        Control ctrl = this.controlDictionary[this.lastTooltip];
                        ctrl.RaiseEventMouseOut();
                        this.toolTip.ClearToolTip();
                    }

                    if (GUI.tooltip != string.Empty && this.controlDictionary.ContainsKey(GUI.tooltip))
                    {
                        Control ctrl = this.controlDictionary[GUI.tooltip];
                        ctrl.RaiseEventMouseOver();

                        if (this.showToolTips)
                        {
                            this.toolTip.ShowToolTip(ctrl);
                        }
                    }

                    this.lastTooltip = GUI.tooltip;
                }
            }
        }
    }
}
