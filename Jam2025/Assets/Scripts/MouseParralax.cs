using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParralax : MonoBehaviour
{
    [SerializeField] private GameObject[] ParallaxElements;
    [SerializeField] private float MouseSpeedX = 1f;
    [SerializeField] private float MouseSpeedY = 0.2f;
    [SerializeField] private float MouseSpeedX2 = 1f;
    [SerializeField] private float MouseSpeedY2 = 0.2f;
    private Vector3[] OriginalPositions;

    [SerializeField] Camera mainCamera;
    private Vector3 OriginalPositionCamera;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined; // cursor can't leave the area

        OriginalPositions = new Vector3[ParallaxElements.Length]; //initialize array lenght
        OriginalPositionCamera = mainCamera.transform.position;

        for ( int i = 0; i< ParallaxElements.Length;i++)
        {
            OriginalPositions[i] = ParallaxElements[i].transform.position; // Set original position of each element
            
        }
    }

    private void FixedUpdate()
    {
        float mousex, mousey, mousex2, mousey2;

        // Better result across different screen sizes
        mousex = (Input.mousePosition.x - (Screen.width/2)) * MouseSpeedX/Screen.width; 
        mousey = (Input.mousePosition.y - (Screen.width/2)) * MouseSpeedY/Screen.width;

        mousex2 = (Input.mousePosition.x - (Screen.width / 2)) * MouseSpeedX2 / Screen.width;
        mousey2 = (Input.mousePosition.y - (Screen.width / 2)) * MouseSpeedY2 / Screen.width;

        for ( int i = 1;i< ParallaxElements.Length +1; i++)
        {
            ParallaxElements[i-1].transform.position = OriginalPositions[i-1] + (new Vector3(mousex, mousey,0f)); 
            // set position with corresponding offset
        }

        mainCamera.transform.position = OriginalPositionCamera + (new Vector3(mousex2, mousey2, 0f));

    }


}
