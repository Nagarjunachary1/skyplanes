using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject 
{

    public static int TotalCoins
    {
        get { return PlayerPrefs.GetInt("mcoins"); }
        set
        {
           
            PlayerPrefs.SetInt("mcoins", value);
        }
    }
   
}
