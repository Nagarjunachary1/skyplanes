using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyHitHandler : MonoBehaviour
{
    public bool IsBossPlane = false;
    public bool NeedHalfLife = false;
    public bool ISFinalEnemyPlane = false;
    public Enemies MainRootEnemy;
    public GameObject ParentObj;
    public GameObject HelathObj;
    public int Health = 10;
    public GameObject CoinSet;
    [HideInInspector]
    public float MainHelath;
    public BoxCollider[] MboxCollider;
    private float PlaneHalfLife;


    public static event Action<EnemyHitHandler, string> DamageCall = delegate {};

    private void OnEnable()
    {
        Bullets.DamageAmount += MdamageNotification;
    }

    private void OnDisable()
    {
        Bullets.DamageAmount -= MdamageNotification;

    }
    private void Start()
    {
        MainHelath = Health;
        PlaneHalfLife = MainHelath * 0.5f;
    }
    void MdamageNotification(GameObject otherObj, int val)
    {
       // Debug.Log(Mobj +" "+ this.gameObject);
        if (otherObj != null && otherObj == this.gameObject)
        {
            if (Health > 0)
            {
                Health -= val;
                HelathObj.transform.localScale = new Vector3(Health / MainHelath, 1, 1);

                if (Health <= PlaneHalfLife && NeedHalfLife)
                {
                    OnKill();
                    Destroy(ParentObj);
                    DamageCall(this,"runaway");
                }
            }
            else
            {
                //foreach (BoxCollider BC in MboxCollider)
                //{
                //    Destroy(BC);

                //}
                OnKill();
                //if (IsBossPlane)
               // {
                    DamageCall(this,"");
                //}
                Destroy(ParentObj);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
      if(other.transform.CompareTag("border") && other.gameObject.layer == 8)
        {
            Destroy(transform.parent.gameObject);
        }
    }

    private HitHandler TempCoins;
    void OnKill()
    {

        
            if (ISFinalEnemyPlane)
        {
            GameHandler.Instance.OnLevelCompleteFun();
          
        }

        if (MainRootEnemy.NextWave!=null)
        {
            MainRootEnemy.NextWave.SetActive(true);
        }
    }
}
