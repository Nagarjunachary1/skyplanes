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
        switch (currentobjType)
        {
            case ObjectType.coin:
                if (other.transform.CompareTag("Player"))
                {
                    ValueObject.TotalCoins+= Coinval;
                    gameObject.SetActive(false);
                  //  Debug.Log(ValueObject.TotalCoins);
                   // Destroy(this.gameObject);
                }
                break;
        }

    }
}
