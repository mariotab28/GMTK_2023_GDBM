using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedSpeedBooster : MonoBehaviour, IGenericHandicup
{
    public Vector3 playerGoalCenter;
    public float accMulti;
    public int handicupNumber;
    public PlayerInfo playerInfo;

    void Start()
    {
        playerGoalCenter = playerInfo.AssignedGoal.transform.position;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ball"){
            if(other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)){
                Vector3 acceleratedVector = (playerGoalCenter - rb.transform.position) * accMulti;
                rb.velocity = acceleratedVector;
            }
        }
    }

    void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;
    }


}
