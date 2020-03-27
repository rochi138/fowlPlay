using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour {
    public static void LoadNextScene() {
        // SceneManager.LoadScene( SceneManager.GetActiveScene().buildIndex + 1 );
        SceneManager.LoadScene("Tutorial");
    }
}
