using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] private float speed = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (Input.GetButton("Horizontal"))
        {
            Vector3 move = Input.GetAxis("Horizontal") * transform.right;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            Vector3 move = Input.GetAxis("Vertical") * transform.forward;
            controller.Move(move * speed * Time.deltaTime);
        }
    }
}
