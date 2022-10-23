using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonColorChange : MonoBehaviour
{
    private ColorBlock colors;
    public Button button;

    private void Awake()
    {
        colors = GetComponent<Button>().colors;
    }

    public void ButtonTransitionColors(Color color)
    {
        colors.normalColor = color;
        colors.pressedColor = Color.green;
        colors.selectedColor = Color.green;
        colors.disabledColor = Color.green;

        button.colors = colors;
        print("Cliked");
    }
}
