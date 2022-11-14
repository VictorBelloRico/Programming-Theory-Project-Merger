using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    Vector3 mousePositionOffset;
    protected Vector2 initialPosition;

    public static bool mouseButtonReleased;
    public static bool isCollided;

    private void Awake()
    {
        initialPosition = transform.position;
    }

    private Vector3 GetMouseWorldPosition()
    {
        return Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
    private void OnMouseDown()
    {
        mouseButtonReleased = false;
        isCollided = false;
        mousePositionOffset = gameObject.transform.position - GetMouseWorldPosition();
    }

    private void OnMouseDrag()
    {
        transform.position = GetMouseWorldPosition() + mousePositionOffset;
    }

    private void OnMouseUp()
    {
        mouseButtonReleased = true;
        if (!isCollided)
        {
            transform.position = initialPosition;
        }

    }

    private void OnTriggerStay2D(Collider2D collision)
    {

        isCollided = true;

        string thisGameObjectName = gameObject.name.Substring(0, name.IndexOf("_"));
        string collisionGameobjectName = collision.gameObject.name.Substring(0, name.IndexOf("_"));
        Debug.Log("Item1" + thisGameObjectName + "AND Item2" + collisionGameobjectName);

        if (mouseButtonReleased && thisGameObjectName == collisionGameobjectName)
        {
            GridManager.Instance.LiberateGridTile(initialPosition);
            Vector3 position = collision.transform.position;
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Merge(position);
        }
        else if (mouseButtonReleased && thisGameObjectName != collisionGameobjectName)
        {
            transform.position = initialPosition;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollided = false;
    }

    public virtual void Merge(Vector3 position)
    {
    }

}
