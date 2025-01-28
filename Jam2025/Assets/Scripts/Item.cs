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
    public UnityEvent onInteractionPast;
    public UnityEvent onInteractionPresent;
    public Sprite pastSprite;
    public Sprite presentSprite;

    public Item(string itemName, GameObject pastPrefab, GameObject presentPrefab, Vector3 itemPos, Sprite pastSprite, Sprite presentSprite)
    {
        this.itemName = itemName;
        this.pastPrefab = pastPrefab;
        this.presentPrefab = presentPrefab;
        this.itemPos = itemPos;
        this.pastSprite = pastSprite;
        this.presentSprite = presentSprite;
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

            pastPrefab.SetActive(true);
        }

        else
        {
            pastPrefab.SetActive(false);
            presentPrefab.transform.SetParent(gameManager.Instance.inputManager.player.hand);
            presentPrefab.transform.localPosition = itemPos;
            presentPrefab.SetActive(true);
        }
    }

}
