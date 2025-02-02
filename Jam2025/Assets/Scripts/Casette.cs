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
            chargeDialogue.StartConversation();
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
