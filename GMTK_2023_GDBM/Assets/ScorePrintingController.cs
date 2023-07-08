using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePrintingController : MonoBehaviour
{
    public List<TextMeshProUGUI> scoresPerPlayer;

    public void PrintScore(PlayerInfo playerInfo)
    {
        TextMeshProUGUI targetText = scoresPerPlayer[playerInfo.Number];
        targetText.text = playerInfo.Score.ToString();
    }

}
