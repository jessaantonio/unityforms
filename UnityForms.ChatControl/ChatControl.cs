//-----------------------------------------------------------------------
// <copyright file="ChatControl.cs" company="Marcelo Roca">
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

    /// <summary>
    /// Implementa la interface GUI para un chat
    /// </summary>
    public class ChatControl : Control
    {
        /// <summary>
        /// Se llama cuando el usuario del chat escribe un mensaje
        /// </summary>
        public event MessageEventHandler SendMessage;

        /// <summary>
        /// Lista de mensajes en la cola
        /// </summary>
        private readonly Queue<Message> messageList = new Queue<Message>();

        /// <summary>
        /// Indica si muesta o no un borde del control
        /// </summary>
        private bool showBorder = true;

        /// <summary>
        /// El texto que ha introducido el usuario
        /// </summary>
        private string text = string.Empty;

        /// <summary>
        /// Cantidad máxima de mensajes que se permiten en la lista
        /// si se sobrepasa este númeró, se elimina los mensajes
        /// más antiguos
        /// </summary>
        private int maxMessages = 10;

        /// <summary>
        /// Cantidad de mensajes que tiene la lista
        /// </summary>
        private int messageCount;

        /// <summary>
        /// El nombre del usuario del control
        /// </summary>
        private string userName = "Me";

        /// <summary>
        /// El área del recuadro del texto de ingreso de mensajes
        /// </summary>
        private Rect textRect;

        /// <summary>
        /// El área del recuadro de mensajes
        /// </summary>
        private Rect chatRect;

        /// <summary>
        /// Contiene el estilo del recuadro de texto
        /// </summary>
        private GUIStyle textStyle;

        /// <summary>
        /// Contiene el estilo del recuadro de texto
        /// </summary>
        private GUIStyle chatStyle;

        /// <summary>
        /// La posición del scroll del recuadro de mensajes
        /// </summary>
        private Vector2 scrollPosition;

        /// <summary>
        /// Se llama cuando sale un mensaje
        /// </summary>
        /// <param name="sender">
        /// El control que produjo el evento
        /// </param>
        /// <param name="e">
        /// Los datos del mensaje
        /// </param>
        public delegate void MessageEventHandler(Control sender, ChatEventArgs e);

        /// <summary>
        /// Gets or sets a value indicating whether AutoSize.
        /// </summary>
        public new bool AutoSize
        {
            get { return base.AutoSize; }
            set { base.AutoSize = value; }
        }

        /// <summary>
        /// Gets or sets a value indicating whether ShowBorder.
        /// </summary>
        public bool ShowBorder
        {
            get { return this.showBorder; }
            set { this.showBorder = value; }
        }

        /// <summary>
        /// Gets or sets UserName.
        /// </summary>
        public string UserName
        {
            get { return this.userName; }
            set { this.userName = value; }
        }

        /// <summary>
        /// Gets or sets MaxMessages.
        /// </summary>
        public int MaxMessages
        {
            get { return this.maxMessages; }
            set { this.maxMessages = value > 4 ? value : 5; }
        }

        /// <summary>
        /// Gets or sets MessageCount.
        /// </summary>
        public int MessageCount
        {
            get { return this.messageCount; }
            set { this.messageCount = value; }
        }

        /// <summary>
        /// Gets or sets TextStyle.
        /// </summary>
        public GUIStyle TextStyle
        {
            get { return this.textStyle; }
            set { this.textStyle = value; }
        }

        /// <summary>
        /// Gets or sets ChatStyle.
        /// </summary>
        public GUIStyle ChatStyle
        {
            get { return this.chatStyle; }
            set { this.chatStyle = value; }
        }

        /// <summary>
        /// Eliminamos el contenido del chat
        /// </summary>
        public void Clear()
        {
            this.messageList.Clear();
            this.messageCount = 0;
            this.text = string.Empty;
        }

        /// <summary>
        /// Inserta un mensaje en el chat
        /// </summary>
        /// <param name="userName">
        /// The user name.
        /// </param>
        /// <param name="message">
        /// The message.
        /// </param>
        public void InsertMessage(string userName, string message)
        {
            this.AddMessage(userName, message);
        }
     
        /// <summary>
        /// Pinta el GUI
        /// </summary>
        protected override void DrawControl()
        {
            // nos permite tener el height actual utilizado por los mensajes en el chat
            // con el fin de llevar el scrollPosition a la posicion que permita
            // mostrar el último mensaje escrito
            float h = 0;

            // mostramos el borde si es necesario
            if (this.showBorder)
            {
                if (Style != null)
                {
                    GUI.BeginGroup(ControlRect, Content, Style);
                }
                else
                {
                    GUI.BeginGroup(ControlRect, Content);
                }
            }

            // Mostramos el área del CHAT
            if (this.ChatStyle != null)
            {
                GUILayout.BeginArea(this.chatRect, Content, this.ChatStyle);
            }
            else
            {
                GUILayout.BeginArea(this.chatRect, Content);
            }

            // comenzamos el área de scroll para mensajes
            this.scrollPosition = GUILayout.BeginScrollView(this.scrollPosition, GUILayout.Width(this.chatRect.width - 10), GUILayout.Height(this.chatRect.height - 15));

            // mostramos los mensajes de la lista calculando el área 
            // que ocupa para posicionar correctamente el scroll al final
            foreach (Message m in this.messageList)
            {
                GUILayout.BeginHorizontal(GUILayout.Height(20));
                GUILayout.Label(m.UserName + ":");
                GUILayout.EndHorizontal();
                h += GUILayoutUtility.GetLastRect().height;
                GUILayout.Label(m.Text);
                h += GUILayoutUtility.GetLastRect().height;
            }

            GUILayout.EndScrollView();
            GUILayout.EndArea();

            // colocamos el textbox para que el usuairo coloque el mensaje
            if (this.TextStyle != null)
            {
                this.text = GUI.TextArea(this.textRect, this.text, this.TextStyle);
            }
            else
            {
                this.text = GUI.TextArea(this.textRect, this.text);
            }

            // si el mensaje contiene un RETURN mandamos el mensaje
            if (this.text.Contains("\n"))
            {
                // adicionamos el mensaje a la lista
                this.AddMessage(this.text.Replace("\n", string.Empty));

                // colocamos el scroll para que muestre el último mensaje
                this.scrollPosition = new Vector2(0, h);

                // limpiamos el texto de entrada
                this.text = string.Empty;
            }

            if (this.showBorder)
            {
                GUI.EndGroup();
            }
        }

        /// <summary>
        /// Se produce cuando cambiamos el tamaño del control
        /// </summary>
        protected override void ResizeControl()
        {
            if (this.AutoSize)
            {
                // si es autosize llenamos el control dentro del contenedor
                __Location = new Point(0, 0);
                __Size = Parent.Size;

                this.chatRect = new Rect(0, 0, ControlRect.width, ControlRect.height - 70);
                this.textRect = new Rect(0, ControlRect.height - 65, ControlRect.width, 60);
            }
            else
            {
                // colocamos el tamaño correcto de los controle internos
                this.chatRect = new Rect(5, 5, ControlRect.width - 10, ControlRect.height - 75);
                this.textRect = new Rect(5, ControlRect.height - 65, ControlRect.width - 10, 60);
            }
        }

        /// <summary>
        /// Add message to the list
        /// </summary>
        /// <param name="message">
        /// The message string
        /// </param>
        private void AddMessage(string message)
        {
            // si es cls
            if (message == "cls")
            {
                // limpiamos el chat
                this.Clear();
                return;
            }

            Message m = this.AddMessage(this.userName, message);

            if (this.SendMessage != null)
            {
                this.SendMessage(this, new ChatEventArgs(m));
            }
        }

        /// <summary>
        /// Adicionamos un mensaje a la ventana del chat
        /// </summary>
        /// <param name="userName">
        /// El nombre del usuario
        /// </param>
        /// <param name="message">
        /// El mensaje
        /// </param>
        /// <returns>
        /// The add message.
        /// </returns>
        private Message AddMessage(string userName, string message)
        {
            // si el contenido excede la cantidad eliminamos los mensajes 
            // sobrantes
            int cant = this.maxMessages - this.messageCount;

            if (cant < 1)
            {
                for (int i = 1; i > cant; i--)
                {
                    this.messageList.Dequeue();
                }

                this.messageCount += cant;
            }
            else
            {
                this.messageCount++;
            }

            // adicionamos el nuevo mensaje
            Message m = new Message();
            m.UserName = userName;
            m.Text = message;

            this.messageList.Enqueue(m);

            return m;
        }

        /// <summary>
        /// El mensaje que se ha enviado
        /// </summary>
        public struct Message
        {
            /// <summary>
            /// Nombre del usuario
            /// </summary>
            public string UserName;

            /// <summary>
            /// El mensaje
            /// </summary>
            public string Text;

            /// <summary>
            /// Indica si el mensaje es vacio
            /// </summary>
            public bool IsEmpty;

            /// <summary>
            /// Gets Empty message.
            /// </summary>
            public static Message Empty
            {
                get
                {
                    Message m = new Message();
                    m.IsEmpty = true;
                    return m;
                }
            }
        }

        /// <summary>
        /// Define el argumento de un evento de chat
        /// </summary>
        public class ChatEventArgs : EventArgs
        {
            /// <summary>
            /// el mensaje
            /// </summary>
            private readonly Message message;

            /// <summary>
            /// Initializes a new instance of the <see cref="ChatEventArgs"/> class.
            /// </summary>
            /// <param name="message">
            /// The message.
            /// </param>
            public ChatEventArgs(Message message)
            {
                this.message = message;
            }

            /// <summary>
            /// Gets Message.
            /// </summary>
            public Message Message
            {
                get
                {
                    return this.message;
                }
            }
        }
    }
}
