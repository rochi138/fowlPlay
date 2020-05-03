using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidPodTrigger : MonoBehaviour
{

    public Animator animator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        var objectName = other.gameObject.name;
        GameObject strikingBird = other.gameObject;

        //check if player is headbutting right side of pod
        //if (strikingBird.GetComponent<Player_Control>().getHeadbutt() == true)
        //{
        //    Debug.Log("Collided with " + objectName);
        //    animator.SetTrigger("FadeIn");
        //    //disable kid pod
        //    gameObject.transform.GetChild(0).gameObject.SetActive(false);
        //    //enable opened pod
        //    gameObject.transform.GetChild(1).gameObject.SetActive(true); 
        //}

    }

    void Start()
    {
        animator = GameObject.Find("LvlChanger").GetComponent<Animator>();
    }
}
