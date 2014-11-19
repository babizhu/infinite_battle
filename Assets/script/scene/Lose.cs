using UnityEngine;
using System.Collections;

public class Lose : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            print("AbstractMonster.count" + AbstractMonster.count);
            AbstractMonster.count = 0;
            Application.LoadLevel("battle");
        }
	}
}
