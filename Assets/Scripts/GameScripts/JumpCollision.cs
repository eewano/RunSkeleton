using System;
using UnityEngine;

public class JumpCollision : MonoBehaviour {

    private ManagerPlayerMaster managerPlayerMaster;
    private Mgr_PlayerBtnJumpCtrl mgrPlayerBtnJumpCtrl;

    private event EveHandPlayerMotion isGroundedON;

    private event EveHandPlayerMotion isGroundedOFF;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        mgrPlayerBtnJumpCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnJumpCtrl>();
    }

    void Start() {
        isGroundedON = new EveHandPlayerMotion(managerPlayerMaster.OrderToRun);
        isGroundedON = new EveHandPlayerMotion(mgrPlayerBtnJumpCtrl.IsGroundedON);

        isGroundedOFF = new EveHandPlayerMotion(managerPlayerMaster.OrderToJump);
        isGroundedOFF = new EveHandPlayerMotion(mgrPlayerBtnJumpCtrl.IsGroundedOFF);
    }

    void OnTriggerEnter(Collider other) {
        this.isGroundedON(this, EventArgs.Empty);
    }

    void OnTriggerExit(Collider other) {
        this.isGroundedOFF(this, EventArgs.Empty);
    }
}