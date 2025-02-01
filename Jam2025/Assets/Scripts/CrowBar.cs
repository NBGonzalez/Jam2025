using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrowBar : MonoBehaviour
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
            if (gameManager.Instance.firstInteractItem) gameManager.Instance.firstInteractItem = false;
            if (gameManager.Instance.inputManager.player.currentInteractable.typeOfItem == ItemInteract)
            {
                AudioManager.PlaySound(SoundType.Push, 1);
                AudioManager.PlaySound(SoundType.Nails, 1);
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
