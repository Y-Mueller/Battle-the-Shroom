using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 100;

    // Methode, die Schaden auf den Gegner anwendet
    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log("Enemy hit! Remaining Health: " + health);

        if (health <= 0)
        {
            Die();
        }
    }

    // Methode, die den Gegner sterben l�sst
    private void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // Zerst�rt den Gegner
    }
}