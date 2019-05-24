using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

class ButtonSelector : MonoBehaviour
{
    public Button[] buttons;
    public int selectedIndex;
    public UnityEvent ButtonEvents;

    private Color temporaryColor;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex++;
            CheckIndexInRange();
            buttons[selectedIndex].Select();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            selectedIndex--;

            CheckIndexInRange();
            buttons[selectedIndex].Select();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            temporaryColor = buttons[selectedIndex].GetComponent<Image>().color;
            buttons[selectedIndex].GetComponent<Image>().color = buttons[selectedIndex].colors.pressedColor;
        }
        else if (Input.GetKeyUp(KeyCode.Return))
        {
            buttons[selectedIndex].GetComponent<Image>().color = temporaryColor;
            buttons[selectedIndex].onClick.Invoke();
        }
    }

    void CheckIndexInRange()
    {
        if (selectedIndex < 0) selectedIndex = buttons.Length - 1;
        else if (selectedIndex >= buttons.Length) selectedIndex = 0;
    }
}
