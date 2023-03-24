using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    
   public float rotationX = 0f; //variable apra rotar en el eje x
   public float rotationY = 0f; //variable apra rotar en el eje y

   public float sensibility = 15f; //para ir calando la sensibilidad

    float limitXizq = -60f;
    float limitXder = 60f;
    float limityder = 60f;
    float limityizq = -60f;

    // Update is called once per frame
    void Update()
    {

        if (rotationX <= limitXder )
        {
            rotationX += Input.GetAxis("Mouse Y") * -1 * sensibility;
        }
        else
        {
            rotationX = 60f;
        }
        if (rotationX >= limitXizq)
        {
            rotationX += Input.GetAxis("Mouse Y") * -1 * sensibility;
        }
        else
        {
            rotationX = -60f;
        }
        if (rotationY <= limityder)
        {
            rotationY += Input.GetAxis("Mouse X") * sensibility;
        }
        else
        {
            rotationY = 60f;
        }
        if (rotationY >= limityizq)
        {
            rotationY += Input.GetAxis("Mouse X") * sensibility;
        }
        else
        {
            rotationY = -60f;
        }


       
        transform.localEulerAngles = new Vector3 (rotationX, rotationY, 0);
       // Debug.Log(rotationX);

    }
}
