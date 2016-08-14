using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGameMaster : MonoBehaviour {

    private Mgr_GameSE mgrGameSE;
    private Mgr_GameText mgrGameText;
    private Mgr_GameButton mgrGameButton;
    private AudioSource stageBGM;

    private float doubleTapTime;
    private bool isDoubleTapStart;
    private bool gameOver = false;

    private event EveHandPLAYSE gameOverBGM;

    private event EveHandMoveState eventPLAYING;

    private event EveHandMoveState eventGAMEOVER;

    void Awake() {
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
        mgrGameText = GameObject.Find("Mgr_GameText").GetComponent<Mgr_GameText>();
        mgrGameButton = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_GameButton>();
        stageBGM = GameObject.Find("StageBGM").GetComponent<AudioSource>();
    }

    void Start() {
        eventPLAYING = new EveHandMoveState(mgrGameText.ModePLAYING);
        eventPLAYING = new EveHandMoveState(mgrGameButton.ModePLAYING);
        gameOverBGM = new EveHandPLAYSE(mgrGameSE.BGMGameOverEvent);
        eventGAMEOVER = new EveHandMoveState(mgrGameText.ModeGAMEOVER);
        eventGAMEOVER = new EveHandMoveState(mgrGameButton.ModeGAMEOVER);
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
        }
    }

    void GameReady() {
        Invoke("GamePlaying", 0.1f);
    }

    void GamePlaying() {
        this.eventPLAYING(this, EventArgs.Empty);
    }

    void GameIsOver() {
        stageBGM.Stop();
        this.eventGAMEOVER(this, EventArgs.Empty);
        this.gameOverBGM(this, EventArgs.Empty);
        gameOver = true;
    }

    public void ModeGameOver() {
        Invoke("GameIsOver", 0.5f);
    }
}