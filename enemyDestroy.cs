﻿using UnityEngine;
using System.Collections;

public class enemyDestroy : MonoBehaviour {


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Slow Enemy")
        {
            Destroy(coll.gameObject);
        }
        if (coll.gameObject.tag == "Final Enemy")
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
