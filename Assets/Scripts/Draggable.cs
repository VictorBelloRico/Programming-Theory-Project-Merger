using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    protected Vector3 mousePositionOffset;
    protected Vector2 initialPosition;

    private static bool mouseButtonReleased;
    private bool isCollided;
    private bool isSelected;



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
        isSelected = true;
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
            isSelected = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        isCollided = true;

        if (isSelected && mouseButtonReleased && gameObject.tag == collision.tag)
        {
            Vector3 instatiatePosition = collision.transform.position;
            mouseButtonReleased = false;
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Merge(instatiatePosition, initialPosition);
        }
        else if (mouseButtonReleased && gameObject.tag != collision.tag)
        {
            transform.position = initialPosition;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isCollided = false;
    }

    public virtual void Merge(Vector3 instantiatePosition, Vector3 liberatePosition)
    {
    }
    private void Update()
    {
        if (!GameManager.Instance.isGameActive)
        {
            Destroy(gameObject);
        }
    }
}
