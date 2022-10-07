using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    private enum Player{
      One,
      Two
    }

    [SerializeField]
    private Timer playerOneTimer;
    [SerializeField]
    private Timer playerTwoTimer;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Button startTimer;
    [SerializeField]
    private Button endTurn;
    [SerializeField] 
    private Button pauseTimer;

    [SerializeField]
    private int secondsPerPlayer = 60;

    private Timer activeTimer;

    // Start is called before the first frame update
    private void Start()
    {
        SetActivePlayer(Player.One, playerOneTimer);

        startTimer.onClick.AddListener(StartTimer);
        endTurn.onClick.AddListener(EndTurn);
        pauseTimer.onClick.AddListener(TogglePause);
    }

    private void TogglePause()
    {
        activeTimer.PauseTime = true;
    }

    private void StartTimer()
    {
        playerOneTimer.PlayerTimer = secondsPerPlayer;
        playerTwoTimer.PlayerTimer = secondsPerPlayer;

        activeTimer.PauseTime = false;
    }

    private void EndTurn()
    {
        if (player == Player.One)
        {
            SetActivePlayer(Player.Two, playerTwoTimer);
            return;
        }

        SetActivePlayer(Player.One, playerOneTimer);
    }

    private void SetActivePlayer(Player playerToSet, Timer playerTimer)
    {
        if(activeTimer != null)
        {
            activeTimer.PauseTime = true;
        }
        
        playerTimer.PlayerTimer = secondsPerPlayer;

        player = playerToSet;
        activeTimer = playerTimer;
    }
}
