using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Instance = null;
    public static AudioSource BackgroundAS;
    void Awake() {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }
}
