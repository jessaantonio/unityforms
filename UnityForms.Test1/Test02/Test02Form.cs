using System;
using UnityEngine;

public class Test02Form : UnityForms.Form
{
    private UnityForms.Button button1;
    private UnityForms.Label label1;
    private UnityForms.Toolbar toolbar1;
    private UnityForms.ToolButton toolButton1;
    private UnityForms.ToolButton toolButton2;
    private UnityForms.ToolButton toolButton3;
    private UnityForms.ToolButton toolButton4;
    private UnityForms.ToolButton toolButton5;
    private UnityForms.HorizontalScrollbar horizontalScrollbar1;
    private UnityForms.VerticalScrollbar verticalScrollbar1;
    private UnityForms.HorizontalSlider horizontalSlider1;
    private UnityForms.VerticalSlider verticalSlider1;
    private UnityForms.TextArea textArea1;
    private UnityForms.TextField textField1;
    private UnityForms.Toggle toggle1;
    private UnityForms.RepeatButton repeatButton1;
    private UnityForms.Box box1;
    private UnityForms.ListBox listBox1;
    private UnityForms.ListItem listItem1;
    private UnityForms.ListItem listItem2;
    private UnityForms.ListItem listItem3;
    private UnityForms.ListItem listItem4;
    private UnityForms.ListItem listItem5;
    private UnityForms.PasswordField passwordField1;
    private UnityForms.DropDownList comboBox1;
    private UnityForms.ListItem listItem6;
    private UnityForms.ListItem listItem7;
    private UnityForms.ListItem listItem8;
    private UnityForms.ListItem listItem9;
    private UnityForms.ListItem listItem10;
    private UnityForms.ListItem listItem11;

