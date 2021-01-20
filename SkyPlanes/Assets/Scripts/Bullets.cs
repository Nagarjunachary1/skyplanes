using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Bullets : MonoBehaviour
{
    [HideInInspector]
    public float Speed;
    public int BulletStrength = 1;
    public Rigidbody MRigidbody;
    public static event Action<GameObject, int> DamageAmount = delegate { };
    public static event Action<int> PlayerDamageAmount = delegate { };

    public bool isMissile = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        //  this.name = "a";
        if (other.transform.CompareTag("enemy") && this.transform.CompareTag("playerbullet"))
        {
            DamageAmount(other.gameObject, BulletStrength);
        }

        if (other.transform.CompareTag("Player") && this.transform.CompareTag("enemybullet"))
        {
            //Debug.Log("pp");
            PlayerDamageAmount(BulletStrength);
        }
        //  Debug.Log("aa "+other.transform.tag+ " :: "+ this.transform.tag);
        this.gameObject.SetActive(false);
    }
    // Update is called once per frame
    void Update()
    {
        // MRigidbody.AddForce(Vector3.up*5, ForceMode.Force);
        if (!isMissile)
        {
            transform.position += transform.forward * Speed * Time.deltaTime;
        }
        else
        {
            SetMissileTarget();


        }
    }

    public Transform followTarget = null;
    private Vector3 M_direction;
    private Enemies[] Allenemies;
    private Enemies nearestEnemy;
    private float nearestDistance, sqrDistance = 5;
    private float SlerpSpeed = 5;
    private Quaternion targetRotation;
    void SetMissileTarget()
    {
        if (followTarget == null)
        {

            followTarget = FindEnemyTarget();
        }
        else
        {

            M_direction = (followTarget.position - transform.position).normalized;
            targetRotation = Quaternion.LookRotation(M_direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * SlerpSpeed);


            transform.position += Time.deltaTime * (transform.forward * Speed);

        }


    }


    Transform FindEnemyTarget()
    {
        Allenemies = GameObject.FindObjectsOfType<Enemies>();

        if (Allenemies.Length <= 0)
        {
            return null;
        }

        nearestEnemy = Allenemies[0];
        nearestDistance = float.MaxValue;
        for (int i = 0; i < Allenemies.Length; ++i)
        {
            sqrDistance = Vector3.SqrMagnitude(Allenemies[i].transform.position - transform.position);
            if (sqrDistance < nearestDistance)
            {
                nearestEnemy = Allenemies[i];
            }
        }

        return nearestEnemy.transform;
    }

    void GetDirection()
    {
        if (this.followTarget != null)
        {

        }
    }

    void Move()
    {

    }
}
