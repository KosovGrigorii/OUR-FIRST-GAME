using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    float dirX, moveSpeed = 3f;

    private bool moveUp = true;
    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -15f)
            moveUp = true;
        if (transform.position.y > -1f)
            moveUp = false;

        if (moveUp)
            transform.position = new Vector2(transform.position.x, transform.position.y + moveSpeed*Time.deltaTime);
        else
        {
            transform.position = new Vector2(transform.position.x, transform.position.y - moveSpeed*Time.deltaTime);
        }
    }
}
