using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipMovement : MonoBehaviour
{
    public Rigidbody ship;


    // Start is called before the first frame update
    void Start()
    {
        //prevent ship from rotating too fast
        ship.maxAngularVelocity = .7f;
        //slowly halt rotation when controls released
        ship.angularDrag = .5f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        GetInput();
    }

    public void GetInput()
    {
        
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
            ship.AddRelativeForce(0, 0, 4000 * Time.deltaTime);
        }
        if (Input.GetKey("w"))
        {
            ship.AddRelativeTorque(50 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("s"))
        {
            ship.AddRelativeTorque(-50 * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey("d"))
        {
            ship.AddRelativeTorque(0, 50 * Time.deltaTime, 0);
        }
        if (Input.GetKey("a"))
        {
            ship.AddRelativeTorque(0, -50 * Time.deltaTime, 0);
        }
        if (Input.GetKey("q"))
        {
            ship.AddRelativeTorque(0, 0, 50 * Time.deltaTime);
        }
        if (Input.GetKey("e"))
        {
            ship.AddRelativeTorque(0, 0, -50 * Time.deltaTime);
        }
    }


}
