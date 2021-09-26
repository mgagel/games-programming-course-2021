using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public bool changeSceneNow = false;
    private float waitTimer = 3.0f;
    private float fadeTimer = 3.0f;
    public Animator anim;
    private bool animPlayed = false;

    void Update()
    {
        MaybeChangeScene();
    }

    void MaybeChangeScene()
    {
        if (changeSceneNow)
        {
            if (waitTimer>0)
            {
                waitTimer -= Time.deltaTime;
            } else
            {
                if (fadeTimer>0)
                {
                    if (!animPlayed)
                    {
                        anim.Play("CrossFade_End");
                    }
                    fadeTimer -= Time.deltaTime;
                } else
                {
                    SceneManager.LoadScene("EndScene");
                }
            }
        }
    }
}
