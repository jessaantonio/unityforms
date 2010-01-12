//-----------------------------------------------------------------------
// <copyright file="ContainerControl.cs" company="Marcelo Roca">
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

    /// <summary>
    /// Container control
    /// </summary>
    public abstract class ContainerControl : Control, IEnumerable<Control>
    {
        #region Private Variables

        /// <summary>
        /// list of controls
        /// </summary>
        private List<Control> controls = new List<Control>();

        /// <summary>
        /// the front control 
        /// </summary>
        private Control frontControl = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the count of controls in the list
        /// </summary>
        public int Count
        {
            get { return this.controls.Count; }
        }

        /// <summary>
        /// Gets the control list
        /// </summary>
        public List<Control> Controls
        {
            get { return this.controls; }
        }

        #endregion

        #region Public Methods

        public Control this[int index]
        {
            get
            {
                if (index >= 0 && index < this.controls.Count)
                {
                    return this.controls[index];
                }

                throw new ApplicationException("Indice incorrecto");
            }

            set
            {
                this.controls[index] = value;
            }
        }

        /// <summary>
        /// Add a control
        /// </summary>
        /// <param name="control">the control</param>
        /// <returns>the added control</returns>
        public virtual Control Add(Control control)
        {
            this.controls.Add(control);
            return control;
        }

        /// <summary>
        /// Indica si el control existe en la lista
        /// </summary>
        /// <param name="control">el control</param>
        /// <returns>true si el control existe</returns>
        public bool Contains(Control control)
        {
            return this.controls.Contains(control);
        }

        /// <summary>
        /// Indica si el control existe en la lista
        /// </summary>
        /// <param name="control">el control</param>
        /// <returns>true si el control existe</returns>
        public bool Removes(Control control)
        {
            if (this.Contains(control))
            {
                return this.Controls.Remove(control);
            }

            return false;
        }

        public void BringToFront(Control control)
        {
            if (this.frontControl == null || this.frontControl.ID != control.ID)
            {
                if (this.controls.Contains(control))
                {
                    this.frontControl = control;
                }
                else
                {
                    this.frontControl = null;
                }
            }
        }

        #endregion

        #region IEnumerable

        public IEnumerator<Control> GetEnumerator()
        {
            return this.controls.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.controls.GetEnumerator();
        }

        #endregion

        #region Implements Control

        protected override void Initialize()
        {
            for (int i = 0; i < this.controls.Count; i++)
            {
                this.controls[i].InitializeControl(this.ParentForm, this);
                ParentForm.AddDictionaryControl(this.controls[i]);
            }
        }

        #endregion

        #region Protected Methods

        protected int DrawInnerControls()
        {
            if (this.controls != null)
            {
                if (this.frontControl != null)
                {
                    this.frontControl.OnGUI();
                }

                if (!SuspendedLayout)
                {
                    try
                    {
                        foreach (Control obj in this.controls)
                        {
                            if (this.frontControl == null || this.frontControl.ID != obj.ID)
                            {
                                obj.OnGUI();
                            }
                        }
                    }
                    catch
                    {
                    }
                }

                if (this.frontControl != null)
                {
                    this.frontControl.OnGUI();
                }

                return this.controls.Count;
            }

            return 0;
        }

        protected int DrawInnerControls(int index)
        {
            if (this.controls != null && index < this.controls.Count)
            {
                this.controls[index].OnGUI();

                return 1;
            }

            return 0;
        }

        #endregion
    }
}
