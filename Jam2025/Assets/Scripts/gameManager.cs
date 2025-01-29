using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class gameManager : MonoBehaviour
{
    public enum TimeLine
    {
        Past,
        Present
    }

    private TimeLine timeLine;
    public InventoryUI inventory;
    public InputManager inputManager;
    public Item currentItem;
    public UnityEvent onChangeTime;

    private static gameManager instance;

    public static gameManager Instance
    {
        get
        {
            return instance;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        timeLine = TimeLine.Past;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTimeLine()
    {
        if (timeLine == TimeLine.Past) timeLine = TimeLine.Present;
        else timeLine = TimeLine.Past;
        if (currentItem != null) currentItem.ChangeItemTime();
        Debug.Log(timeLine);
    }

    public TimeLine GetTimeLine()
    {
        return timeLine;
    }

    public void SetCurrentItem(Item item)
    {
        currentItem = item;
        if (GetTimeLine() == TimeLine.Past)
        {
            currentItem.pastPrefab.transform.SetParent(inputManager.player.hand);
            currentItem.pastPrefab.transform.localPosition = item.itemPos;

            currentItem.pastPrefab.SetActive(true);
        }

        else
        {
            currentItem.presentPrefab.transform.SetParent(inputManager.player.hand);
            currentItem.presentPrefab.transform.localPosition = currentItem.itemPos;
            currentItem.presentPrefab.SetActive(true);
        }
        //gameObject.SetActive(false);
    }

    public void DisableCurrentItem()
    {
        currentItem.pastPrefab.SetActive(false);
        currentItem.presentPrefab.SetActive(false);
    }
}
