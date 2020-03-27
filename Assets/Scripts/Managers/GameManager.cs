using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager m_Instance = null;
    public GameObject goose;
    public GameObject kid;
    public Goose gooseScript;
    // [SerializeField] Camera2DFollow Camera2DFollow;
    [SerializeField] PlayerEvents PlayerEvents;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] InventoryManager InventoryManager;
    [SerializeField] SceneManager SceneManager;
    [SerializeField] StateManager StateManager;

    public static GameManager GetInstance() {
        return m_Instance;
    }

    void Awake() {
        if (m_Instance == null) {
            m_Instance = this;
        } else if (m_Instance != this) {
            Destroy(gameObject);
        }
    }

    void Start() {
        // goose = GameObject.FindGameObjectWithTag("goose");
        // kid = GameObject.FindGameObjectWithTag("kid");
        // inventory = GameObject.FindGameObjectWithTag("inventoryController");
    }

    // TODO: figure out what these do and rename if needed
    void SwitchInventory() {
        // goose.SendMessage("toggle");
        // kid.SendMessage("toggle");
        // inventory.SendMessage("gooseToKid");
        //Debug.Log("switched players");
    }

    void SwitchInventory2() {
        //goose.SendMessage("toggle");
        //kid.SendMessage("toggle");
        // inventory.SendMessage("toggle");
    }
}
