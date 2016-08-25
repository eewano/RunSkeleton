using System;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private delegate void EveHandMotion(object sender, EventArgs e);

    private ManagerPlayerMaster managerPlayerMaster;
    private ManagerGameMaster managerGameMaster;

    private event EveHandMotion orderToJump;

    private event EveHandMotion playerObjHit;

    private event EveHandMotion playerFall;

    //左右移動関連----------
    [SerializeField]
    private GameObject btnLeft;
    [SerializeField]
    private GameObject btnRight;
    [SerializeField]
    private float maxSpeed = 3.0f;
    private float moveSpeed;
    private const float forceSpeed = 30.0f;
    private bool leftON = false;
    private bool rightON = false;

    public void PushLeftDown() {
        leftON = true;
    }

    public void PushLeftUp() {
        leftON = false;
    }

    public void PushRightDown() {
        rightON = true;
    }

    public void PushRightUp() {
        rightON = false;
    }

    void MoveLeft() {
        moveSpeed = Mathf.Abs(rb.velocity.x * -1.0f);
        if (moveSpeed < maxSpeed)
        {
            rb.AddForce(transform.right * forceSpeed * -1.0f);
        }
    }

    void MoveRight() {
        moveSpeed = Mathf.Abs(rb.velocity.x);
        if (moveSpeed < maxSpeed)
        {
            rb.AddForce(transform.right * forceSpeed);
        }
    }
    //左右移動関連----------

    //ジャンプ関連----------
    [SerializeField]
    private GameObject btnJump;
    [SerializeField]
    private float gravityPower = 0.2f;
    [SerializeField]
    private float jumpPower = 14.0f;
    private Rigidbody rb;
    private bool jumpON = false;

    public void OnBtnJumpClicked() {
        jumpON = true;
    }
    //ジャンプ関連----------

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
        managerGameMaster = GameObject.Find("ManagerGameMaster").GetComponent<ManagerGameMaster>();
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        orderToJump += new EveHandMotion(managerPlayerMaster.OrderToJump);
        playerObjHit += new EveHandMotion(managerPlayerMaster.OrderToDown);
        playerFall += new EveHandMotion(managerPlayerMaster.OrderToFall);
    }

    void Update() {
        ModeRun();
        ModeJump();

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4, 4), transform.position.y, transform.position.z);
    }

    void ModeRun() {
        if (rb.velocity.y >= -0.001f && rb.velocity.y <= 0.001f)
        {
            if (leftON == true)
            {
                MoveLeft();
            }
            else if (rightON == true)
            {
                MoveRight();
            }
            moveSpeed = 0.0f;
        }
    }

    void ModeJump() {
        if (rb.velocity.y >= -0.001f && rb.velocity.y <= 0.001f)
        {
            if (jumpON == true || Input.GetKeyDown(KeyCode.Space))
            {
                {
                    jumpON = false;
                    this.orderToJump(this, EventArgs.Empty);
                    float jumpHeight = Mathf.Sqrt(gravityPower * Mathf.Abs(Physics.gravity.y) * jumpPower);
                    rb.velocity = Vector3.up * jumpHeight;
                }
            }
        }
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        btnLeft.gameObject.SetActive(true);
        btnRight.gameObject.SetActive(true);
        btnJump.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        btnLeft.gameObject.SetActive(false);
        btnRight.gameObject.SetActive(false);
        btnJump.gameObject.SetActive(false);
    }

    void OnCollisionEnter(Collision hit) {
        if (hit.gameObject.tag == "Obstacle" || hit.gameObject.tag == "Ball")
        {
            this.playerObjHit(this, EventArgs.Empty);
            managerGameMaster.ModeGameOver();
        }

        if (hit.gameObject.tag == "Fall")
        {
            this.playerFall(this, EventArgs.Empty);
            managerGameMaster.ModeGameOver();
        }
    }
}