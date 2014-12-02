using UnityEngine;
using System.Collections;

public class MaskTest : MonoBehaviour {
    float f = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        f += 0.001f;
        renderer.material.SetFloat("_Progress", f);
        
	}
}
