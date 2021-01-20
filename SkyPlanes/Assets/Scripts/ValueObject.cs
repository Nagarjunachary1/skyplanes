using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValueObject 
{
    public static string loadingScene = "loading";
    public static string MenuScene = "0Scene";
    public static string GamePlayScene = "GamePlay";
    public static int TotalCoins
    {
        get { return PlayerPrefs.GetInt("mcoins"); }
        set
        {
           
            PlayerPrefs.SetInt("mcoins", value);
        }
    }

    public static int HighKills
    {
        get { return PlayerPrefs.GetInt("HighKills"); }
        set
        {

            if (value> PlayerPrefs.GetInt("HighKills"))
            {
                PlayerPrefs.SetInt("HighKills", value);

            }
        }
    }


    public static int TotalKills
    {
        get { return PlayerPrefs.GetInt("TotalKills"); }
        set
        {

            PlayerPrefs.SetInt("TotalKills", value);
        }
    }


    public static int LastKills
    {
        get { return PlayerPrefs.GetInt("LastKills"); }
        set
        {

            PlayerPrefs.SetInt("LastKills", value);
        }
    }


    public static int GameVolume
    {
        get { return PlayerPrefs.GetInt("GameVolume",1); }
        set
        {

            PlayerPrefs.SetInt("GameVolume", value);
        }
    }
}
