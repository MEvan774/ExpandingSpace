using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    bool tutorialMovement = true;
    bool tutorialAttack = false;

    bool startScene = true;

    public GameObject moveScreen;
    public GameObject attackSceen;

    void Update()
    {
        if (startScene)
        {
            GameEventTutorial.current.StartTutorial();
            startScene = false;
        }

        if (tutorialMovement)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D))
            {
                
                moveScreen.gameObject.SetActive(false);
                attackSceen.gameObject.SetActive(true);
                tutorialMovement = false;
                tutorialAttack = true;
            }
        }
        else if (tutorialAttack)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                attackSceen.gameObject.SetActive(false);
                tutorialAttack = true;

                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        ProgressBar progress = FindObjectOfType<ProgressBar>();
        progress.TutorialNonActive();


        SpawnMeteor meteorSpawner = FindObjectOfType<SpawnMeteor>();
        meteorSpawner.TutorialEnd();
    }
}
