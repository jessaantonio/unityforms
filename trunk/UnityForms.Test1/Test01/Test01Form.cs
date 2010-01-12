using System.Collections.Generic;
using UnityForms;

public class Test01Form : Form
{
    private ListBox listBox1;
    private ListItem listItem1;
    private ListItem listItem2;
    private ListItem listItem3;
    private ListItem listItemA;
    private ListBox listBox2;
    private Button button1;
    private Button button2;
    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    public override void Initialize()
    {
        this.InitializeComponent();
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
        this.listBox1 = new UnityForms.ListBox();
        this.listItem1 = new UnityForms.ListItem();
        this.listItem2 = new UnityForms.ListItem();
        this.listItem3 = new UnityForms.ListItem();
        this.listItemA = new UnityForms.ListItem();
        this.listBox2 = new UnityForms.ListBox();
        this.button1 = new UnityForms.Button();
        this.button2 = new UnityForms.Button();
        this.SuspendLayout();
        // 
        // listBox1
        // 
        this.listBox1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.listBox1.Controls.Add(this.listItem1);
        this.listBox1.Controls.Add(this.listItem2);
        this.listBox1.Controls.Add(this.listItem3);
        this.listBox1.Location = new System.Drawing.Point(14, 71);
        this.listBox1.Name = "listBox1";
        this.listBox1.ShowToolTip = true;
        this.listBox1.Size = new System.Drawing.Size(108, 80);
        this.listBox1.TabIndex = 0;
        this.listBox1.Text = "listBox1";
        this.listBox1.ToolTip = "";
        this.listBox1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.listBox1.SelectionMode = SelectionMode.Multiple;
        // 
        // listItem1
        // 
        this.listItem1.ShowToolTip = true;
        this.listItem1.Text = "item 1";
        this.listItem1.ToolTip = "item 1";
        // 
        // listItem2
        // 
        this.listItem2.ShowToolTip = true;
        this.listItem2.Text = "item 2";
        this.listItem2.ToolTip = "item 2";
        // 
        // listItem3
        // 
        this.listItem3.ShowToolTip = true;
        this.listItem3.Text = "item 3";
        this.listItem3.ToolTip = "item3";
        // 
        // listBox2
        // 
        this.listBox2.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.listBox2.Controls.Add(this.listItemA);
        this.listBox2.Location = new System.Drawing.Point(163, 71);
        this.listBox2.Name = "listBox2";
        this.listBox2.ShowToolTip = true;
        this.listBox2.Size = new System.Drawing.Size(99, 80);
        this.listBox2.TabIndex = 1;
        this.listBox2.Text = "listBox2";
        this.listBox2.ToolTip = "";
        this.listBox2.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        // 
        // listItemA
        // 
        this.listItemA.ShowToolTip = true;
        this.listItemA.Text = "item A";
        this.listItemA.ToolTip = "itemA";
        // 
        // button1
        // 
        this.button1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.button1.Location = new System.Drawing.Point(128, 71);
        this.button1.Name = "button1";
        this.button1.ShowToolTip = true;
        this.button1.Size = new System.Drawing.Size(29, 23);
        this.button1.TabIndex = 2;
        this.button1.Text = ">";
        this.button1.ToolTip = "";
        this.button1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // button2
        // 
        this.button2.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.button2.Location = new System.Drawing.Point(128, 100);
        this.button2.Name = "button2";
        this.button2.ShowToolTip = true;
        this.button2.Size = new System.Drawing.Size(29, 23);
        this.button2.TabIndex = 3;
        this.button2.Text = "<";
        this.button2.ToolTip = "";
        this.button2.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.button2.Click += new System.EventHandler(this.button2_Click);
        // 
        // EmptyForm
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.button2);
        this.Controls.Add(this.button1);
        this.Controls.Add(this.listBox2);
        this.Controls.Add(this.listBox1);
        this.Draggable = true;
        this.Name = "EmptyForm";
        this.Size = new System.Drawing.Size(331, 232);
        this.WindowMode = UnityForms.WindowMode.Window;
        this.ResumeLayout(false);

    }

    #endregion

    private void button1_Click(object sender, System.EventArgs e)
    {
        List<ListItem> list = this.listBox1.SelectedItems();

        for (int i = 0; i < list.Count; i++)
        {
            list[i].Selected = false;
            list[i].Move(this.listBox2);
        }
    }

    private void button2_Click(object sender, System.EventArgs e)
    {
        List<ListItem> list = this.listBox2.SelectedItems();

        for (int i = 0; i < list.Count; i++)
        {
            list[i].Selected = false;
            list[i].Move(this.listBox1);
        }
    }
}
