using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator;

public class InventoryItem : MonoBehaviour {

    public string[] send = new string[2];
    public bool isTouched = false;
    public GameObject inventoryController;

    void Start () {
        // Locator.Get<PlayerEventsService>( "PlayerEventsService" ).OnEDown += Obtain;
        inventoryController = GameObject.FindGameObjectWithTag("inventoryController");
        send[0] = this.name;
	}

    void OnDestroy() {
        // Locator.Get<PlayerEventsService>( "PlayerEventsService" ).OnEDown -= Obtain;
    }
	
	void Obtain () {
        if (isTouched) {
            inventoryController.SendMessage("obtain", this.send);
        }
	}

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "goose" || collision.gameObject.tag == "kid") {
            isTouched = true;
            send[1] = collision.gameObject.tag;
        }
    }

    private void OnCollisionExit2D(Collision2D collision) {
        if (collision.gameObject.tag == "goose" || collision.gameObject.tag == "kid") {
            isTouched = false;
            send[1] = null;
        }
    }
}
