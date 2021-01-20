using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Text Coins_txt,HighKills_txt,TotalKills_txt,lastKills_txt,Sound_txt;
    // Start is called before the first frame update
    void Start()
    {
        Coins_txt.text = ValueObject.TotalCoins.ToString();
        HighKills_txt.text = "Best HighScore: "+ ValueObject.HighKills + " Kills";
        TotalKills_txt.text = "Total Kills: " + ValueObject.TotalKills + " Kills";
        lastKills_txt.text = "Last Sesion Kills: "+ValueObject.LastKills+" Kills";
        CheckSoundData();
    }

    public void PlayClick()
    {
        SoundManager.Instance.PlayBtn1_Clip(SoundManager.Instance.BtnClip);
        SceneManager.LoadSceneAsync(ValueObject.GamePlayScene);

    }

    public void CheckSoundData()
    {
        if (ValueObject.GameVolume == 1)
        {
            Sound_txt.text = "Sound \non";
        }
        else
        {
            Sound_txt.text = "Sound \noff";

        }

        AudioListener.volume = ValueObject.GameVolume;
    }
    public void SoudClick()
    {
        if (ValueObject.GameVolume == 1)
        {
            ValueObject.GameVolume = 0;
            Sound_txt.text = "Sound \nOFF";
        }
        else
        {
            ValueObject.GameVolume = 1;
            Sound_txt.text = "Sound \non";

        }

        AudioListener.volume = ValueObject.GameVolume;

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
