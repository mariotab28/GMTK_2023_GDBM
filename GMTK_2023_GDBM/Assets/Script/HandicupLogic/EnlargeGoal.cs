using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeGoal : MonoBehaviour, IGenericHandicup
{
    private GameObject goalObj;
    [Range(1, 2)]
    public float sizeEnlargeMulti;
    public int handicupNumber;
    public PlayerInfo playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        if(playerInfo != null){
            calculateGoalObj();
        }
    }

    public void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;
        calculateGoalObj();
    }

    public int GetHandicupNumber(){
        return handicupNumber;
    }

    private void calculateGoalObj(){
        goalObj = playerInfo.AssignedGoal;
        goalObj.transform.localScale = new Vector3(goalObj.transform.localScale.x, goalObj.transform.localScale.y * sizeEnlargeMulti, goalObj.transform.localScale.z);
    }

}
