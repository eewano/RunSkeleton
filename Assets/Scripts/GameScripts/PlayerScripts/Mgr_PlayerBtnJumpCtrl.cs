using System;
using UnityEngine;

public class Mgr_PlayerBtnJumpCtrl : MonoBehaviour {

    [SerializeField]
    private float jumpHeight = 10.0f;
    [SerializeField]
    private float gravityPower = 1.0f;
    [SerializeField]
    private GameObject btnJump;
    private ManagerPlayerMaster managerPlayerMaster;
    private Rigidbody rb;
    private float speedY;

    private bool isGrounded;
    private bool jumpMode = false;

    private event EveHandMoveState orderToJump;

    void Awake() {
        managerPlayerMaster = GameObject.Find("ManagerPlayerMaster").GetComponent<ManagerPlayerMaster>();
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
                speedY = Mathf.Sqrt(gravityPower * Mathf.Abs(Physics.gravity.y) * jumpHeight);
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
        Debug.Log("true");
        isGrounded = true;
    }

    public void IsGroundedOFF(object o, EventArgs e) {
        Debug.Log("false");
        isGrounded = false;
    }

    public void OnBtnJumpClicked() {
        if (isGrounded == true)
        {
            jumpMode = true;
        }
    }
}