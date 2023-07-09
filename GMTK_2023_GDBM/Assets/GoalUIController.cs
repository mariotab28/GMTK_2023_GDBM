using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class GoalUIController : MonoBehaviour
{
    public TextMeshProUGUI animationGoalCounter;
    public TextMeshProUGUI animationPlayerWhoScored;
    public TextMeshProUGUI handicapText;
    public UnityEvent animationFinished;
    private Animator goalUIAnimator;
    private int currentGoalCount = 4;

    void Start()
    {
        goalUIAnimator = GetComponent<Animator>();
    }

    public void PlayGoalAnimation(PlayerInfo playerInfo)
    {
        currentGoalCount = playerInfo.Score;
        animationPlayerWhoScored.text =
            playerInfo.PlayerNumber == PlayerNumber.PlayerOne ? "Player 1" : "Player 2";
        animationGoalCounter.text = (currentGoalCount - 1).ToString();
        goalUIAnimator.SetTrigger("Goal");
    }

    public void UpdateAddedHandicap(int addedHandicapIndex)
    {
        string usedText = "";
        switch (addedHandicapIndex)
        {
            case 0:
                usedText = "Goal Shrink";
                break;
            case 1:
                usedText = "Goal Enlarge";
                break;
            case 2:
                usedText = "Speed Booster";
                break;
            case 3:
                usedText = "Cannon";
                break;
            default:
                Debug.LogError(
                    "Unidentified handincap with handicap index " + addedHandicapIndex.ToString()
                );
                break;
        }
        handicapText.text = usedText;
    }

    void UpdateGoalAnimationCounter()
    {
        animationGoalCounter.text = currentGoalCount.ToString();
    }

    void EmitAnimationFinishedEvent()
    {
        animationFinished.Invoke();
    }
}
