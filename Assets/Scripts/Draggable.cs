using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Draggable : MonoBehaviour
{

    public string Id;
    

    public delegate void DragEndedDelegate(Draggable draggableObject);

    public DragEndedDelegate dragEndedCallback;

    private bool isDragged = false;
    private Vector3 mouseDragStartPosition;
    private Vector3 spriteDragStartPosition;


    //als je de muis aanklikt pak je de sprite op
    private void OnMouseDown() {
        isDragged = true;
        mouseDragStartPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        spriteDragStartPosition = transform.localPosition;
    }
    //als je de muis beweegt beweegt de sprite mee
    private void OnMouseDrag() {
        if (isDragged) {
            transform.localPosition = spriteDragStartPosition + (Camera.main.ScreenToWorldPoint(Input.mousePosition) - mouseDragStartPosition);
        }
    }    
    //als je de sprite loslaat valt die weer terug op de originele plek
    private void OnMouseUp() {
        isDragged = false;
        dragEndedCallback(this);
    }
}
