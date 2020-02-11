using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeDead : MonoBehaviour
{
    public PlyaerController player;
    public GameObject gameover;
    public GameSuccess gs;
    private AudioSource source;
    public AudioClip shootSound;
    private bool play;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        play = true;

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player"&&!gs.ended)
        {
            if (play&&!player.dead)
            {
                source.PlayOneShot(shootSound, 1);
                play = false;
            }
            player.dead = true;
            gameover.SetActive(true);

        }



    }
}
