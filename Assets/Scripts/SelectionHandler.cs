using System;
using Pieces;
using UnityEditor;
using UnityEngine;

public class SelectionHandler : MonoBehaviour
{
    private static Piece selectedPiece;
    private static GameObject highlighter;
    private static SpriteRenderer highlighterSpriteRenderer;
    
    public static Color NormalColor;
    public static Color CollisionColor = Color.yellow;

    [SerializeField]
    private GameObject highlighterObject;

    private void Start()
    {
        highlighter = highlighterObject;
        highlighterSpriteRenderer = highlighter.GetComponent<SpriteRenderer>();
        NormalColor = highlighterSpriteRenderer.color;
    }

    public static Vector3 Position
    {
        get => highlighter.transform.position;
        set => highlighter.transform.position = value;
    }

    public static Color HighlightColor
    {
        set => highlighterSpriteRenderer.color = value;
    }
    
    public static void SelectPiece(Piece piece)
    {
        DeselectPiece();
        selectedPiece = piece;
        highlighter.SetActive(true);
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
        
        highlighter.SetActive(false);

        selectedPiece = null;
    }
}
