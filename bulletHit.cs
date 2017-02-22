using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

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
        if (coll.gameObject.tag == "Enemy")
        {
            Destroy(coll.gameObject);
            pS.Score += 10;
        }
        if (coll.gameObject.tag == "Final Enemy")
        {
            Destroy(coll.gameObject);
            pS.Score += 25;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
}
