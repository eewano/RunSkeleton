using System;
using UnityEngine;

public class Mgr_GameButton : MonoBehaviour {

    private Mgr_PlayerBtnMoveCtrl mgrPlayerBtnMoveCtrl;
    private Mgr_PlayerBtnJumpCtrl mgrPlayerBtnJumpCtrl;
    private Mgr_BtnRetry mgrBtnRetry;

    private event EveHandAppearHide btnModePLAYING;

    private event EveHandAppearHide btnModeGAMEOVER;

    void Awake() {
        mgrPlayerBtnMoveCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnMoveCtrl>();
        mgrPlayerBtnJumpCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnJumpCtrl>();
        mgrBtnRetry = GetComponent<Mgr_BtnRetry>();
    }

    void Start() {
        //PLAYINGステート
        btnModePLAYING = new EveHandAppearHide(mgrPlayerBtnMoveCtrl.AppearBtnEvent);
        btnModePLAYING = new EveHandAppearHide(mgrPlayerBtnJumpCtrl.AppearBtnEvent);
        btnModePLAYING = new EveHandAppearHide(mgrBtnRetry.HideBtnEvent);
        //GAMEOVERステート
        btnModeGAMEOVER = new EveHandAppearHide(mgrPlayerBtnMoveCtrl.HideBtnEvent);
        btnModeGAMEOVER = new EveHandAppearHide(mgrPlayerBtnJumpCtrl.HideBtnEvent);
        btnModeGAMEOVER = new EveHandAppearHide(mgrBtnRetry.AppearBtnEvent);
    }

    public void ModePLAYING(object o, EventArgs e) {
        this.btnModePLAYING(this, EventArgs.Empty);
    }

    public void ModeGAMEOVER(object o, EventArgs e) {
        this.btnModeGAMEOVER(this, EventArgs.Empty);
    }
}