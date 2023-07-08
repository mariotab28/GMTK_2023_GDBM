using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndOfMatchUIController : MonoBehaviour
{
    public TextMeshProUGUI winningPlayerText;
    public string drawText = "It's a Draw!";
    public string player1WinText = "Player 1 wins!";
    public string player2WinText = "Player 2 wins!";
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartEndOfMatchAnimation(PlayerInfo winningPlayer)
    {
        if (winningPlayer == null)
        {
            winningPlayerText.text = drawText;
        }
        else if (winningPlayer.Is(PlayerNumber.PlayerOne))
        {
            winningPlayerText.text = player1WinText;
        }
        else if (winningPlayer.Is(PlayerNumber.PlayerTwo))
        {
            winningPlayerText.text = player2WinText;
        }
        
        animator.SetTrigger("EndOfMatch");
    }
}
