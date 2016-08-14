using System;
using UnityEngine;

public class Mgr_PlayerCollision : MonoBehaviour {

    private ManagerPlayerMaster managerPlayerMaster;
    private ManagerGameMaster managerGameMaster;

    private event EveHandMoveState playerObjHit;

    private event EveHandMoveState playerFall;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        managerGameMaster = GameObject.Find("ManagerGameMaster").GetComponent<ManagerGameMaster>();
    }

    void Start() {
        playerObjHit = new EveHandMoveState(managerPlayerMaster.OrderToDown);
        playerFall = new EveHandMoveState(managerPlayerMaster.OrderToFall);
    }

    void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.tag == "Obstacle" || hit.gameObject.tag == "Ball")
        {
            this.playerObjHit(this, EventArgs.Empty);
        }

        if (hit.gameObject.tag == "Fall")
        {
            this.playerFall(this, EventArgs.Empty);
        }
    }
}