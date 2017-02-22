using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;

    // Use this for initialization
    void Start () {
        bullet = GameObject.Find("Bullet");
        //bullet.SetActive(false); // Disables the object on game start
        player = GameObject.Find("Player");
	}

    // Update is called once per frame
    void Update()
    {
        float playerX, playerY;
        playerX = player.transform.position.x;
        playerY = player.transform.position.y;
        if (Input.GetKeyDown(KeyCode.Space)) //spawn bullet on space press
        {
            GameObject newBullet = Instantiate(bullet, new Vector2(playerX, playerY + 1), Quaternion.identity) as GameObject;
            newBullet.transform.localScale = new Vector2(0.35f, 0.35f);
        }
    }
        }
	

