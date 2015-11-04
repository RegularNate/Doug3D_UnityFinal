using UnityEngine;
using System.Collections;
using System.IO;
using System;

public class ExceptionTester : MonoBehaviour {

	// Use this for initialization
	void Start () {
        FileStream file = null;
        FileInfo fileInfo = null;


        try
        {
            fileInfo = new FileInfo("C:\\file.txt");
            file = fileInfo.OpenWrite();

            for (int i = 0; i < 255; i++)
            {
                file.WriteByte((byte)i);
            }
        }
        catch(UnauthorizedAccessException e)
        {
            Debug.Log("DIDNT WORK!");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
