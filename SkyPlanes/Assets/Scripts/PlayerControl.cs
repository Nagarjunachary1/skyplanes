using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    public float DragSpeed = 1.1f;
    private Vector3 initialPosition,mousePos, mouseDragPos;
    



    // Start is called before the first frame update
    void Start()
    {

    }



    // Update is called once per frame
    void Update()
    {



        MControls();
        RestricToBoundaries();


    
    }



    void MControls()
    {


        if (Input.GetMouseButtonDown(0))
        {
            mousePos = GameHandler.Instance.mainCam.ScreenToWorldPoint(Input.mousePosition); //calculating mouse position in the worldspace
            mousePos.z = transform.position.z;

            initialPosition = (transform.position - mousePos);

        }
        else if (Input.GetMouseButton(0))
        {
            mouseDragPos = GameHandler.Instance.mainCam.ScreenToWorldPoint(Input.mousePosition);
            mouseDragPos.z = transform.position.z;

            if (mouseDragPos != mousePos)
            {
                transform.position = mouseDragPos * (DragSpeed) + initialPosition;


            }
        }



    }

    private Vector3 tempPos;
    public Vector2 X_Boundries, Y_Boundries;
    void RestricToBoundaries()
    {
        tempPos = transform.position;
        tempPos.x = Mathf.Clamp(tempPos.x, X_Boundries.x, X_Boundries.y);
        tempPos.y = Mathf.Clamp(tempPos.y, Y_Boundries.x, Y_Boundries.y);
        transform.position = tempPos;
    }
}
