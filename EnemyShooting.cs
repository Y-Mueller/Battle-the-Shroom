using System.Collections;
using UnityEngine;

public class EnemyShooter : MonoBehaviour
{
    public GameObject fireballPrefab;
    public Transform fireballSpawnPoint;
    public float fireRate = 2f;
    public float shootingRange = 10f;
    public float moveSpeed = 3f;
    public float rotationSpeed = 5f;

    [SerializeField] private Transform player;  // Make player a serialized field for manual assignment in the Inspector

    void Start()
    {
        if (player == null)
        {
            player = GameObject.FindGameObjectWithTag("Player")?.transform;  // Use null-conditional operator just in case
        }

        if (player == null)
        {
            Debug.LogError("Player not found. Please assign the Player object to the EnemyShooter script.");
            return;
        }

        StartCoroutine(ShootFireball());
    }

void Update()
    {
        // Überprüfe, ob der Spieler in Reichweite ist
        if (Vector2.Distance(transform.position, player.position) <= shootingRange)
        {
            // Verfolge den Spieler
            FollowPlayer();

            // Achte darauf, dass der Feind den Spieler immer anschaut
            RotateTowardsPlayer();
        }
    }

    private void FollowPlayer()
    {
        // Bewege den Feind in Richtung des Spielers
        Vector2 direction = (player.position - transform.position).normalized;
        transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
    }

    private void RotateTowardsPlayer()
    {
        // Berechne die Rotation des Feindes, um immer auf den Spieler zu schauen
        Vector2 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private IEnumerator ShootFireball()
    {
        while (true)
        {
            // Warte die festgelegte Zeit zwischen den Schüssen
            yield return new WaitForSeconds(fireRate);

            // Wenn der Spieler in Reichweite ist, feuere einen Feuerball ab
            if (Vector2.Distance(transform.position, player.position) <= shootingRange)
            {
                FireFireball();
            }
        }
    }

    private void FireFireball()
    {
        // Spawne den Feuerball an der festgelegten Stelle
        GameObject fireball = Instantiate(fireballPrefab, fireballSpawnPoint.position, Quaternion.identity);

        // Berechne die Richtung zum Spieler
        Vector2 direction = (player.position - fireball.transform.position).normalized;

        // Setze die Geschwindigkeit des Feuerballs in die richtige Richtung
        fireball.GetComponent<Rigidbody2D>().velocity = direction * 10f; // Geschwindigkeit des Feuerballs anpassen

        // Zerstöre den Feuerball nach 5 Sekunden, um ihn nicht ewig im Spiel zu lassen
        Destroy(fireball, 5f);
    }
}