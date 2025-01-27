using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Player : MonoBehaviour
{
    CharacterController controller;
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float playerReach = 3f;

    [Header("Animaciones")]
    private Animator animator;
    private bool movement = false;

    Interactable currentInteractable;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }
    }

    public void Move()
    {
        movement = false;
        if (Input.GetButton("Horizontal"))
        {
            movement = true;
            Vector3 move = Input.GetAxis("Horizontal") * transform.right;
            controller.Move(move * speed * Time.deltaTime);
        }

        if (Input.GetButton("Vertical"))
        {
            movement = true;
            Vector3 move = Input.GetAxis("Vertical") * transform.forward;
            controller.Move(move * speed * Time.deltaTime);
        }


        animator.SetBool("Walk", movement);

    }

    public void CheckInteraction()
    {
        RaycastHit hit;
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        //Debug.DrawLine(ray.origin, ray.direction, Color.red);
        Debug.DrawRay(ray.origin, ray.direction * playerReach, Color.red);
        if (Physics.Raycast(ray, out hit, playerReach))
        {
            //Debug.DrawLine(ray.origin, hit.transform.position, Color.red);
            if (hit.collider.tag == "interactable")
            {
                Interactable newInteractable = hit.collider.GetComponent<Interactable>();

                if (currentInteractable && newInteractable != currentInteractable)
                {
                    DisableCurrentInteractable();
                }

                if (newInteractable.enabled)
                {
                    SetNewCurrentInteractable(newInteractable);
                }

                else
                {
                    DisableCurrentInteractable();
                }
            }

            else
            {
                DisableCurrentInteractable();
            }
        }

        else
        {
            DisableCurrentInteractable();
        }
    }

    private void SetNewCurrentInteractable(Interactable newInteractable)
    {
        currentInteractable = newInteractable;
        currentInteractable.EnableOutline();
        //HUDController.instance.EnableInteractionText(currentInteractable.message);
    }

    private void DisableCurrentInteractable()
    {
        //HUDController.instance.DisableInteractionText();
        if (currentInteractable == null) return;
        currentInteractable.DisableOutline();
        currentInteractable = null;
    }
}
