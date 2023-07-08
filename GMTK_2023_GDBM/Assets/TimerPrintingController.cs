using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerPrintingController : MonoBehaviour
{
    public TextMeshProUGUI targetText;

    public void Print(float seconds)
    {
        string toPrint = GetFormattedTimeInMinutes(seconds);
        targetText.text = toPrint;
    }

    string GetFormattedTimeInMinutes(float seconds)
    {
        int printedMinutes = Mathf.FloorToInt(seconds / 60f);
        int printedSeconds = (int)(seconds % 60f);
        string toPrint = "";

        if (printedMinutes > 0)
        {
            toPrint += printedMinutes + ":";
        }
        toPrint += printedSeconds < 10 ? "0" + printedSeconds.ToString() : printedSeconds.ToString();
        return toPrint;
    }
}
