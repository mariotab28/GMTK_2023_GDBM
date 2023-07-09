using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour, IGenericHandicup
{
    public GameObject prefab;
    public UnityEngine.Vector3 initialDirectionVector;
    public int initialVelocity;
    public UnityEngine.Vector3 spawnPosition;
    public float spawnTimer;

    public int handicupNumber;
    public PlayerInfo playerInfo;

    private Vector3 player1GoalCenter = new Vector3(-8, 0, 0);
    private Vector3 player2GoalCenter = new Vector3(8, 0, 0);

    [ContextMenu("Spawn Object")]
    public void SpawnObj(){

        GameObject obj =Instantiate(prefab, spawnPosition, new UnityEngine.Quaternion(0,0,0,0));
        obj.GetComponent<Rigidbody2D>().velocity = initialDirectionVector  * initialVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", spawnTimer, spawnTimer);
    }

    public void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;

        if(playerInfo.PlayerNumber == PlayerNumber.PlayerOne) {
            initialDirectionVector = player1GoalCenter - spawnPosition;
        } else {
            initialDirectionVector = player2GoalCenter- spawnPosition;
        }
         
    }

    public int GetHandicupNumber(){
        return handicupNumber;
    }

}
