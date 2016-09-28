using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Mgr_Score : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Text hiScoreText;
    [SerializeField]
    private Text getHiScoreText;
    private PlayerController player;
    private int score;
    private string keyNORMAL = "HScore_NORMAL";
    private string keyHARD = "HScore_HARD";

    private bool gameOver = false;
    private bool repeat = false;

    void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Start() {
        if (SceneManager.GetActiveScene().name == "Stage01")
        {
            hiScoreText.text = "HighScore : " + PlayerPrefs.GetInt(keyNORMAL) + " pts";
            if (PlayerPrefs.GetInt(keyNORMAL) >= 15000)
            {
                hiScoreText.color = new Color32(255, 192, 0, 255);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage02")
        {
            hiScoreText.text = "HighScore : " + PlayerPrefs.GetInt(keyHARD) + " pts";
            if (PlayerPrefs.GetInt(keyHARD) >= 20000)
            {
                hiScoreText.color = new Color32(255, 192, 0, 255);
            }
        }
    }

    void Update() {
        ScoreUpdate();
        HiScoreFlash();
    }

    void ScoreUpdate() {
        if (gameOver == false) {
            score = CalcScore();
            scoreText.text = score + " pts";

            if (Input.GetKeyUp("d"))
            {
                PlayerPrefs.DeleteAll();
                hiScoreText.text = "HighScore : " + PlayerPrefs.GetInt("HighScore") + " pts";
            }
        }
    }

    void HiScoreFlash() {
    }

    public void ChangeScore(object o, int i) {
        score += i;
    }

    private int CalcScore() {
        return (int)player.transform.position.z * 10;
    }

    public void ResultScore(object o, EventArgs e) {
        if (SceneManager.GetActiveScene().name == "Stage01" && PlayerPrefs.GetInt(keyNORMAL) < score)
        {
            gameOver = true;
            scoreText.text = "";
            PlayerPrefs.SetInt(keyNORMAL, score);
            repeat = true;

            hiScoreText.fontSize = 80;
            hiScoreText.fontStyle = FontStyle.Bold;
            hiScoreText.color = new Color32(255, 192, 0, 255);
            hiScoreText.text = "Y o u   G o t\n" + PlayerPrefs.GetInt(keyNORMAL) + " pts";
        }
        else if (SceneManager.GetActiveScene().name == "Stage02" && PlayerPrefs.GetInt(keyHARD) < score)
        {
            gameOver = true;
            scoreText.text = "";
            PlayerPrefs.SetInt(keyHARD, score);
            repeat = true;

            hiScoreText.fontSize = 80;
            hiScoreText.fontStyle = FontStyle.Bold;
            hiScoreText.color = new Color32(255, 192, 0, 255);
            hiScoreText.text = "Y o u   G o t\n" + PlayerPrefs.GetInt(keyHARD) + " pts";
        }
    }
}