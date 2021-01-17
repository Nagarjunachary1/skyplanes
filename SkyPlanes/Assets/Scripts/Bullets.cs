using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullets : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    public Rigidbody MRigidbody;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
      //  this.name = "a";
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
       // MRigidbody.AddForce(Vector3.up*5, ForceMode.Force);
        transform.position += transform.up * Speed*Time.deltaTime;
    }
}
