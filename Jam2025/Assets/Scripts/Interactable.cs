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
    [SerializeField] public Quaternion itemRot;
    [SerializeField] public Vector3 itemScale;
    public bool itemInteract = false;
    public bool itemTransform = false;
    public Transform t;
    public Item.ItemInteract typeOfItem;
    public UnityEvent onInteractionPast;
    public UnityEvent onInteractionPresent;
    public Sprite pastSprite;
    public Sprite presentSprite;

    public string[] sentences;


    [SerializeField] public Interactable otherInteractable;

    public UnityEvent onInteraction;
    public UnityEvent onWrongInteraction;
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

    public void WrongInteract()
    {
        onWrongInteraction.Invoke();
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
        Item item = new Item(itemName, pastPrefab, presentPrefab, itemPos, pastSprite, presentSprite, itemScale, itemRot);
        if (itemTransform)
        {
            item.SetPos(true);
            item.SetTransform(t);
        }
        item.onInteractionPast = onInteractionPast;
        item.onInteractionPresent = onInteractionPresent;
        gameManager.Instance.inventory.AddItem(item);
        if (gameManager.Instance.currentItem != null)
        {
            gameManager.Instance.DisableCurrentItem();
            gameManager.Instance.inventory.DisableCurrentItem();
        }
        gameManager.Instance.SetCurrentItem(item);
        Destroy(gameObject);
        //gameManager.Instance.currentItem = item;

        //if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past)
        //{
        //    item.pastPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
        //    item.pastPrefab.transform.localPosition = itemPos;

        //    item.pastPrefab.SetActive(true);
        //}

        //else
        //{
        //    item.presentPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
        //    item.presentPrefab.transform.localPosition = itemPos;
        //    item.presentPrefab.SetActive(true);
        //}
        //gameObject.SetActive(false);
    }

    public void Dialogue()
    {
        DialogueManager.StartDialogue(sentences);
    }

}
