using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rigBody;

    UnityEvent collideWithBall;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();

        if (collideWithBall == null)
            collideWithBall = new UnityEvent();

        collideWithBall.AddListener(OnCollideWithBall);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ball"){ /*Si colisiona con la pelota*/
            collideWithBall.Invoke();
        }
    }

    private void OnCollideWithBall() 
    {
        Debug.Log("Collide with ball");
    }
}
