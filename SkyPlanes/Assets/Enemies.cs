using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public Animator M_anim;
    public float Speed;
   

    // Start is called before the first frame update
    void Start()
    {
        
        M_anim.speed = Speed;
    }

   

    // Update is called once per frame
    void Update()
    {

    }
}
