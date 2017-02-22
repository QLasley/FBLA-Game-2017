using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class backgroundScript : MonoBehaviour {

    InputField inField;

    GameObject input;

	// Use this for initialization
	void Start () {

        input = GameObject.Find("InputField");
        inField = input.GetComponent<InputField>();
	}
	
	// Update is called once per frame
	void Update () {
            if (Input.GetKeyDown(KeyCode.R) && inField.isFocused == false)
            {
                Application.LoadLevel("Level 1");
            }
        }
    
}
