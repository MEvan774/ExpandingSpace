using UnityEngine;
using UnityEngine.UI;

public class ScoreUI : MonoBehaviour
{
    [Header("UI")]
    private int currentScore;
    public Text score;

    public void updateScore(int score)
    {
        currentScore = score;
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score" + currentScore;
    }
}