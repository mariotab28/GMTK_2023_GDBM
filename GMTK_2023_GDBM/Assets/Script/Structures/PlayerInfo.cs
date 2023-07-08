using UnityEngine;

public class PlayerInfo
{
    PlayerNumber playerNumber;
    int score;
    GameObject assignedPaddle;
    GameObject assignedGoal;

    public PlayerNumber PlayerNumber { get { return playerNumber;} }
    public int Score { get { return score; }}

    public PlayerInfo(PlayerNumber playerNumber, GameObject paddle, GameObject goal)
    {
        this.playerNumber = playerNumber;
        this.assignedPaddle = paddle;
        this.assignedGoal = goal;
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
