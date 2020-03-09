using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerSlowButton : MonoBehaviour
{
    public GameObject[] spinnings;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClick()
    {
        spinnings = GameObject.FindGameObjectsWithTag("spinning circle");
        foreach(GameObject spinningObject in spinnings)
        {
            rotator spinning = (rotator)spinningObject.GetComponent(typeof(rotator));
            spinning.setRotateSpeed((float)(spinning.rotateSpeed * 0.3f));
        }
    }
}
