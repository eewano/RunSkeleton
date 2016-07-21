using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerGameMaster : MonoBehaviour {

    private Mgr_GameText mgrGameText;
    private Mgr_GameSE mgrGameSE;
    private AudioSource stageBGM;
    private float doubleTapTime;
    private bool isDoubleTapStart;

    private event EveHandPLAYSE gameOverBGM;

    private event EveHandMoveState eventPLAYING;

    private event EveHandMoveState eventGAMEOVER;

    enum State {
        PLAYING,
        GAMEOVER
    }

    private State state;

    void Awake() {
        mgrGameText = GameObject.Find("Mgr_GameText").GetComponent<Mgr_GameText>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
        stageBGM = GameObject.Find("StageBGM").GetComponent<AudioSource>();
    }

    void Start() {
        //PLAYINGステート
        eventPLAYING = new EveHandMoveState(mgrGameText.StatePLAYING);
        //GAMEOVERステート
        gameOverBGM = new EveHandPLAYSE(mgrGameSE.BGMGameOverEvent);
        eventGAMEOVER = new EveHandMoveState(mgrGameText.StateGAMEOVER);
        Playing();
    }

    void Update() {
        switch (state) {

            case State.PLAYING:
                break;

            case State.GAMEOVER:
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
                break;
        }
    }

    void Playing() {
        state = State.PLAYING;
        this.eventPLAYING(this, EventArgs.Empty);
    }

    void GameOver() {
        state = State.GAMEOVER;
        stageBGM.Stop();
        this.eventGAMEOVER(this, EventArgs.Empty);
    }
}