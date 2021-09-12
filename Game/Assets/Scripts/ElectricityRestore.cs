using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ElectricityRestore : MonoBehaviour
{
    public TMP_Text electext;
    public GameObject fence;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            electext.enabled = true;
            fence.GetComponent<FenceBlock>().OpenFence();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            electext.enabled = false;
            Destroy(gameObject);
        }
    }
}
