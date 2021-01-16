using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingHandler : MonoBehaviour
{
    public static ShootingHandler Instance;
    public TextMesh PlayerStrength;
    [Range(1,5)]
    public int ShootingPower = 0;

    public GameObject[] ShootingMachine;

    
    // Start is called before the first frame update
    void Start()
    {
        Instance = this;
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
