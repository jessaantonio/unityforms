using UnityEngine;
using UnityForms;

public class CallTest01: MonoBehaviour
{
    public GUISkin Skin;
    private Test01Form form;

    // Use this for initialization
    public void Start()
    {
        this.form = (Test01Form)FormsManager.LoadForm(gameObject, typeof(Test01Form), this.Skin);
        this.form.Show();
    }

    // Update is called once per frame
    public void Update()
    {
        this.form.Skin = this.Skin;
    }
}
