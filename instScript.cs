using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class instScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.R))
        {
            Application.LoadLevel("Start");
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            Application.LoadLevel("Level 1");
        }
	}
}
