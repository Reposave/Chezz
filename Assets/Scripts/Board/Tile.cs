using System;
using UnityEngine;

namespace Board
{
    public class Tile : MonoBehaviour
    {
        [SerializeField] 
        private GameObject spriteObject;
        private SpriteRenderer sprite;

        public TileInfo Info;

        public int Id
        {
            get => Info.Id;
            set => Info.Id = value;
        }

        public void ChangeColor(Color color)
        {
            sprite.color = color;
        }
        
        private void Awake()
        {
            Info = new TileInfo();
            sprite = spriteObject.GetComponent<SpriteRenderer>();
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

        public int Id { get; set; }

        public TileState State = TileState.Normal;
    }
}