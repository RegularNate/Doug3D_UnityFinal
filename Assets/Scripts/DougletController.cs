using UnityEngine;
using System.Collections;

public class DougletController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider _c)
    {
        Debug.Log(_c.gameObject.name);
        Debug.Log(_c.gameObject.tag); 

        if(_c.gameObject.tag == "Enemy")
        {
            Destroy(_c.gameObject);          
        }
        Destroy(gameObject);
    }
}
