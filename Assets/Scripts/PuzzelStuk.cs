using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PuzzelStuk : MonoBehaviour
{
    private Camera _cam;
    private Vector3 _dragOffset, _originalPos;
    [SerializeField] private float _speed = 100;
    


    void Awake()
    {
        _cam = Camera.main;
        _originalPos = transform.position;

    }

    void OnMouseDown()
    {
        _dragOffset = transform.position - GetMousePos();
    }

    void OnMouseUp()
    {
        transform.position = _originalPos;
        

    }

    void OnMouseDrag()
    {
        transform.position = Vector3.MoveTowards(transform.position, GetMousePos() + _dragOffset, _speed * Time.deltaTime);
        

    }



    Vector3 GetMousePos()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }
}
