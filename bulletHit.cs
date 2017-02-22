using UnityEngine;
using System.Collections;

public class bulletHit : MonoBehaviour {

    playerScript pS;

    slowScript sS;

    public const int NORMAL_SCORE = 10;
    public const int FINAL_SCORE = 25;
    public const int SLOW_SCORE = 15;
    public const int SLOW_HP = 3;

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
            pS.Score += NORMAL_SCORE;
        }
        if (coll.gameObject.tag == "Final Enemy")
        {
            Destroy(coll.gameObject);
            pS.Score += FINAL_SCORE;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
        if (coll.gameObject.tag == "Slow Enemy")
        {
            Debug.Log(coll.gameObject.GetComponent<slowScript>().hp);

            if (coll.gameObject.GetComponent<slowScript>().hp == 0)
            {
                Destroy(coll.gameObject);
                pS.Score += SLOW_SCORE;
            }
        }
    }
}
