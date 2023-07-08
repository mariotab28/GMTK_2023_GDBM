using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalLogic : MonoBehaviour
{
    public PlayerNumber playerWhoScoresHere;
    public UnityEvent<PlayerNumber> collideWithGoal;


    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ball"){
            collideWithGoal.Invoke(playerWhoScoresHere);
        }
    }

    private void ScorePoint() 
    {
        Debug.Log("Goooooooooooool!");
    }
}

