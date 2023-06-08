using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragBehaviour : MonoBehaviour
{
    private float x_offset;
    private float y_offset;
    private float x;
    private float y;
    private bool onDrag;
    private bool onDragUp;


    // Start is called before the first frame update
    void Start()
    {
        onDrag = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown() {
        onDrag = true;
        x_offset = Input.mousePosition.x;
        y_offset = Input.mousePosition.y;
    }

    private void OnMouseDrag() {
        x = Input.mousePosition.x - x_offset;
        y= Input.mousePosition.y - y_offset;
    }

    private void OnMouseUp() {
        onDrag = false;
        onDragUp = true;
    }

    public bool isDragging() {
        return onDrag;
    }

    public float getX() {
        return x;
    }

    public bool isDragUp() {
        if (onDragUp) {
            onDragUp = false;
            return true;
        } else {
            return false;
        }
    }

    public float getY() {
        return y;
    }
}
