using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    public static GameManager Instance { get; private set; }
    public GameObject goose;
    public GameObject kid;
    public Goose gooseScript;
    // [SerializeField] Camera2DFollow Camera2DFollow;
    [SerializeField] PlayerEvents PlayerEvents;
    [SerializeField] AudioManager AudioManager;
    [SerializeField] InventoryManager InventoryManager;
    // [SerializeField] SceneManager SceneManager;
    [SerializeField] StateManager StateManager;
    void Awake() {
        if (Instance == null) { Instance = this; } else { Debug.Log("Warning: multiple " + this + " in scene!"); }
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
