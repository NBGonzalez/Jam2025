using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTime : MonoBehaviour
{

    [SerializeField] private InputManager inputManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void TimeChange()
    {
        inputManager.timeChange = false;
    }
}
