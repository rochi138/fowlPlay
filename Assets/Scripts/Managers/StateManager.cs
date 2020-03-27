using UnityEngine;

public class StateManager {
    public static StateManager Instance = null;
    void Awake() {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
    }
}