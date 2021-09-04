using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundsDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision)
    {
        //if(collision.collider.name == "")
        //Debug.Log(collision.collider.name);
        Destroy(collision.gameObject);
    }
}
