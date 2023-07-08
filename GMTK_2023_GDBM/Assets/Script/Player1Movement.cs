using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player1Movement : PlayerController
{
    private bool usingGamepad = false;

    // Update is called once per frame
    void Update()
    {
        // Check direction
        directionX = Input.GetAxisRaw("HorizontalKeyboardPlayer1");
        directionY = Input.GetAxisRaw("VerticalKeyboardPlayer1");

        if (directionX == 0 && directionY == 0)
        {
            directionX = Input.GetAxisRaw("HorizontalGamepadPlayer1");
            directionY = -Input.GetAxisRaw("VerticalGamepadPlayer1");
        }

        PlayerDirection = new Vector2(directionX, directionY).normalized;
        movement.SetDirection(PlayerDirection);

        // Check sprint
        CheckSprintInput();

        // Check dash
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
            print("DASH");//movement.SetSpeed(sprintSpeed);
    }


    private void CheckSprintInput()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement.SetSpeed(sprintSpeed);
            usingGamepad = false;
        }

        if (Input.GetAxisRaw("SprintGamepadPlayer1") > 0)
        {
            movement.SetSpeed(sprintSpeed);
            usingGamepad = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift) && !usingGamepad)
            movement.SetSpeed(defaultSpeed);

        if (Input.GetAxisRaw("SprintGamepadPlayer1") <= 0 && usingGamepad)
            movement.SetSpeed(defaultSpeed);

    }

}
