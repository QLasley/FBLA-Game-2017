using UnityEngine;
using System.Collections;

public class enemyDestroy : MonoBehaviour {

    playerScript pS;

	// Use this for initialization
	void Start () {
        GameObject player = GameObject.Find("Player");
        pS = player.GetComponent<playerScript>();

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
        if (coll.gameObject.tag == "Final Enemy" && !pS.loseText.enabled)
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
