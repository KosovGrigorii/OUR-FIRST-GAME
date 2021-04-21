using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleportation : MonoBehaviour
{
    public GameObject Portal;
    public GameObject Player1;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag=="Player1")
        {
            StartCoroutine(Teleport());
        }
    }
    
    IEnumerator Teleport()
    {
        yield return new WaitForSeconds(0.2f);
        Player1.transform.position = new Vector2(Portal.transform.position.x, Portal.transform.position.y);
    }
}
