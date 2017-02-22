using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;
using System.Collections.Generic;

public class gameScore : MonoBehaviour {

    ScoreObj[] highScores;

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
        }

        public ScoreObj(string JsonObj)
        {
            ScoreObj temp = JsonUtility.FromJson<ScoreObj>(JsonObj);
            this.score = temp.score;
            this.name = temp.name;
        }

        public string getJson()
        {
            return JsonUtility.ToJson(this);
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
        input = GameObject.Find("InputField").GetComponent<InputField>();
        try
        {
            GameObject obj1 = GameObject.Find("GlobalObject 1");
            SK1 = obj1.GetComponent<ScoreKeeping>();
            GameObject obj2 = GameObject.Find("GlobalObject 2");
            SK2 = obj2.GetComponent<ScoreKeeping>();
            GameObject obj3 = GameObject.Find("GlobalObject 3");
            SK3 = obj3.GetComponent<ScoreKeeping>();
            finalScore = SK1.GlobalScore + SK2.GlobalScore + SK3.GlobalScore;
        } catch
        {
            finalScore = 99;
        }

        ScoreDisplay tempDisp = JsonUtility.FromJson<ScoreDisplay>(PlayerPrefs.GetString("highscores"));
        highScores = tempDisp.scores;

        scoreText.text = "Your Score: " + finalScore.ToString();

        updateHighScores();

        Debug.Log(PlayerPrefs.GetString("highscores"));
    }

    void updateHighScores()
    {
        int count = 1;

        for (int i = 0; i < highScores.Length; i++)
        {
            if (i != highScores.Length - 1)
            {
                if (highScores[i].score < highScores[i + 1].score)
                {
                    int temp = highScores[i].score;
                    highScores[i].score = highScores[i + 1].score;
                    highScores[i + 1].score = temp;
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
        }
	}
}
