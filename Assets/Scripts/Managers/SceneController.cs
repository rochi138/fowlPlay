using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController {
    public static SceneController Instance = null;
    void Awake() {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }
    public void LoadNextScene() {
        // SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
        SceneManager.LoadScene("Tutorial");
    }
}
