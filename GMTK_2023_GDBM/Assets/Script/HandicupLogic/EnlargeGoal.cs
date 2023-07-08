using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnlargeGoal : MonoBehaviour
{
    private GameObject goalObj;
    public int affectedPlayer;
    [Range(1, 2)]
    public float sizeEnlargeMulti;
    // Start is called before the first frame update
    void Start()
    {
        if(affectedPlayer == 0){
            goalObj = GameObject.FindGameObjectsWithTag("GoalPlayer1")[0];
        } else {
            goalObj = GameObject.FindGameObjectsWithTag("GaolPlayer2")[0];
        }
        
        goalObj.transform.localScale = new Vector3(goalObj.transform.localScale.x, sizeEnlargeMulti, goalObj.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
