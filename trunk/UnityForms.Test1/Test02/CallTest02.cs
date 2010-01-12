using UnityEngine;
using UnityForms;

public class CallTest02 : MonoBehaviour
{
    public GUISkin Skin;
    private Test02Form form;

    // Use this for initialization
    public void Start()
    {
        this.form = (Test02Form)FormsManager.LoadForm(gameObject, typeof(Test02Form), this.Skin);
        this.form.Show();
    }

    // Update is called once per frame
    public void Update()
    {
        this.form.Skin = this.Skin;
    }
}
