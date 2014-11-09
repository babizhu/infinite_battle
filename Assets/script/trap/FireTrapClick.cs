using UnityEngine;
using System.Collections;

public class FireTrapClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public bool click(GameObject prevChoose)
    {
        print("click");
        return true;
    }

    public void unClick()
    {
        print("unclick");
    }

    public bool isUnchoosePrevObject(GameObject prevChoose)
    {
        print("isUnchoosePrevObject");
        return false;
    }
}
