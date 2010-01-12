//-----------------------------------------------------------------------
// <copyright file="ListBox.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System.Collections.Generic;
    using UnityEngine;

    public class ListBox : ListContainerControl
    {
        private Vector2 scrollPosition;

        public List<Control>Items
        {
            get
            {
                return Controls;
            }
        }

        public override GUIStyle Style
        {
            get
            {
                if (base.Style == null)
                {
                    base.Style = new GUIStyle(Skin.box);
                }

                return base.Style;
            }

            set
            {
                base.Style = value;
            }
        }

        protected override void DrawControl()
        {
            GUIContent content = Content;
            content.text = string.Empty;

            if (this.Style != null)
            {
                GUILayout.BeginArea(ControlRect, content, this.Style);
            }
            else
            {
                GUILayout.BeginArea(ControlRect, content);
            }

            // desplegamos la lista en un area GUILayout
            {
                GUILayout.BeginVertical();
                {
                    this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, GUILayout.Width(this.Size.Width - 10), GUILayout.Height(this.Size.Height - 15));
                    {
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
                    }

                    GUILayout.EndScrollView();
                }

                GUILayout.EndVertical();
            }

            GUILayout.EndArea();
        }
    }
}
