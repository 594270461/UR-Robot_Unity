using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SendData : Photon.PunBehaviour
{
#if UNITY_EDITOR
    public TCPConnection connect;
#endif

    public GetBallandPosterPosDiff diff;

    public static Vector3 robotPosition;
    public static Vector3 ballPosition;
    public static Vector3 differencePosition;
    public string posx;
    public string posy;
    public string posz;
    public static string move;
    public Text textDisplay;

    public void SendClickData()
    {
        PhotonView SendClickData = this.GetComponent<PhotonView>();
        SendClickData.RPC("ReceiveConnectClick", PhotonTargets.Others, null);
        Debug.Log("Sending Click Data");
    }

    public void SendMoveData(string move)
    {
        PhotonView SendMoveData = this.GetComponent<PhotonView>();
        SendMoveData.RPC("ReceiveMoveClick", PhotonTargets.Others, move);
        Debug.Log("Sending Move Data");
    }

    public void SendRobotPosData(Vector3 robotPos)
    {
        PhotonView SendRobotPosData = this.GetComponent<PhotonView>();
        SendRobotPosData.RPC("ReceiveRobotPosClick", PhotonTargets.Others, robotPos);
        Debug.Log("Sending Robot Pos Data");
        robotPosition = robotPos;
    }

    public void SendPosterPosData(Vector3 posterPos)
    {
        PhotonView SendPosterPosData = this.GetComponent<PhotonView>();
        SendPosterPosData.RPC("ReceivePosterPosClick", PhotonTargets.Others, posterPos);
        Debug.Log("Sending Poster Pos Data");
    }

    public void SendBallPosData(Vector3 ballPos)
    {
        PhotonView SendBallPosData = this.GetComponent<PhotonView>();
        SendBallPosData.RPC("ReceiveBallPosClick", PhotonTargets.Others, ballPos);
        Debug.Log("Sending Ball Pos Data");
        ballPosition = ballPos;
    }

    public void SendDiffData(Vector3 diff)
    {
        PhotonView SendDiffData = this.GetComponent<PhotonView>();
        SendDiffData.RPC("ReceiveDiffClick", PhotonTargets.Others, diff);
        Debug.Log("Sending Diff Data");
        differencePosition = diff;
        posx = differencePosition.x.ToString();
        posy = differencePosition.y.ToString();
        posz = differencePosition.z.ToString();
        move = "movej(p[" + posz +", -" + posx + ", " + posy + ", 2.22, -2.22, 0], a = 1.0, v = 0.4)" + Environment.NewLine;
        Debug.Log("Move = " + move);
        textDisplay.text = move;
    }

    [PunRPC]
    void ReceiveConnectClick()
    {
        Debug.Log("Recieved Connect Click");
#if UNITY_EDITOR
        connect.setupSocket();
#endif
    }

    [PunRPC]
    void ReceiveMoveClick(string move)
    {
        string path = @"C:\Users\User\Desktop\RobotPositions\RobotPositions.txt";

        File.AppendAllText(path, move);

        Debug.Log("Received Move Click");
        Debug.Log("Robot Moving Position =" + move);

#if UNITY_EDITOR
        connect.loop(move);
#endif
    }


    [PunRPC]
    void ReceiveRobotPosClick(Vector3 robotPos)
    {
        Debug.Log("Recieved Robot Location: ");
        Debug.Log("Robot Position: X = " + robotPos.x + " Y = " + robotPos.y + " Z = " + robotPos.z);
    }

    [PunRPC]
    void ReceivePosterPosClick(Vector3 pos)
    {
        Debug.Log("Received Poster Location: ");
        Debug.Log("Poster Position: X = " + pos.x + " Y = " + pos.y + " Z = " + pos.z);
    }

    [PunRPC]
    void ReceiveBallPosClick(Vector3 ballPos)
    {
        Debug.Log("Received Poster Location: ");
        Debug.Log("Ball Position: X = " + ballPos.x + " Y = " + ballPos.y + " Z = " + ballPos.z);
    }

    [PunRPC]
    void ReceiveDiffClick(Vector3 diff)
    {
        Debug.Log("Received Difference: ");
        Debug.Log("Difference: X = " + diff.x + " Y = " + diff.y + " Z = " + diff.z);
    }
}
