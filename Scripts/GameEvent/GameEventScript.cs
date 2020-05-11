using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEventScript : MonoBehaviour
{
    public static GameEventScript current;
    private void Awake()
    {
        current = this;
    }

    public event Action onPlayerDeath;
    public void playerDeath()
    {
        if(onPlayerDeath != null)
        {
            onPlayerDeath();
        }
    }
}