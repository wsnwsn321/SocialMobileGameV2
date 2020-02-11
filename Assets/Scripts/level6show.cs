using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level6show : MonoBehaviour
{
    public PlyaerController player;
    public GameObject showCircle1;
    public GameObject showCircle2;
    public GameObject showCircle3;
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
            showCircle1.SetActive(true);
            showCircle2.SetActive(true);
            showCircle3.SetActive(true);
        }



    }
}
