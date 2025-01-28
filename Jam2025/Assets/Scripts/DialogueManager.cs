using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int index = 0;
    public float DialogueSpeed;
    [SerializeField] private Sprite mouse;
    [SerializeField] private Sprite interactionMouse;
    [SerializeField] private Image mouseImage;
    private bool normalMouse = true;

    // Start is called before the first frame update

    private static DialogueManager instance;

    public static DialogueManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Start()
    {
        instance = this;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (DialogueText.text == Sentences[index])
            {
                NextSentence();
            }
            else
            {
                StopAllCoroutines();
                DialogueText.text = Sentences[index];
            }


        }
        

    }

    public void StartDialogue()
    {
        index = 0;
        StartCoroutine(WriteSentence());
    }

    public void NextSentence()
    {
        if(index < Sentences.Length - 1)
        {
            index++;
            DialogueText.text = "";
            StartCoroutine(WriteSentence());
        }

        else
        {
            DialogueText.text = "";
        }
    }

    IEnumerator WriteSentence()
    {
        foreach(char Character in Sentences[index].ToCharArray())
        {
            DialogueText.text += Character;
            yield return new WaitForSeconds(DialogueSpeed);
        }
        //index++;
    }

    public static void SetInteractionMouse()
    {
        if (!instance.normalMouse) return;
        instance.mouseImage.sprite = instance.interactionMouse;
        instance.normalMouse = false;
    }

    public static void SetNormalMouse()
    {
        if (instance.normalMouse) return;
        instance.mouseImage.sprite = instance.mouse;
        instance.normalMouse = true;
    }
}
