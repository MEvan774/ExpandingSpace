using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelUIManager : MonoBehaviour
{

    public GameObject WinScreen;

    public GameObject GameOverScreen;

    public GameObject DeathScreen;
    public Animator DeathAnimScreen;

    private void Start()
    {
        GameEventScript.current.onPlayerDeath += Death;
    }

    public void LevelComplete()
    {
        Debug.Log("LevelManager: Complete");
        WinScreen.gameObject.SetActive(true);

        SceneTransition fadeIn = FindObjectOfType<SceneTransition>();
        fadeIn.TransitionIn();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    //Picks next scene in order
    public void NextLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        Debug.Log("LevelManager: GameOver");
        GameOverScreen.gameObject.SetActive(true);
    }

    public void Death()
    {
        if (DeathAnimScreen != null)
        {
            DeathAnimScreen.SetTrigger("deathTriggerAnim");
        }
        Debug.Log("LevelManager: Death");
    }

}
