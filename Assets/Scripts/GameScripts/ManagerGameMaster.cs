using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGameMaster : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    private Mgr_GameSE mgrGameSE;
    private Mgr_TextGameOver mgrTextGameOver;
    private Mgr_TextToTitle mgrTextToTitle;
    private Mgr_BtnRetry mgrBtnRetry;
    private Mgr_BtnCtrl mgrBtnCtrl;
    private AudioSource stageBGM;
    private Mgr_Score mgrScore;

    private float doubleTapTime;
    private bool isDoubleTapStart;
    private bool gameOver = false;

    private event EventHandler hideBtnCtrl;

    private event EventHandler modeGAMEOVER;

    void Awake() {
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
        mgrTextGameOver = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextGameOver>();
        mgrTextToTitle = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextToTitle>();
        mgrBtnRetry = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_BtnRetry>();
        mgrBtnCtrl = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_BtnCtrl>();
        stageBGM = GameObject.Find("StageBGM").GetComponent<AudioSource>();
        mgrScore = GameObject.Find("Mgr_GameText").GetComponent<Mgr_Score>();
    }

    void Start() {
        hideBtnCtrl += new EventHandler(mgrBtnCtrl.HideBtnEvent);
        modeGAMEOVER += new EventHandler(mgrGameSE.BGMGameOverEvent);
        modeGAMEOVER += new EventHandler(mgrTextGameOver.AppearTextEvent);
        modeGAMEOVER += new EventHandler(mgrTextToTitle.AppearTextEvent);
        modeGAMEOVER += new EventHandler(mgrBtnRetry.AppearBtnEvent);
        modeGAMEOVER += new EventHandler(mgrScore.ResultScore);

        GameStart();
    }

    void Update() {
        if (gameOver == true)
        {
            if (isDoubleTapStart == true)
            {
                doubleTapTime += Time.deltaTime;
                if (doubleTapTime < 0.3f)
                {
                    if (Input.GetMouseButtonDown(0))
                    {
                        isDoubleTapStart = false;
                        doubleTapTime = 0.0f;
                        SceneManager.LoadScene("Title");
                    }
                }
                else
                {
                    isDoubleTapStart = false;
                    doubleTapTime = 0.0f;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    isDoubleTapStart = true;
                }
            }
        }
    }

    void GameStart() {
        stageBGM.Play();
    }

    void GameIsOver() {
        stageBGM.Stop();
        this.modeGAMEOVER(this, EventArgs.Empty);
        gameOver = true;
    }

    public void ModeGameOver(object o, EventArgs e) {
        this.hideBtnCtrl(this, EventArgs.Empty);
        Invoke("GameIsOver", 0.5f);
    }
}