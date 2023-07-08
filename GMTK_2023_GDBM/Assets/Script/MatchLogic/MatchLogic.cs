using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MatchTimer))]
public class MatchLogic : MonoBehaviour
{
    public MatchDefinition matchDefinition;
    private List<PlayerInfo> playersInfo;
    private MatchTimer matchTimer;

    private void Start()
    {
        GetDependencies();
        StartMatch();
    }

    private void GetDependencies()
    {
        matchTimer = GetComponent<MatchTimer>();
    }

    private void StartMatch()
    {
        DefinePlayers();
        matchTimer.SetUp(matchDefinition.matchSecondsDuration);
        matchTimer.Start();
    }

    private void DefinePlayers()
    {
        if (matchDefinition.matchType == MatchType.Multiplayer1v1)
        {
            playersInfo = new List<PlayerInfo>{new PlayerInfo(0), new PlayerInfo(1)};
        }
    }

    private void AddScore()
    {
        
    }

}
