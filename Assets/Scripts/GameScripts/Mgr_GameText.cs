using System;
using UnityEngine;

public class Mgr_GameText : MonoBehaviour {

    private Mgr_TextGameOver mgrTextGameOver;
    private Mgr_TextToTitle mgrTextToTitle;

    private event EveHandAppearHide textModePLAYING;

    private event EveHandAppearHide textModeGAMEOVER;

    void Awake() {
        mgrTextGameOver = GetComponent<Mgr_TextGameOver>();
        mgrTextToTitle = GetComponent<Mgr_TextToTitle>();
    }

    void Start() {
        //PLAYINGステート
        textModePLAYING = new EveHandAppearHide(mgrTextGameOver.HideTextEvent);
        textModePLAYING = new EveHandAppearHide(mgrTextToTitle.HideTextEvent);
        //GAMEOVERステート
        textModeGAMEOVER = new EveHandAppearHide(mgrTextGameOver.AppearTextEvent);
        textModeGAMEOVER = new EveHandAppearHide(mgrTextToTitle.AppearTextEvent);
    }

    public void ModePLAYING(object o, EventArgs e) {
        this.textModePLAYING(this, EventArgs.Empty);
    }

    public void ModeGAMEOVER(object o, EventArgs e) {
        this.textModeGAMEOVER(this, EventArgs.Empty);
    }
}