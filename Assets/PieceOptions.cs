using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Pieces;

public class PieceOptions : MonoBehaviour
{
    public Button MoveButton;

    [SerializeField]
    private Button ShootButton;
    [SerializeField]
    private Camera camera;

    private Piece selectedPiece;
    private RectTransform menuRect;

    private void Start()
    {
        menuRect = GetComponent<RectTransform>();
        ShootButton.onClick.AddListener(Shoot);
        HideMenu();
    }

    public void MovePiece()
    {
        selectedPiece.AddShot();
    }

    public void SetSelectedPiece(Piece piece)
    {
        selectedPiece = piece;
        menuRect.position = camera.WorldToScreenPoint(piece.transform.position);
        ShowMenu();
    }

    private void Shoot()
    {
        selectedPiece.useShot();
    }

    private void HideMenu() 
    {
        gameObject.SetActive(false);
    }

    private void ShowMenu() 
    {
        gameObject.SetActive(true);
    }

}
