using System;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private float accelerationZ;
    [SerializeField]
    private float speedZ;
    [SerializeField]
    private float speedPlus;

    private ManagerGameMaster managerGameMaster;
    private Mgr_GameSE mgrGameSE;
    private CharacterController controller;
    private Animator animator;
    private CameraFollow01 cameraFollow;

    private const int DefaultLife = 1; //プレイヤーのライフ
    private const float StunDuration = 1.0f; //被ダメージ時の仰け反り時間

    private int life = DefaultLife;
    private float recoverTime = 0.0f;



    //左右移動関連----------
    [SerializeField]
    private float speedX;

    private Vector3 moveDirection = Vector3.zero;
    private bool Left = false;
    private bool Right = false;

    public void PushLeftDown() {
        Left = true;
    }

    public void PushLeftUp() {
        Left = false;
    }

    public void PushRightDown() {
        Right = true;
    }

    public void PushRightUp() {
        Right = false;
    }

    void MoveLeft() {
        this.transform.position += this.transform.right * Time.deltaTime * speedX * -1;
    }

    void MoveRight() {
        this.transform.position += this.transform.right * Time.deltaTime * speedX;
    }
    //左右移動関連----------



    //ジャンプ関連----------
    [SerializeField]
    private float speedJump;
    [SerializeField]
    private float gravity;

    private bool Jump = false;

    void PushJumpDown() {
        Jump = true;
    }

    void PushJumpUp() {
        Jump = false;
    }

    void MoveJump() {
        if (IsStan())
        {
            return; //仰け反り時の入力キャンセル
        }
        if (controller.isGrounded && Jump == true)
        {
            moveDirection.y = speedJump;
            animator.SetTrigger("Jump");
            this.jumpModeSE(this, EventArgs.Empty);
        }
    }
    //ジャンプ関連----------



    private event EventHandler jumpModeSE;

    private event EventHandler downModeSE;

    private event EventHandler fallModeSE;

    void Awake() {
        managerGameMaster = GameObject.Find("ManagerGameMaster").GetComponent<ManagerGameMaster>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        cameraFollow = GameObject.Find("Main Camera").GetComponent<CameraFollow01>();
    }

    void Start() {
        jumpModeSE += new EventHandler(mgrGameSE.SEJumpEvent);
        downModeSE += new EventHandler(mgrGameSE.SEDownEvent);
        downModeSE += new EventHandler(managerGameMaster.ModeGameOver);
        fallModeSE += new EventHandler(mgrGameSE.SEFallEvent);
        fallModeSE += new EventHandler(cameraFollow.PlayerFall);
        fallModeSE += new EventHandler(managerGameMaster.ModeGameOver);
        Application.targetFrameRate = 30;
    }

    void Update() {
        if (Life() <= 0)
        {
            Invoke("Dead", 1.5f); //ライフが0になったらプレイヤーを消去する
        }

        //移動を実行する
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        //重力分の力を毎フレーム追加する
        moveDirection.y -= gravity * Time.deltaTime;

        //移動後接地してたらY方向の速度はリセットする
        if (controller.isGrounded)
        {
            moveDirection.y = 0;
        }

        //速度が０以上なら走るアニメーションにする
        animator.SetBool("Run", moveDirection.z > 0.0f);

        speedZ += Time.deltaTime * speedPlus;

        if (Left && controller.isGrounded)
        {
            MoveLeft();
        }
        else if (Right && controller.isGrounded)
        {
            MoveRight();
        }
        else if (Jump)
        {
            MoveJump();
        }

        //仰け反り時の行動----------
        if (IsStan())
        {
            //動きを止めて仰け反り状態からの復帰カウントを進める
            moveDirection.x = 0.0f;
            moveDirection.z = 0.0f;
            speedX = 0.0f;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            //徐々に加速しながら前進する
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);
        }
        //仰け反り時の行動----------

        if (speedX < 12.0f)
        {
            speedX += 0.0008f;
        }
        else if (speedX >= 12.0f)
        {
            speedX = 12.0f;
        }
    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if (IsStan())
        {
            return;
        }

        if (hit.gameObject.tag == "Obstacle")
        {
            //ライフを減らして仰け反り状態に移行
            life--;
            recoverTime = StunDuration;
            animator.SetTrigger("Down");
            this.downModeSE(this, EventArgs.Empty);
        }

        if (hit.gameObject.tag == "Ball")
        {
            life--;
            recoverTime = StunDuration;
            animator.SetTrigger("Down");
            this.downModeSE(this, EventArgs.Empty);
            Destroy(hit.gameObject, 1.5f);
        }

        if (hit.gameObject.tag == "Fall")
        {
            speedX = 0.0f;
            life = 0;
            this.fallModeSE(this, EventArgs.Empty);
            Destroy(hit.gameObject);
        }
    }

    void Dead() {
        gameObject.SetActive(false);
    }

    //ライフ取得用の関数----------
    public int Life() {
        return life;
    }
    //ライフ取得用の関数----------

    //仰け反り判定----------
    private bool IsStan() {
        return recoverTime > 0.0f || life <= 0;
    }
    //仰け反り判定----------

    public void moveSpeedUp(object o, float i) {
        speedX += i;
    }
}