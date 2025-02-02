using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorCode : MonoBehaviour
{
    [SerializeField] private Sprite[] colors;
    [SerializeField] private Image[] display;
    private string code;
    private string answer;
    [SerializeField] private GameObject code_GameObject;
    [SerializeField] private GameObject answer_GameObject;

    // Start is called before the first frame update
    void Start()
    {
        code = "";
        answer = "143";

        for (int i = 0; i < display.Length; i++)
        {
            display[i].sprite = colors[0]; // display no color
        }

        PushButton.ButtonPressed += AddNumberToDisplay; // Subscribe to the event
    }

    private void AddNumberToDisplay(string value)
    {
        if (code.Length < 2)
        {
            code += value;
            display[code.Length-1].sprite = colors[int.Parse(value)];
        }
        else
        {
            code += value;
            display[code.Length - 1].sprite = colors[int.Parse(value)];
            if (code == answer)
            {
                Debug.Log("Correct");
                Invoke("Win", 0.5f);
            }
            else
            {
                Debug.Log("Wrong");
                Invoke("Reset", 0.5f);
            }
        }
    }


    private void Reset()
    {
        code = "";

        for (int i = 0; i < display.Length; i++)
        {
            display[i].sprite = colors[0];
        }

    }

    public void Activate()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        gameManager.Instance.canTravel = false;
        gameManager.Instance.inputManager.player.controller.enabled = false;
        gameManager.Instance.inputManager.player.camara.GetComponent<PlayerCamera>().enabled = false;
        gameManager.Instance.inputManager.player.otherPlayer.camara.GetComponent<PlayerCamera>().enabled = false;
    }

    public void Desactivate()
    {
        Reset();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.Instance.inputManager.player.camara.GetComponent<PlayerCamera>().enabled = true;
        gameManager.Instance.inputManager.player.otherPlayer.camara.GetComponent<PlayerCamera>().enabled = true;
        gameManager.Instance.canTravel = true;
        gameManager.Instance.inputManager.player.controller.enabled = true;
        code_GameObject.SetActive(false);
    }

    public void Win()
    {
        answer_GameObject.GetComponent<Door>().OpenClose();
        answer_GameObject.GetComponent<Interactable>().onInteraction = null;
        Desactivate();
    }

    private void OnDestroy()
    {
        PushButton.ButtonPressed -= AddNumberToDisplay;
    }
}

