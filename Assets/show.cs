using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class show : MonoBehaviour
{
    public PlyaerController player;
    public GameObject showStick;
    public GameObject showStick2;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            showStick.SetActive(true);
            showStick2.SetActive(true);
        }



    }
}
