using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public static GameHandler mee;
    public Camera mainCam;
    // Start is called before the first frame update
    void Start()
    {
        mee = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
