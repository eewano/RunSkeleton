using System;
using UnityEngine;

public class Mgr_PlayerCollision : MonoBehaviour {

    private delegate void EveHandMotion(object sender, EventArgs e);

    private ManagerPlayerMaster managerPlayerMaster;
    private ManagerGameMaster managerGameMaster;

    private event EveHandMotion playerObjHit;

    private event EveHandMotion playerFall;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        managerGameMaster = GameObject.Find("ManagerGameMaster").GetComponent<ManagerGameMaster>();
    }

    void Start() {
        playerObjHit += new EveHandMotion(managerPlayerMaster.OrderToDown);
        playerFall += new EveHandMotion(managerPlayerMaster.OrderToFall);
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