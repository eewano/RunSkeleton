using System;
using UnityEngine;

public class Mgr_GameButton : MonoBehaviour {

    private PlayerController playerController;
    private Mgr_BtnRetry mgrBtnRetry;

    private event EveHandAppearHide btnModePLAYING;

    private event EveHandAppearHide btnModeGAMEOVER;

    void Awake() {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        mgrBtnRetry = GetComponent<Mgr_BtnRetry>();
    }

    void Start() {
        //PLAYINGステート
        btnModePLAYING = new EveHandAppearHide(playerController.AppearBtnEvent);
        btnModePLAYING = new EveHandAppearHide(mgrBtnRetry.HideBtnEvent);
        //GAMEOVERステート
        btnModeGAMEOVER = new EveHandAppearHide(playerController.HideBtnEvent);
        btnModeGAMEOVER = new EveHandAppearHide(mgrBtnRetry.AppearBtnEvent);
    }

    public void ModePLAYING(object o, EventArgs e) {
        this.btnModePLAYING(this, EventArgs.Empty);
    }

    public void ModeGAMEOVER(object o, EventArgs e) {
        this.btnModeGAMEOVER(this, EventArgs.Empty);
    }
}