using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item
{
    [SerializeField] private string itemName;
    [SerializeField] private GameObject pastPrefab;
    [SerializeField] private GameObject presentPrefab;
    public UnityEvent onInteractionPast;
    public UnityEvent onInteractionPresent;

    public Item(string itemName, GameObject pastPrefab, GameObject presentPrefab)
    {
        this.itemName = itemName;
        this.pastPrefab = pastPrefab;
        this.presentPrefab = presentPrefab;
    }

    public void InteractPast()
    {
        onInteractionPast.Invoke();
    }

    public void InteractPresent()
    {
        onInteractionPresent.Invoke();
    }
}
