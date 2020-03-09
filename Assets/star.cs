using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class star : MonoBehaviour
{
    public Rigidbody2D rigidbody;
    GameObject circlePlayer;
    Vector2 circleDirection;
    float timeStamp;
    public float distance;
    bool flyToPlayer;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(flyToPlayer){
            circleDirection = - (transform.position - circlePlayer.transform.position).normalized;
            rigidbody.velocity = new Vector2(circleDirection.x, circleDirection.y)*10f*(Time.time/timeStamp);
            //Debug.Log((transform.position - circlePlayer.transform.position).sqrMagnitude);
            if((transform.position - circlePlayer.transform.position).sqrMagnitude>distance){
                flyToPlayer = false;
                rigidbody.velocity = new Vector2(0,0);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.name.Equals("StarMagnet")){
            timeStamp = Time.time;
            //circlePlayer = GameObject.Find("Player");
            circlePlayer = GameObject.FindWithTag("Player");
            flyToPlayer = true;
        }
    }

    public void buttonHandler(){
        flyToPlayer = false;
    }
}