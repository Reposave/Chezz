using UnityEngine;
using UnityEngine.EventSystems;

namespace Pieces
{
    public abstract class IDraggableObject : MonoBehaviour
    {
        private Vector3 mouseOffset;
        protected Vector3 snappedPosition;
        private float mouseZPosition;
        protected bool isColliding = false;
        bool mouseDragging = false;

        public virtual void OnMouseDown()
        {
            MousePositionCorrection();
        }
    
        public virtual void OnMouseUp()
        {
            mouseDragging = false;
            isColliding = false;
            transform.position = snappedPosition;
        }
        
        protected virtual Vector3 SnapPosition(Vector3 position)
        {
            Vector3 resultPosition = new Vector3((int)Mathf.Round(position.x), 0.0f, (int)Mathf.Round(position.z));
            return resultPosition;
        }

        protected bool IsMouseOverUI()
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return true;
            }

            return false;
        }

        private void MousePositionCorrection()
        {
            mouseOffset = transform.position - GetMouseAsWorldPoint();
        }

        private Vector3 GetMouseAsWorldPoint()
        {
            mouseZPosition = Camera.main.WorldToScreenPoint(transform.position).z;
        
            // Pixel coordinates of mouse (x,y)
            Vector3 mousePoint = Input.mousePosition;
            // z coordinate of game object on screen
            mousePoint.z = mouseZPosition;
            // Convert it to world points
            return Camera.main.ScreenToWorldPoint(mousePoint);
        }

        public virtual void OnMouseDrag()
        {
            mouseDragging = true;
        
            Vector3 newPosition = GetMouseAsWorldPoint() + mouseOffset;
            newPosition.y = 0.0f;
        
            snappedPosition = SnapPosition(newPosition);
        
            transform.position = newPosition;
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (mouseDragging)
            {
                isColliding = true;
            }
        }

        private void OnTriggerExit(Collider collision)
        {
            isColliding = false;
        }
    }
}
