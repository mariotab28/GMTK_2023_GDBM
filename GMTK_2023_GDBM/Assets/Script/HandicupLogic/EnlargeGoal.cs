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
        goalObj = playerInfo.AssignedGoal;
        goalObj.transform.localScale = new Vector3(goalObj.transform.localScale.x, sizeEnlargeMulti, goalObj.transform.localScale.z);
    }

    void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;
    }
}
