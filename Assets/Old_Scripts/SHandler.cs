using System;
using Pieces;
using UnityEngine;


/// <summary>
/// Point and click movement of pieces.
/// </summary>
public class SHandler : MonoBehaviour
{
    private static Piece selectedPiece;
    private static Vector3 mouseOffset;

    [SerializeField]
    private GameObject highlighter;
    
    private static float mouseZPosition;
    
    bool isColliding = false;
    bool mouseDragging = false;
    
    public static void SelectPiece(Piece piece)
    {
        DeselectPiece();
        selectedPiece = piece;
        selectedPiece.Position = new Vector3(selectedPiece.Position.x, 0.5f, selectedPiece.Position.z);
        mouseOffset = selectedPiece.Position - GetMouseAsWorldPoint();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            MovePiece();
        }
    }

    void MovePiece()
    {
        if (selectedPiece == null)
        {
            return;
        }

        Vector3 mouseWorldPosition = GetMouseAsWorldPoint();

        Vector3 newPosition = mouseWorldPosition + mouseOffset;

        newPosition.x = (int)Mathf.Round(newPosition.x);
        newPosition.y = 0;
        newPosition.z = (int)Mathf.Round(newPosition.z);

        selectedPiece.Position = newPosition;

        //selectedPiece = null;
    }
    
    private static Vector3 GetMouseAsWorldPoint()
    {
        mouseZPosition = Camera.main.WorldToScreenPoint(selectedPiece.Position).z;
        
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;
        
        // z coordinate of game object on screen
        mousePoint.z = mouseZPosition;
        // Convert it to world points
        return Camera.main.ScreenToWorldPoint(mousePoint);
    }

    /// <summary>
    /// Deselects the currently selected Piece.
    /// </summary>
    public static void DeselectPiece()
    {
        if (selectedPiece == null)
        {
            return;
        }

        Vector3 newPosition = selectedPiece.Position;
        newPosition.y = 0f;
        selectedPiece.Position = newPosition;
        
        selectedPiece = null;
    }

    private void OnMouseDown()
    {
        
    }
}
