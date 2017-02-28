using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class gameScore : MonoBehaviour {

    ScoreObj[] highScores = new ScoreObj[3];

    [Serializable]
    public class ScoreDisplay
    {
        public ScoreObj[] scores;

        public ScoreDisplay(ScoreObj[] objs)
        {
            scores = objs;
        }
    }

    [Serializable]
    public class ScoreObj
    {
        public int score;
        public string name;

        public ScoreObj(string name, int score)
        {
            this.score = score;
            this.name = name;
            //Debug.Log("ScoreOBJ string and int done");
        }

        public ScoreObj(string JsonObj)
        {
            ScoreObj temp = JsonUtility.FromJson<ScoreObj>(JsonObj);
            this.score = temp.score;
            this.name = temp.name;
            //Debug.Log("public ScoreObj string Done");
        }

        public string getJson()
        {
            return JsonUtility.ToJson(this);
            //Debug.Log("string getJson Done");
        }
    }

    public Text scoreText;

    ScoreKeeping SK1;
    
    ScoreKeeping SK2;

    ScoreKeeping SK3;

    public int finalScore;

    InputField input;

    // Use this for initialization
    void Start () {
        Debug.Log(PlayerPrefs.GetString("highscores"));
        input = GameObject.Find("InputField").GetComponent<InputField>();
        input.Select();
        try
        {
            GameObject obj1 = GameObject.Find("GlobalObject 1");
            SK1 = obj1.GetComponent<ScoreKeeping>();
            GameObject obj2 = GameObject.Find("GlobalObject 2");
            SK2 = obj2.GetComponent<ScoreKeeping>();
            GameObject obj3 = GameObject.Find("GlobalObject 3");
            SK3 = obj3.GetComponent<ScoreKeeping>();
            finalScore = SK1.GlobalScore + SK2.GlobalScore + SK3.GlobalScore;
        } catch (Exception e)
        {
            Debug.Log(e.Message);
            finalScore = 0;
        }
        try {
            ScoreDisplay tempDisp = JsonUtility.FromJson<ScoreDisplay>(PlayerPrefs.GetString("highscores"));
            highScores = tempDisp.scores; }
        catch
        {
            for (int i = 0; i < 3; i++)
            {
                highScores[i] = new ScoreObj("None", 0);
            }
            btnClick();
            updateHighScores();
        }

        bool newHigh = false;

        foreach (ScoreObj obj in highScores)
        {
            if (obj.score < finalScore) newHigh = true;
        }

        if (!newHigh)
        {
            input.gameObject.active = false;
        }


        scoreText.text = "Your Score: " + finalScore.ToString();

        updateHighScores();

        Debug.Log(PlayerPrefs.GetString("highscores"));
    }

    void updateHighScores()
    {
        int count = 1;

        for (int j = 0; j < 2; j++)
        {
            for (int i = 0; i < highScores.Length; i++)
            {
                if (i != highScores.Length - 1)
                {
                    if (highScores[i].score < highScores[i + 1].score)
                    {
                        ScoreObj temp = highScores[i];
                        highScores[i] = highScores[i + 1];
                        highScores[i + 1] = temp;
                    }
                }
            }
        }

        foreach (ScoreObj obj in highScores)
        {
            Text name = GameObject.Find("Name" + count.ToString()).GetComponent<Text>();
            Text score = GameObject.Find("Score" + count.ToString()).GetComponent<Text>();

            name.text = obj.name;
            score.text = obj.score.ToString();

            count++;
        }
    }

    private void btnClick()
    {
        ScoreObj tempObj = new ScoreObj(input.text, finalScore);

        for (int i = 0; i < highScores.Length; i++)
        {
            if (highScores[i].score < tempObj.score)
            {
                changed = true;
                if (i != highScores.Length - 1)
                {
                    KeyValuePair<int, int> lowest = new KeyValuePair<int, int>(i, highScores[i].score);
                    for (int j = 0; j < highScores.Length; j++)
                    {
                        if (highScores[j].score < lowest.Value)
                        {
                            lowest = new KeyValuePair<int, int>(j, highScores[j].score);
                        }
                    }

                    highScores[lowest.Key] = tempObj;
                } else
                {
                    highScores[i] = tempObj;
                }
                break;
            }
        }

        ScoreDisplay disp = new ScoreDisplay(highScores);

        PlayerPrefs.SetString("highscores", JsonUtility.ToJson(disp));
    }

    bool callUpdate = true;
    bool changed = false;

    // Update is called once per frame
    void Update () {
        if(Input.GetKeyDown(KeyCode.Return) && callUpdate && input.text.Trim(' ') != "")
        {
            Debug.Log("Enter Hit!");
            btnClick();
            if (changed)
            {
                updateHighScores();
            }
            callUpdate = false;
            updateHighScores();
        }
        if (Input.GetKeyDown(KeyCode.R) && !input.isFocused)
        {
            Application.LoadLevel("Start");
        }
        if (Input.GetKeyDown(KeyCode.C) && !input.isFocused)
        {
            for (int i = 0; i < highScores.Length; i++)
            {
                highScores[i] = new ScoreObj("None", 0);
            }
            btnClick();
            updateHighScores();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
}
