using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
       bool holdingCompanion = collision.gameObject.GetComponent<PlayerMovement>().isCarryingCompanion;
       if (holdingCompanion)
        {
            Debug.Log("Level Complete!");
        } else
        {
            Debug.Log("Must carry Companion");
        }
 
    }
}
