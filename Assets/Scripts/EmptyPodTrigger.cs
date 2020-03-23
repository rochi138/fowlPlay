using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EmptyPodTrigger : MonoBehaviour {
    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other) {
        var objectName = other.gameObject.name;
        GameObject strikingBird = other.gameObject;

        //check if player is headbutting right side of pod
        if (strikingBird.GetComponent<Player_Control>().getHeadbutt() == true && CheckCollidingSide(other) == true) {
            Debug.Log("Collided with " + objectName);
            animator.SetBool("TipPod", true);
            gameObject.GetComponentInChildren<BoxCollider2D>().isTrigger = false;
        }  
    }

    private bool CheckCollidingSide(Collider2D other) {
        return (transform.position.x < other.transform.position.x);
    }

    private void Start() {
        Debug.Log(gameObject.name);
        animator = gameObject.GetComponent<Animator>();
    }
}
