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

        if (Input.GetKeyDown(KeyCode.Space))
        {
            keyJump = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            keyJump = false;
        }


        if (keyJump == true)
        {
            JumpMode();
        }
    }

    void JumpMode() {
        if (charaCtrl.isGrounded && keyJump == true) {
            moveDirection.y = jumpSpeed;
            jumpAnimator.SetTrigger("Jump");
        }
    }
}