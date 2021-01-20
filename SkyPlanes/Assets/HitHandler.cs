using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitHandler : MonoBehaviour
{
    public ObjectType currentobjType;
    public int Coinval = 1;
    public enum ObjectType
    {
        coin,
        powerup1,
        powerup2,
        medicine,
        sheild
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Player"))
        {
            switch (currentobjType)
            {
                case ObjectType.coin:

                    ValueObject.TotalCoins += Coinval;
                    gameObject.SetActive(false);
                    //  Debug.Log(ValueObject.TotalCoins);
                    // Destroy(this.gameObject);
                    playEffect(0);

                    break;

                case ObjectType.powerup1:

                    ShootingHandler.Instance.ShootingPower = 4;
                    ShootingHandler.Instance.SwitchWeapons();

                    gameObject.SetActive(false);

                    playEffect(1);


                    break;

                case ObjectType.powerup2:

                    ShootingHandler.Instance.ShootingPower = 5;
                    ShootingHandler.Instance.SwitchWeapons();

                    gameObject.SetActive(false);

                    playEffect(1);

                    break;

                case ObjectType.medicine:
                    ShootingHandler.Instance.PlayerHealth = 100;
                    gameObject.SetActive(false);

                    playEffect(1);

                    break;

                case ObjectType.sheild:
                    ShootingHandler.Instance.ActivateShield();

                    gameObject.SetActive(false);
                    playEffect(1);

                    break;
            }
        }

    }
    private ParticleSystem TempEffectObj;
    void playEffect(int numm)
    {


        TempEffectObj = GameObject.Instantiate(GameHandler.Instance.PowerEffect_list[numm]); 
        // Temp_coins.gameObject.SetActive(true);
        TempEffectObj.transform.position = this.transform.position;
        TempEffectObj.Play();


        
    }
}
