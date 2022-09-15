using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TileUI : MonoBehaviour
{
    private Image image;
    private Color tileColor;
    
    public int Id { get; set; }
    
    private void Awake()
    {
        image = GetComponent<Image>();
    }
    
    public void ChangeColor(Color color)
    {
        tileColor = color;
        image.color = color;
    }
}
