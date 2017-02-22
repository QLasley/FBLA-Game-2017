using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slowScript : MonoBehaviour {

    public int hp = 3;
	// Use this for initialization
	void Start () {
		
	}

    int getHp()
    {
        return hp;
    }

    void setHp(int hp)
    {
        this.hp = hp;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Bullet")
        {
            hp--;
            Destroy(coll.gameObject);
        }
    }
}
