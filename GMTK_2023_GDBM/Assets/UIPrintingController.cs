using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPrintingController : MonoBehaviour
{
    [HideInInspector]
    public TimerPrintingController timer;
    [HideInInspector]
    public ScorePrintingController score;

    void Start()
    {
        timer = GetComponent<TimerPrintingController>();
        score = GetComponent<ScorePrintingController>();
    }
}
