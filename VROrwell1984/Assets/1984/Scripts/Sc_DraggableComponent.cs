using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    /*
    Nicht verwendetes Script:
    Erlaubt einen Gegenstand zunächst auszuwählen und dann durch den Blick zu bewegen.
    Erneuter Aufruf der Funktion HandleClick() wählt das Objekt ab, woraufhin es
    an der aktuellen Position verharrt.
     */

[RequireComponent(typeof(GameObject))]
public class Sc_DraggableComponent : MonoBehaviour {

    public float cameraDistance = 10;
    public float maxGrabDistance = 20;
    GameObject vrInteractive;

    enum State { Ready, Dragging, Blocked }
    State currState;

    Vector3 initialPos;
    Quaternion initialRot;

    public GameObject myCanvas = null;

    public void Awake()
    {
        currState = State.Ready;

        initialPos = transform.position;
        initialRot = transform.rotation;
    }

    public void HandleClick()
    {
        if(currState == State.Ready)
        {
            if (myCanvas != null)
            {
                myCanvas.SetActive(false);
            }
            float dist = Vector3.Distance(transform.position, Camera.main.transform.position);

            if (dist > maxGrabDistance) return;
            currState = State.Dragging;
            
        }
        else if(currState == State.Dragging)
        {
            currState = State.Ready;
            if (myCanvas != null)
            {
                myCanvas.SetActive(false);
            }
            transform.LookAt(Camera.main.transform);
        }
    }

    private void Update()
    {
        if(currState == State.Dragging)
        {
            Transform cam = Camera.main.transform;
            transform.position = cam.position + cam.forward * cameraDistance;
           
            
        }
    }
}
