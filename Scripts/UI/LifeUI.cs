using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    [Header("UI")]
    private float currentLifes;
    public Text lifes;

    public void setCurrentLifes(float lifes)
    {
        currentLifes = lifes;
    }

    void Update()
    {
        lifes.text = "X" + currentLifes;
    }


}
