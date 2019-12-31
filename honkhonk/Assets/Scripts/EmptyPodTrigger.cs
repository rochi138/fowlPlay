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

        }

        //ContactPoint2D = ;

        //gother.contacts 
        


        Debug.Log("Collided with " + name);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
