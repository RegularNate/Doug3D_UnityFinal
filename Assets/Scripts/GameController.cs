using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

    static GameController _instance = null;


    public List<GameObject> PowerUps;
    public List<Transform> SpawnPoints;

    public List<GameObject> Guns;
    public List<Transform> GunSpawns;


  

	// Use this for initialization
	void Start () {
        //BoostSpawner();
        if (_instance)
        {
           Destroy(gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        GunSpawner();
        //Used this to check that the spawner was working properly
        //InvokeRepeating("BoostSpawner", 0, 2.0f);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            if (Application.loadedLevelName == "EndlessSurvival")
            {
                Application.LoadLevel("DougNativity");
                //Application.LoadLevelAdditive("DougNativity");
            }
            else if (Application.loadedLevelName == "DougNativity")
            {
                Application.LoadLevel("EndlessSurvival");
            }
        }


	
	}

    private void BoostSpawner() {
        foreach(Transform _powerSpawn in SpawnPoints){
            Instantiate(PowerUps[Random.Range(0, PowerUps.Count)], _powerSpawn.position, Quaternion.identity); 
        }
    }

    private void GunSpawner()
    {
        for (int i = 0; i < Guns.Count; i++)
        {
            Instantiate(Guns[i], GunSpawns[i].position + new Vector3(0,0.3f,0), Quaternion.identity);
        }
    }

}
