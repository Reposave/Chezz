using UnityEngine;
using UnityEngine.UI;

namespace Pieces
{
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

        private void TogglePlayerOneVisibility()
        {
            player = Piece.Player.One;
            TogglePieceVisibility();
        }

        private void TogglePlayerTwoVisibility()
        {
            player = Piece.Player.Two;
            TogglePieceVisibility();
        }

        private void TogglePieceVisibility()
        {
            GameObject pieceObject;
        
            foreach (var piece in hiddenPieces)
            {
                if (piece.PiecePlayer != player)
                {
                    continue;
                }

                pieceObject = piece.gameObject;
                pieceObject.SetActive(!pieceObject.activeSelf);
            }
        }
    }
}
