using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class FenceBlock : MonoBehaviour
{
    public GameObject fence;
    public TMP_Text fencetext;

    public bool sewersopen = false;

    public void OpenFence()
    {
        Destroy(fence);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fencetext.enabled = true;
            sewersopen = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            fencetext.enabled = false;
        }
    }
}
