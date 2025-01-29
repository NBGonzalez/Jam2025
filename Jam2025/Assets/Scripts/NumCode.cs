using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NumCode : MonoBehaviour
{
    [SerializeField] private Sprite[] numbers;
    [SerializeField] private Image[] display;
    private string code;
    private string answer; 

    // Start is called before the first frame update
    void Start()
    {
        code = "";
        answer = "1234";

        for(int i = 0; i < display.Length; i++)
        {
            display[i].sprite = numbers[10]; // display no number
        }

        PushButton.ButtonPressed += AddNumberToDisplay; // Subscribe to the event
    }

    private void AddNumberToDisplay(string value)
    {
        if(code.Length < 3)
        {
            code += value;
            CodeSequence(int.Parse(value));
        } 
        else
        {
            code += value;
            CodeSequence(int.Parse(value));
            if (code == answer)
            {
                Debug.Log("Correct");
            }
            else
            {
                Debug.Log("Wrong");
                Invoke("Reset", 0.5f);
            }
        }
    }

    private void CodeSequence(int value)
    {
        switch (code.Length)
        {
            case 1:
                display[0].sprite = numbers[10];
                display[1].sprite = numbers[10];
                display[2].sprite = numbers[10];
                display[3].sprite = numbers[value];
                break;

            case 2:
                display[0].sprite = numbers[10];
                display[1].sprite = numbers[10];
                display[2].sprite = display[3].sprite;
                display[3].sprite = numbers[value];
                break;

            case 3:
                display[0].sprite = numbers[10];
                display[1].sprite = display[2].sprite;
                display[2].sprite = display[3].sprite;
                display[3].sprite = numbers[value];
                break;

            case 4:
                display[0].sprite = display[1].sprite;
                display[1].sprite = display[2].sprite;
                display[2].sprite = display[3].sprite;
                display[3].sprite = numbers[value];
                break;
        }
    }

    private void Reset()
    {
        code = "";

        for (int i = 0; i < display.Length; i++)
        {
            display[i].sprite = numbers[10];
        }

    }

    private void OnDestroy()
    {
        PushButton.ButtonPressed -= AddNumberToDisplay;
    }
}
