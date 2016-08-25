using System;
using System.Collections;
using UnityEngine;

public class ManagerPlayerMaster : MonoBehaviour {

    private delegate void EveHandMotion(object sender, EventArgs e);

    private delegate void EveHandPLAYSE(object sender, EventArgs e);

    private GameObject player;
    private Mgr_PlayerAnim mgrPlayerAnim;
    private AreaGenerator areaGenerator;
    private Mgr_GameSE mgrGameSE;

    private event EveHandPLAYSE jumpSE;

    private event EveHandPLAYSE downSE;

    private event EveHandPLAYSE fallSE;

    private event EveHandMotion motionRUN;

    private event EveHandMotion motionJUMP;

    private event EveHandMotion motionDOWN;

    private event EveHandMotion motionFALL;

    private event EveHandMotion gameOverFlag;

    private enum State {
        RUN,
        JUMP,
        DOWN,
        FALL
    }

    private State statePlayer;

    void Awake() {
        player = GameObject.FindWithTag("Player");
        mgrPlayerAnim = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerAnim>();
        areaGenerator = GameObject.Find("AreaGenerator").GetComponent<AreaGenerator>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
    }

    void Start() {
        //RUNステート
        motionRUN += new EveHandMotion(mgrPlayerAnim.MotionRunEvent);
        //JUMPステート
        jumpSE += new EveHandPLAYSE(mgrGameSE.SEJumpEvent);
        motionJUMP += new EveHandMotion(mgrPlayerAnim.MotionJumpEvent);
        //DOWNステート
        downSE += new EveHandPLAYSE(mgrGameSE.SEDownEvent);
        motionDOWN += new EveHandMotion(mgrPlayerAnim.MotionDownEvent);
        gameOverFlag += new EveHandMotion(areaGenerator.GameOverFlag);
        //FALLステート
        fallSE += new EveHandPLAYSE(mgrGameSE.SEFallEvent);

        RunPlayer();
    }

    void Update() {
        switch (statePlayer) {
            case State.RUN:
                break;
            case State.JUMP:
                break;
            case State.DOWN:
                break;
            case State.FALL:
                break;
        }
    }

    void RunPlayer() {
        statePlayer = State.RUN;
        this.motionRUN(this, EventArgs.Empty);
    }

    void JUMPPlayer() {
        statePlayer = State.JUMP;
        this.jumpSE(this, EventArgs.Empty);
        this.motionJUMP(this, EventArgs.Empty);
    }

    void DOWNPlayer() {
        statePlayer = State.DOWN;
        this.downSE(this, EventArgs.Empty);
        this.motionDOWN(this, EventArgs.Empty);
        this.gameOverFlag(this, EventArgs.Empty);
        StartCoroutine(DeletePlayer());
    }

    void FALLPlayer() {
        statePlayer = State.DOWN;
        this.fallSE(this, EventArgs.Empty);
        this.motionFALL(this, EventArgs.Empty);
        StartCoroutine(DeletePlayer());
    }

    IEnumerator DeletePlayer() {
        yield return new WaitForSeconds(0.8f);
        player.gameObject.SetActive(false);
    }

    public void OrderToRun(object o, EventArgs e) {
        RunPlayer();
    }

    public void OrderToJump(object o, EventArgs e) {
        JUMPPlayer();
    }

    public void OrderToDown(object o, EventArgs e) {
        DOWNPlayer();
    }

    public void OrderToFall(object o, EventArgs e) {
        FALLPlayer();
    }
}