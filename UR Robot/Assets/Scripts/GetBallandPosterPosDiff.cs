using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBallandPosterPosDiff : MonoBehaviour {

    public SendData send;

	public void GetDifference()
    {
        Vector3 diff = SendData.ballPosition - SendData.robotPosition;
        Debug.Log("Difference = " + diff);
        send.SendDiffData(diff);
    }
}
