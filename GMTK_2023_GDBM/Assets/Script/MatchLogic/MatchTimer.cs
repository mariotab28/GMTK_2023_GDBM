using UnityEngine;

public class MatchTimer : MonoBehaviour
{
    public TimerPrintingController timerPrintingController;
    private float totalCountdownTime;
    private bool countingDown;
    private float currentTime;

    void Update()
    {
        if (countingDown)
        {
            DecreaseTime();
            timerPrintingController.Print(currentTime);
        }
    }

    public void SetUp(float countdownTime)
    {
        totalCountdownTime = countdownTime;
    }

    public void Start()
    {
        currentTime = totalCountdownTime;
        timerPrintingController.Print(currentTime);
        countingDown = true;
    }

    void DecreaseTime()
    {
        currentTime -= Time.deltaTime;
    }

}