using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceMoving : MonoBehaviour
{
    private Rigidbody2D rb2d;
    public float moveSpeed;
    bool isIced;
    public Transform iceCheck;
    public LayerMask iceLayer;
    
    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        //moveSpeed = 0.5f;
        //sp = GetComponent<SpriteRenderer>(); 
    }
    // Start is called before the first frame update
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (isIced)
            {
                MoveOnIce();
            }
        }
        
    }

    private void FixedUpdate()
    {
        isIced = Physics2D.OverlapCircle(iceCheck.position, 0.2f, iceLayer);
    }

    void MoveOnIce()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        { 
            rb2d.AddForce(new Vector2(-moveSpeed, 0));
        }
        
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            rb2d.AddForce(new Vector2(moveSpeed, 0));
        }
    }
}