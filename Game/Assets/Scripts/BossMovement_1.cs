using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovement_1 : MonoBehaviour
{
    public int attackPattern = 0; //0 = left<->right default; 1 = follow player; 2 = fast left->right
    public float baseMoveSpeedBoss;
    public Transform player;
    private Rigidbody2D rigidBodyBoss;
    private Transform transformBoss;
    private EnemyHealth healthBoss;
    private bool movingLeft = true;
    private bool executePattern1 = false;
    public bool laserMovement = false;
    private float pattern1Wait = 1.5f;
    public float basePatternChangeTime;
    public float patternChangeTime;
    private float patternChangeWait;
    private bool stopPatternChangeTimer = false;
    public float moveSpeedBoss;
    private int maxHealth;
    public Animator animator;

    void Start()
    {
        rigidBodyBoss = gameObject.GetComponent<Rigidbody2D>();
        transformBoss = gameObject.GetComponent<Transform>();
        healthBoss = gameObject.GetComponent<EnemyHealth>();
        patternChangeWait = basePatternChangeTime;
        patternChangeTime = basePatternChangeTime;
        moveSpeedBoss = baseMoveSpeedBoss;
        maxHealth = healthBoss.health;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(player.position, gameObject.transform.position);
        if (distanceToPlayer<40.0f)
        {
            updatePatternChangeRate();
            updateMoveSpeed();
            changePattern();
            moveBoss();
        }
    }

    void moveBoss()
    {
        switch (attackPattern)
        {
            case 0:
                if (movingLeft)
                {
                    if (transformBoss.position.x <= 291.0f)
                    {
                        movingLeft = false;
                        moveRightNormal();
                    } else
                    {
                        moveLeftNormal();
                    }
                } else
                {
                    if (transformBoss.position.x >= 310.0f)
                    {
                        movingLeft = true;
                        moveLeftNormal();
                    } else
                    {
                        moveRightNormal();
                    }
                }
                break;

            case 1:
                if (player.position.x <= transformBoss.position.x)
                {
                    moveLeftNormal();
                }
                if (player.position.x > transformBoss.position.x)
                {
                    moveRightNormal();
                }
                break;

            case 2:
                if (executePattern1)
                {
                    if (transformBoss.position.x >= 310.0f)
                    {
                        laserMovement = false;
                        executePattern1 = false;
                        pattern1Wait = 1.5f;
                        stopPatternChangeTimer = false;
                        attackPattern = Random.Range(0,2);
                        animator.SetBool("laser", false);
                    } else
                    {
                        if (pattern1Wait>0)
                        {
                            pattern1Wait -= Time.deltaTime;
                            shakeBoss();
                        } else
                        {
                            laserMovement = true;
                            animator.SetBool("laser", true);
                            transformBoss.rotation = Quaternion.Euler(0, 0, 0);
                            rigidBodyBoss.velocity = new Vector2(moveSpeedBoss * 2.5f, 0);
                        }
                    }
                } else
                {
                    if (transformBoss.position.x <= 291.0f)
                    {
                        executePattern1 = true;;
                    } else
                    {
                        moveLeftNormal();
                    }
                }
                break;
        }
    }

    void shakeBoss()
    {
        transformBoss.rotation = Quaternion.Euler(0, 0, Random.Range(-20f, 20f));
    }

    void moveLeftNormal()
    {
        rigidBodyBoss.velocity = new Vector2(-moveSpeedBoss, 0);
    }

    void moveRightNormal()
    {
        rigidBodyBoss.velocity = new Vector2(moveSpeedBoss, 0);
    }

    void changePattern()
    {
        if (!stopPatternChangeTimer)
        {
            if (patternChangeWait>0)
            {
                patternChangeWait -= Time.deltaTime;
            } else
            {
                attackPattern = Random.Range(0,3);
                if (attackPattern==2)
                {
                    stopPatternChangeTimer = true;
                }
                patternChangeWait = patternChangeTime;
            }
        }
    }

    void updateMoveSpeed()
    {
        moveSpeedBoss = Mathf.Lerp(6*baseMoveSpeedBoss, baseMoveSpeedBoss, ((float) healthBoss.health)/((float) maxHealth));
    }
    
    void updatePatternChangeRate()
    {
        patternChangeTime = Mathf.Lerp(1.0f, basePatternChangeTime, ((float) healthBoss.health)/((float) maxHealth));
    }
}