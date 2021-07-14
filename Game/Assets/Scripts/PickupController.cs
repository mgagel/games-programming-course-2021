using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupController : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public Transform playerTransform;

    // Update is called once per frame
    void Update()
    {
        followPlayer();
    }

    void followPlayer()
    {
        if (playerMovement.isCarryingCompanion)
        {
            this.transform.position = playerTransform.position;
        }
    }
}
