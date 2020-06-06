using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventTutorial : MonoBehaviour
{
    public static GameEventTutorial current;
    private void Awake()
    {
        current = this;
    }

    public event Action tutorialStart;
    public void StartTutorial()
    {
        //Debug.Log("PlayerDeath Event Active");
        if (tutorialStart != null)
        {
            tutorialStart();
        }
    }
}