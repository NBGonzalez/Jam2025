using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casette : MonoBehaviour
{
    public Item.ItemInteract ItemInteract;
    public string[] sentences;
    public bool charge = false;
    public Dialogo chargeDialogue;
    public Dialogo pastDialogue;
    public Dialogo wrongDialogue;
    public AudioSource AudioSource;

    private static Casette instance;

    public static Casette Instance
    {
        get
        {
            return instance;
        }
    }

    public void WronInteraction()
    {
        wrongDialogue.StartConversation();
    }

    public void PastInteraction()
    {
        pastDialogue.StartConversation();
    }
    public void Interaction()
    {
        if (charge)
        {
            if (DialogueManager.Instance.lastDialogue) return;
            chargeDialogue.StartLastConversation();
            AudioSource.Play();
        }

        else
        {
            WronInteraction();
        }
    }

    public void Charge()
    {
        charge = true;
    }
}
