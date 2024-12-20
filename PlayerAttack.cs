using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public int damage = 20; // Amount of damage the player deals
    public float attackRange = 1f; // Range of the player's attack
    public LayerMask enemyLayer; // The layer mask for detecting enemies

    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) // Example: left mouse button or 'F' key (you can change this input)
        {
            Attack();
        }
    }

    private void Attack()
    {
        // Create an attack area (a small circle in front of the player)
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(transform.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            if (enemy != null)
            {
                EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
                if (enemyHealth != null)
                {
                    enemyHealth.TakeDamage(damage); // Apply damage to the enemy
                    Debug.Log("Enemy hit! Damage dealt: " + damage);
                }
            }
        }
    }

    // Visualize the attack range in the Editor (optional)
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}