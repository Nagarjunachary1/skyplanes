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
    public ParticleSystem BlastObj;
    public GameObject CoinSet;
    [HideInInspector]
    public float MainHelath;
    public BoxCollider[] MboxCollider;
    private float PlaneHalfLife;
    private ParticleSystem TempDamgeObj;

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

                
                //TempDamgeObj.transform.eulerAngles = new Vector3(-90,0,0);



               CreateDamgeEffect();

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

                ValueObject.TotalKills++;
                GameHandler.Instance.SessionKillsCount++;
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
      
        TempDamgeObj = GameObject.Instantiate(BlastObj);
        
        TempDamgeObj.transform.position = this.transform.position;
        

        if (ISFinalEnemyPlane)
        {
            GameHandler.Instance.OnLevelCompleteFun();
          
        }

        if (MainRootEnemy.NextWave!=null)
        {
            MainRootEnemy.NextWave.SetActive(true);
        }
    }

    void CreateDamgeEffect()
    {
        if (GameHandler.Instance.CommonDamageEffect_list.Count <= 20)
        {

            TempDamgeObj = GameObject.Instantiate(GameHandler.Instance.NormalDamge_ps);// transform.position,Quaternion.identity);
            TempDamgeObj.transform.position = transform.position;


           
            TempDamgeObj.Play();
            GameHandler.Instance.CommonDamageEffect_list.Add(TempDamgeObj);
        }
        else
        {
            TempDamgeObj = GameHandler.Instance.CommonDamageEffect_list[GameHandler.Instance.effect_count];
           // Temp_coins.gameObject.SetActive(true);
            TempDamgeObj.transform.position = this.transform.position;
            TempDamgeObj.Play();

            GameHandler.Instance.effect_count++;
            if (GameHandler.Instance.effect_count >= 20)
            {
                GameHandler.Instance.effect_count = 0;
            }
        }
    }
}
