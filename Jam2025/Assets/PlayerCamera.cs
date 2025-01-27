using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    //Variables publicas
    public float sensibilidad = 80f;
    public Transform player;

    //Variables privadas
    float xRotation = 0;
    float yRotation = 0;



    void Start()
    {
        //Mantener el cursor en la escena Game
        Cursor.lockState = CursorLockMode.Locked;
    }


    void Update()
    {

        //Movimiento del raton en los ejes x e y
        float x = Input.GetAxis("Mouse X") * sensibilidad * Time.deltaTime;
        float y = Input.GetAxis("Mouse Y") * sensibilidad * Time.deltaTime;


        //Rotacion de la camara
        xRotation -= y;
        yRotation += x;


        //Limites de rotacion en el eje x
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);


        //Transformaciones de la camara y del personaje
        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        player.Rotate(Vector3.up * x);

    }
}
