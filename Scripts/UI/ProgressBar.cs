using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    public Slider progress;
    private float progressAmount;
    private float progressPerSec;

    // Start is called before the first frame update
    void Start()
    {
        progressAmount = 0f;
        progressPerSec = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = (int)progressAmount;
        progressAmount += progressPerSec * Time.deltaTime;

        if(progressAmount >= 100)
        {
            Debug.Log("Level Completed!");
        }

        //!
        if (Input.GetKey("p"))
        {
            progressAmount = 98;
        }
        //!
    }
}
