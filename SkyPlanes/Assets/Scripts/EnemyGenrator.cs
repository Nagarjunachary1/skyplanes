using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenrator : MonoBehaviour
{
    public EnemyEnum EnemyObj;
    public enum EnemyEnum
    {
        e1, e2, e3, e4, e5, e6,e7,e8,e9,e10, b1, b2, b3
    }

    // public Enemies EnemyObj;
    public float pathDelay;
    public int Mcount=6;
    public float Enemy_speed=1.5f, Enemy_delay=0.5f;

    public EnemyAnim AnimPath;

    public enum EnemyAnim
    {
        random0,path1,path2,path3,path4,path5,path6
    }
    // Start is called before the first frame update
    void Start()
    {
        Invoke("pathDelayFun",pathDelay);

    }

    void pathDelayFun()
    {
        InvokeRepeating("Enemy_Genrate", 0.2f, Enemy_delay);

    }
    private Enemies Temp_enemies;
    private Vector3 RandomVect;
    void Enemy_Genrate()
    {
        if (Mcount >= 1)
        {
            Temp_enemies = GameObject.Instantiate(GameHandler.Instance.AllEnemies[EnemyObj.GetHashCode()]);
            Temp_enemies.Speed = Enemy_speed;
            Temp_enemies.name = "e" + Mcount;
            if (AnimPath == EnemyAnim.random0)
            {
                RandomVect = new Vector3(Random.Range(-2.5f,2.5f), Random.Range(9, 10),0);
                Temp_enemies.transform.position = RandomVect;
            }
            else
            {
                Temp_enemies.transform.position = transform.position;
                Temp_enemies.M_anim.SetTrigger(AnimPath.ToString());

            }


            Mcount--;
        }
        else
        {
            CancelInvoke("Enemy_Genrate");
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
