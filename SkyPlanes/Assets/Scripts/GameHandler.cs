﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public static GameHandler Instance;
    public Camera mainCam;
    public GameObject All_BulletsHolder;

    public Enemies[] AllEnemies;
   

    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}