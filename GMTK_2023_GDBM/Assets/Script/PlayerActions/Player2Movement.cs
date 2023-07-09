using System.Security.Cryptography;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Movement : PlayerController
{
    [Header("AI Settings")]
    public bool aIMode = false;
    public float ballFollowSpeed = 5f;
    public float chanceToFollowHorizontallyPerSecond = 0.02f;
    public float chanceToGoBackToGoalPerSecond = 0.02f;
    public float maxHorizontalFollowTime = 5f;
    public float minHorizontalFollowTime = 2f;
    public GameObject AIGoal;
    private bool usingGamepad = false;
    private GameObject followedBall;
    private bool isFollowingHorizontally = false;
    private bool isFollowingGoal = false;

    // Update is called once per frame
    void Update()
    {
        if (aIMode)
        {
            AIControls();
        }
        else
        {
            HumanControls();
        }
    }

    private void HumanControls()
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
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetButtonDown("Fire2"))
            kick.Activate();
    }

    private void AIControls()
    {
        followedBall = FindClosestBall();
        bool willFollowHorizontallyThisUpdate = isFollowingHorizontally;

        if (!isFollowingHorizontally)
        {
            willFollowHorizontallyThisUpdate = RollChanceToStartFollowingHorizontally();
            if (willFollowHorizontallyThisUpdate)
            {
                isFollowingHorizontally = true;
                StartCoroutine(TimerUntilStopFollow());
            }
            else
            {
                bool shouldStartFollowGoal = RollChanceToStartFollowingGoal();
                if (shouldStartFollowGoal)
                {
                    isFollowingGoal = true;
                    StartCoroutine(TimerUntilStopFollow());
                }
            }
        }
        FollowTransform(followedBall.transform, willFollowHorizontallyThisUpdate, isFollowingGoal);
    }

    private IEnumerator TimerUntilStopFollow()
    {
        float horizontalFollowSeconds = Random.Range(
            minHorizontalFollowTime,
            maxHorizontalFollowTime
        );
        yield return new WaitForSeconds(horizontalFollowSeconds);
        isFollowingHorizontally = false;
        isFollowingGoal = false;
    }

    private bool RollChanceToStartFollowingHorizontally()
    {
        float roll = Random.Range(0f, 1f);
        return roll < chanceToFollowHorizontallyPerSecond * Time.deltaTime;
    }

    private bool RollChanceToStartFollowingGoal()
    {
        float roll = Random.Range(0f, 1f);
        return roll < chanceToGoBackToGoalPerSecond * Time.deltaTime;
    }

    private void FollowTransform(
        Transform followedTransform,
        bool shouldFollowHorizontally,
        bool shouldPrioritizeGoal
    )
    {
        movement.SetSpeed(ballFollowSpeed);
        Vector2 direction;
        if (shouldPrioritizeGoal)
        {
            direction = AIGoal.transform.position - transform.position;
        }
        else
        {
            float verticalDistanceToBall = -(transform.position.y - followedTransform.position.y);
            float horizontalDirection = shouldFollowHorizontally
                ? -(transform.position.x - followedTransform.position.x)
                : 0;
            direction = new Vector2(horizontalDirection, verticalDistanceToBall).normalized;
        }

        movement.SetDirection(direction);
    }

    public GameObject FindClosestBall()
    {
        GameObject[] ballsInScene = GameObject.FindGameObjectsWithTag("Ball");
        return GetGameObjectNearestToTransform(ballsInScene);
    }

    private GameObject GetGameObjectNearestToTransform(GameObject[] goList)
    {
        GameObject[] NearGameobjects = goList;
        GameObject closestObject = null;
        float oldDistance = 9999;
        foreach (GameObject g in NearGameobjects)
        {
            float dist = Vector3.Distance(transform.position, g.transform.position);
            if (dist < oldDistance)
            {
                closestObject = g;
                oldDistance = dist;
            }
        }
        return closestObject;
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
