using UnityEngine;

public class GameManager : MonoBehaviour {
    public static AudioManager AudioManager = new AudioManager();
    public static InventoryManager InventoryManager = new InventoryManager();
    public static SceneController SceneController = new SceneController();
    public static StateManager StateManager = new StateManager();
}