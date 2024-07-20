using UnityEngine;

[CreateAssetMenu(fileName = "towerData", menuName = "Tower Base Data", order = 2)]

public class TowerBaseData : ScriptableObject
{
    [Header("Tower Base Data")]
    public int id;
    public string tName;
    public GameObject prefab;
    public GameObject projectilePrefab;

    public float baseDamage;
    public float fireRate;
    public float damageMultiplier;
    public float fireRateMultiplier;
}