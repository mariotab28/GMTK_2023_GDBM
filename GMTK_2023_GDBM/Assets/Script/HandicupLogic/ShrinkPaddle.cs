using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkPaddle : MonoBehaviour
{
    public GameObject[] respawns;
    public int affectedPlayer;
    // Start is called before the first frame update
    void Start()
    {
        respawns = GameObject.FindGameObjectsWithTag("PaddlePlayer2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
