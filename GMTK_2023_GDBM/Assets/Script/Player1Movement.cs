using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : MonoBehaviour
{
    private Rigidbody2D rigBody;

    public float playerSpeed;
    private Vector2 PlayerDirection;
    private float directionX;
    private float directionY;

    // Start is called before the first frame update
    void Start()
    {
        rigBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update() 
    {
        directionX = Input.GetAxisRaw("HorizontalKeyboardPlayer1");
        directionY = Input.GetAxisRaw("VerticalKeyboardPlayer1");
        if(Input.GetKeyDown(KeyCode.S))
        {
            directionX = 1;
        }

        PlayerDirection = new Vector2(directionX, directionY).normalized;
    }

    void FixedUpdate() 
    {
        rigBody.velocity = new Vector2(PlayerDirection.x * playerSpeed, PlayerDirection.y * playerSpeed);
    }
}