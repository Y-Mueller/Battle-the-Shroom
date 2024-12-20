using UnityEngine;

public class Knife : MonoBehaviour
{
    public int damage = 20; // Schaden, den das Messer verursacht

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // �berpr�fe, ob das Messer mit dem Gegner kollidiert
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Schaden am Gegner verursachen
            EnemyHealth enemyHealth = collision.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);  // Schaden anwenden
                Debug.Log("Enemy hit by knife! Damage dealt: " + damage);
            }
            else
            {
                Debug.LogWarning("Enemy does not have EnemyHealth script!");
            }

            // Zerst�re das Messer nach der Kollision
            Destroy(gameObject);
        }

        // �berpr�fe, ob das Messer den Boden oder eine andere Wand ber�hrt
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // Zerst�re das Messer, wenn es den Boden ber�hrt (optional)
            Destroy(gameObject);
        }
    }
}