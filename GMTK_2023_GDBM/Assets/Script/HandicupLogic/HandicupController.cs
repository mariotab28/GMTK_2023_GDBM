using UnityEngine;
using System.Collections.Generic;

public class HandicupController : MonoBehaviour
{
    public List<GameObject> handicupObjList;
    private List<GameObject> _handicupObjListPlayer1;
    private List<GameObject> _handicupObjListPlayer2;

    public List<Transform> canonListPlayer1;
    public List<Transform> canonListPlayer2;

    private int _canonListPlayer1Index = 0;
    private int _canonListPlayer2Index = 0;
    
    public List<Transform> boostListPlayer1;
    public List<Transform> boostListPlayer2;

    private int _boostListPlayer1Index = 0;
    private int _boostListPlayer2Index = 0;

    // Start is called before the first frame update
    void Start()
    {
        _handicupObjListPlayer1 = handicupObjList;
        _handicupObjListPlayer2 = handicupObjList;
    }

    public void addHandicup(PlayerInfo player){
        Transform spawnPosition;
        GameObject hc;

        if(player.PlayerNumber == 0){ // Player 1
            int index = Random.Range(0, 3);
            hc = _handicupObjListPlayer1[index];
            IGenericHandicup gHScript = hc.GetComponent<IGenericHandicup>();
            gHScript.SetPlayerInfo(player);
            int handicupType = gHScript.GetHandicupNumber();

            if(handicupType == 3){ // Inverted Velocity Booster
                spawnPosition = boostListPlayer1[_boostListPlayer1Index];
                boostListPlayer1.RemoveAt(_boostListPlayer1Index);
                _boostListPlayer1Index++;
                if(_boostListPlayer1Index > 5) { // Max Booster
                    _handicupObjListPlayer1.RemoveAt(index);
                }
            } else if(handicupType == 4){ // Canon
                spawnPosition = canonListPlayer1[_canonListPlayer1Index];
                canonListPlayer1.RemoveAt(_canonListPlayer1Index);
                _canonListPlayer1Index++;
                if(_boostListPlayer1Index > 3) { // Max Canons
                    _handicupObjListPlayer1.RemoveAt(index);
                }
            } else {
                spawnPosition = new GameObject().transform;
            }
        } else{ // Player 2
            int index = Random.Range(0, 3);
            hc = _handicupObjListPlayer2[index];
            IGenericHandicup gHScript = hc.GetComponent<IGenericHandicup>();
            gHScript.SetPlayerInfo(player);
            int handicupType = gHScript.GetHandicupNumber();

            if(handicupType == 3){ // Inverted Velocity Booster
                spawnPosition = boostListPlayer2[_boostListPlayer2Index];
                boostListPlayer2.RemoveAt(_boostListPlayer2Index);
                _boostListPlayer2Index++;
                if(_boostListPlayer2Index > 5) { // Max Booster
                    _handicupObjListPlayer2.RemoveAt(index);
                }
            } else if(handicupType == 4){ // Canon
                spawnPosition = canonListPlayer2[_canonListPlayer2Index];
                canonListPlayer2.RemoveAt(_canonListPlayer2Index);
                _canonListPlayer2Index++;
                if(_canonListPlayer2Index > 3) { // Max Canons
                    _handicupObjListPlayer2.RemoveAt(index);
                }
            } else {
                spawnPosition = new GameObject().transform;
            }
        }
        
        Instantiate(hc, spawnPosition);
    }
}
