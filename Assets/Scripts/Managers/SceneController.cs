using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public static SceneController Instance { get; private set; }
    void Awake() {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }

    public static void LoadNextScene() {
        // SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
        SceneManager.LoadScene("Tutorial");
    }
}
