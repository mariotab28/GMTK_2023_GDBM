using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Canon : MonoBehaviour, IGenericHandicup
{
    public GameObject prefab;
    private UnityEngine.Vector3 initialDirectionVector;
    public int initialVelocity;
    public GameObject spawnPoint;
    public float spawnTimer;

    [SerializeField] public PlayerValues defaultPlayer; // for testing

    public int handicupNumber;
    public PlayerInfo playerInfo;

    private Vector3 player1GoalCenter = new Vector3(-8, 0, 0);
    private Vector3 player2GoalCenter = new Vector3(8, 0, 0);

    [ContextMenu("Spawn Object")]
    public void SpawnObj(){

        GameObject obj =Instantiate(prefab, spawnPoint.transform.position, new UnityEngine.Quaternion(0,0,0,0));
        obj.GetComponent<Rigidbody2D>().velocity = initialDirectionVector  * initialVelocity;
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObj", Random.Range(0.5f, spawnTimer), spawnTimer);

        if (playerInfo == null)
        {
            playerInfo = new PlayerInfo(defaultPlayer.playerNumber, defaultPlayer.paddle, defaultPlayer.goal);
        }
    }

    public void SetPlayerInfo( PlayerInfo player){
        playerInfo = player;

        if(playerInfo.PlayerNumber == PlayerNumber.PlayerOne) {
            initialDirectionVector = player1GoalCenter - spawnPoint.transform.position;
        } else {
            initialDirectionVector = player2GoalCenter - spawnPoint.transform.position;
        }

        initialDirectionVector.Normalize();
         
    }

    public int GetHandicupNumber(){
        return handicupNumber;
    }

}
