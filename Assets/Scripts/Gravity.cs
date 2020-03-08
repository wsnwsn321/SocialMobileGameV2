using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void enable()
    {
        // Debug.Log("test");
        obj = GameObject.FindGameObjectsWithTag("star");
        foreach(GameObject dropstar in obj){
            Rigidbody2D rig = (Rigidbody2D) dropstar.GetComponent(typeof(Rigidbody2D));
            rig.gravityScale = 1;
        }
    }
    
}
