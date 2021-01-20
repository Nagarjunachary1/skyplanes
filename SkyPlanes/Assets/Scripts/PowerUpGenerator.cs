using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpGenerator : MonoBehaviour
{
    public int DelayTime = 10;
    public int DelayTime_Bonusobj = 10;
    public List<GameObject> AllPowerUps= new List<GameObject>();
    public List<GameObject> ExtraBoosters= new List<GameObject>();
    private int PowerNum;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("GeneratePowerObj", DelayTime);
        StartCoroutine("GenerateBonusObj", DelayTime_Bonusobj);
    }


     IEnumerator GeneratePowerObj(int val)
    {
        while (AllPowerUps.Count>0)
        {
            yield return new WaitForSeconds(val);
            PowerNum = Random.Range(0,AllPowerUps.Count);
            Instantiate(AllPowerUps[PowerNum], new Vector2(Random.Range(-2,2),7),Quaternion.identity);
            AllPowerUps.RemoveAt(PowerNum);
        }
    }


    IEnumerator GenerateBonusObj(int val)
    {
        while (ExtraBoosters.Count > 0)
        {
            yield return new WaitForSeconds(val);
            PowerNum = Random.Range(0, ExtraBoosters.Count);
            Instantiate(ExtraBoosters[PowerNum], new Vector2(Random.Range(-2, 2), 7), Quaternion.identity);
          
        }
    }

}
    

