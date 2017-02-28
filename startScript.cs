using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.G))
        {
            Application.LoadLevel("Level 1");
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.LoadLevel("Leaderboard");
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            Application.LoadLevel("Instructions");
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
	}
}
