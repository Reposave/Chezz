using UnityEngine;

namespace Pieces
{
    [CreateAssetMenu(menuName = "Create Piece")]
    public class PieceType : ScriptableObject
    {
        [SerializeField]
        private string id;
        [SerializeField]
        private Mesh mesh;
    
        public MovementData movementData;

        public string ID => id;
        public Mesh PieceMesh => mesh;
    }
}