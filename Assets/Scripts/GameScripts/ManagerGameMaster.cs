using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGameMaster : MonoBehaviour {

    private delegate void EveHandAppearHide(object sender, EventArgs e);

    private delegate void EveHandPLAYSE(object sender, EventArgs e);

    private PlayerController playerController;
    private Mgr_GameSE mgrGameSE;
    private Mgr_TextGameOver mgrTextGameOver;
    private Mgr_TextToTitle mgrTextToTitle;
    private Mgr_BtnRetry mgrBtnRetry;
    private AudioSource stageBGM;

    private float doubleTapTime;
    private bool isDoubleTapStart;
    private bool gameOver = false;

    private event EveHandPLAYSE gameOverBGM;

    private event EveHandAppearHide statePLAYING;

    private event EveHandAppearHide stateGAMEOVER;

    void Awake() {
        playerController = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
        mgrTextGameOver = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextGameOver>();
        mgrTextToTitle = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextToTitle>();
        mgrBtnRetry = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_BtnRetry>();
        stageBGM = GameObject.Find("StageBGM").GetComponent<AudioSource>();
    }

    void Start() {
        statePLAYING += new EveHandAppearHide(playerController.AppearBtnEvent);
        statePLAYING += new EveHandAppearHide(mgrTextGameOver.HideTextEvent);
        statePLAYING += new EveHandAppearHide(mgrTextToTitle.HideTextEvent);
        statePLAYING += new EveHandAppearHide(mgrBtnRetry.HideBtnEvent);
        gameOverBGM += new EveHandPLAYSE(mgrGameSE.BGMGameOverEvent);
        stateGAMEOVER += new EveHandAppearHide(playerController.HideBtnEvent);
        stateGAMEOVER += new EveHandAppearHide(mgrTextGameOver.AppearTextEvent);
        stateGAMEOVER += new EveHandAppearHide(mgrTextToTitle.AppearTextEvent);
        stateGAMEOVER += new EveHandAppearHide(mgrBtnRetry.AppearBtnEvent);
        GameReady();
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
                        //                        Debug.Log("double tap");
                        isDoubleTapStart = false;
                        doubleTapTime = 0.0f;
                        SceneManager.LoadScene("Title");
                    }
                }
                else
                {
                    //                    Debug.Log("reset");
                    // reset
                    isDoubleTapStart = false;
                    doubleTapTime = 0.0f;
                }
            }
            else
            {
                if (Input.GetMouseButtonDown(0))
                {
                    //                    Debug.Log("down");
                    isDoubleTapStart = true;
                }
            }
        }
    }

    void GameReady() {
        Invoke("GamePlaying", 0.1f);
    }

    void GamePlaying() {
        this.statePLAYING(this, EventArgs.Empty);
    }

    void GameIsOver() {
        stageBGM.Stop();
        this.stateGAMEOVER(this, EventArgs.Empty);
        this.gameOverBGM(this, EventArgs.Empty);
        gameOver = true;
    }

    public void ModeGameOver() {
        Invoke("GameIsOver", 0.5f);
    }
}