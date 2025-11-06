using UnityEngine; // Import Unity engine classes and functions
using TMPro; // Import TextMeshPro namespace for UI text components
using UnityEngine.SceneManagement; // Import SceneManagement namespace for loading scenes

public class GameOverManager : MonoBehaviour // GameOverManager class inherits from MonoBehaviour (Unity component base class)
{
    public TextMeshProUGUI scoreText; // Reference to the TextMeshProUGUI component that displays the score (assigned in Unity Inspector)

    void Start() // Called once when the GameObject is first created/activated
    {
        int finalScore = PlayerPrefs.GetInt("FinalScore", 0); // Get the final score from PlayerPrefs (default to 0 if not found)
        if(scoreText != null) // Check if scoreText reference exists
        {
            scoreText.text = "Score : " + finalScore.ToString(); // Update the text to display the final score
        }
        else // If scoreText reference is null
        {
            Debug.LogWarning("Score Text not assigned in GameOverManager!"); // Print warning message to console
        }
    }

    void Update() // Called every frame (typically 60 times per second)
    {
        // Restart the game by pressing the R key
        if(Input.GetKeyDown(KeyCode.R)) // Check if R key is pressed this frame
        {
            RestartGame(); // Call the restart game method
        }
    }

    public void RestartGame() // Method to restart the game by loading the main scene
    {
        SceneManager.LoadScene("MainScene"); // Load the MainScene scene to restart the game
    }
}

