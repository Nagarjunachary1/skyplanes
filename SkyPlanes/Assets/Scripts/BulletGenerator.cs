using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletGenerator : MonoBehaviour
{
    public Bullets MBullet;
    public float FireDelay = 0.3f;
    public Vector3 MoveDirection;
    public float BulletSpeed;

    public int MaxPool_bullets = 25;
    public List<Bullets> Bullets_list = new List<Bullets>();

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("firebullets", 0.1f, FireDelay);
    }

    private Bullets Temp_bullet;
    private int B_count;
    void firebullets()
    {
        if (Bullets_list.Count<= MaxPool_bullets)
        {
            Temp_bullet = GameObject.Instantiate(MBullet);
            Temp_bullet.transform.parent = GameHandler.Instance.All_BulletsHolder.transform;
            Bullets_list.Add(Temp_bullet);
        }
        else
        {
            Temp_bullet = Bullets_list[B_count];
            Temp_bullet.gameObject.SetActive(true);
            B_count++;
            if (B_count>= MaxPool_bullets)
            {
                B_count = 0;
            }
        }
       
        Temp_bullet.transform.position = transform.position;
        Temp_bullet.transform.localEulerAngles = MoveDirection;
        Temp_bullet.Speed = BulletSpeed;
        



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
