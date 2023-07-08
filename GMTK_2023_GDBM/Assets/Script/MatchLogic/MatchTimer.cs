using UnityEngine;

public class MatchTimer : MonoBehaviour
{
    public TimerPrintingController timerPrintingController;
    private WinConditionLogic winConditionLogic;
    private float totalCountdownTime;
    private bool countingDown;
    private float currentTime;

    public void Start()
    {
        currentTime = totalCountdownTime;
        timerPrintingController.Print(currentTime);
        countingDown = true;
        winConditionLogic = GetComponent<WinConditionLogic>();
    }

    void Update()
    {
        if (countingDown)
        {
            DecreaseTime();
            timerPrintingController.Print(currentTime);
            if (currentTime <= 0)
            {
                winConditionLogic.FinishMatchAndDeclareWinner();
            }
        }
    }

    public void SetUp(float countdownTime)
    {
        totalCountdownTime = countdownTime;
    }

    void DecreaseTime()
    {
        currentTime -= Time.deltaTime;
    }
}
