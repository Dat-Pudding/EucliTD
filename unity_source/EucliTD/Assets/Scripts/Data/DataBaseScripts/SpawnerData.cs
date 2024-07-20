using UnityEngine;

[CreateAssetMenu(fileName = "levelSpawnData", menuName = "Map Spawner Data", order = 2)]

public class SpawnerData : ScriptableObject
{
    [Header("Map Spawner Data")]
    public int levelNumber;
    public int spawnCount;
    public GameObject[] enemies;
    public Transform[] wayPoints;
}