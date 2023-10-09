using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using TMPro;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using Pieces;

public class GameManager : MonoBehaviour
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
    private TextMeshProUGUI movesText;
    [SerializeField]
    private TextMeshProUGUI turnsText;

    [SerializeField]
    private int secondsPerPlayer = 60;
    [SerializeField]
    private PieceOptions pieceOptionsMenu;

    private Timer activeTimer;

    private int playerOneMoves;
    private int playerTwoMoves;
    private int turnNumber;

    // Start is called before the first frame update
    private void Start()
    {
        playerOneMoves = 0;
        playerTwoMoves = 0;

        startTimer.onClick.AddListener(StartTimer);
        endTurn.onClick.AddListener(EndTurn);
        pauseTimer.onClick.AddListener(TogglePause);

        pieceOptionsMenu.MoveButton.onClick.AddListener(UseMove);
        Piece.pieceOptionsMenu = pieceOptionsMenu;

        SetActivePlayer(Player.One, playerOneTimer);
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
            playerOneMoves = 0;
            playerTwoMoves = 1;
            SetActivePlayer(Player.Two, playerTwoTimer, pauseTimer: false);
            
            return;
        }

        playerTwoMoves = 0;
        playerOneMoves = 1;
        SetActivePlayer(Player.One, playerOneTimer, pauseTimer: false);
        
        StartNextTurn();
    }

    private void StartNextTurn()
    {
        ++turnNumber;
        turnsText.text = turnNumber.ToString();
    }

    private void SetActivePlayer(Player playerToSet, Timer playerTimer, bool pauseTimer = true)
    {
        if(activeTimer != null)
        {
            activeTimer.PauseTime = true;
        }
        
        playerTimer.PlayerTimer = secondsPerPlayer;

        player = playerToSet;
        activeTimer = playerTimer;
        activeTimer.PauseTime = pauseTimer;

        UpdateMoveText();
    }

    private void UseMove()
    {
        if (player == Player.One)
        {
            if (playerOneMoves > 0)
            {
                --playerOneMoves;
            }
        }
        else
        {
            if (playerTwoMoves > 0)
            {
                --playerTwoMoves;
            }
        }

        UpdateMoveText();
        pieceOptionsMenu.MovePiece();
    }

    private void UpdateMoveText()
    {
        if (player == Player.One)
        {
            movesText.text = playerOneMoves.ToString();
        }
        else
        {
            movesText.text = playerTwoMoves.ToString();
        }
    }
}
