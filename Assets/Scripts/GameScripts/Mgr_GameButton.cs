using System;
using UnityEngine;

public class Mgr_GameButton : MonoBehaviour {

    private Mgr_PlayerBtnMoveCtrl mgrPlayerBtnMoveCtrl;
    private Mgr_PlayerBtnJumpCtrl mgrPlayerBtnJumpCtrl;
    private Mgr_BtnRetry mgrBtnRetry;

    private event EveHandAppearHide statePLAYING;

    private event EveHandAppearHide stateGAMEOVER;

    void Awake() {
        mgrPlayerBtnMoveCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnMoveCtrl>();
        mgrPlayerBtnJumpCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnJumpCtrl>();
        mgrBtnRetry = GameObject.Find("Mgr_GameButton").GetComponent<Mgr_BtnRetry>();
    }

    void Start() {
        //PLAYINGステート
        statePLAYING = new EveHandAppearHide(mgrPlayerBtnMoveCtrl.AppearBtnEvent);
        statePLAYING = new EveHandAppearHide(mgrPlayerBtnJumpCtrl.AppearBtnEvent);
        statePLAYING = new EveHandAppearHide(mgrBtnRetry.AppearBtnEvent);
        //GAMEOVERステート
        stateGAMEOVER = new EveHandAppearHide(mgrPlayerBtnMoveCtrl.HideBtnEvent);
        stateGAMEOVER = new EveHandAppearHide(mgrPlayerBtnJumpCtrl.HideBtnEvent);
        stateGAMEOVER = new EveHandAppearHide(mgrBtnRetry.HideBtnEvent);
    }

    public void StatePLAYING(object o, EventArgs e) {
        this.statePLAYING(this, EventArgs.Empty);
    }

    public void StateGAMEOVER(object o, EventArgs e) {
        this.stateGAMEOVER(this, EventArgs.Empty);
    }
}