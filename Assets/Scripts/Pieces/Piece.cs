using UnityEngine;

namespace Pieces
{
    [ExecuteInEditMode]
    public class Piece : IDraggableObject
    {
        public enum Player
        {
            One,
            Two
        }

        [SerializeField]
        private Player player;
        [SerializeField]
        private PieceType pieceType;

        public Player PiecePlayer => player;
        
        // Start is called before the first frame update
        private void Start()
        {
            UpdatePieceType();
            transform.position = SnapPosition(transform.position);
        }
        
        public Vector3 Position
        {
            get => transform.position;
            set => transform.position = value;
        }

        public override void OnMouseDown()
        {
            SelectionHandler.SelectPiece(this);
            base.OnMouseDown();
        }

        public override void OnMouseUp()
        {
            if (isColliding)
            {
                snappedPosition.y = 1.0f;
            }
        
            SelectionHandler.DeselectPiece();
            base.OnMouseUp();
        }

        public override void OnMouseDrag()
        {
            base.OnMouseDrag();
            Vector3 selectionPosition = SelectionHandler.Position;
            SelectionHandler.Position = new Vector3(snappedPosition.x, selectionPosition.y, snappedPosition.z);
        
            if (isColliding)
            {
                SelectionHandler.HighlightColor = SelectionHandler.CollisionColor;
            }
            else
            {
                SelectionHandler.HighlightColor = SelectionHandler.NormalColor;
            }
        }

        private void UpdatePieceType()
        {
            if (pieceType == null)
            {
                return;
            }
        
            MeshFilter pieceMeshFilter = GetComponent<MeshFilter>();
            pieceMeshFilter.mesh = pieceType.PieceMesh;

            gameObject.name = pieceType.ID;
        }
    }
}
