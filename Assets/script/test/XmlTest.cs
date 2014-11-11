using UnityEngine;
using System.Collections;

public class XmlTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {
        GUI.Label(new Rect(0, 50, 200, 200), MissionTempletConfig.getInstance().get(2).Name);


    }
}
