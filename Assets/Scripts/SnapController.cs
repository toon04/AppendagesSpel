using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SnapController : MonoBehaviour
{
    private Vector2 _originalPostition;
    public Vector2 startPosition;
    public List<Transform> snapPoints;
    public List<Draggable> draggableObjects;
    public float snapRange = 0.5f;
    public int teller = 0;
    public int aantal;
    //aantal moet in de code verranderd worden
    // Start is called before the first frame update
    void Awake() {
        _originalPostition = transform.position;
    }

    void Start()
    {
        startPosition = transform.position;
        foreach (Draggable draggable in draggableObjects) {
            draggable.dragEndedCallback = OnDragEnded;
        }
        

    }

    

    private void OnDragEnded(Draggable draggable) {
        float closestDistance = -1;
        Transform closestSnapPoint = null;

        


        foreach (Transform snapPoint in snapPoints) {
            float currentDistance = Vector2.Distance(draggable.transform.localPosition, snapPoint.localPosition);
            if (closestSnapPoint == null || currentDistance < closestDistance)
            {
                //hieronder word gekeken of de plaatsen van het puzzelstuk en de plek in de list hetzelfde zijn, zo ja dan snapt hij op zijn plek
                if (snapPoints.IndexOf(snapPoint) == draggableObjects.IndexOf(draggable))
                {
                    closestSnapPoint = snapPoint;
                    closestDistance = currentDistance;

                }
                


            }
           
        }



        if (closestSnapPoint != null && closestDistance <= snapRange)
        {
            draggable.transform.localPosition = closestSnapPoint.localPosition;
            
            teller++;
            if (teller >= aantal)
            {
                Debug.Log(aantal);
                Debug.Log("Je mag door naar het volgende onderdeel!!");
                SceneManager.LoadScene(4);

            }

        }
        else
        {

                transform.position = startPosition;
            

            Debug.Log("spowspowspowspow pow pow poow");
            
        }


    }  

}
