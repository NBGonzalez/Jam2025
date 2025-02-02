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
    [SerializeField] private GameObject backGround;
    [SerializeField] private bool writing = false;
    public bool lastDialogue = false;
    [SerializeField] private AudioSource audioSource;

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
        StartDialogue(Sentences);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && writing)
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

    public static void StartDialogue(string[] dialogue)
    {
        if (instance.lastDialogue) return;
        instance.StopAllCoroutines();
        instance.DialogueText.text = "";
        instance.Sentences = dialogue;
        instance.writing = true;
        instance.index = 0;
        instance.backGround.SetActive(true);
        instance.StartCoroutine(instance.WriteSentence());
    }
    
    public static void StartLastDialogue(string[] dialogue)
    {
        if (instance.lastDialogue) return;
        instance.audioSource.Stop();
        instance.lastDialogue = true;
        instance.StopAllCoroutines();
        instance.DialogueText.text = "";
        instance.Sentences = dialogue;
        instance.writing = true;
        instance.index = 0;
        instance.backGround.SetActive(true);
        instance.StartCoroutine(instance.WriteSentence());
    }

    public static void StopDialogue()
    {
        if (instance.lastDialogue) return;
        instance.StopAllCoroutines();
        instance.writing = false;
        instance.DialogueText.text = "";
        instance.backGround.SetActive(false);
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

            writing = false;
            DialogueText.text = "";
            if (!lastDialogue)backGround.SetActive(false);
            if (lastDialogue) Invoke("ChangeCinematic", 0.5f);
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

    public void ChangeCinematic()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
        TransitionManager.Instance.LoadScene(TransitionManager.SCENE_LASTCINEMATIC);
    }
}
