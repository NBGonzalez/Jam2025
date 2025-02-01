using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogo : MonoBehaviour
{
    [SerializeField] private string[] sentences;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>() != null)
        {
            DialogueManager.StartDialogue(sentences);
        }
    }

    public void StartConversation()
    {
        DialogueManager.StartDialogue(sentences);
    }
}
