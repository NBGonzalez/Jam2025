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
    [SerializeField] private float gravity = -9.8f;
    [SerializeField] private Vector3 velocity;
    [SerializeField] private float footRange;
    [SerializeField] private Transform footTransform;
    [SerializeField] private bool isTouching;
    [SerializeField] private LayerMask collisionMask;
    [SerializeField] private Vector3 otherPosition;
    [SerializeField] private Camera camara;
    [SerializeField] private AudioListener listener;
    public bool controllPlayer = false;
    public Player otherPlayer;
    public Transform hand;

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
        if (!controllPlayer) return;
        Move();
        CheckInteraction();
        if (Input.GetKeyDown(KeyCode.E) && currentInteractable != null)
        {
            currentInteractable.Interact();
        }

        isTouching = Physics.Raycast(footTransform.position, -footTransform.up, footRange, collisionMask);
        Debug.DrawRay(footTransform.position, -footTransform.up * footRange, Color.blue);

        if (isTouching)
        {
            if (velocity.y < 0)
            {
                velocity.y = -3;
            }
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        //otherPosition = otherPlayer.transform.localPosition - transform.localPosition;
        otherPlayer.transform.localPosition = transform.localPosition + otherPosition;
        otherPlayer.transform.localRotation = transform.localRotation;
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

    public void DisablePlayer()
    {
        listener.enabled = false;
        camara.enabled = false;
        
        controllPlayer = false;
    }

    public void EnablePlayer()
    {
        camara.enabled = true;
        listener.enabled = true;
        controllPlayer = true;
    }
}
