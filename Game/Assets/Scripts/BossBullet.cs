using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBullet : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
        var player = collision.collider.GetComponent<Health>();
        if (player)
        {
            player.gotHit = true;
        }
    }
}
