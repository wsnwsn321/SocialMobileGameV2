using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collisionDetect : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public float speed = 0.5f;
    public bool isGrounded;
    public GameObject gameover;
    public Rigidbody2D rb;
    public bool dead, gameStart, canJump;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.parent.parent.GetComponent<Rigidbody2D>();
        dead = false;
        gameStart = false;
        canJump = true;
        rb.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (gameStart)
            {
                if (isGrounded && !dead && canJump)
                {
                    rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
                    isGrounded = false;
                    canJump = false;
                }


            }
            else
            {
                gameStart = true;
                rb.gravityScale = 1;
            }

        }
        if (transform.position.x < -5 || transform.position.x > 5 || transform.position.y < -5)
        {
            gameover.SetActive(true);
            dead = true;
        }

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "star")
        {
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag == "stick" || col.gameObject.tag == "switch" || col.gameObject.tag == "floor" || col.gameObject.tag == "star")
        {
            isGrounded = true;
            canJump = true;
        }
        if (col.gameObject.tag == "star")
        {
            //pop up the go to next level window
        }
        if (col.gameObject.tag == "switch")
        {
            //pop up the go to next level window
            rb.AddForce(new Vector3(speed, 0, 0), ForceMode2D.Impulse);
        }


    }
    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.tag == "stick" || col.gameObject.tag == "switch" || col.gameObject.tag == "floor" || col.gameObject.tag == "star")
        {
            print("left");
            StartCoroutine(delayjump());
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "stick")
        {
            isGrounded = true;
        }
    }
    IEnumerator delayjump()
    {
        print(Time.time);
        yield return new WaitForSeconds(0.3f);
        isGrounded = false;
        print(Time.time);
    }
}
