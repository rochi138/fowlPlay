using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public GameObject goose;
    public GameObject kid;
    public GameObject inventory;
    public Goose gooseScript;

    void Start() {
        goose = GameObject.FindGameObjectWithTag("goose");
        kid = GameObject.FindGameObjectWithTag("kid");
        inventory = GameObject.FindGameObjectWithTag("inventoryController");
    }

    // TODO: figure out what these do and rename if needed
    void SwitchInventory() {
        goose.SendMessage("toggle");
        kid.SendMessage("toggle");
        inventory.SendMessage("gooseToKid");
        //Debug.Log("switched players");
    }

    void SwitchInventory2() {
        //goose.SendMessage("toggle");
        //kid.SendMessage("toggle");
        inventory.SendMessage("toggle");
    }
}
