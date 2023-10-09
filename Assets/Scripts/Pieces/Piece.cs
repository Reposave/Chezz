using Board;
using TMPro;
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
        [SerializeField]
        private TextMeshProUGUI shotsAvailableText;

        private Sprite tileUIMovement;

        public static PieceOptions pieceOptionsMenu;

        public int ShotsAvailable { get; set; } = 0;

        public Player PiecePlayer => player;
        public Sprite TileUIMovement => tileUIMovement;
        
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
            if (IsMouseOverUI())
            {
                return;
            }

            SelectionHandler.SelectPiece(this);
            pieceOptionsMenu.SetSelectedPiece(this);
            base.OnMouseDown();
        }

        public override void OnMouseUp()
        {
            if (IsMouseOverUI())
            {
                return;
            }

            if (isColliding)
            {
                snappedPosition.y = 1.0f;
            }
        
            SelectionHandler.DeselectPiece();
            base.OnMouseUp();
        }

        public override void OnMouseDrag()
        {
            if (IsMouseOverUI())
            {
                return;
            }

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

        public void useShot()
        {
            if (ShotsAvailable > 0)
            {
                --ShotsAvailable;
            }
        }

        public void AddShot()
        {
            ++ShotsAvailable;
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

            tileUIMovement = pieceType.UiMovementImage;
        }
    }
}
