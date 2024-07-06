using UnityEngine;

public class Tower : MonoBehaviour
{
    [Header("Tower Reference Data")]
    public string towerName;
    public int towerId;
    public Sprite towerSprite;
    public GameObject towerPrefab;
    public Transform towerFirePoint;
    public GameObject towerProjectile;
    public Collider2D attackRangeCollider;
    public Transform currentTarget;

    public Vector2 towerPos;
    public Vector2 targetPos;

    [Header("Tower Specific Data")]
    public TowerBaseData towerBaseData;
    public float baseDamage;
    public float damage;
    public float damageMultiplier;
    public float reloadSpeed;
    public float reloadSpeedMultiplier;
    public float firingCooldown;
    public float timeStamp;

    void Start()
    {
        towerPos = this.transform.position;
        attackRangeCollider = this.GetComponent<Collider2D>();
        timeStamp = Time.time;

        towerName = towerBaseData.tName;
        towerId = towerBaseData.id;
        towerPrefab = towerBaseData.prefab;
        towerSprite = towerPrefab.GetComponent<Sprite>();
        towerProjectile = towerBaseData.projectilePrefab;

        baseDamage = towerBaseData.baseDamage;
        damageMultiplier = towerBaseData.damageMultiplier;
        damage = baseDamage * damageMultiplier;
        reloadSpeed = towerBaseData.fireRate;
        reloadSpeedMultiplier = towerBaseData.fireRateMultiplier;
        firingCooldown = reloadSpeed * reloadSpeedMultiplier;
    }

    private void Update()
    {
        if (currentTarget != null)
        {
            Shoot();
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.name == "TestEnemy")
        {
            currentTarget = other.transform;
            targetPos = new Vector2(currentTarget.position.x, currentTarget.position.y);
            RaycastHit2D aimingRay = Physics2D.Raycast(towerPos, targetPos);
            Aim();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            currentTarget = null;
            Idle();
        }
    }

    void Aim()
    {
        float aimAngle = (Mathf.Atan2(targetPos.x - towerPos.x, targetPos.y - towerPos.y) * Mathf.Rad2Deg) * -1f;
        Quaternion aimAngleQuat = Quaternion.Euler(0, 0, aimAngle);

        this.transform.rotation = aimAngleQuat;
    }

    void Shoot()
    {
        if (Time.time >= timeStamp + firingCooldown)
        {
            timeStamp = Time.time + firingCooldown;
            Instantiate(towerProjectile, towerFirePoint.position, towerFirePoint.rotation);
        }
    }

    void Idle()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
    }
}