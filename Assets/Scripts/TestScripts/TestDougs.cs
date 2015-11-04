using UnityEngine;
using System.Collections;

public class TestDougs : MonoBehaviour {

    public bool inWater;
    Vector3 bobbing = new Vector3(0, 0.0005f, 0.001f);
    public bool onGround;
    Vector3 walking = new Vector3(0, -0.005f, 0);
    public bool isDiving;
    public bool isSwimming;


	// Use this for initialization
	void Start () {
        if(inWater)
            InvokeRepeating("InWater", 4, 4);
        if(isDiving)
            InvokeRepeating("Diving", 4, 4);
        if (onGround)
            InvokeRepeating("Move", 6, 6);
	}
	
	// Update is called once per frame
	void Update () {
        if (inWater)
        {
            transform.Translate(bobbing);
        }

        if(isSwimming)
        {
            transform.Translate(new Vector3(0,-0.005f,0));
            transform.Rotate(new Vector3(0,0,-0.1f));
        }

        if(isDiving)
        {
            transform.Translate(new Vector3(0, -0.01f, 0));
        }

        if(onGround)
        {
            transform.Translate(walking);
        }
	}


    void InWater()
    {
        bobbing *= -1;
    }

    void Diving()
    {
        transform.Rotate(new Vector3(180,0,0));
    }

    void Move()
    {
        transform.Rotate(new Vector3(0, 0, Random.Range(90,270)));
    }
}
