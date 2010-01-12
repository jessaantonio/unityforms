using System;

/// <summary>
/// Prueba de uso del control chat
/// </summary>
public class Test03Form : UnityForms.Form
{
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private readonly System.ComponentModel.IContainer components = null;

    /// <summary>
    /// El chat control
    /// </summary>
    private UnityForms.ChatControl chatControl1;

    /// <summary>
    /// Cantidad máxima de mensajes a mostrar
    /// </summary>
    private int maxMesages;

    /// <summary>
    /// Se produce cuando se manda un mnesane
    /// </summary>
    public event EventHandler<UnityForms.ChatControl.ChatEventArgs> SendMessage;

    /// <summary>
    /// Gets or sets UserName.
    /// </summary>
    public string UserName
    {
        get { return this.chatControl1.UserName; }
        set { this.chatControl1.UserName = value; }
    }

    /// <summary>
    /// Gets or sets MaxMesages.
    /// </summary>
    public int MaxMesages
    {
        get
        {
            return this.maxMesages;
        }

        set
        {
            if (this.maxMesages != value)
            {
                this.chatControl1.MaxMessages = this.maxMesages = value;
            }
        }
    }

    /// <summary>
    /// Inicializa el formulario
    /// </summary>
    public override void Initialize()
    {
        this.InitializeComponent();
    }

    /// <summary>
    /// Adiciona un menwsaje al chat
    /// </summary>
    /// <param name="userName">
    /// Nombre del usuario
    /// </param>
    /// <param name="message">
    /// Mensaje a mostrar
    /// </param>
    public void AddMessage(string userName, string message)
    {
        this.chatControl1.InsertMessage(userName, message);
    }

    /// <summary> 
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (this.components != null))
        {
            this.components.Dispose();
        }

        base.Dispose(disposing);
    }

    #region Component Designer generated code

    /// <summary> 
    /// Required method for Designer support - do not modify 
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        this.chatControl1 = new UnityForms.ChatControl();
        // 
        // chatControl1
        // 
        //this.chatControl1.Size = new System.Drawing.Size(290, 390);
        //this.chatControl1.Location = new System.Drawing.Point(0, 0);
        this.chatControl1.AutoSize = true;
        this.chatControl1.ShowBorder = false;
        this.chatControl1.ChatStyle = Skin.box;
        this.chatControl1.SendMessage += new UnityForms.ChatControl.MessageEventHandler(chatControl1_SendMessage);
        // 
        // Test03Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.chatControl1);
        this.Draggable = true;
        this.Name = "Test03Form";
        this.Size = new System.Drawing.Size(300, 400);
        this.WindowMode = UnityForms.WindowMode.Window;
        this.ResumeLayout(false);
    }

    private void chatControl1_SendMessage(UnityForms.Control sender, UnityForms.ChatControl.ChatEventArgs e)
    {
        if (this.SendMessage != null)
        {
            this.SendMessage(sender, e);
        }
    }

    #endregion
}
