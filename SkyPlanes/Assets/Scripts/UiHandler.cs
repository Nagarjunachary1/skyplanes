using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiHandler : MonoBehaviour
{
    public Image HealthBar;
    public GameObject Ingame_page,Pause_page,LC_page, LF_page;
    public Text Messagertxt_obj,CoinsLC_txt,KillsLc_txt;
    public GameObject healthBlinkObj;

    public static UiHandler Instance;
    // Start is called before the first frame update
    void Start()
    {
        Instance = this; 
    }

    public void Next_Lc()
    {
        SoundManager.Instance.PlayBtn1_Clip(SoundManager.Instance.BtnClip);

        SceneManager.LoadSceneAsync(ValueObject.loadingScene);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
