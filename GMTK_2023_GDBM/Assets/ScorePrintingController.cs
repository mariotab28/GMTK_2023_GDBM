using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePrintingController : MonoBehaviour
{
    public List<PlayerAttachedUICollection> scoresPerPlayer;

    public void PrintScore(PlayerInfo playerInfo)
    {
        TextMeshProUGUI targetText = scoresPerPlayer.Find((item) => item.playerNumber == playerInfo.PlayerNumber).UITextElement;
        targetText.text = playerInfo.Score.ToString();
    }

}

[System.Serializable]
public class PlayerAttachedUICollection
{
    public PlayerNumber playerNumber;
    public TextMeshProUGUI UITextElement;
}