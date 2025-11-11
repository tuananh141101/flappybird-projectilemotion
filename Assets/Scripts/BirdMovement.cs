using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdMovement : MonoBehaviour
{
    public float jumpSpeed = 5f;
    public float gravity = 9.8f;
    private float verticalVelocity = 0f; // van toc doc
    public float forwardSpeed = 0f; //toc do di chuyen ngang

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) 
        {
            verticalVelocity = jumpSpeed;
            Debug.Log("Press key space");
        }
        Debug.Log("check verticalVelocity: " + verticalVelocity);

        // Mo phong trong luc (giong nem xien theo truc Y) - Vy
        verticalVelocity -= gravity * Time.deltaTime;
   

        //Cap nhap vi tri theo truc y
        transform.position += new Vector3(0, verticalVelocity * Time.deltaTime, 0);
        //transform.position = new Vector3(deltaX, deltaY, 0);

        // xoay con chim theo huong van toc xien
        float rotationZ = Mathf.Atan2(verticalVelocity, 5f) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rotationZ);
    }
}
