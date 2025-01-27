using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    private Outline outline;
    [SerializeField] public string message;

    public UnityEvent onInteraction;
    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();
        DisableOutline();
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

    // Update is called once per frame
    void Update()
    {

    }
}
