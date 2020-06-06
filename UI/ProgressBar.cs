using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progress;
    private float progressAmount = 0f;
    private float progressPerSec = 2f;

    private bool death;

    public GameObject Player;

    private void Start()
    {
        GameEventScript.current.onPlayerDeath += ResetProgress;

        GameEventTutorial.current.tutorialStart += TutorialActive;
    }

    private void TutorialActive()
    {
        Debug.Log("TutorialActive");
        progressPerSec = 0f;
    }

    public void TutorialNonActive()
    {
        progressPerSec = 2f;
    }

    private void ResetProgress()
    {
        death = true;
        progressAmount = 0;
    }

    public void StartProgress()
    {
        death = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(death == false)
        {
            progress.value = (int)progressAmount;
            progressAmount += progressPerSec * Time.deltaTime;

            if (progressAmount >= 100)
            {
                LevelUIManager levelUiManager = FindObjectOfType<LevelUIManager>();
                levelUiManager.LevelComplete();
            }
        }

        //Sets Progress to 98
        if (Input.GetKey("p"))
        {
            progressAmount = 98;
        }
        //!
    }
}
