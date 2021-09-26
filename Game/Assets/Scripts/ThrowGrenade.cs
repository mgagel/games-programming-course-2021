using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowGrenade : MonoBehaviour
{
    public Transform firePoint;
    public GameObject grenadePrefab;

    public int grenadeAmount;
    public Animator animator;
    public PlayerMovement playerMovement;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q) && grenadeAmount>0 && !playerMovement.isWalking)
        {
            Throw();
        }
    }

    void Throw()
    {
        animator.SetTrigger("throw");
        grenadeAmount -= 1;
        GameObject grenade = Instantiate(grenadePrefab, firePoint.position, firePoint.rotation);
        GrenadeMovement gm = grenade.GetComponent<GrenadeMovement>();
        PlayerMovement pm = gameObject.GetComponent<PlayerMovement>();

        switch (pm.lookingDirection)
        {
            case 0:
                gm.fliesHorizontal = false;
                gm.direction = -1;
                break;
            case 1:
                gm.fliesHorizontal = true;
                gm.direction = -1;
                break;
            case 2:
                gm.fliesHorizontal = false;
                gm.direction = 1;
                break;
            case 3:
                gm.fliesHorizontal = true;
                gm.direction = 1;
                break;
        }
    }
}
