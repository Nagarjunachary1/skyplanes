using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{


    public float DragSpeed = 1.1f;

    // Start is called before the first frame update
    void Start()
    {

    }

    Vector3 initialPosition;





    void MControls()
    {


        if (Input.GetMouseButtonDown(0))
        {
            mousePos = GameHandler.mee.mainCam.ScreenToWorldPoint(Input.mousePosition); //calculating mouse position in the worldspace
            mousePos.z = transform.position.z;
            Vector3 myPosition = transform.position;

            initialPosition = (myPosition - mousePos);

        }
        else if (Input.GetMouseButton(0))
        {
            mouseDragPos = GameHandler.mee.mainCam.ScreenToWorldPoint(Input.mousePosition);
            mouseDragPos.z = transform.position.z;

            if (mouseDragPos != mousePos)
            {
                Vector3 newPosition = mouseDragPos*(DragSpeed) + initialPosition;
                transform.position = newPosition;


            }
        }


       
    }

    private Vector3 mousePos, mouseDragPos;
    // Update is called once per frame
    void Update()
    {



        MControls();
        RestricToBoundaries();
    
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
