using UnityEngine;


public class Bullet : MonoBehaviour
{
   public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime * bulletSpeed);
        //if the bullet is out of bounds, destroy it
        if(transform.position.y > 6.5f)
        {
            Destroy(gameObject);
        }
    }
}
