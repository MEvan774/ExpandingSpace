using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public ScoreUI scoreUi;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        scoreUi = FindObjectOfType<ScoreUI>();
        scoreUi.updateScore(score);
    }

    private void Update()
    {
        if (Input.GetKey("o"))
        {
            Debug.Log("+100");
            score += 100;
            scoreUi.updateScore(score);
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score"))
        {
            score += 100;
            scoreUi.updateScore(score);
        }
    }
}
