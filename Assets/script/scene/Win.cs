using UnityEngine;
using System.Collections;

public class Win : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("AbstractMonster.count" + AbstractMonster.count);
            PlayerData.getInstance().CurrentMission += 1;
            Application.LoadLevel("battle");
        }
	}
}
