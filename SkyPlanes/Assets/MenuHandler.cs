using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuHandler : MonoBehaviour
{
    public Text Coins_txt,HighKills_txt,TotalKills_txt,lastKills_txt;
    // Start is called before the first frame update
    void Start()
    {
        Coins_txt.text = ValueObject.TotalCoins.ToString();
        HighKills_txt.text = "Best HighScore: "+ ValueObject.HighKills + " Kills";
        TotalKills_txt.text = "Total Kills: " + ValueObject.TotalKills + " Kills";
        lastKills_txt.text = "Last Sesion Kills: "+ValueObject.LastKills+" Kills";
    }

    public void PlayClick()
    {
        SceneManager.LoadSceneAsync(ValueObject.GamePlayScene);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
