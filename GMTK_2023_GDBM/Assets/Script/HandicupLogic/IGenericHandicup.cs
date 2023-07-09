using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public struct PlayerValues
{
    public PlayerNumber playerNumber;
    public GameObject paddle;
    public GameObject goal;
}

public interface IGenericHandicup
{
    public void SetPlayerInfo(PlayerInfo player);
    public int GetHandicupNumber();
}
