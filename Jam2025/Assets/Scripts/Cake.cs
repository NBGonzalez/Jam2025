using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cake : MonoBehaviour
{
    public Item.ItemInteract ItemInteract;
    public string[] sentences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Interaction()
    {
        if (gameManager.Instance.inputManager.player.currentInteractable == null) DialogueManager.StartDialogue(sentences); ;
        if (gameManager.Instance.inputManager.player.currentInteractable.itemInteract)
        {
            if (gameManager.Instance.inputManager.player.currentInteractable.typeOfItem == ItemInteract)
            {
                gameManager.Instance.inputManager.player.currentInteractable.Interact();
                gameManager.Instance.inventory.RemoveItem(gameManager.Instance.currentItem);
            }

            else
            {
                DialogueManager.StartDialogue(sentences);
            }
        }
        else
        {
            DialogueManager.StartDialogue(sentences);
        }
    }
}
