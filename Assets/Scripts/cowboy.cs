using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float VelocityPerJump = 3;
    public float XSpeed = 1;
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    


    void Update()
    {

        MoveBirdOnXAxis();
        if (WasTouchedOrClicked())
        {
            BoostOnYAxis();
        }

    }

    bool WasTouchedOrClicked()
    {
        if (Input.GetButtonUp("Jump") || Input.GetMouseButtonDown(0) ||
            (Input.touchCount > 0 && Input.touches[0].phase == TouchPhase.Ended))
            return true;
        else
            return false;
    }

    void MoveBirdOnXAxis()
    {
        transform.position += new Vector3(Time.deltaTime * XSpeed, 0, 0);
    }

    void BoostOnYAxis()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(0, VelocityPerJump);
    }


}
