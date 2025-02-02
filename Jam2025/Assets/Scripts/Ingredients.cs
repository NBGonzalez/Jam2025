using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredients : MonoBehaviour
{
    public Item.ItemInteract ItemInteract;
    public string[] sentences;
    public int num = 0;

    public void Interaction()
    {
        if (gameManager.Instance.inputManager.player.currentInteractable == null) DialogueManager.StartDialogue(sentences); ;
        if (gameManager.Instance.inputManager.player.currentInteractable.itemInteract)
        {
            if (gameManager.Instance.inputManager.player.currentInteractable.typeOfItem == ItemInteract)
            {
                num++;
                if (num >= 3)
                {
                    gameManager.Instance.inputManager.player.currentInteractable.Interact();
                }
                
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
