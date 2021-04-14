using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterA : MonoBehaviour
{
    public float moveSpeed;
    private float xInput, yInput;
    private Rigidbody2D rb2d;
    private SpriteRenderer sp;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private bool canDoubleJump;
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        sp = GetComponent<SpriteRenderer>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded)
            {
                Jump();
                canDoubleJump = true;
            }
            
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }
    }

    private void FixedUpdate()
    {
        xInput = Input.GetKey(KeyCode.LeftArrow) ? Input.GetAxis("Horizontal") :
            Input.GetKey(KeyCode.RightArrow) ? Input.GetAxis("Horizontal") : 0;
        //yInput = Input.GetKey(KeyCode.UpArrow) ? Input.GetAxis("Vertical") :
        //    Input.GetKey(KeyCode.DownArrow) ? Input.GetAxis("Vertical") : 0;
        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
        
        PlatformerMove();
        FlipPlayer();

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);

    }
    

    void PlatformerMove()
    {
        rb2d.velocity = new Vector2(moveSpeed * xInput, rb2d.velocity.y);
    }

    void FlipPlayer()
    {
        if (rb2d.velocity.x < 0f)
        {
            sp.flipX = true;
        }

        else if(rb2d.velocity.x > 0f)
        {
            sp.flipX = false;
        }
    }

    void Jump()
    {
        rb2d.velocity = Vector2.up * jumpForce;
    }
}
