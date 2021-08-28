using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //difficulty: 0 = easy, 1 = medium, 2 = hard;
    public int difficulty = 1;
    public GameObject easyScreen;
    public GameObject mediumScreen;
    public GameObject hardScreen;

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void ChangeDifficulty()
    {
        if (difficulty == 0)
        {
            easyScreen.SetActive(false);
            mediumScreen.SetActive(true);
            difficulty = 1;
        } else if (difficulty == 1)
        {
            mediumScreen.SetActive(false);
            hardScreen.SetActive(true);
            difficulty = 2;
        } else
        {
            hardScreen.SetActive(false);
            easyScreen.SetActive(true);
            difficulty = 0;
        }
    }
}
