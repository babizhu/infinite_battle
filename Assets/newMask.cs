using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class newMask : MonoBehaviour {
    Image m;
	// Use this for initialization
	void Start () {
        m = GetComponent<Image>();
         //print(m);
	}
	
	// Update is called once per frame
	void Update () {
        
        m.fillAmount  -= 0.002f;
        if (m.fillAmount <= 0)
        {
            m.fillAmount = 1;
        }
	}
}
