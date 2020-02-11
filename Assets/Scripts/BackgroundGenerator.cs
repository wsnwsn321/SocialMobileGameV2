using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundGenerator : MonoBehaviour
{
    public Sprite[] Backgrounds;
    // Start is called before the first frame update
    void Start()
    {
        (GetComponent<Renderer>() as SpriteRenderer).sprite = Backgrounds[Random.Range(0, Backgrounds.Length)];
        System.Console.WriteLine(1);

    }

    // Update is called once per frame
    void Update()
    {
    }
}
