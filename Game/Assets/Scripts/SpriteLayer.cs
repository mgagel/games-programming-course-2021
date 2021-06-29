using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteLayer : MonoBehaviour
{
    void Awake() {
        SetPosition();
    }
    void Update()
    {
        SetPosition();
    }

    void SetPosition() {
        GetComponent<SpriteRenderer>().sortingOrder = (int)transform.position.y*-1;
    }
}
