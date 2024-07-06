using UnityEngine;

public class TestFire : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public AudioSource sound;
    public SpriteRenderer sprite;
    public float firingForce = 5f;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        sound = GetComponent<AudioSource>();

        rb2D.AddForce(transform.up * firingForce, ForceMode2D.Impulse);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            sound.Play();
            Destroy(this.GetComponent<SpriteRenderer>());
            Destroy(this.gameObject.GetComponent<Collider2D>());
            Destroy(this.gameObject, 0.5f);
        }
    }
}