using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSuccess : MonoBehaviour
{
    public PlyaerController player;
    public GameObject success;
    public GameObject fail;
    public bool ended;
    public int totalStar;
    private AudioSource source;
    public AudioClip win;
    public AudioClip lose;
    // Start is called before the first frame update
    void Start()
    {
        ended = false;
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player"&&!player.dead)
        {
            player.dead = true;
            ended = true;
            if (player.currentStar == totalStar)
            {
                success.SetActive(true);
                source.PlayOneShot(win, 1);
            }
            else
            {
                fail.SetActive(true);
                source.PlayOneShot(lose, 1);
            }

        }
    }
}
