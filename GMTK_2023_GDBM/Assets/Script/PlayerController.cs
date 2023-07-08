using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    // Player values
    public float defaultSpeed;
    public float sprintSpeed;
    protected Vector2 PlayerDirection;
    protected float directionX;
    protected float directionY;

    // Player components
    protected Movement movement;

    private Rigidbody2D rigBody;

    UnityEvent collideWithBall;

    
    void Awake()
    {
        movement = GetComponent<Movement>();

        rigBody = GetComponent<Rigidbody2D>();

        if (collideWithBall == null)
            collideWithBall = new UnityEvent();

        collideWithBall.AddListener(OnCollideWithBall);
    }

    private void Start()
    {
        movement.SetSpeed(defaultSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.gameObject.tag == "Ball"){ /*Si colisiona con la pelota*/
            collideWithBall.Invoke();
        }
    }

    private void OnCollideWithBall() 
    {
        //Debug.Log("Collide with ball");
    }
}
