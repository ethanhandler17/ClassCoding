using UnityEngine;

public class Barrier : MonoBehaviour
{
    
    void OnTriggerEnter(Collider other) // Called when this GameObject's trigger collider enters another collider (3D)
    {
        // Die if hit by bullet
        if(other.gameObject.CompareTag("Enemy")) // Check if the colliding object has the "Barrier" tag
        {
            Destroy(other.gameObject); // Destroy the Barrier GameObject that hit the enemy
            Debug.Log("Enemy hit by Barrier and died"); // Print message to console for debugging
        }

    }
}
