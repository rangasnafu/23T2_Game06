using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{
    Vector3 mousePositionOffset;
    bool isDraggable = false;

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    private void OnMouseDown()
    {
        // Add your condition here to determine if the object should be draggable
        if (ShouldBeDraggable())
        {
            isDraggable = true;
            mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
        }
    }

    private void OnMouseDrag()
    {
        if (isDraggable)
        {
            transform.position = GetMouseWorldPosition() + mousePositionOffset;
        }
    }

    private bool ShouldBeDraggable()
    {
        return gameObject.GetComponent<SpriteRenderer>().sprite.name == "objects_1";
        //return true; // Change this to your specific condition
    }
}
