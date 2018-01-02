using UnityEngine;
using System.Collections;
using System;
using System.IO;
#if UNITY_EDITOR
using System.Net.Sockets;
#endif


public class TCPConnection : MonoBehaviour
{
    //ip/address of the server, 127.0.0.1 is for your own computer
    public string conHost = "192.168.1.104";

    //port for the server, make sure to unblock this in your router firewall if you want to allow external connections
    public int conPort = 30002;

    //a true/false variable for connection status
    public bool socketReady = false;

    public GameObject checkBoxTick;
#if UNITY_EDITOR
    TcpClient mySocket;
    NetworkStream theStream;
    StreamWriter theWriter;
    StreamReader theReader;

    //try to initiate connection
    public void setupSocket()
    {
        try
        {
            mySocket = new TcpClient(conHost, conPort);
            theStream = mySocket.GetStream();
            theWriter = new StreamWriter(theStream);
            theReader = new StreamReader(theStream);
            socketReady = true;
            checkBoxTick.gameObject.SetActive(false);
            if (socketReady == true)
            {
                checkBoxTick.gameObject.SetActive(true);
            }
            else
            {
                checkBoxTick.gameObject.SetActive(false);
            }
        }
        catch (Exception e)
        {
            Debug.Log("Socket error:" + e);
        }
    }

    //send message to server
    public void writeSocket(string theLine)
    {
        if (!socketReady)
            return;
        String tmpString = theLine + "\n";
        theWriter.Write(tmpString);
        theWriter.Flush();
    }

    public void writePositions(string pos)
    {
        if (!socketReady)
            return;
        String posString = pos + '\n';
        theWriter.Write(posString);
        theWriter.Flush();
    }

    //read message from server
    public string readSocket()
    {
        String result = "";
        if (theStream.DataAvailable)
        {
            Byte[] inStream = new Byte[mySocket.SendBufferSize];
            theStream.Read(inStream, 0, inStream.Length);
            result += System.Text.Encoding.UTF8.GetString(inStream);
        }
        return result;
    }

    //disconnect from the socket
    public void closeSocket()
    {
        if (!socketReady)
            return;
        theWriter.Close();
        theReader.Close();
        mySocket.Close();
        socketReady = false;
    }

    //keep connection alive, reconnect if connection lost
    public void maintainConnection()
    {
        if (!theStream.CanRead)
        {
            setupSocket();
        }
    }

    public void loop(string pos)
    {
        int i;
        for (i=0; i < 1; i++)
        {
            writePositions(pos);
        }
    }

    
#endif
}


