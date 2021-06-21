using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;

    void Update() 
    {
        Vector3 newCamPosition = new Vector3(player.position.x, player.position.y, this.transform.position.z);
        updateCamPosition(newCamPosition);
    }

    void updateCamPosition(Vector3 position)
    {
        this.transform.position = position;
    }
}
