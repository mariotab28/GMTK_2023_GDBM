using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : PlayerController
{
    

    // Update is called once per frame
    void Update() 
    {
        // Check direction
        directionX = Input.GetAxisRaw("HorizontalKeyboardPlayer1");
        directionY = Input.GetAxisRaw("VerticalKeyboardPlayer1");

        if (directionX == 0 && directionY == 0)
        {
            print(directionX + ", " + directionY);
            directionX = Input.GetAxisRaw("HorizontalGamepadPlayer1");
            directionY = -Input.GetAxisRaw("VerticalGamepadPlayer1");
        }

        PlayerDirection = new Vector2(directionX, directionY).normalized;
        movement.SetDirection(PlayerDirection);

        // Check sprint
        if (Input.GetKeyDown(KeyCode.LeftShift) || Input.GetAxisRaw("SprintGamepadPlayer1") > 0)
            movement.SetSpeed(sprintSpeed);

        if (Input.GetKeyUp(KeyCode.LeftShift) || Input.GetAxisRaw("SprintGamepadPlayer1") <= 0)
            movement.SetSpeed(defaultSpeed);

        // Check dash
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            print("DASH");//movement.SetSpeed(sprintSpeed);
    }

    
}
