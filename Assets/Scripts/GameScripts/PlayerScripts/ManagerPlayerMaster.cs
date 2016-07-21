using System;
using UnityEngine;

public class ManagerPlayerMaster : MonoBehaviour {

    private Mgr_PlayerAnim mgrPlayerAnim;
    private Mgr_PlayerBtnMoveCtrl mgrPlayerBtnMoveCtrl;
    private Mgr_PlayerBtnJumpCtrl mgrPlayerBtnJumpCtrl;
    private AreaGenerator areaGenerator;
    private Mgr_GameSE mgrGameSE;

    private event EveHandPLAYSE jumpSE;

    private event EveHandPLAYSE downSE;

    private event EveHandPLAYSE fallSE;

    private event EveHandPlayerMotion stateRUN;

    private event EveHandPlayerMotion stateJUMP;

    private event EveHandPlayerMotion stateDOWN;

    private event EveHandPlayerMotion stateFALL;

    private event EveHandGameOver gameOverFlag;

    enum State {
        RUN,
        JUMP,
        DOWN,
        FALL
    }

    private State statePlayer;

    void Awake() {
        mgrPlayerAnim = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerAnim>();
        mgrPlayerBtnMoveCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnMoveCtrl>();
        mgrPlayerBtnJumpCtrl = GameObject.FindWithTag("Player").GetComponent<Mgr_PlayerBtnJumpCtrl>();
        areaGenerator = GameObject.Find("AreaGenerator").GetComponent<AreaGenerator>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
    }

    void Start() {
        //RUNステート
        stateRUN = new EveHandPlayerMotion(mgrPlayerAnim.MotionRunEvent);
        //JUMPステート
        jumpSE = new EveHandPLAYSE(mgrGameSE.SEJumpEvent);
        stateJUMP = new EveHandPlayerMotion(mgrPlayerAnim.MotionJumpEvent);
        //DOWNステート
        downSE = new EveHandPLAYSE(mgrGameSE.SEDownEvent);
        stateDOWN = new EveHandPlayerMotion(mgrPlayerAnim.MotionDownEvent);
        gameOverFlag = new EveHandGameOver(areaGenerator.GameOverFlag);
        //FALLステート
        fallSE = new EveHandPLAYSE(mgrGameSE.SEFallEvent);

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
        this.stateRUN(this, EventArgs.Empty);
    }

    void JUMPPlayer() {
        statePlayer = State.JUMP;
        this.jumpSE(this, EventArgs.Empty);
        this.stateJUMP(this, EventArgs.Empty);
    }

    void DOWNPlayer() {
        statePlayer = State.DOWN;
        this.downSE(this, EventArgs.Empty);
        this.stateDOWN(this, EventArgs.Empty);
        this.gameOverFlag(this, EventArgs.Empty);
    }

    void FALLPlayer() {
        statePlayer = State.DOWN;
        this.fallSE(this, EventArgs.Empty);
        this.stateFALL(this, EventArgs.Empty);
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

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Obstacle" || hit.gameObject.tag == "Ball")
        {
            DOWNPlayer();
        }

        if (hit.gameObject.tag == "Fall")
        {
            FALLPlayer();
        }
    }
}