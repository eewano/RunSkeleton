using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TextScore : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Outline scoreOutLine;
    private int score;

    void Start() {
        scoreText.fontSize = 40;
        scoreText.color = new Color32(0, 0, 0, 255);
        scoreOutLine.effectDistance = new Vector2(2, 2);
        scoreOutLine.effectColor = new Color32(255, 255, 255, 255);
        scoreText.text = "Score : " + score + "pts";
    }

    void Update() {
        scoreText.text = "Score : " + score + "pts";
    }
}

//-----NORMAL STAGE のスコアラベルを更新する-----
//                if (ManagerTitleMaster.Stage01) {
//                    int score01 = CalcScoreStage01();
//                    scoreLabel.text = "Score : " + score01 + "pts";
//                    if (player.Life() <= 0) {
//                        if (PlayerPrefs.GetInt("Hiscore01") < score01) {
//                            PlayerPrefs.SetInt("Hiscore01", score01);    //NORMAL STAGE のハイスコアを更新する
//                        }
//                        //Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
//                        Invoke("GameOver", 0.5f);
//                        //よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
//                        state = State.EMPTY;
//                    }
//                }
//                    //----------
//
//                    //-----HARD STAGE のスコアラベルを更新する-----
//                else if (ManagerTitleMaster.Stage02) {
//                    int score02 = CalcScoreStage02();
//                    scoreLabel.text = "Score : " + score02 + "pts";
//                    if (player.Life() <= 0) {
//                        if (PlayerPrefs.GetInt("Hiscore02") < score02) {
//                            PlayerPrefs.SetInt("Hiscore02", score02);    //HARD STAGE のハイスコアを更新する
//                        }
//                        //Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
//                        Invoke("GameOver", 0.5f);
//                        //よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
//                        state = State.EMPTY;
//                    }
//                }
//                    //----------
//
//                    //-----SPECIAL STAGE のスコアラベルを更新する-----
//                else if (ManagerTitleMaster.Stage03) {
//                    int score03 = CalcScoreStage03();
//                    scoreLabel.text = "Score : " + score03 + "pts";
//                    if (player.Life() <= 0) {
//                        if (PlayerPrefs.GetInt("Hiscore03") < score03) {
//                            PlayerPrefs.SetInt("Hiscore03", score03);    //HARD STAGE のハイスコアを更新する
//                        }
//                        //Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
//                        Invoke("GameOver", 0.5f);
//                        //よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
//                        state = State.EMPTY;
//                    }
//                }
//----------