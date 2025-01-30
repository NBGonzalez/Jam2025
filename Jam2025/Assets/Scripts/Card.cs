using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public Item.ItemInteract ItemInteract;
    public string[] sentences;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Interaction()
    {
        if (gameManager.Instance.inputManager.player.currentInteractable == null) return;
        if (gameManager.Instance.inputManager.player.currentInteractable.itemInteract)
        {
            if (gameManager.Instance.inputManager.player.currentInteractable.typeOfItem == ItemInteract)
            {
                AudioManager.PlaySound(SoundType.Unlock, 1);
                gameManager.Instance.inputManager.player.currentInteractable.Interact();
                gameManager.Instance.inputManager.player.currentInteractable.itemInteract = false;
                if (gameManager.Instance.inputManager.player.currentInteractable.otherInteractable != null)
                {
                    gameManager.Instance.inputManager.player.currentInteractable.otherInteractable.itemInteract = false;
                }
                gameManager.Instance.inventory.RemoveItem(gameManager.Instance.currentItem);
            }

            else
            {
                DialogueManager.StartDialogue(sentences);
            }
        }
    }
}
