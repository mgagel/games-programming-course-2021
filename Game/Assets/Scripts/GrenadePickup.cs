using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadePickup : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collider)
    {
        var Player = collider.gameObject.GetComponent<ThrowGrenade>();
        if (Player)
        {
            Player.grenadeAmount += 3;
            Destroy(gameObject);
        }
    }
}
