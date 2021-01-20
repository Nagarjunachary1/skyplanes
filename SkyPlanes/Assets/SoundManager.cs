using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip MenuClip, gameplayClip, BtnClip, WinClip, FailClip,FinalClip,powerupClip, coinClip,enemyExplosion_clip;

    public AudioSource BgSource, Btn1Source, Btn2Source, Btn3Source,ExplosionSource;
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
    public void PlayBtn3_Clip(AudioClip val)
    {
        Btn3Source.clip = val;
        Btn3Source.Play();
    }
    public void PlayBtn4_Clip(AudioClip val)
    {
        ExplosionSource.clip = val;
        ExplosionSource.Play();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}
