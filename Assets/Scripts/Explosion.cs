using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float lifetime = 0.5f; // How long the explosion lasts before destroying itself
    
    void Start()
    {
        // Destroy this GameObject after the lifetime duration
        Destroy(gameObject, lifetime);
    }
}

