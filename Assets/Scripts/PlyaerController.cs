using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlyaerController : MonoBehaviour
{
    public float jumpForce = 2.0f;
    public bool isGrounded;
    public bool isMagnetic;
    public bool shield;
    public GameObject gameover;
    public Rigidbody2D rb;
    public bool dead, gameStart, canJump;
    public GameObject bottomCollider;
    public GameObject starMagnet;
    public GameSuccess gs;
    private Vector3 jumpDirection;
    public int currentStar;
    private AudioSource source;
    public AudioClip shootSound;
    public AudioClip jump;
    public AudioClip sw;
    public AudioClip lose;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dead = false;
        gameStart = false;
        shield = false;
        canJump = true;
        isMagnetic = false;
        rb.gravityScale = 0;
        currentStar = 0;
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isMagnetic){
            starMagnet.transform.position = new Vector2 (transform.position.x, transform.position.y);
        }else{
            starMagnet.transform.position = new Vector2 (1920, 1080);
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (gameStart)
            {
                if (isGrounded && !dead && canJump)
                {
                    jumpBall();
                }


            }
            else
            {
                gameStart = true;
                rb.gravityScale = 1;
            }

        }
        if (this.gameObject.name != "controller")
        {
            if (transform.position.x < -5 || transform.position.x > 5 || transform.position.y < -5 && !gs.ended)
            {
                if (!dead)
                {
                    source.pitch = 2;
                    source.PlayOneShot(lose, 1);
                    source.pitch = 1;
                    gameover.SetActive(true);
                    dead = true;
                }

            }
        }


    }
    public void jumpBall()
    {
        source.PlayOneShot(jump, 1);
        rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode2D.Impulse);
        isGrounded = false;
        canJump = false;
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "star")
        {
            currentStar++;
            Destroy(col.gameObject);
            source.PlayOneShot(shootSound, 1);
        }

        if (col.gameObject.tag == "stick" || col.gameObject.tag == "floor")
        {
            Vector3 collisionPoint = col.contacts[0].point;
            if (collisionPoint.y < transform.position.y)
            {
                isGrounded = true;
                canJump = true;
            }


        }


        if (col.gameObject.tag == "switch")
        {
            source.PlayOneShot(sw, 1);
        }


    }
    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.tag == "stick" || col.gameObject.tag == "switch" || col.gameObject.tag == "floor" || col.gameObject.tag == "star")
        {
            StartCoroutine(delayjump());
        }
    }

    void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.tag == "stick" || col.gameObject.tag == "floor")
        {
            isGrounded = true;
        }
    }
    IEnumerator delayjump()
    {
        yield return new WaitForSeconds(0.3f);
        isGrounded = false;
    }

    public void buttonhandler(){
        isMagnetic = !isMagnetic;
    }
    public void bubblePowerUp()
    {
        Debug.Log("shield activated");
        shield = !shield;

        //gameObject.SetActive(false);
    }
}