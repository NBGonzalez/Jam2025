using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    private Outline outline;
    [SerializeField] public string message;


    [Header("Items Configuration")]
    [SerializeField] public string itemName;
    [SerializeField] public GameObject pastPrefab;
    [SerializeField] public GameObject presentPrefab;
    [SerializeField] public Vector3 itemPos;
    public UnityEvent onInteractionPast;
    public UnityEvent onInteractionPresent;

    [SerializeField] private Interactable otherInteractable;

    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        Copy();
        outline = GetComponent<Outline>();
        DisableOutline();
    }

    public void Copy()
    {
        if (otherInteractable == null) return;
        otherInteractable.itemName = itemName;
        otherInteractable.pastPrefab = pastPrefab;
        otherInteractable.presentPrefab = presentPrefab;
        otherInteractable.itemPos = itemPos;
        otherInteractable.onInteractionPast = onInteractionPast;
        otherInteractable.onInteractionPresent = onInteractionPresent;
    }

    public void Interact()
    {
        onInteraction.Invoke();
    }

    public void DisableOutline()
    {
        if (outline == null) return;
        outline.enabled = false;
    }

    public void EnableOutline()
    {
        if (outline == null) return;
        outline.enabled = true;
    }

    public void AddItem()
    {
        Item item = new Item(itemName, pastPrefab, presentPrefab, itemPos);
        item.onInteractionPast = onInteractionPast;
        item.onInteractionPresent = onInteractionPresent;
        gameManager.Instance.inventory.AddItem(item);
        gameManager.Instance.currentItem = item;
        if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past)
        {
            item.pastPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
            item.pastPrefab.transform.localPosition = itemPos;
 
            item.pastPrefab.SetActive(true);
        }

        else
        {
            item.presentPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
            item.presentPrefab.transform.localPosition = itemPos;
            item.presentPrefab.SetActive(true);
        }
        gameObject.SetActive(false);
    }

}
