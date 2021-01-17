using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHitHandler : MonoBehaviour
{
    public GameObject ParentObj;
    public GameObject HelathObj;
    public int Health = 10;
    [HideInInspector]
    public float MainHelath;
    public BoxCollider[] MboxCollider;

    private void Start()
    {
        MainHelath = Health;
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("trigg " + ParentObj.name);
        if (collision.transform.CompareTag("playerbullet"))
        {
            if (Health > 0)
            {
                Health--;
                HelathObj.transform.localScale = new Vector3(Health / MainHelath, 1, 1);
            }
            else
            {
                //foreach (BoxCollider BC in MboxCollider)
                //{
                //    Destroy(BC);

                //}
                Destroy(ParentObj);
            }
        }
    }
}
