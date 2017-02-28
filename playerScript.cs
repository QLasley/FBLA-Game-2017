using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class playerScript : MonoBehaviour {
    public GameObject bullet;
    public GameObject player;
    public float Speed = 0f;
    private float movex = 0f;
    private float movey = 0f;
    public int Lives = 3;
    public Text liveText;
    public Text scoreText;
    public Text loseText;
    public int Score;
    public AudioClip Shoot;
    AudioSource Source;
    //playerScript sk; // may remove

    // Use this for initialization
    void Start () {
        bullet = GameObject.Find("Bullet");
        //bullet.SetActive(false); // Disables the object on game start
        player = GameObject.Find("Player");
        SetLiveText();
        SetScoreText();
        loseText.text = "You Lose!";
        loseText.enabled = false;
        //GameObject GS = GameObject.Find("GlobalObject"); // may remove
        //sk = GS.GetComponent<playerScript>(); // may remove
        //Score = sk.GlobalScore; // may remove
        Source = player.GetComponent<AudioSource>();
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
            Source.PlayOneShot(Shoot, 1f);
        }
        SetScoreText();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }

        void FixedUpdate () {
        movex = Input.GetAxis("Horizontal");
        GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, movey * Speed);
        
        if (Lives == 0)
        {
            loseText.enabled = true;
            player.gameObject.active = false;
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy" || coll.gameObject.tag == "Slow Enemy")
        {
            Destroy(coll.gameObject);
            Lives = Lives - 1;
            SetLiveText();
        }

        if (coll.gameObject.tag == "Final Enemy")
        {
            Destroy(coll.gameObject);
            Lives = Lives - 1;
            Application.LoadLevel(Application.loadedLevel + 1);
        }
    }
    void SetLiveText()
    {
        liveText.text = "Lives: " + Lives.ToString();
    }
    
    void SetScoreText()
    {
        scoreText.text = "Score: " + Score.ToString();
    }
}
