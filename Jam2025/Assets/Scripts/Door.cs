using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{

    [Header("Settings")]
    [SerializeField] private float speed;
    [SerializeField, Range(-90,90)] private float openCuantity;

    [Header("Information")]
    public Quaternion openPos;
    public Quaternion closePos;
    public bool open = false;
    public bool opening = false;
    public bool closing = false;
    // Start is called before the first frame update
    void Start()
    {
        closePos = transform.localRotation;
        //openPos = new Quaternion(transform.localRotation.x, transform.localRotation.y + openCuantity, transform.localRotation.z, transform.localRotation.w);
    }

    // Update is called once per frame
    void Update()
    {
        if (opening)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, openPos, Time.deltaTime * speed);
            
            if (Quaternion.Angle(transform.localRotation, openPos) < 0.0001f)
            {
                opening = false;
                open = true;
            }
        }

        if (closing)
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, closePos, Time.deltaTime * speed);
            if (Quaternion.Angle(transform.localRotation, closePos) < 0.0001f)
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
