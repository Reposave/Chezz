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

    private float playerOneTimer;
    private float playerTwoTimer;

    [SerializeField]
    private Player player;

    [SerializeField]
    private Button startTimer;
    [SerializeField]
    private Button endTurn;
    [SerializeField] 
    private Button pauseTimer;

    [SerializeField] 
    private TextMeshProUGUI playerOneTimerText;
    [SerializeField] 
    private TextMeshProUGUI playerTwoTimerText;

    [SerializeField]
    private int secondsPerPlayer = 60;

    private bool pauseTime = true;

    // Start is called before the first frame update
    private void Start()
    {
        startTimer.onClick.AddListener(StartTimer);
        endTurn.onClick.AddListener(EndTurn);
        pauseTimer.onClick.AddListener(TogglePause);
    }

    // Update is called once per frame
    private void Update()
    {
        if (pauseTime)
        {
            return;
        }

        if (player == Player.One)
        {
            DecrementTimer(ref playerOneTimer, ref playerOneTimerText);
            return;
        }
        
        DecrementTimer(ref playerTwoTimer, ref playerTwoTimerText);
    }

    private void DecrementTimer(ref float timer, ref TextMeshProUGUI text)
    {
        timer -= Time.deltaTime;
        text.text = ((int)timer).ToString();
    }

    private void TogglePause()
    {
        pauseTime = !pauseTime;
    }

    private void StartTimer()
    {
        playerOneTimer = secondsPerPlayer;
        playerTwoTimer = secondsPerPlayer;

        playerOneTimerText.text = playerOneTimer.ToString();
        playerTwoTimerText.text = playerTwoTimer.ToString();

        pauseTime = false;
    }

    private void EndTurn()
    {
        if (player == Player.One)
        {
            playerTwoTimer = secondsPerPlayer;
            player = Player.Two;
            return;
        }

        playerOneTimer = secondsPerPlayer;
        player = Player.One;
    }
}
