using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorBehavior : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("Hit: " + collision.gameObject.tag);
        if(collision.gameObject.tag != "PLayer")
        {
            Destroy(collision.gameObject, 6f);
        }
    }
}
