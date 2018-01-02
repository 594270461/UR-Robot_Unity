using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeepTrackRobotMovement : MonoBehaviour {

    public GameObject prefab;
    public GameObject go;
    public Vector3 pos;
    public Vector3 start;
    public Vector3 end;
    public List<Vector3> posData = new List<Vector3>();
    int numberOfInstantiatedPrefabs;

    private void Start()
    {

    }

    public void KeepTrackBallPosition()
    {
        //Instantiate Robot Moved Positions
        pos = prefab.transform.position;
        Debug.Log("ballPos = " + pos);
        go = Instantiate(prefab, pos, Quaternion.identity) as GameObject;
        go.transform.parent = GameObject.Find("Zone1").transform;

        //Add into List of Moved Positions
        posData.Add(go.transform.position);
        numberOfInstantiatedPrefabs = posData.Count;
        Debug.Log("number" + numberOfInstantiatedPrefabs);

        //Set instantiated prefabs properties
        go.GetComponent<Renderer>().material.color = Color.cyan;
        go.transform.localScale -= new Vector3(0.02F, 0.02F, 0.02F);
        go.GetComponent<HandDraggable>().enabled = false;

        DrawLine(start, end);
    }

    public void DrawLine(Vector3 start, Vector3 end)
    {
        for(int i = 0; i< numberOfInstantiatedPrefabs; i++)
        {
            start = posData[i];
            if (numberOfInstantiatedPrefabs > 1)
            {
                end = posData[numberOfInstantiatedPrefabs - 2];
            }
            else
            {
                end = start;
            }
        }
        GameObject myLine = new GameObject();
        myLine.AddComponent<LineRenderer>();
        LineRenderer lr = myLine.GetComponent<LineRenderer>();
        Color c1 = new Color(0, 1, 1, 1);
        lr.SetWidth(0.01f, 0.01f);
        lr.material = new Material(Shader.Find("Particles/Additive"));
        lr.SetColors(c1,c1);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);


        Debug.Log("i = " + posData[0]);
        Debug.Log("Start = " + start);
        Debug.Log("End = " + end);

    }
}
