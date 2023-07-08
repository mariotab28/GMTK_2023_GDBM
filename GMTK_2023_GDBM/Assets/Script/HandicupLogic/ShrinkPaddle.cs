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
        paddleObj = playerInfo.AssignedPaddle;
        paddleObj.transform.localScale = new Vector3(sizeReductionMulti, sizeReductionMulti, sizeReductionMulti);
    }

    void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;
    }
}
