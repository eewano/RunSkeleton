using System;
using UnityEngine;

public class Mgr_GameText : MonoBehaviour {

    private Mgr_TextGameOver mgrTextGameOver;
    private Mgr_TextToTitle mgrTextToTitle;

    private event EveHandAppearHide statePLAYING;

    private event EveHandAppearHide stateGAMEOVER;

    void Awake() {
        mgrTextGameOver = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextGameOver>();
        mgrTextToTitle = GameObject.Find("Mgr_GameText").GetComponent<Mgr_TextToTitle>();
    }

    void Start() {
        //PLAYINGステート
        statePLAYING = new EveHandAppearHide(mgrTextGameOver.HideTextEvent);
        statePLAYING = new EveHandAppearHide(mgrTextToTitle.HideTextEvent);
        //GAMEOVERステート
        stateGAMEOVER = new EveHandAppearHide(mgrTextGameOver.AppearTextEvent);
        stateGAMEOVER = new EveHandAppearHide(mgrTextToTitle.AppearTextEvent);
    }

    public void StatePLAYING(object o, EventArgs e) {
        this.statePLAYING(this, EventArgs.Empty);
    }

    public void StateGAMEOVER(object o, EventArgs e) {
        this.stateGAMEOVER(this, EventArgs.Empty);
    }
}