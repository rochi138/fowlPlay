using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableObject : MonoBehaviour
{

    public void OnCollisionEnter(Collision other)
    {
        Debug.Log("collision");

        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
        }
                
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
