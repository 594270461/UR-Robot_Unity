using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBallLocation : MonoBehaviour {

    public Vector3 ballPos;
    public SendData send;

    public void GetBallPos()
    {
        ballPos = gameObject.transform.localPosition;
        send.SendBallPosData(ballPos);
    }
}
