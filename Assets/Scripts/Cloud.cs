using UnityEngine;

public class Cloud : MonoBehaviour
{
    private float speed = .5f;
    private GameManager gameManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); // Find the GameManager object in the scene and get the GameManager component script
        // search by tag, layer or by children
        transform.localScale = transform.localScale * Random.Range(.1f, .6f); // Scale the cloud to a random size between .1 and .6
        transform.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, Random.Range(.1f, .7f)); // Set the color of the cloud to a random color between .1 and .7,  (red, green, blue, alpha)
        speed = Random.Range(3f, 7f); // Set the speed of the cloud to a random speed between 3 and 7
    }

    // Update is called once per frame
    void Update()
    {
       transform.Translate(Vector3.down * Time.deltaTime * speed); // Move the cloud down at the speed
       if(transform.position.y < -5f) // Check if cloud has fallen below the bottom of the screen
       {
        transform.position = new Vector3(Random.Range(-gameManager.horizontalScreenSize, gameManager.horizontalScreenSize), 6f, 0); // Reset the cloud to a random position at the top of the screen
       }
    }
}
