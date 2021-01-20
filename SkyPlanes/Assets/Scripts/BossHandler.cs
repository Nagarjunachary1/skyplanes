using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHandler : MonoBehaviour
{

    public EnemyHitHandler MainBossGun;
    public int TotalMinGuns = 2;
    public static BossHandler Instance;

    public Enemies MEnemy;

    private void OnEnable()
    {
        EnemyHitHandler.DamageCall += Damage_notification;
    }

    private void OnDisable()
    {
        EnemyHitHandler.DamageCall -= Damage_notification;

    }
    void Damage_notification(EnemyHitHandler otherObj, string val="null")
    {
        if (val== "runaway")
        {
            MEnemy.M_anim.SetTrigger("exit");
            MEnemy.M_anim.speed = 0.3f;
            MainBossGun.enabled = false;
            MainBossGun.GetComponent<BoxCollider>().enabled = false;
        }
        


        TotalMinGuns--;
        if (TotalMinGuns == 0)
        {
            MainBossGun.enabled = true;
            MainBossGun.GetComponent<BoxCollider>().enabled = true;
        }
    }
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
