using UnityEngine;

public class Knife : MonoBehaviour
{
    public int damage = 20; // Schaden, den das Messer verursacht

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Überprüfe, ob das Messer mit dem Gegner kollidiert
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

            // Zerstöre das Messer nach der Kollision
            Destroy(gameObject);
        }

        // Überprüfe, ob das Messer den Boden oder eine andere Wand berührt
        else if (collision.gameObject.CompareTag("Ground"))
        {
            // Zerstöre das Messer, wenn es den Boden berührt (optional)
            Destroy(gameObject);
        }
    }
}