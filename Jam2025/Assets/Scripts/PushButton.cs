using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public static event Action<String> ButtonPressed = delegate { };
    //Acction/Delegate - method parameter string return nothing - void

    private string buttonValue;

    void Start()
    {
        buttonValue = gameObject.name;
        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
    {
        ButtonPressed(buttonValue); // when the button is pressed the event is launched
    }

}
