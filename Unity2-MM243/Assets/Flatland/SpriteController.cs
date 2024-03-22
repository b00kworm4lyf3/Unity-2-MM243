using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpriteController : MonoBehaviour
{
    Rigidbody2D rb;
    public bool running;
    public bool jumpKeyWasPressed;
    public float speed = 1.5f;
    public float runSpeed = 2.5f;
    public float jumpPower = 100;
    float useSpeed;
    float horizontalMovement;
    public Transform groundCheckTransform;
    public InputAction run;

    void OnEnable()
    {
        run.Enable(); 
    }

    void OnDisable()
    {
        run.Disable();
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        useSpeed = speed;
        
        run.performed += _ => {
            running = true;
        };
        run.canceled += _ =>{
            running = false;
        };

    }

    // Update is called once per frame
    void Update()
    {
        if (running)
        {
            useSpeed = speed * runSpeed;
        }
        else
        {
            useSpeed = speed;
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalMovement * useSpeed, rb.velocity.y);

        if (Physics2D.OverlapBoxAll(groundCheckTransform.position, new Vector2(1.5f, 0.1f), 0f).Length == 1)
        {
            return;
        }
        
        if(jumpKeyWasPressed)
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Force);
            jumpKeyWasPressed = false;
        }
    }

    public void OnMove(InputValue value)
    {
        Vector2 movement = value.Get<Vector2>();
        horizontalMovement = movement.x;
    }

    void OnJump()
    {
        jumpKeyWasPressed = true; 
    }
    
}
