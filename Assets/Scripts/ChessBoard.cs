using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{
    [SerializeField]
    private int height = 8;
    [SerializeField]
    private int width = 8;
    [SerializeField] 
    private GameObject tile;
    [SerializeField] 
    private GameObject tileUI;
    [SerializeField] 
    private GameObject chessboardUI;

    //Remove Temp Code...
    [SerializeField] private MovementData _movementData;

    private List<Tile> tiles;
    private List<TileInfo> _tileInfos;
    
    private Color tileColorPrimary = Color.white;
    private Color tileColorAlternate = Color.black;
    private Color tileColorSides = new Color(0.5f, 0.4f, 0.2f, 1);

    private bool selectAlternateColor = false;
    public int numberOfTiles { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        SetupTiles();
        _movementData.TilesInfos = _tileInfos;
        _movementData.OutputJson();
    }

    private void SetupTiles(bool withBorder = true)
    {
        //Add 2 to create Borders around the board.
        tiles = new List<Tile>((width+2) * (height+2));
        _tileInfos = new List<TileInfo>((width+2) * (height+2));
        
        for (int i = -1; i < height + 1; ++i)
        {
            for (int j = -1; j < width + 1; ++j)
            {
                GameObject newTileObject = Instantiate(tile, transform);
                //Assuming origin of chessboard is zero.
                Vector3 position = new Vector3(j, 0, i);
                newTileObject.transform.position = position;
                
                Tile newTile = newTileObject.GetComponent<Tile>();
                
                tiles.Add(newTile);
                _tileInfos.Add(newTile.tileInfo);
                
                newTile.Id = numberOfTiles;
                newTile.tileInfo.Id = numberOfTiles;
                
                ++numberOfTiles;
                
                Color newColor = selectAlternateColor ? tileColorAlternate : tileColorPrimary;
                newColor = IdentifyBorders(j, i) ? tileColorSides : newColor;
                
                selectAlternateColor = !selectAlternateColor;
                newTile.ChangeColor(newColor);
            }
            selectAlternateColor = !selectAlternateColor;
        }
    }

    private bool IdentifyBorders(int widthPosition, int heightPosition)
    {
        if (widthPosition < 0 || widthPosition > width - 1)
        {
            return true;
        }

        if (heightPosition < 0 || heightPosition > height - 1)
        {
            return true;
        }

        return false;
    }
}
