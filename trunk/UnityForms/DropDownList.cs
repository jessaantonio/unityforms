//-----------------------------------------------------------------------
// <copyright file="DropDownList.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using UnityEngine;

    /// <summary>
    /// Lista despeglable
    /// </summary>
    public class DropDownList : ListControl
    {
        #region Private Variables

        /// <summary>
        /// Estilo de la caja que muestra la lista de items
        /// </summary>
        private GUIStyle boxStyle;

        /// <summary>
        /// Posición del scroll dentro de la lista
        /// </summary>
        private Vector2 scrollPosition;

        /// <summary>
        /// Indica si la lista se está o no desplegando
        /// </summary>
        private bool dropDown = false;

        #endregion

        #region public Properties

        /// <summary>
        /// Gets or set el estilo del control que muestra el item seleccionado
        /// </summary>
        public override GUIStyle Style
        {
            get
            {
                if (base.Style == null)
                {
                    base.Style = new GUIStyle(Skin.textField);
                }

                return base.Style;
            }

            set
            {
                base.Style = value;
            }
        }

        /// <summary>
        /// Gets or sets el estilo de la caja que contiene los items a seleccionar
        /// </summary>
        public GUIStyle BoxStyle
        {
            get
            {
                if (this.boxStyle == null)
                {
                    this.boxStyle = new GUIStyle(Skin.box);
                }

                return this.boxStyle;
            }

            set
            {
                this.boxStyle = value;
            }
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Dibujamos el control GUI
        /// </summary>
        protected override void DrawControl()
        {
            if (GUI.Button(this.ControlRect, this.GetCaption(), this.Style))
            {
                this.dropDown = !this.dropDown;
            }

            if (this.dropDown)
            {
                Parent.BringToFront(this);

                GUIContent content = Content;
                content.text = string.Empty;

                // TODO: hay que sacar los valores estáticos y utilizar propiedades
                Rect pos = new Rect(ControlRect.x, ControlRect.y + ControlRect.height + 5, ControlRect.width, 100);

                GUILayout.BeginArea(pos, content, this.BoxStyle);
                GUILayout.BeginVertical();

                // TODO: hay que sacar los valores estáticos y utilizar propiedades
                this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, GUILayout.Width(ControlRect.width - 10), GUILayout.Height(85));

                foreach (ListItem item in Controls)
                {
                    GUILayout.BeginHorizontal();

                    bool selected;

                    switch (SelectionMode)
                    {
                        case SelectionMode.None:
                            GUILayout.Toggle(false, item.Content);
                            break;

                        case SelectionMode.One:
                            selected = GUILayout.Toggle(item.Selected, item.Content);
                            if (selected != item.Selected)
                            {
                                item.Selected = selected;
                                if (item.Selected)
                                {
                                    ClearSelection(item);
                                }

                                this.dropDown = !this.dropDown;

                                RaiseEventSelectionChange(new SelectionChangeEventArgs(item));
                            }

                            break;

                        case SelectionMode.Multiple:
                            selected = GUILayout.Toggle(item.Selected, item.Content);

                            if (selected != item.Selected)
                            {
                                item.Selected = selected;

                                RaiseEventSelectionChange(new SelectionChangeEventArgs(item));
                            }

                            break;
                    }

                    GUILayout.EndHorizontal();
                }

                GUILayout.EndScrollView();
                GUILayout.EndVertical();
                GUILayout.EndArea();
            }
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Obtenemos el titulo que se mostrará en el el texto, se obtiene de unir todos 
        /// los items seleccionados
        /// </summary>
        /// <returns>Texto que se colocará en el campo de texto</returns>
        private string GetCaption()
        {
            string caption = string.Empty;

            foreach (ListItem item in Controls)
            {
                if (item.Selected)
                {
                    caption = caption + (caption == string.Empty ? string.Empty : ", ") + item.Content.text;
                }
            }

            return caption;
        }

        #endregion
    }
}
