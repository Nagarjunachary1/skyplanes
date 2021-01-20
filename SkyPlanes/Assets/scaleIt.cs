using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleIt : MonoBehaviour
{
    public Vector3 KeyValue = Vector3.one;
    public iTween.EaseType esaetype = iTween.EaseType.linear;
    public float timeee = 1;
    // Start is called before the first frame update
    void Start()
    {
        iTween.ScaleFrom(gameObject, iTween.Hash("x", KeyValue.x, "y", KeyValue.y, "time", timeee, "easetype", esaetype, "looptype", iTween.LoopType.pingPong));

    }


}
