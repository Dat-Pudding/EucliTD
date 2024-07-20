using UnityEngine;

public class Spawner : MonoBehaviour
{
    public SpawnerData spawnerData;
    public int spawnedEnemyCounter;
    public int spawnedEnemyMax;
    public float spawnTime;
    public float timeStamp;

    void Start()
    {
        spawnedEnemyMax = spawnerData.spawnCount;
        timeStamp = Time.time;
    }

    void Update()
    {
        if (spawnedEnemyCounter < spawnedEnemyMax)
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        if (Time.time > timeStamp + spawnTime)
        {
            Instantiate(spawnerData.enemies[0], this.transform.position, this.transform.rotation);
            timeStamp = Time.time;
            ++spawnedEnemyCounter;
        }
    }
}