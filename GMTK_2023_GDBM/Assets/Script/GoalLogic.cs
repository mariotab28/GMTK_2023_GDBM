using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GoalLogic : MonoBehaviour
{
    UnityEvent collideWithGoal;

    // Start is called before the first frame update
    void Start()
    {
        if (collideWithGoal == null)
            collideWithGoal = new UnityEvent();

        collideWithGoal.AddListener(ScorePoint);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ball"){
            collideWithGoal.Invoke();
        }
    }

    private void ScorePoint() 
    {
        Debug.Log("Goooooooooooool!");
    }
}

