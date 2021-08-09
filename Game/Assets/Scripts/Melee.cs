using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Melee : MonoBehaviour
{
    public Transform firePoint;
    public GameObject SwordPrefab;
    public GameObject SwordAnimPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            StartCoroutine(MeleeAttack());
        }
    }

    IEnumerator MeleeAttack()
    {
        //Animation:
        GameObject swordanimation = Instantiate(SwordAnimPrefab, firePoint.position, firePoint.rotation);


        //Actual Weapon functionality:
        GameObject sword = Instantiate(SwordPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = sword.GetComponent<Rigidbody2D>();
        yield return new WaitForSeconds(0.25F);
        Destroy(swordanimation);
        Destroy(sword);
    }
}
