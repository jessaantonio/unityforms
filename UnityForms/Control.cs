//-----------------------------------------------------------------------
// <copyright file="Control.cs" company="Marcelo Roca">
//     Copyright (c) 2010 Marcelo Roca. All rights reserved.
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

    public abstract class Control
    {
        #region Private Variables

        private Rect controlRect;

        /// <summary>
        /// Identificador del control (valor único)
        /// </summary>
        private readonly string id = Guid.NewGuid().ToString();

        /// <summary>
        /// Nombre del control
        /// </summary>
        private string name = string.Empty;

        /// <summary>
        /// Orden de tabulación
        /// </summary>
        private int tabIndex = 0;

        /// <summary>
        /// Un tag para que el programador pueda utilizar
        /// </summary>
        private object tag;

        private GUIContent content = new GUIContent();

        /// <summary>
        /// El contenedor al que pertenece
        /// </summary>
        private ContainerControl parent = null;

        /// <summary>
        /// El formulario al que pertenece
        /// </summary>
        private Form parentForm = null;

        /// <summary>
        /// Indica si muestra o no el tooltip
        /// </summary>
        private bool showToolTip = true;

        /// <summary>
        /// El estilo utilizado para desplegar el control
        /// </summary>
        private GUIStyle style;

        /// <summary>
        /// El skin utilizado para desplegar el control
        /// </summary>
        private GUISkin skin;

        /// <summary>
        /// Indica si el control está o no visible
        /// </summary>
        private bool visible = true;

        /// <summary>
        /// Indica si el contro está o no habilitado (es o no editable)
        /// </summary>
        private bool enabled = true;

        /// <summary>
        /// El mensaje tooltip a mostrar
        /// </summary>
        private string tooltip = string.Empty;

        /// <summary>
        /// Indica si tiene el foco
        /// </summary>
        private bool focus = false;

        /// <summary>
        /// Indica si el control debe ser redibujado 
        /// </summary>
        private bool invalidated = true;

        /// <summary>
        /// Indica si el control debe modificar su tamaño automaticamente de 
        /// acuerdo al tamaño del contenido
        /// </summary>
        private bool autoSize = false;

        /// <summary>
        /// Indica el modo de alineamiento horizontal
        /// </summary>
        private HorizontalAlignment horizontalAlignment = HorizontalAlignment.Manual;

        /// <summary>
        /// Indica el modo de alineamiento vertical
        /// </summary>
        private VerticalAlignment verticalAlignment = VerticalAlignment.Manual;

        #endregion

        #region Public Events

        /// <summary>
        /// Cuando el cursor del mouse está encima
        /// </summary>
        public event EventHandler MouseOver;

        /// <summary>
        /// Cuando el cursos del mouse sale del control
        /// </summary>
        public event EventHandler MouseOut;

        /// <summary>
        /// Cuando el control ha cambiado de tamaño
        /// </summary>
        public event EventHandler Resize;

        #endregion

        #region public Properties

        /// <summary>
        /// Gets or sets a value indicating whether ShowToolTip needs to show or not.
        /// </summary>
        public bool ShowToolTip
        {
            get { return this.showToolTip; }
            set { this.showToolTip = value; }
        }

        /// <summary>
        /// Gets Content.
        /// </summary>
        public GUIContent Content
        {
            get
            {
                this.content.tooltip = this.id;
                return this.content;
            }
        }

        /// <summary>
        /// Gets or sets Text.
        /// </summary>
        public string Text
        {
            get
            {
                return this.Content.text;
            }

            set
            {
                if (this.Content.text != value)
                {
                    this.Content.text = value;
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets HorizontalAlignment.
        /// </summary>
        public HorizontalAlignment HorizontalAlignment
        {
            get
            {
                return this.horizontalAlignment;
            }

            set
            {
                if (this.horizontalAlignment != value)
                {
                    this.horizontalAlignment = value;
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets VerticalAlignment.
        /// </summary>
        public VerticalAlignment VerticalAlignment
        {
            get
            {
                return this.verticalAlignment;
            }

            set
            {
                if (this.verticalAlignment != value)
                {
                    this.verticalAlignment = value;
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets Name.
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }

            set
            {
                this.name = value;
            }
        }

        /// <summary>
        /// Gets or sets TabIndex.
        /// </summary>
        public int TabIndex
        {
            get
            {
                return this.tabIndex;
            }

            set
            {
                this.tabIndex = value;
            }
        }

        /// <summary>
        /// Gets a value indicating whether Disabled.
        /// </summary>
        public bool Disabled
        {
            get
            {
                return this.ParentForm.Disabled == DisableMode.None;
            }
        }

        /// <summary>
        /// Gets ID of the control.
        /// </summary>
        public string ID
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets or sets ToolTip.
        /// </summary>
        public string ToolTip
        {
            get { return this.tooltip; }
            set { this.tooltip = value; }
        }

        /// <summary>
        /// Gets or sets Tag.
        /// </summary>
        public object Tag
        {
            get { return this.tag; }
            set { this.tag = value; }
        }

        /// <summary>
        /// Gets or sets Size of the control.
        /// </summary>
        public virtual Size Size
        {
            get
            {
                // TODO verificar si esto esta bien o comos erá el autosize
                if (this.invalidated)
                {
                    this.ResizeControl();
                    this.invalidated = false;
                }

                return new Size((int)this.controlRect.width, (int)this.controlRect.height);
            }

            set
            {
                if (new Size((int)this.controlRect.width, (int)this.controlRect.height) != value)
                {
                    this.controlRect = new Rect(this.controlRect.x, this.controlRect.y, value.Width, value.Height);
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets Location.
        /// </summary>
        public Point Location
        {
            get
            {
                return new Point((int)this.controlRect.x, (int)this.controlRect.y);
            }

            set
            {
                Rect r = new Rect(value.X, value.Y, this.controlRect.width, this.controlRect.height);

                if (r != this.controlRect)
                {
                    this.controlRect = r;
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets Style.
        /// </summary>
        public virtual GUIStyle Style
        {
            get
            {
                return this.style;
            }

            set
            {
                if (this.style != value)
                {
                    this.style = value;
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets or sets Skin.
        /// </summary>
        public GUISkin Skin
        {
            get
            {
                if (this.skin == null)
                {
                    return this.ParentForm.Skin;
                }

                return this.skin;
            }

            set
            {
                if (this.skin != value)
                {
                    this.skin = value;
                    this.invalidated = true;
                }
            }
        }

        /// <summary>
        /// Gets Parent container.
        /// </summary>
        public ContainerControl Parent
        {
            get
            {
                return this.parent;
            }

            private set
            {
               

                if (this.parent == value)
                {
                    return;
                }

                if (this.parent == null)
                {
                    this.parent = value;
                }
                else
                {
                    this.SuspendLayout();

                    this.parent.Removes(this);
                    this.parent = value;
                    this.parent.Add(this);
                    

                    if (this is ContainerControl)
                    {
                        foreach (Control children in ((ContainerControl)this).Controls)
                        {
                            children.Parent = value;
                        }
                    }

                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Gets ParentForm.
        /// </summary>
        public Form ParentForm
        {
            get
            {
                return this.parentForm;
            }

            private set
            {
                if (this.parentForm == value)
                {
                    return;
                }
                
                if (this.parentForm == null)
                {
                    this.parentForm = value;
                }
                else 
                {
                    this.SuspendLayout();

                    this.parentForm.RemoveDictionaryControl(this);
                    this.parentForm = value;
                    this.parentForm.AddDictionaryControl(this);

                    if (this is ContainerControl)
                    {
                        foreach (Control children in ((ContainerControl)this).Controls)
                        {
                            children.ParentForm = value;
                        }
                    }

                    this.ResumeLayout();
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is Visible.
        /// </summary>
        public bool Visible
        {
            get { return this.visible; }
            set { this.visible = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether Enabled (can be edited).
        /// </summary>
        public bool Enabled
        {
            get
            {
                if (this.Parent == null || this.Parent.Enabled)
                {
                    // si no tiene un contenedor retornamos el estado del control
                    return this.ParentForm.Enabled ? this.enabled : false;
                }

                // retornamos no habilitado
                return false;
            }

            set
            {
                this.enabled = value;
            }
        }

        #endregion

        #region internal properties

        internal string TypeName
        {
            get
            {
                return this.name + " [" + this.GetType().Name + "]";
            }
        }

        #endregion

        #region Protected Properties

        /// <summary>
        /// used in internal operations
        /// </summary>
        protected Size __Size
        {
            get
            {
                return new Size((int)this.controlRect.width, (int)this.controlRect.height);
            }

            set
            {
                this.controlRect = new Rect(this.controlRect.x, this.controlRect.y, value.Width, value.Height);
            }
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

        protected bool AutoSize
        {
            get
            {
                return this.autoSize;
            }

            set
            {
                this.autoSize = value;
                if (this.autoSize && this.autoSize != value)
                {
                    this.invalidated = true;
                }
            }
        }

        protected bool Invalidated
        {
            get
            {
                return this.invalidated;
            }

            set
            {
                this.invalidated = value;
            }
        }

        protected Rect ControlRect
        {
            get
            {
                return this.controlRect;
            }

            set
            {
                this.controlRect = value;
            }
        }

        #endregion

        #region Public Methods

        public void InitializeControl(Form parentForm, ContainerControl parent)
        {
            this.Parent = parent;
            this.ParentForm = parentForm;

            this.Initialize();
        }

        public void Move(ContainerControl container)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            this.ParentForm = container.ParentForm;
            this.Parent = container;
        }

        #endregion

        #region Internal Methods

        internal void OnGUI()
        {
            if (this.Visible)
            {
                GUI.skin = this.Skin;
                GUI.enabled = this.Enabled;
                GUI.SetNextControlName(this.ID);

                this.PerformLayout();
                this.DrawControl();
            }
        }

        internal void RaiseEventMouseOut()
        {
            if (this.MouseOut != null)
            {
                this.MouseOut(this, new EventArgs());
            }
        }

        internal void RaiseEventMouseOver()
        {
            if (this.MouseOver != null)
            {
                this.MouseOver(this, new EventArgs());
            }
        }

        internal void SetFocus()
        {
            this.Focus = true;
        }

        #endregion

        #region Abstract & Virtual Methods

        protected abstract void DrawControl();

        protected virtual void Initialize()
        {
        }

        protected virtual void ResizeControl()
        {
        }

        #endregion

        private bool suspendedLayout;

        protected bool SuspendedLayout
        {
            get
            {
                return this.suspendedLayout;
            }

            set
            {
                this.suspendedLayout = value; 
            }
        }

        protected void SuspendLayout()
        {
            this.SuspendedLayout = true;
        }

        protected void ResumeLayout()
        {
            this.SuspendedLayout = false;
        }

        #region Private Methods

        private void PerformLayout()
        {
            if (this.invalidated && !this.SuspendedLayout)
            {
                this.ResizeControl();

                // calculamos las posiciones de acuerdo a los margenes
                if (this.parent != null)
                {
                    int x = this.Location.X;
                    int y = this.Location.Y;

                    switch (this.HorizontalAlignment)
                    {
                        case HorizontalAlignment.Left:
                            x = 0;
                            break;

                        case HorizontalAlignment.Center:
                            x = (this.Parent.Size.Width / 2) - (this.Size.Width / 2);
                            break;

                        case HorizontalAlignment.Right:
                            x = this.Parent.Size.Width - this.Size.Width;
                            break;
                    }

                    switch (this.VerticalAlignment)
                    {
                        case VerticalAlignment.Top:
                            y = 0;
                            break;
                        case VerticalAlignment.Middle:
                            y = (this.Parent.Size.Height / 2) - (this.Size.Height / 2);
                            break;
                        case VerticalAlignment.Botton:
                            y = this.Parent.Size.Height - this.Size.Height;
                            break;
                    }

                    this.Location = new Point(x, y);
                }

                this.invalidated = false;

                if (this.Resize != null)
                {
                    this.Resize(this, new EventArgs());
                }
            }
        }

        #endregion
    }
}