using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;



public class Exit : MonoBehaviour
{
    public TMP_Text cantleavetext;

    void OnTriggerEnter2D(Collider2D collision)
    {
       bool holdingCompanion = collision.gameObject.GetComponent<PlayerMovement>().isCarryingCompanion;
       if (holdingCompanion)
        {
            SceneManager.LoadScene("TransitionToLevel2");
        } else
        {
            cantleavetext.enabled = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            cantleavetext.enabled = false;
       
        }
    }
}
