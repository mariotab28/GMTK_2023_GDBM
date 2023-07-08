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

    private void FreezeMatch()
    {
        Time.timeScale = 0;
    }

    private void ResumeMatch()
    {
        Time.timeScale = 1;
    }

    private void TriggerStartMatchProcess()
    {
        DefinePlayers();
        matchTimer.SetUp(matchDefinition.matchSecondsDuration);
        matchTimer.Start();
        uIPrintingController.startMenuController.StartStartingMatchAnimation();
        // FreezeMatch();
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

    public void AddScore(PlayerNumber playerNumber)
    {
        FreezeMatch();

        PlayerInfo player = playersInfo.Find((player) => player.PlayerNumber == playerNumber);
        player.AddScore(1);
        uIPrintingController.score.PrintScore(player);

        uIPrintingController.goalUIController.PlayGoalAnimation(player);
    }

    public void ContinueMatchAfterScore()
    {
        // Reset ball
        ResumeMatch();
        resetPositionsEvent.Invoke();
    }

}
