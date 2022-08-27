using UnityEngine;

[CreateAssetMenu(menuName = "Create Piece")]
public class PieceType : ScriptableObject
{
    [SerializeField]
    private string id;
    [SerializeField]
    private Mesh mesh;

    public string ID => id;
    public Mesh PieceMesh => mesh;
}