using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace Board
{
    /// <summary>
    /// Creates a board and manages its data.
    /// </summary>
    public class GameBoard : MonoBehaviour
    {
        private GameObject tile;
        
        private int width;
        private int height;
        private int numberOfTiles;

        private Color tileColorPrimary = Color.white;
        private Color tileColorAlternate = Color.black;
        private Color borderColor = new Color(0.5f, 0.4f, 0.2f, 1);

        private List<TileInfo> tileInfos;
    
        private Transform parent;

        public ReadOnlyCollection<TileInfo> TileInfos => tileInfos.AsReadOnly();

        public int NumberOfTiles { get; }
        public int Width { get; }
        public int Height { get; }

        public void SetupTiles(Transform boardParent, int boardWidth, int boardHeight, bool withBorder)
        {
            
            tile = Resources.Load<GameObject>("Prefabs/Tile");

            if (tile == null)
            {
                Debug.LogError("Tile prefab not found.");
                return;
            }

            width = boardWidth;
            height = boardHeight;
            parent = boardParent;
            
            bool selectAlternateColor = false;
            int borderSize = 2;

            tileInfos = new List<TileInfo>((boardWidth + borderSize) * (boardHeight + borderSize));
            
            for (int i = -1; i < boardHeight + 1; ++i)
            {
                for (int j = -1; j < boardWidth + 1; ++j)
                {
                    GameObject newTileObject = Instantiate(tile, boardParent);
                
                    Vector3 position = new Vector3(j, 0, i);
                    newTileObject.transform.localPosition = position;
            
                    Tile newTile = newTileObject.GetComponent<Tile>();
                
                    tileInfos.Add(newTile.Info);
                    newTile.Id = numberOfTiles;
                    ++numberOfTiles;
            
                    Color newColor = selectAlternateColor ? tileColorAlternate : tileColorPrimary;
                    
                    if (withBorder)
                    {
                        newColor = IdentifyBorders(j, i) ? borderColor : newColor;
                    }

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
}
