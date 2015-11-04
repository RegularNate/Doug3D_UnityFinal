using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Input.GetKey("w"))
        {
            transform.Translate(new Vector3(0,0,0.5f));
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(new Vector3(0, 0, -0.5f));
        }

        if (Input.GetKey("left"))
        {
            transform.Rotate(Vector3.forward);
        }
        if (Input.GetKey("right"))
        {
            transform.Rotate(Vector3.back);
        }

        if (Input.GetKey("up"))
        {
            transform.Rotate(Vector3.left);
        }
        if (Input.GetKey("down"))
        {
            transform.Rotate(Vector3.right);
        }  
        if (Input.GetKey("a"))
        {
            transform.Rotate(Vector3.down);
        }
        if (Input.GetKey("d"))
        {
           transform.Rotate(Vector3.up);
        } 
	}
}
