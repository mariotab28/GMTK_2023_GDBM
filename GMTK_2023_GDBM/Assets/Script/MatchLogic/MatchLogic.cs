using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(MatchTimer))]
public class MatchLogic : MonoBehaviour
{
    public MatchDefinition matchDefinition;
    public UIPrintingController uIPrintingController;
    public UnityEvent resetPositionsEvent;
    public StartMenuController startMenuController;
    public HandicupController handicupController;
    private List<PlayerInfo> playersInfo;
    private MatchTimer matchTimer;

    private void Start()
    {
        GetDependencies();
        TriggerStartMatchProcess();
    }

    private void GetDependencies()
    {
        matchTimer = GetComponent<MatchTimer>();
    }

    public void FreezeMatch()
    {
        Time.timeScale = 0;
    }

    public void ResumeMatch()
    {
        Time.timeScale = 1;
    }

    private void TriggerStartMatchProcess()
    {
        DefinePlayers();
        matchTimer.SetUp(matchDefinition.matchSecondsDuration);
        matchTimer.Start();
        uIPrintingController.startMenuController.StartStartingMatchAnimation();
        FreezeMatch();
    }

    public void StartMatch()
    {
        ResumeMatch();
    }

    private void DefinePlayers()
    {
        if (matchDefinition.matchType == MatchType.Multiplayer1v1)
        {
            playersInfo = new List<PlayerInfo>
            {
                new PlayerInfo(PlayerNumber.PlayerOne),
                new PlayerInfo(PlayerNumber.PlayerTwo)
            };
        }
    }

    public PlayerInfo GetWinningPlayer()
    {
        PlayerInfo winningPlayer;
        PlayerInfo playerOne = playersInfo.Find(
            (player) => player.PlayerNumber == PlayerNumber.PlayerOne
        );
        PlayerInfo playerTwo = playersInfo.Find(
            (player) => player.PlayerNumber == PlayerNumber.PlayerTwo
        );
        if (playerOne.Score == playerTwo.Score)
        {
            winningPlayer = null;
        }
        else if (playerOne.Score > playerTwo.Score)
        {
            winningPlayer = playerOne;
        }
        else
        {
            winningPlayer = playerTwo;
        }
        return winningPlayer;
    }

    public void AddScore(PlayerNumber playerNumber)
    {
        FreezeMatch();

        PlayerInfo player = playersInfo.Find((player) => player.PlayerNumber == playerNumber);
        player.AddScore(1);
        uIPrintingController.score.PrintScore(player);

        uIPrintingController.goalUIController.PlayGoalAnimation(player);
        handicupController.addHandicup(player);
    }

    public void ContinueMatchAfterScore()
    {
        // Reset ball
        ResumeMatch();
        resetPositionsEvent.Invoke();
    }
}
