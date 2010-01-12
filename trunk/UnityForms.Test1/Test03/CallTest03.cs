using System.Drawing;
using UnityEngine;
using UnityForms;

public class CallTest03 : MonoBehaviour
{
    public GUISkin Skin;
    private Test03Form form1;
    private Test03Form form2;
    public int MaxMesages = 10;

    // Use this for initialization
    public void Start()
    {
        this.form1 = (Test03Form)FormsManager.LoadForm(gameObject, typeof(Test03Form), this.Skin);
        this.form1.Show();
        this.form1.Location = new Point(10, 10);
        this.form1.UserName = "user1";
        this.form1.SendMessage += form1_SendMessage;

        this.form2 = (Test03Form)FormsManager.LoadForm(gameObject, typeof(Test03Form), this.Skin);
        this.form2.Show();
        this.form2.Location = new Point(320, 10);
        this.form2.UserName = "user2";
        this.form2.SendMessage += form2_SendMessage;
    }

    private void form1_SendMessage(object sender, ChatControl.ChatEventArgs e)
    {
       this.form2.AddMessage(e.Message.UserName, e.Message.Text);
    }

    private void form2_SendMessage(object sender, ChatControl.ChatEventArgs e)
    {
        this.form1.AddMessage(e.Message.UserName, e.Message.Text);
    }

    // Update is called once per frame
    public void Update()
    {
        this.form1.Skin = this.Skin;
        this.form1.MaxMesages = this.MaxMesages;
    }
}
