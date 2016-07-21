using System;
using UnityEngine;

public class Mgr_PlayerBtnJumpCtrl : MonoBehaviour {

    [SerializeField]
    private float jumpHeight = 4.0f;
    [SerializeField]
    private GameObject btnJump;
    private ManagerPlayerMaster managerPlayerMaster;
    private Rigidbody rb;
    private float speedY;

    private bool isGrounded;
    private bool jumpMode = false;

    private event EveHandMoveState orderToJump;

    void Awake() {
        managerPlayerMaster = GameObject.FindWithTag("Player").GetComponent<ManagerPlayerMaster>();
        rb = GetComponent<Rigidbody>();
    }

    void Start() {
        orderToJump = new EveHandMoveState(managerPlayerMaster.OrderToJump);
    }

    void Update() {
        if (isGrounded == true)
        {
            if (jumpMode == true || Input.GetKey(KeyCode.Space))
            {
                this.orderToJump(this, EventArgs.Empty);
                speedY = Mathf.Sqrt(0.5f * Mathf.Abs(Physics.gravity.y) * jumpHeight);
                rb.velocity = Vector3.up * speedY;
                isGrounded = false;
                jumpMode = false;
            }
        }
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        btnJump.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        btnJump.gameObject.SetActive(false);
    }

    public void IsGroundedON(object o, EventArgs e) {
        isGrounded = true;
    }

    public void OnBtnJumpClicked() {
        if (isGrounded == true)
        {
            jumpMode = true;
        }
    }
}