using UnityEngine;

public class PlayerThrow : MonoBehaviour
{
    public GameObject knifePrefab; // Referenz auf das Messer-Prefab
    public Transform throwPoint; // Der Punkt, von dem das Messer geworfen wird (meistens vor dem Spieler)
    public float throwForce = 10f; // Die Wurfgeschwindigkeit des Messers

    private void Update()
    {
        if (Input.GetButtonDown("Fire2")) // Standard: "Fire2" ist meist der rechte Mausklick oder eine andere Taste (kann angepasst werden)
        {
            ThrowKnife();
        }
    }

    private void ThrowKnife()
    {
        // Erstelle das Messer an der Wurfposition
        GameObject knife = Instantiate(knifePrefab, throwPoint.position, Quaternion.identity);

        // Gib dem Messer eine Geschwindigkeit nach rechts
        Rigidbody2D rb = knife.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = new Vector2(throwForce, 0); // Wirf das Messer nach rechts
        }
    }
}