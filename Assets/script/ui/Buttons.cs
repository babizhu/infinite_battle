using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class Buttons : MonoBehaviour {

    public GameObject iceBigBomb;
    private BigBombButtonMask mask;
    private float coldSecond = 5;
    private float currentColdSecond = 0;

	// Use this for initialization
	void Start () {

        mask = GetComponentInChildren<BigBombButtonMask>();
        //定义Action，并赋予delegate方法
        UnityEngine.Events.UnityAction action = () => { onClick(); };

        GetComponent<Button>().onClick.AddListener(action);
        //找到Button控件，并订阅事件
       
    }

    private void onClick()
    {
        if (mask.isInCold())
        {
            print("正在冷却中");
            return;
        }
        Instantiate(iceBigBomb);
        mask.beginCold(coldSecond);
        
    }

}
