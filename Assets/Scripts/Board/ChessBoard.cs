using System.Collections.Generic;
using UnityEngine;

namespace Board
{
    public class ChessBoard : MonoBehaviour
    {
        [SerializeField]
        private int height = 8;
        [SerializeField]
        private int width = 8;
        [SerializeField] 
        private bool addBorder = false;

        private GameBoard gameBoard;
        
        //Remove Temp Code...
        [SerializeField] private MovementData _movementData;

        // Start is called before the first frame update
        private void Start()
        {
            gameBoard = gameObject.AddComponent<GameBoard>();
            gameBoard.SetupTiles(transform, width, height, addBorder);
        }
    }
}
