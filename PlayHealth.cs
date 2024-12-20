using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100; // Start-Gesundheit des Spielers
    public GameObject deathEffect; // Effekt, der beim Tod des Spielers abgespielt wird

    public void TakeDamage(int damage)
    {
        health -= damage; // Schaden reduzieren
        if (health <= 0)
        {
            Die(); // Spieler stirbt, wenn die Gesundheit 0 oder weniger erreicht
        }
    }

    private void Die()
    {
        // Hier kannst du einen Effekt abspielen, bevor der Spieler verschwindet
        if (deathEffect != null)
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
        }

        // Zerstöre den Spieler (oder deaktiviere ihn, wenn du eine andere Reaktion willst)
        Destroy(gameObject);
    }
}