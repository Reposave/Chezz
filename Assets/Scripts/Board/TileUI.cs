using UnityEngine;
using UnityEngine.UI;

namespace Board
{
    /// <summary>
    /// Displays the movement of a piece. 
    /// </summary>
    public class TileUI : MonoBehaviour
    {
        private static Image image;
    
        private void Awake()
        {
            image = GetComponent<Image>();
        }

        public static void UpdateUI(Sprite sprite)
        {
            image.sprite = sprite;
        }
    }
}
