using System;
using UnityEngine;

public class Mgr_PlayerAnim : MonoBehaviour {

    private Animator animator;

    void Awake() {
        animator = GetComponent<Animator>();
    }

	public void MotionRunEvent(object o, EventArgs e) {
        animator.SetBool("Run", true);
    }

    public void MotionJumpEvent(object o, EventArgs e) {
        animator.SetTrigger("Jump");
    }

    public void MotionDownEvent(object o, EventArgs e) {
        animator.SetTrigger("Down");
    }
}
