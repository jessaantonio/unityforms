//-----------------------------------------------------------------------
// <copyright file="ListControl.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System.Collections.Generic;

    public abstract class ListControl : ContainerControl
    {
        #region Private Variables

        private SelectionMode selectionMode = SelectionMode.One;

        #endregion

        #region Events

        public event SelectionChangeEventHandler SelectionChange;

        #endregion

        #region Public Properties

        public SelectionMode SelectionMode
        {
            get
            {
                return this.selectionMode;
            }

            set
            {
                if (this.selectionMode != value)
                {
                    this.selectionMode = value;

                    if (this.selectionMode != SelectionMode.Multiple)
                    {
                        this.ClearSelection();
                    }
                }
            }
        }

        #endregion

        #region Public Methods

        public void ClearSelection()
        {
            this.ClearSelection(null);
        }

        public void InvertSelection()
        {
            if (this.selectionMode == SelectionMode.Multiple)
            {
                foreach (ListItem item in Controls)
                {
                    item.Selected = !item.Selected;
                    if (this.SelectionChange != null)
                    {
                        this.SelectionChange(this, new SelectionChangeEventArgs(item));
                    }
                }
            }
        }

        public void SelectAll()
        {
            this.SelectAll(null);
        }

        public List<ListItem> SelectedItems()
        {
            List<ListItem> selectedList = new List<ListItem>();

            foreach (ListItem item in Controls)
            {
                if (item.Selected)
                {
                    selectedList.Add(item);
                }
            }

            return selectedList;
        }

        #endregion

        #region Protected Methods

        protected void ClearSelection(ListItem except)
        {
            foreach (ListItem item in Controls)
            {
                if (item.Selected && item != except)
                {
                    item.Selected = false;
                    if (this.SelectionChange != null)
                    {
                        this.SelectionChange(this, new SelectionChangeEventArgs(item));
                    }
                }
            }
        }

        protected void SelectAll(ListItem except)
        {
            foreach (ListItem item in Controls)
            {
                if (!item.Selected && item != except)
                {
                    item.Selected = true;

                    if (this.SelectionChange != null)
                    {
                        this.SelectionChange(this, new SelectionChangeEventArgs(item));
                    }
                }
            }
        }

        protected void RaiseEventSelectionChange(SelectionChangeEventArgs e)
        {
            if (this.SelectionChange != null)
            {
                this.SelectionChange(this, e);
            }
        }

        #endregion
    }
}
