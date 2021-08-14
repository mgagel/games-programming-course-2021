using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject destination;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        var destinationcoordinats = destination.transform.position;

        collision.gameObject.transform.position = destinationcoordinats;
    }
}
