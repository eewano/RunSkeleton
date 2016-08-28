using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGameMaster : MonoBehaviour {

    private delegate void EveHandAppearHide(object sender, EventArgs e);

    private delegate void EveHandPLAYSE(object sender, EventArgs e);

    private Mgr_GameSE mgrGameSE;
    private Mgr_TextGameOver mgrTextGameOver;
    private Mgr_TextToTitle mgrTextToTitle;
    private Mgr_BtnRetry mgrBtnRetry;
    private Mgr_BtnCtrl mgrBtnCtrl;
    private AudioSource stageBGM;

    private float doubleTapTime;
    private bool isDoubleTapStart;
    private bool gameOver = false;

    private event EveHandPLAYSE gameOverBGM;

    private event EveHandAppearHide hideBtnCtrl;

    private event EveHandAppearHide modeGAMEOVER;

    void Awake() {
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
        mgrTextGameOver = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextGameOver>();
        mgrTextToTitle = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextToTitle>();
        mgrBtnRetry = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_BtnRetry>();
        mgrBtnCtrl = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_BtnCtrl>();
        stageBGM = GameObject.Find("StageBGM").GetComponent<AudioSource>();
    }

    void Start() {
        hideBtnCtrl += new EveHandAppearHide(mgrBtnCtrl.HideBtnEvent);
        gameOverBGM += new EveHandPLAYSE(mgrGameSE.BGMGameOverEvent);
        modeGAMEOVER += new EveHandAppearHide(mgrTextGameOver.AppearTextEvent);
        modeGAMEOVER += new EveHandAppearHide(mgrTextToTitle.AppearTextEvent);
        modeGAMEOVER += new EveHandAppearHide(mgrBtnRetry.AppearBtnEvent);
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

    void GameIsOver() {
        stageBGM.Stop();
        this.modeGAMEOVER(this, EventArgs.Empty);
        this.gameOverBGM(this, EventArgs.Empty);
        gameOver = true;
    }

    public void ModeGameOver(object o, EventArgs e) {
        this.hideBtnCtrl(this, EventArgs.Empty);
        Invoke("GameIsOver", 0.5f);
    }
}