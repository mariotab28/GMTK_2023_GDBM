using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : PlayerController
{
    private bool usingGamepad = false;

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
        CheckSprintInput();

        // Check dash
        if (Input.GetKeyDown(KeyCode.KeypadEnter) || Input.GetButtonDown("Fire2"))
            kick.Activate();
    }

    private void CheckSprintInput()
    {
        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            movement.SetSpeed(sprintSpeed);
            usingGamepad = false;
        }

        if (Input.GetAxisRaw("SprintGamepadPlayer2") > 0)
        {
            movement.SetSpeed(sprintSpeed);
            usingGamepad = true;
        }

        if (Input.GetKeyUp(KeyCode.RightShift) && !usingGamepad)
            movement.SetSpeed(defaultSpeed);

        if (Input.GetAxisRaw("SprintGamepadPlayer2") <= 0 && usingGamepad)
            movement.SetSpeed(defaultSpeed);

    }

}
