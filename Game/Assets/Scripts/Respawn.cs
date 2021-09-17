using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Respawn : MonoBehaviour
{
    
    public Health playerHealth;
    public Health companionHealth;
    public float timeToRespawn;
    public float timeUntilRespawn;


    void Start()
    {
        timeUntilRespawn = timeToRespawn;
    }

    void Update()
    {
        if (playerHealth.playerIsDead || companionHealth.playerIsDead)
        {
            PlayerRespawn();
        }
    }

    void PlayerRespawn()
    {
        if (timeUntilRespawn>0f)
        {
            timeUntilRespawn = timeUntilRespawn - Time.deltaTime;
        } else {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            /*
            playerHealth.fullheal();
            playerPrefab.transform.position = respawnPoint.position;
            playerHealth.deathtext.enabled = false;
            playerPrefab.SetActive(true);
            timeUntilRespawn = timeToRespawn;
            playerMovement.freezePlayer = false;
            playerHealth.playerIsDead = false;
            Debug.Log("Respawn");
            */
        }
    }
}
