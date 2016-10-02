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
    private int itemScore;
    private string keyNORMAL = "HScore_NORMAL";
    private string keyHARD = "HScore_HARD";
//    private string keySPECIAL = "HScore_SPECIAL";

    private bool gameOver = false;

    void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Start() {
        if (SceneManager.GetActiveScene().name == "Stage01")
        {
            hiScoreText.text = "HiScore : " + PlayerPrefs.GetInt(keyNORMAL) + " pts";
            if (PlayerPrefs.GetInt(keyNORMAL) >= 24000)
            {
                hiScoreText.color = new Color32(255, 128, 255, 255);
            }
        }
        else if (SceneManager.GetActiveScene().name == "Stage02")
        {
            hiScoreText.text = "HiScore : " + PlayerPrefs.GetInt(keyHARD) + " pts";
            if (PlayerPrefs.GetInt(keyHARD) >= 21000)
            {
                hiScoreText.color = new Color32(255, 128, 255, 255);
            }
        }
//        else if (SceneManager.GetActiveScene().name == "Stage03")
//        {
//            hiScoreText.text = "HiScore : " + PlayerPrefs.GetInt(keySPECIAL) + " pts";
//            if (PlayerPrefs.GetInt(keySPECIAL) >= 10000)
//            {
//                hiScoreText.color = new Color32(255, 0, 255, 255);
//            }
//        }
    }

    void Update() {
        ScoreUpdate();
    }

    void ScoreUpdate() {
        if (gameOver == false) {
            score = CalcScore() + itemScore;
            scoreText.text = score + " pts";

            if (Input.GetKeyUp("d"))
            {
                PlayerPrefs.DeleteAll();
                hiScoreText.text = "HiScore : " + PlayerPrefs.GetInt("HiScore") + " pts";
            }
        }
    }

    public void ChangeScore(object o, int i) {
        itemScore += i;
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

            hiScoreText.fontSize = 80;
            hiScoreText.fontStyle = FontStyle.Bold;
            hiScoreText.color = new Color32(255, 192, 0, 255);
            hiScoreText.text = "Y o u   G o t\n" + PlayerPrefs.GetInt(keyHARD) + " pts";
        }
//        else if (SceneManager.GetActiveScene().name == "Stage03" && PlayerPrefs.GetInt(keySPECIAL) < score)
//        {
//            gameOver = true;
//            scoreText.text = "";
//            PlayerPrefs.SetInt(keySPECIAL, score);
//
//            hiScoreText.fontSize = 80;
//            hiScoreText.fontStyle = FontStyle.Bold;
//            hiScoreText.color = new Color32(255, 192, 0, 255);
//            hiScoreText.text = "Y o u   G o t\n" + PlayerPrefs.GetInt(keySPECIAL) + " pts";
//        }
    }
}