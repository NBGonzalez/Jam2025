using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Dictionary<Item, int> inventory = new Dictionary<Item, int>();
    public Dictionary<int, Item> itemIndex = new Dictionary<int, Item>();
    public List<int> slots = new List<int>();
    public List<int> takenSlots = new List<int>();
    public List<Image> images = new List<Image>();
    public List<GameObject> currentSlots = new List<GameObject>();

    public void Awake()
    {
        for(int i = 0; i < images.Count; i++)
        {
            slots.Add(i);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool Full()
    {
        return slots.Count == 0;
    }

    public void AddItem(Item item)
    {
        int idx = slots[0];
        if (inventory.ContainsKey(item))
        {
            inventory[item] = idx;
            itemIndex[idx] = item;
        }

        else
        {
            inventory.Add(item, idx);
            itemIndex.Add(idx, item);
        }

        if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past)
        {
            images[idx].sprite = item.pastSprite;
        }

        else
        {
            images[idx].sprite = item.presentSprite;
        }

        images[idx].gameObject.SetActive(true);
        slots.Remove(idx);
        slots.Sort();
        takenSlots.Add(idx);
        takenSlots.Sort();
    }

    public void RemoveItem(Item item)
    {
        int idx = inventory[item];
        images[idx].sprite = null;
        images[idx].gameObject.SetActive(false);
        inventory.Remove(item);
        itemIndex.Remove(idx);
        slots.Add(idx);
        slots.Sort();
        takenSlots.Remove(idx);
        takenSlots.Sort();
        if (takenSlots.Count > 0) gameManager.Instance.SetCurrentItem(itemIndex[takenSlots[0]]);
        else
        {
            gameManager.Instance.currentItem = null;
            currentSlots[idx].SetActive(false);
        }
        Destroy(item.pastPrefab);
        Destroy(item.presentPrefab);
    }

    public void ChangeCurrentItem(Item item, int i)
    {
        int idx = inventory[item];
        idx = takenSlots.IndexOf(idx);
        currentSlots[idx].SetActive(false);
        idx = (idx + i + takenSlots.Count) % takenSlots.Count;
        gameManager.Instance.DisableCurrentItem();
        currentSlots[idx].SetActive(true);
        gameManager.Instance.SetCurrentItem(itemIndex[idx]);

    }

    public void DisableCurrentItem()
    {
        int idx = inventory[gameManager.Instance.currentItem];
        currentSlots[idx].SetActive(false);
    }

    public void EnableCurrentItem()
    {
        int idx = inventory[gameManager.Instance.currentItem];
        currentSlots[idx].SetActive(true);
    }

    public void ChangeAllItemsTime()
    {
        if (gameManager.Instance.GetTimeLine() == gameManager.TimeLine.Past)
        {
            foreach (int i in takenSlots)
            {
                images[i].sprite = itemIndex[i].pastSprite;
            }
        }

        else
        {
            foreach (int i in takenSlots)
            {
                images[i].sprite = itemIndex[i].presentSprite;
            }
        }
    }

}
