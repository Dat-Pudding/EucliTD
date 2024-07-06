using Unity.VisualScripting;
using UnityEngine;

public class TestMove : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Vector2 targetPos;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (transform.position.x != 8)
        {
            targetPos = transform.position;
            targetPos.x = transform.position.x + 0.5f * Time.deltaTime;
            rb2D.MovePosition(targetPos);
        }

        if (transform.position.x >= 8)
        {
            targetPos = transform.position;
            targetPos.y = transform.position.y - 0.5f * Time.deltaTime;
            rb2D.MovePosition(targetPos);
        }
    }
}