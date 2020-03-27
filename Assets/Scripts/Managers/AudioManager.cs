using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource BackgroundAS;
    public static AudioManager Instance { get; private set; }
    void Awake() {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }
}
