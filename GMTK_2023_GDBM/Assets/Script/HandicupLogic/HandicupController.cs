using UnityEngine;
using System;
using System.Collections.Generic;

public class HandicupController : MonoBehaviour
{
    public List<GameObject> handicupObjList;
    private List<GameObject> _handicupObjListPlayer1;
    private List<GameObject> _handicupObjListPlayer2;

    public List<Transform> canonListPlayer1;
    public List<Transform> canonListPlayer2;
    
    public List<Transform> boostListPlayer1;
    public List<Transform> boostListPlayer2;
    public GoalUIController goalUIController;

    // Start is called before the first frame update
    void Start()
    {
        _handicupObjListPlayer1 = handicupObjList;
        _handicupObjListPlayer2 = handicupObjList;
    }

    public void addHandicup(PlayerInfo player){
        Transform spawnPosition;
        GameObject hc;
        var random = new System.Random();
        int index = random.Next(0, 4);
        goalUIController.UpdateAddedHandicap(index);

        if(player.PlayerNumber == PlayerNumber.PlayerOne){ // Player 1
            hc = _handicupObjListPlayer1[index];
            IGenericHandicup gHScript = hc.GetComponent<IGenericHandicup>();

            int handicupType = gHScript.GetHandicupNumber();

            if(handicupType == 3){ // Inverted Velocity Booster
                spawnPosition = boostListPlayer1[0];
                boostListPlayer1.RemoveAt(0);
                if(boostListPlayer1.Count == 0) { // Max Booster
                    _handicupObjListPlayer1.RemoveAt(index);
                }
            } else if(handicupType == 4){ // Canon
                spawnPosition = canonListPlayer1[0];
                canonListPlayer1.RemoveAt(0);
                if(canonListPlayer1.Count == 0) { // Max Canons
                    _handicupObjListPlayer1.RemoveAt(index);
                }
            } else {
                spawnPosition = new GameObject().transform;
            }
        } else{ // Player 2
            hc = _handicupObjListPlayer2[index];
            IGenericHandicup gHScript = hc.GetComponent<IGenericHandicup>();

            int handicupType = gHScript.GetHandicupNumber();

            if(handicupType == 3){ // Inverted Velocity Booster
                spawnPosition = boostListPlayer2[0];
                boostListPlayer2.RemoveAt(0);
                if(boostListPlayer2.Count == 0) { // Max Booster
                    _handicupObjListPlayer2.RemoveAt(index);
                }
            } else if(handicupType == 4){ // Canon
                spawnPosition = canonListPlayer2[0];
                canonListPlayer2.RemoveAt(0);
                if(canonListPlayer2.Count == 0) { // Max Canons
                    _handicupObjListPlayer2.RemoveAt(index);
                }
            } else {
                spawnPosition = new GameObject().transform;
            }
        }
        
        GameObject obj = Instantiate(hc, spawnPosition);
        IGenericHandicup scriptObj = obj.GetComponent<IGenericHandicup>();
        scriptObj.SetPlayerInfo(player);
    }
}
