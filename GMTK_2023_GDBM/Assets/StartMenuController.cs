using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StartMenuController : MonoBehaviour
{
    public UnityEvent matchLogic;
    public Animator startMenuAnimator;

    void Start()
    {
        startMenuAnimator.enabled = false;
    }

    public void StartStartingMatchAnimation()
    {
        startMenuAnimator.enabled = true;
    }

    public void StartMatchEvent()
    {
        matchLogic.Invoke();
    }
}
