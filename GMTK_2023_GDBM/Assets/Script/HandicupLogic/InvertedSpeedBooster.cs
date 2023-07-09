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
        if(playerInfo != null){
            setPlayerGoalCenter();
        } 
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

    public void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;
    }

    public int GetHandicupNumber(){
        return handicupNumber;
    }

    private void setPlayerGoalCenter(){
        playerGoalCenter = playerInfo.AssignedGoal.transform.position;
    }


}
