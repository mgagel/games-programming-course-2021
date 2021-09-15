using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class TeleportBoss : MonoBehaviour
{
    public GameObject destination;

    public TMP_Text cantleavetext;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bool holdingCompanion = collision.gameObject.GetComponent<PlayerMovement>().isCarryingCompanion;
        if (holdingCompanion)
        {
            var destinationcoordinats = destination.transform.position;

            collision.gameObject.transform.position = destinationcoordinats;
        } else
        {
            cantleavetext.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        cantleavetext.enabled = false;
    }
}
