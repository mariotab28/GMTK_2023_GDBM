using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPaddle : MonoBehaviour, IGenericHandicup
{
    private GameObject paddleObj;
    [Range(0, 1)]
    public float sizeReductionMulti;
    public int handicupNumber;
    public PlayerInfo playerInfo;
    // Start is called before the first frame update
    void Start()
    {
        if(playerInfo != null){
            ModifyPaddle();
        }
        
    }

    public void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;
        ModifyPaddle();
    }

    public int GetHandicupNumber(){
        return handicupNumber;
    }

    private void ModifyPaddle(){
        paddleObj = playerInfo.AssignedPaddle;
        paddleObj.transform.localScale = paddleObj.transform.localScale * sizeReductionMulti;
    }

}
