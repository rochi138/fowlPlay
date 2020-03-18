using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryItem : MonoBehaviour {

    public string[] send = new string[2];
    public bool isTouched;
    public GameObject inventoryController;

    void Awake() {
        PlayerEvents.OnEDown += Obtain;
    }

    void OnDestroy() {
        PlayerEvents.OnEDown -= Obtain;
    }

    void Start () {
        isTouched = false;
        inventoryController = GameObject.FindGameObjectWithTag("inventoryController");
        send[0] = this.name;
	}
	
	void Obtain () {
        if (isTouched) {
            inventoryController.SendMessage("obtain", this.send);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goose" || collision.gameObject.tag == "kid")
        {
            isTouched = true;
            send[1] = collision.gameObject.tag;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "goose" || collision.gameObject.tag == "kid")
        {
            isTouched = false;
            send[1] = null;
        }
    }

}
