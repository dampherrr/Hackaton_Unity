using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController cc;
    public float moveSpeed = 7f;
    public float jumpForce = 10f;

    float yRotation = 0f;
    float gravity = -9.81f;  
    float yVelocity = 0.0f;

    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    void Update()
    {
 
        float xInput = Input.GetAxis("Horizontal");
        float xVel = xInput * moveSpeed;

   
        if (cc.isGrounded)
        {
 
            if (Input.GetButtonDown("Jump"))
            {
                yVelocity = jumpForce;
            }
            else
            {
                yVelocity = 0f; 
            }
        }
        else
        {
       
            yVelocity += gravity * Time.deltaTime;
        }

      Vector3 move = new Vector3(xVel, yVelocity, 0) * Time.deltaTime;
        cc.Move(move);
 
   
        if (xInput > 0.1f)
        {
            yRotation = 0f;
        }
        else if (xInput < -0.1f) 
        {
            yRotation = 180f;
        }

        Vector3 rot = transform.rotation.eulerAngles;
        rot.y = Mathf.Lerp(rot.y, yRotation, 5f * Time.deltaTime);
        transform.rotation = Quaternion.Euler(rot);
    }
}
