using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    public static bool pauseActive = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseActive)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pausePanel.gameObject.SetActive(false);
        Time.timeScale = 1f;
        pauseActive = false;
    }

    public void Pause()
    {
        pausePanel.gameObject.SetActive(true);
        Time.timeScale = 0f;
        pauseActive = true;
    }

    public void Quit()
    {
        SceneManager.LoadScene(1);
        //Application.LoadLevel(1);
    }
}
