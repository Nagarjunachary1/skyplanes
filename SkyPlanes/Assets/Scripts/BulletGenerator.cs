using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public bool IsPlayer = false;
    public Bullets MBullet;
    public Vector3 MoveDirection;
    public float BulletSpeed;
    public int BulletStrength = 1;

    [Header("For Player")]
    public float FireDelay = 0.3f;


    [Header("For Enemies")]
    public float MinimumShootDelay;
    public float  MaxShootDelay;
    public bool LookatPlayer = false;
    public int MaxPool_bullets = 25;

    public Transform[] BulletPoses;

    public float nextbulletdelay;
  // public List<Bullets> Bullets_list = new List<Bullets>();

    // Start is called before the first frame update
    void Start()
    {
        if (IsPlayer)
        {
            InvokeRepeating("firebullets", 0.1f, FireDelay);
        }
        else
        {
            //StartCoroutine("firebullets", Random.Range(MinimumShootDelay, MinimumShootDelay));
            Invoke("firebullets", Random.Range(MinimumShootDelay, MaxShootDelay));

        }
    }


    private void OnDisable()
    {
       // Debug.Log("cancel buelltsss ");
              CancelInvoke("firebullets");

    }


    public Bullets Temp_bullet;
    private int B_count;
    void firebullets()
    {

        if (GameHandler.Instance.IsCompleted || GameHandler.Instance.IsFail)
              CancelInvoke("firebullets");

        

        if (!IsPlayer)
        {
            for (int i = 0; i < BulletPoses.Length; i++)
            {
                Temp_bullet = GameObject.Instantiate(MBullet);
                Temp_bullet.transform.parent = GameHandler.Instance.All_BulletsHolder.transform;


                Temp_bullet.transform.position = BulletPoses[i].transform.position;
                Temp_bullet.transform.localEulerAngles = BulletPoses[i].transform.eulerAngles;

                if (LookatPlayer)
                {
                    Temp_bullet.transform.LookAt(GameHandler.Instance.MainPlayer.transform);
                }
                Temp_bullet.Speed = BulletSpeed;
                Temp_bullet.BulletStrength = BulletStrength;
            }
        }
        else
        {
            Temp_bullet = GameObject.Instantiate(MBullet);
            Temp_bullet.transform.parent = GameHandler.Instance.All_BulletsHolder.transform;


            Temp_bullet.transform.position = transform.position;
            Temp_bullet.transform.localEulerAngles = MoveDirection;
            Temp_bullet.Speed = BulletSpeed;
            Temp_bullet.BulletStrength = BulletStrength;
        }
      

        if (!IsPlayer)
        {
            nextbulletdelay = Random.Range(MinimumShootDelay, MaxShootDelay);
           // Debug.Log("delay "+nextbulletdelay);
            Invoke("firebullets", nextbulletdelay);

        }


    }

  
}
