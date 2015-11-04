using UnityEngine;
using System.Collections;

public class GunController : MonoBehaviour {


    Vector3 Idle = new Vector3(0, 0.005f, 0);

    public bool onDoug;


	// Use this for initialization
    void Start()
    {
        if (!onDoug)
        {
            InvokeRepeating("IdleTiming", 2, 1);
        }
    }
	
	// Update is called once per frame
    void Update()
    {
        if (!onDoug)
        {
            transform.Translate(Idle);
            transform.Rotate(new Vector3(0,2,0));
        }


        //Animation placeholder
        //if (onDoug) { 
          //  if(Input.GetButtonDown("Fire1"))
            //{
              //  transform.Rotate(new Vector3(-10, 0, 0));
            //}
            //else              
              //  transform.rotation = Quaternion.identity;
                
        //}
    }

    void IdleTiming()
    {
        Idle *= -1;
    }
}
