using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnection : Photon.MonoBehaviour
{

    public TextMesh text;

    void Update()
    {
        if (!PhotonNetwork.connectedAndReady)
        {
            text.text = "Photon Connection Status: Waiting";
        }
        else
        {
            text.text = "Photon Connection Status: Connected";
        }
    }
}

