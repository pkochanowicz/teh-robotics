using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageFillMonitor : MonoBehaviour
{
    public Image image;
    public FloatVariable currentHealth;

    public FloatVariable maxValue;

    private void Start()
    {
        if (image == null)
        {
            image = GetComponent<Image>();
        }

    }
    // Update is called once per frame
    void Update()
    {
        image.fillAmount = currentHealth.value / maxValue.value;
    }
}
