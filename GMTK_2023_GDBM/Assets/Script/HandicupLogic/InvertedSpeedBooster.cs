using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvertedSpeedBooster : MonoBehaviour
{
    public Vector2 playerGoalCenter;
    public float accMulti;
    public List<Transform> player1BoostPlacement;
    public List<Transform> player2BoostPlacement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Ball"){
            if(other.gameObject.TryGetComponent<Rigidbody2D>(out Rigidbody2D rb)){
                
                Vector2 acceleratedVector = (playerGoalCenter - new Vector2(rb.transform.position.x, rb.transform.position.y)) * accMulti;
                rb.velocity = acceleratedVector;
            }
        }
    }


}
