using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotator : MonoBehaviour
{
    public float rotateSpeed;
    public GameObject anchor;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame s
    void Update()
    {

        transform.RotateAround(anchor.transform.position, Vector3.forward, rotateSpeed * Time.deltaTime);
    }
}
