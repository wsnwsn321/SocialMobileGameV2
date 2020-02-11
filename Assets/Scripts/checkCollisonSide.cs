using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollisonSide : MonoBehaviour
{
    public PlyaerController player;
    private AudioSource source;
    public AudioClip shootSound;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            //print("entered");
            source.PlayOneShot(shootSound, 1);

        }
    }
}
