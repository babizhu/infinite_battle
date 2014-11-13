using UnityEngine;
using System.Collections;

public class XmlTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
        
        //print()
        
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnGUI()
    {

        GUI.Label(new Rect(0, 50, 200, 200), MissionTempletConfig.getInstance().get(1).Name);
        GUI.Label(new Rect(0, 100, 200, 200), MonsterTempletConfig.getInstance().get(154).Name);
        MonsterTemplet t = MonsterTempletConfig.getInstance().get(1);
        GUI.Label(new Rect(0, 150, 200, 200), t.Name + " speed=" + t.Speed);

        GUI.Label(new Rect(0, 200, 200, 200), "arrow name=" + ArrowTempletConfig.getInstance().get(2).Name);
        GUI.Label(new Rect(0, 250, 250, 200), "weapon name=" + WeaponTempletConfig.getInstance().get(1).Name);

    }
}
