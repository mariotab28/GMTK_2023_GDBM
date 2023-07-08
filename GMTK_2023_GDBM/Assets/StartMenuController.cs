using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartMenuController : MonoBehaviour
{
    public UnityEvent matchLogic;
    public Animator startMenuAnimator;


    public void StartStartingMatchAnimation()
    {
        startMenuAnimator.SetTrigger("Start");
    }

    public void StartMatchEvent()
    {
        matchLogic.Invoke();
    }
}
