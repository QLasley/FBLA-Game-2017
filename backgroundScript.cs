﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour {

    InputField inField;

    GameObject input;

	// Use this for initialization
	void Start () {
        Debug.Log(PlayerPrefs.GetString("highscores"));

        input = GameObject.Find("InputField");
        try
        {
            inField = input.GetComponent<InputField>();
        }
        catch
        {

        }
	}

    // Update is called once per frame
    void Update() {
        try
        {
            if (Input.GetKeyDown(KeyCode.R) && inField.isFocused == false)
            {
                Application.LoadLevel("Start");
            }
        }
        catch
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                Application.LoadLevel("Start");
            }
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
