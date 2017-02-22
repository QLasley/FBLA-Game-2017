using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeping : MonoBehaviour {

    Text gameScore;

    playerScript pS;

    public int GlobalScore;

    // Use this for initialization
    void Awake ()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

	void Start () {
        GameObject player = GameObject.Find("Player");
        pS = player.GetComponent<playerScript>();
    }
	
	// Update is called once per frame
	void Update () {
        GlobalScore = pS.Score;
	}
}
