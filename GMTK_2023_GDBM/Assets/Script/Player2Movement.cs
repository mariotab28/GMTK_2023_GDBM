using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : PlayerController
{


    // Update is called once per frame
    void Update() 
    {
        directionX = Input.GetAxisRaw("HorizontalKeyboardPlayer2");
        directionY = Input.GetAxisRaw("VerticalKeyboardPlayer2");

        if (directionX == 0 && directionY == 0)
        {
            directionX = Input.GetAxisRaw("HorizontalGamepadPlayer2");
            directionY = -Input.GetAxisRaw("VerticalGamepadPlayer2");
        }

        PlayerDirection = new Vector2(directionX, directionY).normalized;

        movement.SetDirection(PlayerDirection);

        // Check sprint
        if (Input.GetKeyDown(KeyCode.RightShift))
            movement.SetSpeed(sprintSpeed);

        if (Input.GetKeyUp(KeyCode.RightShift))
            movement.SetSpeed(defaultSpeed);

        // Check dash
        if (Input.GetKeyDown(KeyCode.Space))
            print("DASH");//movement.SetSpeed(sprintSpeed);
    }

}
