using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HidePieces : MonoBehaviour
{
    [SerializeField] 
    private Button P1ToggleButton;
    [SerializeField] 
    private Button P2ToggleButton;
    [SerializeField] 
    private Piece[] hiddenPieces;

    private Piece.Player player = Piece.Player.One;
    
    private void Start()
    {
        P1ToggleButton.onClick.AddListener(TogglePlayerOneVisibility);
        P2ToggleButton.onClick.AddListener(TogglePlayerTwoVisibility);
    }

    public void TogglePlayerOneVisibility()
    {
        player = Piece.Player.One;
        TogglePieceVisibility();
    }

    public void TogglePlayerTwoVisibility()
    {
        player = Piece.Player.Two;
        TogglePieceVisibility();
    }

    private void TogglePieceVisibility()
    {
        GameObject pieceObject;
        
        foreach (var piece in hiddenPieces)
        {
            if (piece.piecePlayer != player)
            {
                continue;
            }

            pieceObject = piece.gameObject;
            pieceObject.SetActive(!pieceObject.activeSelf);
        }
    }
}
