using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    enum State {
        PLAYING,
        GAMEOVER,
        EMPTY
    }

    private State state;

    private bool isDoubleTapStart;
    private float doubleTapTime;

    [SerializeField]
    private PlayerController player;
    [SerializeField]
    private GameObject ButtonLeft;
    [SerializeField]
    private GameObject ButtonRight;
    [SerializeField]
    private GameObject ButtonJump;
    [SerializeField]
    private GameObject RetryButton;

    private Text gameOverLabel;
    private Text toTitleLabel;
    private Text scoreLabel;
    private AudioSource stageBGM;
    private Mgr_GameSE mgrGameSE;

    private event EveHandPLAYSE gameOverBGM;

    void Awake() {
        gameOverLabel = GameObject.Find("GameOverLabel").GetComponent<Text>();
        toTitleLabel = GameObject.Find("ToTitleLabel").GetComponent<Text>();
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
        stageBGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
    }

    void Start() {
        gameOverBGM = new EveHandPLAYSE(mgrGameSE.BGMGameOverEvent);
        gameOverLabel.text = "";
        toTitleLabel.text = "";
        Playing();
    }

    void Update() {
        switch (state) {

            case State.PLAYING:
                //-----NORMAL STAGE のスコアラベルを更新する-----
                if (TitleManager.Stage01) {
                    int score01 = CalcScoreStage01();
                    scoreLabel.text = "Score : " + score01 + "pts";
                    if (player.Life() <= 0) {
                        if (PlayerPrefs.GetInt("Hiscore01") < score01) {
                            PlayerPrefs.SetInt("Hiscore01", score01);    //NORMAL STAGE のハイスコアを更新する
                        }
                        //Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
                        Invoke("GameOver", 0.5f);
                        //よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
                        state = State.EMPTY;
                    }
                }
                    //----------

                    //-----HARD STAGE のスコアラベルを更新する-----
                else if (TitleManager.Stage02) {
                    int score02 = CalcScoreStage02();
                    scoreLabel.text = "Score : " + score02 + "pts";
                    if (player.Life() <= 0) {
                        if (PlayerPrefs.GetInt("Hiscore02") < score02) {
                            PlayerPrefs.SetInt("Hiscore02", score02);    //HARD STAGE のハイスコアを更新する
                        }
                        //Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
                        Invoke("GameOver", 0.5f);
                        //よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
                        state = State.EMPTY;
                    }
                }
                    //----------

                    //-----SPECIAL STAGE のスコアラベルを更新する-----
                else if (TitleManager.Stage03) {
                    int score03 = CalcScoreStage03();
                    scoreLabel.text = "Score : " + score03 + "pts";
                    if (player.Life() <= 0) {
                        if (PlayerPrefs.GetInt("Hiscore03") < score03) {
                            PlayerPrefs.SetInt("Hiscore03", score03);    //HARD STAGE のハイスコアを更新する
                        }
                        //Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
                        Invoke("GameOver", 0.5f);
                        //よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
                        state = State.EMPTY;
                    }
                }
                //----------

                break;

            case State.GAMEOVER:
                if (isDoubleTapStart)
                {
                    doubleTapTime += Time.deltaTime;
                    if (doubleTapTime < 0.3f)
                    {
                        if (Input.GetMouseButtonDown(0))
                        {
                            Debug.Log("double tap");
                            isDoubleTapStart = false;
                            doubleTapTime = 0.0f;
                            SceneManager.LoadScene("Title");
                        }
                    }
                    else
                    {
                        Debug.Log("reset");
                        // reset
                        isDoubleTapStart = false;
                        doubleTapTime = 0.0f;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        Debug.Log("down");
                        isDoubleTapStart = true;
                    }
                }
                //if(Input.GetMouseButtonDown(0))
                //    SceneManager.LoadScene("Title");
                break;

            case State.EMPTY:
                break;
        }
    }

    //-----まずはすべてのテキストやボタンを非表示にしてから、各ステートで表示させたいものをtrueにしている-----
    void AllFalse() {
        ButtonLeft.gameObject.SetActive(false);
        ButtonRight.gameObject.SetActive(false);
        ButtonJump.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(false);
    }
    //----------

    void Playing() {
        state = State.PLAYING;
        AllFalse();

        ButtonLeft.gameObject.SetActive(true);
        ButtonRight.gameObject.SetActive(true);
        ButtonJump.gameObject.SetActive(true);
    }

    void GameOver() {
        state = State.GAMEOVER;
        AllFalse();

        gameOverLabel.text = "G A M E\nO V E R";
        toTitleLabel.text = "画 面 を ダ ブ ル タ ッ プ\nし て 下 さ い 。";

        stageBGM.Stop();
        this.gameOverBGM(this, EventArgs.Empty);
        RetryButton.gameObject.SetActive(true);

        //PlayerPrefs.DeleteAll();	//ハイスコアを初期化する
    }

    public void OnRetryButtonClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    //-----プレイヤーの走行距離をスコアとする-----
    int CalcScoreStage01() {
        return(int)player.transform.position.z * 10;    //NORMAL STAGE
    }

    int CalcScoreStage02() {
        return(int)player.transform.position.z * 10;    //HARD STAGE
    }

    int CalcScoreStage03() {
        return(int)player.transform.position.z * 10;    //SPECIAL STAGE
    }
    //----------
}