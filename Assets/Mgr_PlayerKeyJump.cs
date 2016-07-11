using UnityEngine;
using System.Collections;

public class Mgr_PlayerKeyJump : MonoBehaviour {

    [SerializeField]
    private float gravity;
    [SerializeField]
    private float jumpSpeed;
    private CharacterController charaCtrl;
    private Animator jumpAnimator;
    private Vector3 moveDirection = Vector3.zero;

    private bool keyJump = false;

    void Awake() {
        charaCtrl = GetComponent<CharacterController>();
        jumpAnimator = GetComponent<Animator>();
    }

    void Update() {
        if (charaCtrl.isGrounded)
        {
            moveDirection.y = 0;
        }

        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        charaCtrl.Move(globalDirection * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            MoveJump();
        }

        moveDirection.y -= gravity * Time.deltaTime;
    }

    void MoveJump() {
        if (charaCtrl.isGrounded) {
            moveDirection.y = jumpSpeed;
            jumpAnimator.SetTrigger("Jump");
        }
    }
}