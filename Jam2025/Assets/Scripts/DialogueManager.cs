using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI DialogueText;
    public string[] Sentences;
    private int index = 0;
    public float DialogueSpeed;

    // Start is called before the first frame update
    void Start()
    {
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
}
