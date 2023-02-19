using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] CharacterController controller;
    [SerializeField] float speed = 5f;
    private Vector3 direction;
    [SerializeField] float jumpForce = 5f;
    [SerializeField] float gravity = 50f;
    Animator anim;

    
    void Start()
    {
        
    }

    
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        direction = new Vector3(moveHorizontal, 0, moveVertical);
        direction = transform.TransformDirection(direction) * speed;
        anim = GetComponent<Animator>();

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = 10;
        }
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = 5;
        }
        if (controller.isGrounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                direction.y = jumpForce;
            }
        }

        if (direction.magnitude > 0)
        {
            anim.SetBool("Sprint", true);
        }
        else anim.SetBool("Sprint", false);

        if (direction.magnitude > 0)
        {
            anim.SetBool("Jump", true);
        }
        else anim.SetBool("Jump", false);

        

        
        
        direction.y -= gravity * Time.deltaTime;
        controller.Move(direction * Time.deltaTime);
    }

    
}
