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
    public float minSize = 0.4f;
    private Vector3 _minSizeVector = new Vector3(0.4f, 0.4f, 0.4f);
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
        Vector3 newScale = paddleObj.transform.localScale * sizeReductionMulti;
        paddleObj.transform.localScale = (newScale.x < 0.4) ? _minSizeVector : newScale;
        Debug.Log(paddleObj.transform.localScale);
    }

}
