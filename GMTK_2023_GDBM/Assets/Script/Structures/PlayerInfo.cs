using UnityEngine;

public class PlayerInfo
{
    int playerNumber;
    int score;

    public int Number { get { return playerNumber;} }
    public int Score { get { return score; }}

    public PlayerInfo(int playerNumber)
    {
        this.playerNumber = playerNumber;
        score = 0;
    }
}
