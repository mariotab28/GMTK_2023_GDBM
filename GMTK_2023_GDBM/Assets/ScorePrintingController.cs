using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScorePrintingController : MonoBehaviour
{
    public List<UIAttachedToPlayer> scoresPerPlayer;
    public int startingScore = 0;

    void Start()
    {
        InitializeScores();
    }

    public void PrintScore(PlayerInfo playerInfo)
    {
        UIAttachedToPlayer uIAttachedToPlayerSetting = scoresPerPlayer.Find(
            (item) => item.playerNumber == playerInfo.PlayerNumber
        );
        TextMeshProUGUI targetText = uIAttachedToPlayerSetting.uITextElement;
        targetText.text = playerInfo.Score.ToString();
    }

    private void InitializeScores()
    {
        scoresPerPlayer.ForEach(
            (UIAttachedToPlayer) =>
            {
                UIAttachedToPlayer.uITextElement.text = startingScore.ToString();
            }
        );
    }
}

[System.Serializable]
public class UIAttachedToPlayer
{
    public PlayerNumber playerNumber;
    public TextMeshProUGUI uITextElement;
}
