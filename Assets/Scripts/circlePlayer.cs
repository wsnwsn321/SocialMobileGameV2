using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class circlePlayer: MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = -0.5f;
    public bool isGrounded;
    public Rigidbody2D rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    void    Update()
    {

        if (Input.GetKeyDown(KeyCode.Space)&&isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);

            isGrounded = false;
        }

    }
    void OnCollisionEnter2D(Collision2D col){
            if(col.gameObject.tag =="star")
            {
                Destroy(col.gameObject);
                }

        isGrounded = true;
    }



}
