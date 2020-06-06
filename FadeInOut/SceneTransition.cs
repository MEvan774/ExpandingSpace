using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SceneTransition : MonoBehaviour
{
    public Animator TransIn;
    public Animator TransOut;

    public GameObject FadeIn;
    public GameObject FadeOut;

    public bool transitionOut;

    // Start is called before the first frame update
    void Start()
    {
        if(transitionOut)
        {
            FadeOut.gameObject.SetActive(true);
            TransOut.SetTrigger("FadeOut");
        }
    }
    
    public void TransitionIn()
    {
        FadeIn.gameObject.SetActive(true);
        TransIn.SetTrigger("FadeIn");
    }
}
