using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip MenuClip, gameplayClip, BtnClip, WinClip, FailClip;

    public AudioSource BgSource, Btn1Source, Btn2Source;
    // Start is called before the first frame update

    public static SoundManager Instance;

    void Start()
    {
        Instance = this; 
    }

    public void PlayBg_Clip(AudioClip val)
    {
        BgSource.clip = val;
        BgSource.Play();
    }

    public void PlayBtn1_Clip(AudioClip val)
    {
        Btn1Source.clip = val;
        Btn1Source.Play();
    }

    public void PlayBtn2_Clip(AudioClip val)
    {
        BgSource.Stop();
        Btn2Source.clip = val;
        Btn2Source.Play();
    }

   
    // Update is called once per frame
    void Update()
    {
        
    }
}
