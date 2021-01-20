using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{

    public static GameHandler Instance;
    public Camera mainCam;
    public GameObject MainPlayer;
    public GameObject All_BulletsHolder;
    public GameObject All_CoinsHolder;
    public GameObject CoinObj;
    public Enemies[] AllEnemies;
    [HideInInspector]
    public bool IsCompleted, IsFail;

    public List<GameObject> AllCoins_list;

    private void OnEnable()
    {
        EnemyHitHandler.DamageCall += enemyDestroy_Notification;
    }

    private void OnDisable()
    {
        EnemyHitHandler.DamageCall -= enemyDestroy_Notification;

    }


   

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        //iTween.MoveTo(MainPlayer.gameObject, iTween.Hash("y", 10, "time", 3, "easetype", iTween.EaseType.easeInBack));

    }

    private GameObject Temp_coins;
    private int C_count = 0;
    void enemyDestroy_Notification(EnemyHitHandler otherObj, string val = "")
    {
        //Debug.Log("--- coins "+otherObj);

        if (otherObj.CoinSet!=null)
        {
            Temp_coins = GameObject.Instantiate(otherObj.CoinSet);
            Temp_coins.transform.parent = GameHandler.Instance.All_CoinsHolder.transform;
            Temp_coins.transform.position = otherObj.transform.position;
        }
        else
        {
            if (AllCoins_list.Count <= 50)
            {
                Temp_coins = GameObject.Instantiate(CoinObj);
                Temp_coins.transform.parent = GameHandler.Instance.All_CoinsHolder.transform;
                Temp_coins.transform.position = otherObj.transform.position;
                AllCoins_list.Add(Temp_coins);
            }
            else
            {
                Temp_coins = AllCoins_list[C_count];
                Temp_coins.gameObject.SetActive(true);
                Temp_coins.transform.position = otherObj.transform.position;

                C_count++;
                if (C_count >= 50)
                {
                    C_count = 0;
                }
            }
        }
        
    }


    public void OnLevelCompleteFun()
    {
        
        IsCompleted = true;
        StartCoroutine("opencompletepage");
    }

    public void OnLevelFailFun()
    {
        IsFail = true;
        StartCoroutine("openFailpage");

    }

    IEnumerator opencompletepage()
    {
        UiHandler.Instance.Messagertxt_obj.text = "Level Clear";
        
        UiHandler.Instance.Messagertxt_obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

        iTween.MoveTo(MainPlayer.gameObject,iTween.Hash("y",10,"time",2.5,"easetype",iTween.EaseType.easeInBack));
        yield return new WaitForSeconds(2f);
        UiHandler.Instance.LC_page.SetActive(true);
    }


    IEnumerator openFailpage()
    {
        UiHandler.Instance.Messagertxt_obj.text = "Level Failed";
        UiHandler.Instance.Messagertxt_obj.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);

       
        UiHandler.Instance.LF_page.SetActive(true);
    }




    // Update is called once per frame
    void Update()
    {
        
    }
}
