using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRobotLocation : MonoBehaviour {

    public SendData send;
    public Vector3 robotPos;
    //public Vector3 rot;

    public void GetrobotLocation()
    {
        robotPos = gameObject.transform.localPosition;
        //rot = gameObject.transform.eulerAngles;
        Debug.Log("Position: X = " + robotPos.x + " Y = " + robotPos.y + " Z = " + robotPos.z);
        //Debug.Log("Rotation: X = " + rot.y);
        send.SendRobotPosData(robotPos);
    }

}
