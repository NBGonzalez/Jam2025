using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTime : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("No puede");
        Debug.Log(other.gameObject.name);
        gameManager.Instance.canTravel = false;
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Puede");
        gameManager.Instance.canTravel = true;
    }
}
