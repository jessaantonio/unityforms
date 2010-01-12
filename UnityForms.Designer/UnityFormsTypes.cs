using System;
using UnityEngine;
using System.ComponentModel;

namespace UnityForms
{
   


    public enum DisableMode
    {
        None,
        Form,
        Content,
        ContentExcept
    }
    
    /// <summary>
    ///   Specifies the System.Windows.Forms.ComboBox style.
    /// </summary>
    public enum ComboBoxStyle
    {
        /// <summary>
        /// The text portion is editable. The user must click the arrow button to display
        /// the list portion. This is the default style.
        /// </summary>
        DropDown = 1,
        /// <summary>
        /// The user cannot directly edit the text portion. The user must click the arrow
        /// button to display the list portion. The list displays only if System.Windows.Forms.ComboBox.AutoCompleteMode
        /// is System.Windows.Forms.AutoCompleteMode.Suggest or System.Windows.Forms.AutoCompleteMode.SuggestAppend.
        /// </summary>
        DropDownList = 2
    }

    /// <summary>
    /// Specifies the selection behavior of a list box.
    /// </summary>
    public enum SelectionMode
    {
        /// <summary>
        /// No items can be selected.
        /// </summary>
        None = 0,
        /// <summary>
        /// Only one item can be selected.
        /// </summary>
        One = 1,
        /// <summary>
        /// Multiple items can be selected.
        /// </summary>
        Multiple = 2
    }

    public enum MouseButton
    {
        Left = 0,
        Middle = 1,
        Right = 2
    }

    public enum VerticalAlignment
    {
        Manual,
        Top,
        Middle,
        Botton
    }

    public enum HorizontalAlignment
    {
        Manual,
        Left,
        Center,
        Right
    }


    public enum FormMode
    {
        Modal,
        Modeless
    }

    public enum WindowMode
    {
        None,
        Window,
    }

    public enum BorderStyle
    {
        None,
        Border
    }

    public enum WindowState
    {
        Normal,
        Maximized,
        Minimized,
        Hidden,
    }

    public enum StartPosition
    {
        Manual,
        Center
    }

    public enum ValueType
    {
        Integer,
        Float
    }

   





}
