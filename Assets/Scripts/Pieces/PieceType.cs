using UnityEngine;
using UnityEngine.UI;

namespace Pieces
{
    [CreateAssetMenu(menuName = "Create Piece")]
    public class PieceType : ScriptableObject
    {
        [SerializeField]
        private string id;
        [SerializeField]
        private Mesh mesh;
        [SerializeField]
        private Sprite uiMovementImage;

        public MovementData movementData;
        
        public string ID => id;
        public Mesh PieceMesh => mesh;
        public Sprite UiMovementImage => uiMovementImage;
    }
}