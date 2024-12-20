using UnityEngine;

public class Fireball : MonoBehaviour
{
    public int damage = 20; // Schaden, den der Fireball verursacht
    public float speed = 10f; // Geschwindigkeit des Fireballs

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Überprüfe, ob der Fireball den Spieler trifft
        if (collision.gameObject.CompareTag("Player"))
        {
            // Schaden am Spieler verursachen
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);  // Schaden anwenden
                Debug.Log("Player hit by fireball! Damage dealt: " + damage);
            }
        }

        // Zerstöre den Fireball nach der Kollision
        Destroy(gameObject);
    }

    private void Start()
    {
        // Setze die Geschwindigkeit des Fireballs
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.right * speed;  // Bewege den Fireball in die Richtung, in die er schaut
        }
    }
}