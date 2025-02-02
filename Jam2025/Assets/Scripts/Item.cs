using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using static UnityEditor.Progress;

public class Item 
{
    [SerializeField] private string itemName;
    [SerializeField] public GameObject pastPrefab;
    [SerializeField] public GameObject presentPrefab;
    [SerializeField] public Vector3 itemPos;
    [SerializeField] public Vector3 itemSize;
    [SerializeField] public Quaternion itemRot;
    public bool position = false;
    public Transform transform;
    public UnityEvent onInteractionPast;
    public UnityEvent onInteractionPresent;
    public Sprite pastSprite;
    public Sprite presentSprite;

    public enum ItemInteract
    {
        Key,
        Card,
        List,
        CrowBar,
        Casette
    }

    public ItemInteract itemInteract;

    public Item(string itemName, GameObject pastPrefab, GameObject presentPrefab, Vector3 itemPos, Sprite pastSprite, Sprite presentSprite, Vector3 itemSize, Quaternion itemRot)
    {
        this.itemName = itemName;
        this.pastPrefab = pastPrefab;
        this.presentPrefab = presentPrefab;
        this.itemPos = itemPos;
        this.pastSprite = pastSprite;
        this.presentSprite = presentSprite;
        this.itemSize = itemSize;
        this.itemRot = itemRot;
    }

    public void SetInteract(ItemInteract interact)
    {
        itemInteract = interact;
    }

    public void InteractPast()
    {
        onInteractionPast.Invoke();
    }

    public void InteractPresent()
    {
        onInteractionPresent.Invoke();
    }

    public void ChangeItemTime()
    {
        if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past)
        {
            presentPrefab.SetActive(false);
            pastPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
            pastPrefab.transform.localPosition = itemPos;
            pastPrefab.transform.localRotation = itemRot;
            pastPrefab.transform.localScale = itemSize;
            if (position)
            {
                pastPrefab.transform.localPosition = transform.localPosition;
                pastPrefab.transform.localRotation = transform.localRotation;
                pastPrefab.transform.localScale = transform.localScale;
            }

            pastPrefab.SetActive(true);
        }

        else
        {
            pastPrefab.SetActive(false);
            presentPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
            presentPrefab.transform.localPosition = itemPos;
            presentPrefab.transform.localRotation = itemRot;
            presentPrefab.transform.localScale = itemSize;

            if (position)
            {
                presentPrefab.transform.localPosition = transform.localPosition;
                presentPrefab.transform.localRotation = transform.localRotation;
                presentPrefab.transform.localScale = transform.localScale;
            }
            presentPrefab.SetActive(true);
        }
    }

    public void SetPos(bool t)
    {
        position = t;
    }

    public void SetTransform(Transform t)
    {
        transform = t;
    }

}
