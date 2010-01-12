//-----------------------------------------------------------------------
// <copyright file="Types.cs" company="Marcelo Roca">
//     Copyright (c) 2009-2010 Marcelo Roca. All rights reserved.
// </copyright>
// <license see="prj:///doc/license.txt"/>
// <author name="Marcelo Roca" email="marcelo.roca.urioste@gmail.com"/>
// <version>$Revision: 1 $</version>
//----------------------------------------------------------------------

namespace UnityForms
{
    using System;
    using System.ComponentModel;
    using UnityEngine;

    /// <summary>
    /// Que tipos de desabilitación se va a utilizar para los filtros
    /// </summary>
    public enum DisableMode
    {
        /// <summary>
        /// No se deshabilita
        /// </summary>
        None,

        /// <summary>
        /// El formulario
        /// </summary>
        Form,

        /// <summary>
        /// El contenido
        /// </summary>
        Content,

        /// <summary>
        /// El contenido exceptuando
        /// </summary>
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

    /// <summary>
    /// Botón que fue presionado en el Mouse
    /// </summary>
    public enum MouseButton
    {
        /// <summary>
        /// Botón izquierdo
        /// </summary>
        Left = 0,

        /// <summary>
        /// Botón del central
        /// </summary>
        Middle = 1,

        /// <summary>
        /// Botón de la derecha
        /// </summary>
        Right = 2
    }

    /// <summary>
    /// Modo de alineación vertical de un control
    /// </summary>
    public enum VerticalAlignment
    {
        /// <summary>
        /// Manual, el control se quedará en la misma posición
        /// </summary>
        Manual,

        /// <summary>
        /// El control se colocará arriba
        /// </summary>
        Top,

        /// <summary>
        /// El control se colocará al centro
        /// </summary>
        Middle,

        /// <summary>
        /// El control se colocará abajo
        /// </summary>
        Botton
    }

    /// <summary>
    /// Modo de alineación horizontal de un control
    /// </summary>
    public enum HorizontalAlignment
    {
        /// <summary>
        /// Manual, el control se quedará en la misma posición
        /// </summary>
        Manual,

        /// <summary>
        /// El control se colocará a la izquierda
        /// </summary>
        Left,

        /// <summary>
        /// El control se colocará al centro
        /// </summary>
        Center,

        /// <summary>
        /// El control se colocará a la derecha
        /// </summary>
        Right
    }

    /// <summary>
    /// Modo como se mostrará el formulario
    /// </summary>
    public enum FormMode
    {
        /// <summary>
        /// Se abrirá el formulario como único, los otros formularios quedarán deshabilitados
        /// </summary>
        Modal,

        /// <summary>
        /// Se abrirá el formulario sin deshabilitar los otros
        /// </summary>
        Modeless
    }

    /// <summary>
    /// Modo de la ventana del formulario
    /// </summary>
    public enum WindowMode
    {
        /// <summary>
        /// No se mostrará una ventana
        /// </summary>
        None,

        /// <summary>
        /// Se mostrará una ventana
        /// </summary>
        Window,
    }

    /// <summary>
    /// Modo del borde
    /// </summary>
    public enum BorderStyle
    {
        /// <summary>
        /// No se muestra un borde
        /// </summary>
        None,

        /// <summary>
        /// No se muestra borde
        /// </summary>
        Border
    }

    /// <summary>
    /// Estado de la ventana
    /// </summary>
    public enum WindowState
    {
        /// <summary>
        /// Se muestra la ventana con su tamaño especificado en Size
        /// </summary>
        Normal,

        /// <summary>
        /// La ventana se muyestra maximizada
        /// </summary>
        Maximized,

        /// <summary>
        /// La ventana se muestra minimizada
        /// </summary>
        Minimized,

        /// <summary>
        /// La ventana no se mustra
        /// </summary>
        Hidden,
    }

    /// <summary>
    /// Posición inicial de un formulario
    /// </summary>
    public enum StartPosition
    {
        /// <summary>
        /// En la posición especificada en Location
        /// </summary>
        Manual,

        /// <summary>
        /// Se coloca en el centro de la ventana
        /// </summary>
        Center
    }

    /// <summary>
    /// Tipo de valor
    /// </summary>
    public enum ValueType
    {
        /// <summary>
        /// Es un entero
        /// </summary>
        Integer,

        /// <summary>
        /// Es un flotante
        /// </summary>
        Float
    }
}
