using System;
using UnityEngine;

public class JumpCollider : MonoBehaviour {

    private Mgr_PlayerBtnJumpCtrl mgrPlayerBtnJumpCtrl;

    private event EveHandPlayerMotion isGroundedOn;

    void Awake() {
        mgrPlayerBtnJumpCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnJumpCtrl>();
    }

    void Start() {
        isGroundedOn = new EveHandPlayerMotion(mgrPlayerBtnJumpCtrl.IsGroundedON);
    }

    void OnTriggerStay(Collider col) {
        this.isGroundedOn(this, EventArgs.Empty);
    }
}