using UnityEngine;
using UnityEngine.UI;

public class FloatTextMonitor : MonoBehaviour
{
    public Text text;
    public FloatVariable floatVariable;

    private void Start()
    {
        if (text == null)
        {
            text = GetComponent<Text>();
        }

    }
    // Update is called once per frame
    void Update()
    {
        text.text = "x " + floatVariable.value.ToString();
    }
}
