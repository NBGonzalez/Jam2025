using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoppingList : MonoBehaviour
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
                gameManager.Instance.inputManager.player.currentInteractable.Interact();
                Destroy(gameManager.Instance.inputManager.player.currentInteractable.gameObject);
                gameManager.Instance.inventory.RemoveItem(gameManager.Instance.currentItem);
            }

            else
            {
                DialogueManager.StartDialogue(sentences);
            }
        }
    }


}
