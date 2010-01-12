//-----------------------------------------------------------------------
// <copyright file="FormsManager.cs" company="Marcelo Roca">
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
    using UnityEngine;

    public static class FormsManager
    {
        #region Private Variables

        private static Dictionary<string, Form> formList = new Dictionary<string, Form>();
        private static Stack<string> formStack = new Stack<string>();
        private static int windowsCount = 0;

        #endregion

        #region Public Methods

        public static Form LoadForm(GameObject gameObject, Type formType, GUISkin defaultSkin)
        {
            if (gameObject == null)
            {
                throw new ApplicationException("GameObject cannot be null");
            }

            Form form = (Form) gameObject.AddComponent(formType);

            formList.Add(form.ID, form);

            form.Skin = defaultSkin;

            form.InitializeForm();

            form.OnLoad();

            return form;
        }

        public static void CloseForm(Form form)
        {
            form.OnClose();
            formList.Remove(form.ID);
        }

        #endregion

        #region Internal Methods

        internal static int NewWindowID()
        {
            return ++windowsCount;
        }

        internal static void PushModal(Form source)
        {
            if (!formList.ContainsKey(source.ID))
            {
                throw new ApplicationException("Form not registered in Manager");
            }

            if (formStack.Count == 0)
            {
                foreach (KeyValuePair<string, Form> item in formList)
                {
                    if (source != item.Value)
                    {
                        item.Value.Disabled = DisableMode.Form;
                    }
                }
            }
            else
            {
                formList[formStack.Peek()].Disabled = DisableMode.Form;
            }

            formStack.Push(source.ID);
        }

        internal static void PopModal()
        {
            if (formStack.Count == 1)
            {
                formStack.Pop();

                foreach (KeyValuePair<string, Form> item in formList)
                {
                    item.Value.Disabled = DisableMode.None;
                }
            }
            else
            {
                formStack.Pop();
                formList[formStack.Peek()].Disabled = DisableMode.None;
            }
        }

        #endregion
    }
}
