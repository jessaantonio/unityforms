using UnityEngine;
using UnityForms;

public class CallEmptyForm : MonoBehaviour
{
    public GUISkin Skin;
    private EmptyForm form;

    // Use this for initialization
    public void Start()
    {
        this.form = (EmptyForm)FormsManager.LoadForm(gameObject, typeof(EmptyForm), this.Skin);
        this.form.Show();
    }

    // Update is called once per frame
    public void Update()
    {
        this.form.Skin = this.Skin;
    }
}