    /// <summary> 
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

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
        this.button1 = new UnityForms.Button();
        this.label1 = new UnityForms.Label();
        this.toolbar1 = new UnityForms.Toolbar();
        this.toolButton1 = new UnityForms.ToolButton();
        this.toolButton5 = new UnityForms.ToolButton();
        this.toolButton2 = new UnityForms.ToolButton();
        this.toolButton3 = new UnityForms.ToolButton();
        this.toolButton4 = new UnityForms.ToolButton();
        this.horizontalScrollbar1 = new UnityForms.HorizontalScrollbar();
        this.verticalScrollbar1 = new UnityForms.VerticalScrollbar();
        this.horizontalSlider1 = new UnityForms.HorizontalSlider();
        this.verticalSlider1 = new UnityForms.VerticalSlider();
        this.textArea1 = new UnityForms.TextArea();
        this.textField1 = new UnityForms.TextField();
        this.toggle1 = new UnityForms.Toggle();
        this.repeatButton1 = new UnityForms.RepeatButton();
        this.box1 = new UnityForms.Box();
        this.listBox1 = new UnityForms.ListBox();
        this.listItem1 = new UnityForms.ListItem();
        this.listItem2 = new UnityForms.ListItem();
        this.listItem3 = new UnityForms.ListItem();
        this.listItem4 = new UnityForms.ListItem();
        this.listItem5 = new UnityForms.ListItem();
        this.passwordField1 = new UnityForms.PasswordField();
        this.comboBox1 = new UnityForms.DropDownList();
        this.listItem6 = new UnityForms.ListItem();
        this.listItem7 = new UnityForms.ListItem();
        this.listItem8 = new UnityForms.ListItem();
        this.listItem9 = new UnityForms.ListItem();
        this.listItem10 = new UnityForms.ListItem();
        this.listItem11 = new UnityForms.ListItem();
        this.SuspendLayout();
        // 
        // button1
        // 
        this.button1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.button1.Location = new System.Drawing.Point(23, 89);
        this.button1.Name = "button1";
        this.button1.ShowToolTip = true;
        this.button1.Size = new System.Drawing.Size(75, 23);
        this.button1.TabIndex = 0;
        this.button1.Text = "button1";
        this.button1.ToolTip = "button1";
        this.button1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.button1.Click += new System.EventHandler(this.button1_Click);
        // 
        // label1
        // 
        this.label1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.label1.Location = new System.Drawing.Point(114, 89);
        this.label1.Name = "label1";
        this.label1.ShowToolTip = true;
        this.label1.Size = new System.Drawing.Size(75, 22);
        this.label1.TabIndex = 1;
        this.label1.Text = "label1";
        this.label1.ToolTip = "label1";
        this.label1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.label1.DoubleClick += new UnityForms.MouseEventHandler(this.label1_DoubleClick);
        this.label1.MouseClick += new UnityForms.MouseEventHandler(this.label1_MouseClick);
        // 
        // toolbar1
        // 
        this.toolbar1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.toolbar1.Location = new System.Drawing.Point(54, 3);
        this.toolbar1.Name = "toolbar1";
        this.toolbar1.ShowToolTip = true;
        this.toolbar1.Size = new System.Drawing.Size(345, 41);
        this.toolbar1.TabIndex = 2;
        this.toolbar1.Text = "toolbar1";
        this.toolbar1.Controls.Add(this.toolButton1);
        this.toolbar1.Controls.Add(this.toolButton5);
        this.toolbar1.Controls.Add(this.toolButton2);
        this.toolbar1.Controls.Add(this.toolButton3);
        this.toolbar1.Controls.Add(this.toolButton4);
        this.toolbar1.ToolTip = "";
        this.toolbar1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        // 
        // toolButton1
        // 
        this.toolButton1.ShowToolTip = true;
        this.toolButton1.Text = "button1";
        this.toolButton1.ToolTip = "a";
        // 
        // toolButton5
        // 
        this.toolButton5.ShowToolTip = true;
        this.toolButton5.Text = "button5";
        this.toolButton5.ToolTip = "e";
        // 
        // toolButton2
        // 
        this.toolButton2.ShowToolTip = true;
        this.toolButton2.Text = "button2";
        this.toolButton2.ToolTip = "b";
        // 
        // toolButton3
        // 
        this.toolButton3.ShowToolTip = true;
        this.toolButton3.Text = "button3";
        this.toolButton3.ToolTip = "c";
        // 
        // toolButton4
        // 
        this.toolButton4.ShowToolTip = true;
        this.toolButton4.Text = "button4";
        this.toolButton4.ToolTip = "d";
        // 
        // horizontalScrollbar1
        // 
        this.horizontalScrollbar1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.horizontalScrollbar1.Location = new System.Drawing.Point(23, 211);
        this.horizontalScrollbar1.Max = 10F;
        this.horizontalScrollbar1.Min = 0F;
        this.horizontalScrollbar1.Name = "horizontalScrollbar1";
        this.horizontalScrollbar1.ShowToolTip = true;
        this.horizontalScrollbar1.Size = new System.Drawing.Size(227, 23);
        this.horizontalScrollbar1.TabIndex = 4;
        this.horizontalScrollbar1.Text = "horizontalScrollbar1";
        this.horizontalScrollbar1.ToolTip = "";
        this.horizontalScrollbar1.Value = 0F;
        this.horizontalScrollbar1.ValueType = UnityForms.ValueType.Integer;
        this.horizontalScrollbar1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.horizontalScrollbar1.VisibleSize = 0F;
        this.horizontalScrollbar1.ValueChanged += new System.EventHandler(this.horizontalScrollbar1_ValueChanged_1);
        // 
        // verticalScrollbar1
        // 
        this.verticalScrollbar1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.verticalScrollbar1.Location = new System.Drawing.Point(256, 68);
        this.verticalScrollbar1.Max = 89F;
        this.verticalScrollbar1.Min = 0F;
        this.verticalScrollbar1.Name = "verticalScrollbar1";
        this.verticalScrollbar1.ShowToolTip = true;
        this.verticalScrollbar1.Size = new System.Drawing.Size(31, 144);
        this.verticalScrollbar1.TabIndex = 5;
        this.verticalScrollbar1.Text = "verticalScrollbar1";
        this.verticalScrollbar1.ToolTip = "";
        this.verticalScrollbar1.Value = 0F;
        this.verticalScrollbar1.ValueType = UnityForms.ValueType.Float;
        this.verticalScrollbar1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.verticalScrollbar1.VisibleSize = 0F;
        this.verticalScrollbar1.ValueChanged += new System.EventHandler(this.verticalScrollbar1_ValueChanged);
        // 
        // horizontalSlider1
        // 
        this.horizontalSlider1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.horizontalSlider1.Location = new System.Drawing.Point(304, 80);
        this.horizontalSlider1.Max = 50F;
        this.horizontalSlider1.Min = 0F;
        this.horizontalSlider1.Name = "horizontalSlider1";
        this.horizontalSlider1.ShowToolTip = true;
        this.horizontalSlider1.Size = new System.Drawing.Size(75, 23);
        this.horizontalSlider1.TabIndex = 6;
        this.horizontalSlider1.Text = "horizontalSlider1";
        this.horizontalSlider1.ToolTip = "";
        this.horizontalSlider1.Value = 0F;
        this.horizontalSlider1.ValueType = UnityForms.ValueType.Float;
        this.horizontalSlider1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.horizontalSlider1.ValueChanged += new System.EventHandler(this.horizontalSlider1_ValueChanged);
        // 
        // verticalSlider1
        // 
        this.verticalSlider1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.verticalSlider1.Location = new System.Drawing.Point(404, 48);
        this.verticalSlider1.Max = 100F;
        this.verticalSlider1.Min = 0F;
        this.verticalSlider1.Name = "verticalSlider1";
        this.verticalSlider1.ShowToolTip = true;
        this.verticalSlider1.Size = new System.Drawing.Size(20, 55);
        this.verticalSlider1.TabIndex = 7;
        this.verticalSlider1.Text = "verticalSlider1";
        this.verticalSlider1.ToolTip = "";
        this.verticalSlider1.Value = 0F;
        this.verticalSlider1.ValueType = UnityForms.ValueType.Float;
        this.verticalSlider1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.verticalSlider1.ValueChanged += new System.EventHandler(this.verticalSlider1_ValueChanged);
        // 
        // textArea1
        // 
        this.textArea1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.textArea1.Location = new System.Drawing.Point(114, 118);
        this.textArea1.Name = "textArea1";
        this.textArea1.ShowToolTip = true;
        this.textArea1.Size = new System.Drawing.Size(136, 52);
        this.textArea1.TabIndex = 8;
        this.textArea1.Text = "textArea1";
        this.textArea1.ToolTip = "";
        this.textArea1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.textArea1.TextChanged += new System.EventHandler(this.textArea1_TextChanged);
        // 
        // textField1
        // 
        this.textField1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.textField1.Location = new System.Drawing.Point(23, 147);
        this.textField1.Name = "textField1";
        this.textField1.ShowToolTip = true;
        this.textField1.Size = new System.Drawing.Size(75, 22);
        this.textField1.TabIndex = 9;
        this.textField1.Text = "textField1";
        this.textField1.ToolTip = "";
        this.textField1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.textField1.TextChanged += new System.EventHandler(this.textField1_TextChanged);
        // 
        // toggle1
        // 
        this.toggle1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.toggle1.Location = new System.Drawing.Point(23, 118);
        this.toggle1.Name = "toggle1";
        this.toggle1.ShowToolTip = true;
        this.toggle1.Size = new System.Drawing.Size(75, 23);
        this.toggle1.TabIndex = 10;
        this.toggle1.Text = "toggle1";
        this.toggle1.ToolTip = "toggle";
        this.toggle1.Value = false;
        this.toggle1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.toggle1.CheckedChanged += new System.EventHandler(this.toggle1_CheckedChanged);
        // 
        // repeatButton1
        // 
        this.repeatButton1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.repeatButton1.Location = new System.Drawing.Point(304, 109);
        this.repeatButton1.Name = "repeatButton1";
        this.repeatButton1.ShowToolTip = true;
        this.repeatButton1.Size = new System.Drawing.Size(120, 23);
        this.repeatButton1.TabIndex = 11;
        this.repeatButton1.Text = "repeatButton1";
        this.repeatButton1.ToolTip = "repeat";
        this.repeatButton1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.repeatButton1.Click += new System.EventHandler(this.repeatButton1_Click);
        // 
        // box1
        // 
        this.box1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.box1.Location = new System.Drawing.Point(304, 170);
        this.box1.Name = "box1";
        this.box1.ShowToolTip = true;
        this.box1.Size = new System.Drawing.Size(75, 77);
        this.box1.TabIndex = 12;
        this.box1.Text = "box1";
        this.box1.ToolTip = "box";
        this.box1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        this.box1.DoubleClick += new UnityForms.MouseEventHandler(this.box1_DoubleClick);
        this.box1.MouseClick += new UnityForms.MouseEventHandler(this.box1_MouseClick);
        // 
        // listBox1
        // 
        this.listBox1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.listBox1.Controls.Add(this.listItem1);
        this.listBox1.Controls.Add(this.listItem2);
        this.listBox1.Controls.Add(this.listItem3);
        this.listBox1.Controls.Add(this.listItem4);
        this.listBox1.Controls.Add(this.listItem5);
        this.listBox1.Location = new System.Drawing.Point(114, 240);
        this.listBox1.Name = "listBox1";
        this.listBox1.ShowToolTip = true;
        this.listBox1.Size = new System.Drawing.Size(136, 80);
        this.listBox1.TabIndex = 13;
        this.listBox1.Text = "listBox1";
        this.listBox1.ToolTip = "listBox";
        this.listBox1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        // 
        // listItem1
        // 
        this.listItem1.ShowToolTip = true;
        this.listItem1.Text = "item 1";
        this.listItem1.ToolTip = "1";
        // 
        // listItem2
        // 
        this.listItem2.ShowToolTip = true;
        this.listItem2.Text = "item 2";
        this.listItem2.ToolTip = "2";
        // 
        // listItem3
        // 
        this.listItem3.ShowToolTip = true;
        this.listItem3.Text = "item 3";
        this.listItem3.ToolTip = "3";
        // 
        // listItem4
        // 
        this.listItem4.ShowToolTip = true;
        this.listItem4.Text = "item 4";
        this.listItem4.ToolTip = "4";
        // 
        // listItem5
        // 
        this.listItem5.ShowToolTip = true;
        this.listItem5.Text = "item 5";
        this.listItem5.ToolTip = "5";
        // 
        // passwordField1
        // 
        this.passwordField1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.passwordField1.Location = new System.Drawing.Point(270, 253);
        this.passwordField1.MaskChar = '*';
        this.passwordField1.MaxLenght = 10;
        this.passwordField1.Name = "passwordField1";
        this.passwordField1.ShowToolTip = true;
        this.passwordField1.Size = new System.Drawing.Size(154, 22);
        this.passwordField1.TabIndex = 14;
        this.passwordField1.ToolTip = "";
        this.passwordField1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        // 
        // comboBox1
        // 
        this.comboBox1.HorizontalAlignment = UnityForms.HorizontalAlignment.Manual;
        this.comboBox1.Controls.Add(this.listItem6);
        this.comboBox1.Controls.Add(this.listItem7);
        this.comboBox1.Controls.Add(this.listItem8);
        this.comboBox1.Controls.Add(this.listItem9);
        this.comboBox1.Controls.Add(this.listItem10);
        this.comboBox1.Controls.Add(this.listItem11);
        this.comboBox1.Location = new System.Drawing.Point(270, 281);
        this.comboBox1.Name = "comboBox1";
        this.comboBox1.ShowToolTip = true;
        this.comboBox1.Size = new System.Drawing.Size(154, 22);
        this.comboBox1.TabIndex = 15;
        this.comboBox1.Text = "comboBox1";
        this.comboBox1.ToolTip = "";
        this.comboBox1.VerticalAlignment = UnityForms.VerticalAlignment.Manual;
        // 
        // listItem6
        // 
        this.listItem6.ShowToolTip = true;
        this.listItem6.Text = "item 1";
        this.listItem6.ToolTip = "1";
        // 
        // listItem7
        // 
        this.listItem7.ShowToolTip = true;
        this.listItem7.Text = "item 2";
        this.listItem7.ToolTip = "2";
        // 
        // listItem8
        // 
        this.listItem8.ShowToolTip = true;
        this.listItem8.Text = "item 3";
        this.listItem8.ToolTip = "3";
        // 
        // listItem9
        // 
        this.listItem9.ShowToolTip = true;
        this.listItem9.Text = "item 4";
        this.listItem9.ToolTip = "4";
        // 
        // listItem10
        // 
        this.listItem10.ShowToolTip = true;
        this.listItem10.Text = "item 5";
        this.listItem10.ToolTip = "5";
        // 
        // listItem11
        // 
        this.listItem11.ShowToolTip = true;
        this.listItem11.Text = "item 6";
        this.listItem11.ToolTip = "6";
        // 
        // TT2Form
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.Controls.Add(this.comboBox1);
        this.Controls.Add(this.passwordField1);
        this.Controls.Add(this.listBox1);
        this.Controls.Add(this.box1);
        this.Controls.Add(this.repeatButton1);
        this.Controls.Add(this.toggle1);
        this.Controls.Add(this.textField1);
        this.Controls.Add(this.textArea1);
        this.Controls.Add(this.verticalSlider1);
        this.Controls.Add(this.horizontalSlider1);
        this.Controls.Add(this.verticalScrollbar1);
        this.Controls.Add(this.horizontalScrollbar1);
        this.Controls.Add(this.toolbar1);
        this.Controls.Add(this.label1);
        this.Controls.Add(this.button1);
        this.Draggable = true;
        this.Name = "TT2Form";
        this.Size = new System.Drawing.Size(462, 500);
        this.WindowMode = UnityForms.WindowMode.Window;
        this.ResumeLayout(false);

    }


    #endregion




    public override void Initialize()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        UnityForms.MessageBox.Show(gameObject, "test", "mensaje mensaje mensaje", this.Skin);
    }

    void label1_MouseClick(object sender, UnityForms.MouseEventArgs e)
    {
        Debug.Log("label1_MouseClick");
    }

    void label1_DoubleClick(object sender, UnityForms.MouseEventArgs e)
    {
        Debug.Log("");
    }

    private void textField1_MouseClick(object sender, UnityForms.MouseEventArgs e)
    {
        Debug.Log("textField1_MouseClick");
    }

    private void horizontalScrollbar1_ValueChanged(object sender, EventArgs e)
    {
        Debug.Log("horizontalScrollbar1_ValueChanged");
    }

    private void verticalScrollbar1_ValueChanged(object sender, EventArgs e)
    {
        Debug.Log("verticalScrollbar1_ValueChanged");
    }

    private void horizontalSlider1_ValueChanged(object sender, EventArgs e)
    {
        Debug.Log("horizontalSlider1_ValueChanged");
    }

    private void verticalSlider1_ValueChanged(object sender, EventArgs e)
    {
        Debug.Log("verticalSlider1_ValueChanged");
    }

    private void toggle1_CheckedChanged(object sender, EventArgs e)
    {
        Debug.Log("toggle1_CheckedChanged");
    }

    private void textField1_TextChanged(object sender, EventArgs e)
    {
        Debug.Log("textField1_TextChanged");
    }

    private void textArea1_TextChanged(object sender, EventArgs e)
    {
        Debug.Log("textArea1_TextChanged");
    }

    private void verticalScrollbar1_Click(object sender, EventArgs e)
    {
        Debug.Log("verticalScrollbar1_Click");
    }

    private void horizontalScrollbar1_ValueChanged_1(object sender, EventArgs e)
    {
        Debug.Log("horizontalScrollbar1_ValueChanged_1");
    }

    private void repeatButton1_Click(object sender, EventArgs e)
    {
        Debug.Log("repeatButton1_Click");
    }

    private void box1_DoubleClick(object sender, UnityForms.MouseEventArgs e)
    {
        Debug.Log("box1_DoubleClick");
    }

    private void box1_MouseClick(object sender, UnityForms.MouseEventArgs e)
    {
        Debug.Log("box1_MouseClick");
    }
}
