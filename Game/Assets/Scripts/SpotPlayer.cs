using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotPlayer : MonoBehaviour
{
    public PolygonCollider2D collidercone;
    public Sprite spritedown;
    public Sprite spriteup;
    public Sprite spriteleft;
    public Sprite spriteright;

    public SpriteRenderer enemysprite;

    public GameObject enemy;

    // Update is called once per frame
    void Update()
    {
        if (enemysprite.sprite == spriteup)
        {
            TurnConeUp();
        }
        if (enemysprite.sprite == spritedown)
        {
            TurnConeDown();
        }
        if (enemysprite.sprite == spriteleft)
        {
            TurnConeLeft();
        }
        if (enemysprite.sprite == spriteright)
        {
            TurnConeRight();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            enemy.GetComponent<FixedEnemyMovement>().spottedPlayer = true;
        }
    }

    void TurnConeRight()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 0;
        collidercone.transform.rotation = Quaternion.Euler(rotationVector);
    }

    void TurnConeLeft()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 180;
        collidercone.transform.rotation = Quaternion.Euler(rotationVector);
    }

    void TurnConeUp()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = 90;
        collidercone.transform.rotation = Quaternion.Euler(rotationVector);
    }

    void TurnConeDown()
    {
        var rotationVector = transform.rotation.eulerAngles;
        rotationVector.z = -90;
        collidercone.transform.rotation = Quaternion.Euler(rotationVector);
    }
}
