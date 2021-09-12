using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportSewer : MonoBehaviour
{
    public GameObject destination;
    public GameObject fencetrigger;

    private bool opened = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (opened == true)
        {
            var destinationcoordinats = destination.transform.position;

            collision.gameObject.transform.position = destinationcoordinats;
        }
        else
        {
            if (fencetrigger.GetComponent<FenceBlock>().sewersopen == true)
            {
                var destinationcoordinats = destination.transform.position;

                collision.gameObject.transform.position = destinationcoordinats;

                opened = true;
            }
        }
    }
}
