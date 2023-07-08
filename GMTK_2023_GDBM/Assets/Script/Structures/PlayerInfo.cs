using UnityEngine;

public class PlayerInfo
{
    PlayerNumber playerNumber;
    int score;

    public PlayerNumber PlayerNumber { get { return playerNumber;} }
    public int Score { get { return score; }}

    public PlayerInfo(PlayerNumber playerNumber)
    {
        this.playerNumber = playerNumber;
        score = 0;
    }

    public void AddScore(int amount)
    {
        score += amount;
    }

    public bool Is(PlayerNumber playerNumber)
    {
        return playerNumber == this.playerNumber;
    }

}
