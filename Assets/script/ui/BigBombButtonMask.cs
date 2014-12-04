using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BigBombButtonMask : MonoBehaviour {

    private float coldSecond;
	private Image mask;
    //是否在冷却中
    private bool isCold = true;
	// Use this for initialization
	void Start () {
        mask = GetComponent<Image>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (!isCold) {

            mask.fillAmount -= Time.deltaTime / coldSecond;
            if (mask.fillAmount <= 0)
            {
                isCold = true;
                //mask.fillAmount = 1;
            }
        }
	}

    public void beginCold(float coldSecond)
    {
        
        mask.fillAmount = 1;
        isCold = false;
        this.coldSecond = coldSecond;
    }

    public bool isInCold()
    {
        return !isCold;
    }
}
