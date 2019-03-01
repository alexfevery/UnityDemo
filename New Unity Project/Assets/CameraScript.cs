using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    public Transform ship;
    public Vector3 distance = new Vector3(0, 150, -700);
    public Vector3 shipStartPos;
    public Quaternion shipStartRot;
    Vector3 currentPos;
    public float distanceDamp = 10f;
    public Vector3 velocity = Vector3.one;
    public bool intro = true;
    // Start is called before the first frame update
    void Start()
    {
        currentPos = transform.position;
        //Get original position and rotation incase player ends intro early
        shipStartPos = ship.transform.position;
        shipStartRot = ship.transform.rotation;
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        //check if intro should end early
        if(ship.position != shipStartPos) { intro = false; }
        if (ship.rotation != shipStartRot) { intro = false; }
        GetCamera();
    }

    public void GetCamera()
    {
        //calculate smooth camera transfer steps
        Vector3 TargetPos = ship.position + (ship.rotation * distance);
        Vector3 cameraRelative = ship.InverseTransformPoint(transform.position);

        //check if camera has approached ship enough to end intro camera
        if (cameraRelative.z > -600 && intro)
        {
            //apply smooth camera transfers and add slight camera sideways velocity to prevent sudden camera flip when passing over center of ship
            if(cameraRelative.z > 100) { currentPos = Vector3.SmoothDamp(transform.position, new Vector3(TargetPos.x+500,TargetPos.y,TargetPos.z), ref velocity, 10); }
            else {currentPos = Vector3.SmoothDamp(transform.position, TargetPos, ref velocity, 10); }
        }
        else
        {
            //intro has ended so use flybehind camera for player controlling ship
            intro = false;
            if (cameraRelative.y > 0) { currentPos = Vector3.SmoothDamp(transform.position, TargetPos, ref velocity, .4f); }
            else { currentPos = Vector3.SmoothDamp(transform.position, TargetPos, ref velocity, 0.3f); }
        }
        transform.position = currentPos;
        //point camera at ship
        transform.LookAt(ship, ship.up);
    }
}
