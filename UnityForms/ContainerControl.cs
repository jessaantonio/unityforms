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
        /// <summary>
        /// list of controls
        /// </summary>
        private readonly List<Control> controls = new List<Control>();

        /// <summary>
        /// You must set the AllowDrop property to allow for dragging and dropping to this control
        /// </summary>
        private bool allowDrop = false;

        /// <summary>
        /// the front control 
        /// </summary>
        private Control frontControl;

        /// <summary>
        /// Gets or sets a value indicating whether AllowDrop.
        /// </summary>
        public bool AllowDrop
        {
            get { return this.allowDrop; }
            set { this.allowDrop = value; }
        }

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

        /// <summary>
        /// Retorna un control especifico
        /// </summary>
        /// <param name="index">
        /// El indice del control
        /// </param>
        /// <returns>
        /// El control requerido
        /// </returns>
        public Control this[int index]
        {
            get
            {
                if (index >= 0 && index < this.controls.Count)
                {
                    return this.controls[index];
                }

                throw new ArgumentException("Indice incorrecto", "index");
            }

            set
            {
                this.controls[index] = value;
            }
        }

        /// <summary>
        /// Adiciona un contro al contenedor
        /// </summary>
        /// <param name="control">El contro a adicionar</param>
        /// <returns>El control adicionado</returns>
        public virtual Control Add(Control control)
        {
            this.controls.Add(control);
            return control;
        }

        /// <summary>
        /// Indica si el control existe en el contenedor
        /// </summary>
        /// <param name="control">el control</param>
        /// <returns>true si el control existe</returns>
        public bool Contains(Control control)
        {
            return this.controls.Contains(control);
        }

        /// <summary>
        /// Elimina un control de la lista, primero verifica si existe en el
        /// </summary>
        /// <param name="control">el control</param>
        /// <returns>true si el control fue eliminado</returns>
        public bool Removes(Control control)
        {
            if (this.Contains(control))
            {
                return this.Controls.Remove(control);
            }

            return false;
        }

        /// <summary>
        /// Manda un control al frente
        /// </summary>
        /// <param name="control">
        /// El control que va al frente
        /// </param>
        public void BringToFront(Control control)
        {
            if (this.frontControl == null || this.frontControl.ID != control.ID)
            {
                this.frontControl = this.controls.Contains(control) ? control : null;
            }
        }

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A IEnumerator that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<Control> GetEnumerator()
        {
            return this.controls.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An IEnumerator object that can be used to iterate through the collection.
        /// </returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.controls.GetEnumerator();
        }

        /// <summary>
        /// Inicializa el contenedor
        /// </summary>
        protected override void Initialize()
        {
            for (int i = 0; i < this.controls.Count; i++)
            {
                this.controls[i].InitializeControl(this.ParentForm, this);
                ParentForm.AddDictionaryControl(this.controls[i]);
            }
        }

        /// <summary>
        /// Pinta los controles internos
        /// </summary>
        /// <returns>
        /// Retorna la cantidad de controles pintados
        /// </returns>
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
                    foreach (Control obj in this.controls)
                    {
                        if (this.frontControl == null || this.frontControl.ID != obj.ID)
                        {
                            if (!SuspendedLayout)
                            {
                                obj.OnGUI();
                            }
                            else
                            {
                                break;
                            }
                        }
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

        /// <summary>
        /// Pinta un control especifico
        /// </summary>
        /// <param name="index">
        /// El indice del control
        /// </param>
        /// <returns>
        /// La cantidad de controles pintados
        /// </returns>
        protected int DrawInnerControls(int index)
        {
            if (this.controls != null && index < this.controls.Count)
            {
                this.controls[index].OnGUI();

                return 1;
            }

            return 0;
        }
    }
}
