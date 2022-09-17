using System;
using UnityEngine;

namespace Board
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] 
        private GameObject spriteObject;
        private SpriteRenderer sprite;
        private Color tileColor;

        public TileInfo tileInfo;
    
        public int Id { get; set; }
    
        private void Awake()
        {
            tileInfo = new TileInfo();
            sprite = spriteObject.GetComponent<SpriteRenderer>();
        }

        public void ChangeColor(Color color)
        {
            tileColor = color;
            sprite.color = color;
        }
    }


    /// <summary>
    /// For JSON serialization/Deserialization.
    /// </summary>
    public class TileInfo
    {
        public enum TileState
        {
            Normal,
            Occupied,
            MovementOnly,
            AttackOnly,
            MovementAndAttack
        }

        public int Id;
    
        public TileState State = TileState.Normal;
    }
}