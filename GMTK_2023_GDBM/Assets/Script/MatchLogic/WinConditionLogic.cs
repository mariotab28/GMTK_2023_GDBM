using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinConditionLogic : MonoBehaviour
{
    public EndOfMatchUIController endOfMatchUIController;
    private MatchLogic matchLogic;

    void Start()
    {
        matchLogic = GetComponent<MatchLogic>();
    }

    public void FinishMatchAndDeclareWinner()
    {
        PlayerInfo winningPlayer = matchLogic.GetWinningPlayer();
        matchLogic.FreezeMatch();
        endOfMatchUIController.StartEndOfMatchAnimation(winningPlayer);
    }

}
