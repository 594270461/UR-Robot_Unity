using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetPosterLocation : MonoBehaviour {

    public Vector3 posterPos;
    public SendData send;

    public void GetPosLocation()
    {
        posterPos = gameObject.transform.localPosition;
        Debug.Log("Poster Position: X = " + posterPos.x + " Y = " + posterPos.y + " Z = " + posterPos.z);
        send.SendPosterPosData(posterPos);
    }

}
