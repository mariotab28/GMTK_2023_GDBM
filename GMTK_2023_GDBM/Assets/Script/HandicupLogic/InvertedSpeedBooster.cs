using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InvertedSpeedBooster : MonoBehaviour, IGenericHandicup
{
    private Vector3 playerGoalCenter;
    public float accMulti;
    public int handicupNumber;
    public PlayerInfo playerInfo;
    [SerializeField] public PlayerValues defaultPlayer; // for testing
    private Vector3 player1GoalCenter = new Vector3(-8, 0, 0);
    private Vector3 player2GoalCenter = new Vector3(8, 0, 0);

    void Start()
    {
        if (playerInfo != null)
        {
            setPlayerGoalCenter();
        }
        else
        {
            playerInfo = new PlayerInfo(defaultPlayer.playerNumber, defaultPlayer.paddle, defaultPlayer.goal);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "Ball")
        {
            if (other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb))
            {

                if (playerInfo.PlayerNumber == PlayerNumber.PlayerOne)
                {
                    playerGoalCenter = player1GoalCenter;
                }
                else
                {
                    playerGoalCenter = player2GoalCenter;
                }
                Debug.Log(playerGoalCenter);
                Vector3 acceleratedVector = (playerGoalCenter - rb.transform.position) * accMulti;
                rb.velocity = acceleratedVector;
            }
        }
    }

    public void SetPlayerInfo(PlayerInfo player)
    {
        playerInfo = player;
    }

    public int GetHandicupNumber()
    {
        return handicupNumber;
    }

    private void setPlayerGoalCenter()
    {
        playerGoalCenter = playerInfo.AssignedGoal.transform.position;
    }


}
