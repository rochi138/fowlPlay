using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public struct item {
    public string name;
    public Image imgrep;
    public RectTransform imgTran;
    public string holder;
}

public struct coordinates {
    public int x;
    public int y;
}

public class inventoryController : MonoBehaviour {

    public string word = null;
    public bool isEnabled = false;
    public bool isKid;
    public string[] receive = new string[2];
    public GameObject canvasObj;
    public Image inventoryBase;

    public item keyCard;

    public item[] inventoryListFull = new item[5];
    private item inventoryListGoose;
    private item[] inventoryListKid = new item[5];

    private coordinates[] locations = new coordinates[5];

    public string[] rdata = new string[2];

    void Start () {
        canvasObj = GameObject.FindGameObjectWithTag("canvas");
        inventoryBase = GameObject.Find("InventoryBase").GetComponent<Image>();

        inventoryListFull[0].name = "keyCard";
        inventoryListFull[0].imgrep = GameObject.Find("invKeyCard").GetComponent<Image>();
        inventoryListFull[0].imgrep.enabled = false;
        inventoryListFull[0].imgTran = GameObject.Find("invKeyCard").GetComponent<RectTransform>();
        inventoryListFull[0].holder = null;

        locations[0].x = 36;
        locations[0].y = 32;

        toggle();

    }
	
	void Update () {
        //Debug.Log(inventoryListFull[0].holder);
        if (isKid) {
            //for (int i = 0; i < inventoryListFull.Length; i++)
            //{
            //if (inventoryListKid[0].name != null)
            //    {

            //        inventoryListKid[0].imgrep.enabled = true;
            //    } else { inventoryListFull[0].imgrep.enabled = false; }
            //}
            word = "kid";
        } else {
            //if (inventoryListGoose.name != null)
            //{
            //    Debug.Log(inventoryListGoose.name);
            //    inventoryListGoose.imgrep.enabled = true;
            //}
            //else { inventoryListFull[0].imgrep.enabled = false; }
            word = "goose";
        }

        //    for (int i = 0; i < inventoryListFull.Length; i++)
        //{
        if (inventoryListFull[0].holder == word) {
            inventoryListFull[0].imgrep.enabled = true;
        } else {
            inventoryListFull[0].imgrep.enabled = false;
        }
        //}
	}

    public void obtain (string[] data) {
        if (data[1] == "goose") {
            //checks to see if goose is empty
            if (inventoryListGoose.name == null) {
                for (int i = 0; i < inventoryListFull.Length; i++) {
                    //check if item
                    if (inventoryListFull[i].name == data[0]) {
                        inventoryListGoose = inventoryListFull[i];
                        inventoryListFull[i].holder = "goose";
                        //Debug.Log("goose obtained");
                    }
                }
            }
        } else {
            for (int i = 0; i < inventoryListFull.Length; i++) {
                //check if item
                if (inventoryListFull[i].name == data[0]) {
                    bool added = false;
                    //inserts item in empty slot of kid's inventory
                    for (int ii = 0; ii < inventoryListKid.Length; ii++) {
                        if (inventoryListKid[ii].name == null && !added) {
                            inventoryListKid[ii] = inventoryListFull[i];
                            inventoryListFull[i].holder = "kid";
                            added = true;
                        }
                    }
                }
            }
        }
    }

    public void toggle() {
        //Debug.Log("Bag " + isEnabled);
        //isEnabled = !isEnabled;
        //inventoryBase.enabled = isEnabled;
    }

    public void gooseToKid() {
        isKid = !isKid;
        //Debug.Log(isKid);
        //if (inventoryListGoose.name != null)
        //{
        //    bool added = false;
        //    for (int ii = 0; ii < inventoryListKid.Length; ii++)
        //    {
        //        if (inventoryListKid[ii].name == null && !added)
        //        {
        //            inventoryListKid[ii] = inventoryListGoose;
        //            added = true;
        //            Debug.Log("before " + inventoryListGoose.name);
        //            Debug.Log("kid received");
        //            inventoryListGoose = new item();
        //            Debug.Log("after "+inventoryListGoose.name);
        //        }
        //    }
        //}
    }
}
