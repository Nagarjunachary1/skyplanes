using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameHandler.Instance.IsCompleted || GameHandler.Instance.IsFail)
            return;

        transform.LookAt(GameHandler.Instance.MainPlayer.transform); 
    }
}
