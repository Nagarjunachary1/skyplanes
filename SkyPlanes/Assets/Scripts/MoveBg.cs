using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBg : MonoBehaviour
{
    public float myval;
    public Vector3 SpeedDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (GameHandler.Instance.IsCompleted || GameHandler.Instance.IsFail)
            return;


      //  myval = this.transform.localPosition.y;
        if (this.transform.localPosition.y<-43)
        {
            this.transform.position = new Vector3(0,12.1f,5);
           // Debug.Log("-- stop");
        }
        else
        {
            transform.Translate(SpeedDirection * Time.deltaTime);

        }

    }
}
