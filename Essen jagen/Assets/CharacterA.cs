using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;

public class CharacterA : MonoBehaviour
{
    public float moveSpeed;
    private float xInput, yInput;
    public Rigidbody2D rb2d;
    private SpriteRenderer sp;
    public float jumpForce;
    private bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public LayerMask iceLayer;
    public bool isIce;
    public Vector2 oldVelocity;

    public int maxHealth = 1000;
    public int currentHealth;
    public HealthBar healthBar;
    const int coef = 1;



    private bool canDoubleJump;
    

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();

        sp = GetComponent<SpriteRenderer>(); 
    }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (isGrounded||isIce)
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

        transform.Translate(xInput * moveSpeed, yInput * moveSpeed, 0);
        
        isIce = Physics2D.OverlapCircle(groundCheck.position, 0.2f, iceLayer);
        if (isIce && xInput == 0)
        {
            rb2d.AddForce(oldVelocity);
            oldVelocity = new Vector2(moveSpeed * xInput, rb2d.velocity.y);
            //rb2d.velocity = new Vector2(oldVelocity.x/2, rb2d.velocity.y);

        }
        
        else if (isIce && xInput != 0)
        {
            rb2d.velocity = new Vector2(moveSpeed * xInput, rb2d.velocity.y)*10;
            oldVelocity = rb2d.velocity;
            FlipPlayer();

        }

        else
        {
            PlatformerMove();
            FlipPlayer();
        }

        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        
        TakeDamage();
    }

    public void TakeDamage()
    {
        currentHealth -= coef;
        healthBar.SetHealth(currentHealth);
    }


    

    void PlatformerMove()
    {
        rb2d.velocity = new Vector2(moveSpeed * xInput, rb2d.velocity.y);
        oldVelocity = rb2d.velocity;
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
