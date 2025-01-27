using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawerInteraction : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField] private Vector3 openPos;
    [SerializeField] private float openCuantity;

    [Header("Information")]
    public float differenceDrawer;
    public bool open = false;
    public bool opening = false;
    public bool closing = false;
    Vector3 closePos;

    // Start is called before the first frame update
    void Start()
    {
        closePos = transform.localPosition;
        openPos = new Vector3(transform.localPosition.x , transform.localPosition.y, transform.localPosition.z - openCuantity);
    }

    // Update is called once per frame
    void Update()
    {
        //differenceDrawer = closePos.z - transform.localPosition.z;

        if (opening)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, openPos, Time.deltaTime * speed);
            if (Vector3.Distance(transform.localPosition, openPos) < 0.0001f)
            {
                opening = false;
                open = true;
            }
        }

        if (closing)
        {
            transform.localPosition = Vector3.MoveTowards(transform.localPosition, closePos, Time.deltaTime * speed);
            if (Vector3.Distance(transform.localPosition, closePos) < 0.0001f)
            {
                closing = false;
                open = false;
            }

        }
    }

    public void OpenClose()
    {
        Debug.Log("Entra");
        if (!open) opening = true;
        else closing = true;
    }
}
