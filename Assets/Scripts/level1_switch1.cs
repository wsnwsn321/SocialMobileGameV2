using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1_switch1 : MonoBehaviour
{
    public GameObject platform;
    SpriteRenderer renderer;
    PolygonCollider2D pc;
    // Start is called before the first frame update
    void Start()
    {   
        renderer = GetComponent<SpriteRenderer>();
        pc = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            renderer.color = new Color(0.5f, 0.5f, 0.5f);
            platform.GetComponent<BoxCollider2D>().enabled = true;
            SpriteRenderer platformColor = platform.GetComponent<SpriteRenderer>();
            platformColor.color =new Color(platformColor.color.r,platformColor.color.g,platformColor.color.b,256);
            pc.enabled = false;
        }
       


    }
}
