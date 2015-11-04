using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class SpawnController : MonoBehaviour {
    public Dictionary<string, Transform> PowerUpSpawnDictionary;
    public Dictionary<string, Transform> EnemySpawnDictionary;

    public string[] spawnNames;
    public Transform[] spawnCount;
    public List<GameObject> PowerUps;

    public string[] enemySpawnNames;
    public Transform[] enemySpawnCount;
    public List<GameObject> Enemies;


	// Use this for initialization
	void Start () {
        PowerUpSpawnDictionary = new Dictionary<string, Transform>();
        Transform[] PuSp = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
        foreach (Transform Pu in PuSp)
        {
            Debug.Log(Pu.tag);

            if (Pu.tag == "PowerUpSpawn")
            {
                    PowerUpSpawnDictionary.Add(Pu.name, Pu);
            }
        }
        spawnNames = new string[PowerUpSpawnDictionary.Keys.Count];
        spawnCount = new Transform[PowerUpSpawnDictionary.Values.Count];
        PowerUpSpawnDictionary.Keys.CopyTo(spawnNames, 0);
        PowerUpSpawnDictionary.Values.CopyTo(spawnCount, 0);
        foreach (Transform _spawnPoint in PowerUpSpawnDictionary.Values)
        {
            Instantiate(PowerUps[Random.Range(0, PowerUps.Count)], _spawnPoint.transform.position, Quaternion.identity);
        }


        EnemySpawnDictionary = new Dictionary<string, Transform>();
        Transform[] ESp = GameObject.FindObjectsOfType(typeof(Transform)) as Transform[];
        foreach (Transform E in ESp)
        {
            Debug.Log(E.tag);

            if (E.tag == "EnemySpawn")
            {
                EnemySpawnDictionary.Add(E.name, E);
            }
        }
        enemySpawnNames = new string[PowerUpSpawnDictionary.Keys.Count];
        enemySpawnCount = new Transform[PowerUpSpawnDictionary.Values.Count];
        EnemySpawnDictionary.Keys.CopyTo(spawnNames, 0);
        EnemySpawnDictionary.Values.CopyTo(spawnCount, 0);
        foreach (Transform _enemySpawnPoint in EnemySpawnDictionary.Values)
        {
            Instantiate(Enemies[Random.Range(0, Enemies.Count)], _enemySpawnPoint.transform.position, Quaternion.identity);
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
