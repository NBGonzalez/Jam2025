using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UIElements;

public class gameManager : MonoBehaviour
{
    public enum TimeLine
    {
        Past,
        Present
    }

    [SerializeField]private TimeLine timeLine;
    public InventoryUI inventory;
    public InputManager inputManager;
    public Item currentItem;
    public UnityEvent onChangeTime;

    [Header("Audio")]
    [SerializeField] private AudioSource presentAudio;
    [SerializeField] private AudioSource pastAudio;

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
        //timeLine = TimeLine.Past;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeTimeLine()
    {
        if (timeLine == TimeLine.Past)
        {
            timeLine = TimeLine.Present;
            presentAudio.mute = true;
            pastAudio.mute = false;
        }
        else
        {
            timeLine = TimeLine.Past;
            presentAudio.mute = false;
            pastAudio.mute = true;
        }
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
        inventory.EnableCurrentItem();
        if (GetTimeLine() == TimeLine.Past)
        {
            currentItem.pastPrefab.transform.SetParent(inputManager.player.hand, false);
            currentItem.pastPrefab.transform.localPosition = currentItem.itemPos;
            currentItem.pastPrefab.transform.localRotation = currentItem.itemRot;
            currentItem.pastPrefab.transform.localScale = currentItem.itemSize;
            if (currentItem.position)
            {
                currentItem.pastPrefab.transform.localPosition = transform.localPosition;
                currentItem.pastPrefab.transform.localRotation = transform.localRotation;
                currentItem.pastPrefab.transform.localScale = transform.localScale;
            }
            currentItem.pastPrefab.SetActive(true);
        }

        else
        {
            currentItem.presentPrefab.transform.SetParent(inputManager.player.hand, false);
            currentItem.presentPrefab.transform.localPosition = currentItem.itemPos;
            currentItem.presentPrefab.transform.localRotation = currentItem.itemRot;
            currentItem.presentPrefab.transform.localScale = currentItem.itemSize;
            if (currentItem.position)
            {
                currentItem.presentPrefab.transform.localPosition = transform.localPosition;
                currentItem.presentPrefab.transform.localRotation = transform.localRotation;
                currentItem.presentPrefab.transform.localScale = transform.localScale;
            }
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
