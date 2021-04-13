using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{
    public float speed;
    private float moveInput;
    private Rigidbody2D ridgitBody;
    public bool faceRight = true;

    public float jumpForse;
    private bool isGround;
    public Transform groundCheck;
    private int extraJump;
    public int extraJumpValue;
    public float checkRadius;
    public LayerMask whatIsGraund;

    Vector2 lookVector;
    bool inAir;
    void Start()
    {
        ridgitBody = GetComponent<Rigidbody2D>();
        groundCheck = gameObject.transform;
    }

    void Update()
    {
        if (isGround)
            extraJump = extraJumpValue;

        if (Input.GetKey(KeyCode.W) && extraJump>0)
        {
            ridgitBody.velocity = Vector2.up * jumpForse;
            extraJump--;
        }
        else if (Input.GetKey(KeyCode.W) && extraJump == 0 && isGround)
            ridgitBody.velocity = Vector2.up * jumpForse;
    }

    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGraund);
        moveInput = Input.GetKey(KeyCode.D) ? 1 : Input.GetKey(KeyCode.A) ? -1 : 0;
        ridgitBody.velocity = new Vector2(moveInput * speed, ridgitBody.velocity.y);

        if (!faceRight && moveInput > 0)
        {
            Flip();
        }

        if (faceRight && moveInput < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        faceRight = !faceRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}
