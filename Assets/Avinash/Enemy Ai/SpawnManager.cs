using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public float Spawnrate;
    public GameObject PrefabToSpawn;
    Vector3 SpawnPoint;
    public float XSpawnRandomness;
    


   
    void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), Spawnrate, Spawnrate);
    }

    void SpawnEnemy()
    {
        SpawnPoint = new Vector3(Random.Range(-XSpawnRandomness, XSpawnRandomness), 0, 0) + transform.position;
        GameObject EnemyDuplicate = Instantiate(PrefabToSpawn, SpawnPoint, Quaternion.identity);
        EnemyDuplicate.GetComponent<EnemyAi>().Target = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        
    }
}
