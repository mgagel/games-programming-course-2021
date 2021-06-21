using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Health playerHealth;
    public PlayerMovement playerMovement;
    public Transform respawnPoint;
    public GameObject playerPrefab;
    public float tiomeToRespawn;
    public float timeUntilRespawn;

    void Start()
    {
        timeUntilRespawn = tiomeToRespawn;
    }

    void Update()
    {
        if (playerHealth.playerIsDead)
        {
            PlayerRespawn(respawnPoint);
        }
    }

    void PlayerRespawn(Transform respawnPoint)
    {
        if (timeUntilRespawn>0f)
        {
            timeUntilRespawn = timeUntilRespawn - Time.deltaTime;
        } else {
            playerHealth.health = playerHealth.maxhealth;
            playerPrefab.transform.position = respawnPoint.position;
            playerHealth.deathtext.enabled = false;
            playerPrefab.SetActive(true);
            timeUntilRespawn = tiomeToRespawn;
            playerMovement.freezePlayer = false;
            playerHealth.playerIsDead = false;
            Debug.Log("Respawn");
        }
    }
}
