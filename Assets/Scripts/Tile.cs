using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] 
    private GameObject spriteObject;
    private SpriteRenderer sprite;
    public int Id { get; set; }
    
    private void Awake()
    {
        sprite = spriteObject.GetComponent<SpriteRenderer>();
    }

    public void ChangeColor(Color color)
    {
        sprite.color = color;
    }
}
