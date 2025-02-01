using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Card : MonoBehaviour
{
    public Item.ItemInteract ItemInteract;
    public string[] sentences;
    public UnityEvent Sound;
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
                Sound.Invoke();
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
        else
        {
            DialogueManager.StartDialogue(sentences);
        }
    }

}
