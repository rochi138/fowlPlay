using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GameObject goose;
    public GameObject kid;
    public GameObject inventory;
    Camera cam;

    public int lag;
    public Goose gooseScript;

    void Start()
    {
        goose = GameObject.FindGameObjectWithTag("goose");
        kid = GameObject.FindGameObjectWithTag("kid");
        //inventory = GameObject.FindGameObjectWithTag("inventoryList");
        cam = Camera.main;

        lag = 0;
    }

    void Update()
    {
        if (lag == 0)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                goose.SendMessage("toggle");
                kid.SendMessage("toggle");

                //cam.GetComponent<Camera2DFollow>().SendMessage("toggle");

                lag = 6;
            }

            if (Input.GetKeyDown(KeyCode.Tab))
            {
                goose.SendMessage("toggle");
                kid.SendMessage("toggle");
                //inventory.SendMessage("toggle");
                lag = 6;
            }

        }
        else
        {
            lag -= 1;
        }
    }

}
