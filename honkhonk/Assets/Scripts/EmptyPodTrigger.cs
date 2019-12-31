using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmptyPodTrigger : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        var objectName = other.gameObject.name;
        GameObject strikingBird = other.gameObject;
        if (strikingBird.GetComponent<Player_Control>().getHeadbutt() == true)
        {
            Debug.Log("Collided with " + name);
        }

        //ContactPoint2D = ;

        //gother.contacts 
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
