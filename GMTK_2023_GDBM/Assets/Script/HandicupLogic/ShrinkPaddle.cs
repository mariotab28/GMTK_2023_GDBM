using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPaddle : MonoBehaviour
{
    private GameObject paddleObj;
    public int affectedPlayer;
    [Range(0, 1)]
    public float sizeReductionMulti;
    // Start is called before the first frame update
    void Start()
    {
        if(affectedPlayer == 0){
            paddleObj = GameObject.FindGameObjectsWithTag("PaddlePlayer1")[0];
        } else {
            paddleObj = GameObject.FindGameObjectsWithTag("PaddlePlayer2")[0];
        }
        
        paddleObj.transform.localScale = new Vector3(sizeReductionMulti, sizeReductionMulti, sizeReductionMulti);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
