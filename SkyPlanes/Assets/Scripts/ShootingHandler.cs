using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    [Tooltip("contains player shooting and hit data")]
    public int PlayerHealth = 100;
    public GameObject BlastObbj;
    public static ShootingHandler Instance;
    public TextMesh PlayerStrength;
    [Range(1,5)]
    public int ShootingPower = 0;

    public GameObject[] ShootingMachine;
    [HideInInspector]
    public float MainHelath;

    public GameObject ShieldObj;
    private bool IsInShield = false;
    private void OnEnable()
    {
        Bullets.PlayerDamageAmount += PlayerdamageNotification;
    }

    private void OnDisable()
    {
        Bullets.PlayerDamageAmount -= PlayerdamageNotification;

    }

   
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
        MainHelath = PlayerHealth;
        SwitchWeapons();
    }

    public void SwitchWeapons()
    {

        for (int i=0;i<ShootingMachine.Length;i++)
        {
            ShootingMachine[i].SetActive(false);
        }
        PlayerStrength.text = ShootingPower.ToString();
        ShootingMachine[ShootingPower-1].SetActive(true);

        
    }
    private bool inblink = false;
    void PlayerdamageNotification(int val)
    {
        if (!IsInShield && !GameHandler.Instance.IsCompleted && !GameHandler.Instance.IsFail)
        {

            if (PlayerHealth > 0)
            {
                PlayerHealth -= val;
                // Debug.Log("player damage " + PlayerHealth);

                CameraShake.Instance.Shake();
                UiHandler.Instance.HealthBar.fillAmount = (PlayerHealth / MainHelath) * 1f;
                if (PlayerHealth<20 && inblink==false)
                {
                    inblink = true;
                    UiHandler.Instance.healthBlinkObj.SetActive(true);
                }
                if (PlayerHealth > 20 && inblink == true)
                {
                    inblink = false;
                    UiHandler.Instance.healthBlinkObj.SetActive(false);
                }


            }
            else
            {
                UiHandler.Instance.healthBlinkObj.SetActive(false);

                OnPlayerBlast();
                Destroy(gameObject, 0.2f);

            }
        }
    }


    public void ActivateShield()
    {
        ShieldObj.SetActive(true);
        IsInShield = true;
        StartCoroutine("DisableShield");
    }

    IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(5);
        ShieldObj.SetActive(false);
        IsInShield = false;
    }
    private GameObject TempDamgeObj;
    void OnPlayerBlast()
    {
        GameHandler.Instance.IsFail = true;
        TempDamgeObj = GameObject.Instantiate(BlastObbj);

        TempDamgeObj.transform.position = this.transform.position;

     
        GameHandler.Instance.OnLevelFailFun();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
