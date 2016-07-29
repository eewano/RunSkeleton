using System;
using UnityEngine;

public class Mgr_PlayerBtnMoveCtrl : MonoBehaviour {

    [SerializeField]
    private GameObject btnLeft;
    [SerializeField]
    private GameObject btnRight;
    [SerializeField]
    private float moveSpeed;

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

    void Update() {
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

    void MoveLeft() {
        this.transform.position += this.transform.right * Time.deltaTime * moveSpeed * -1;
    }

    void MoveRight() {
        this.transform.position += this.transform.right * Time.deltaTime * moveSpeed;
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        btnLeft.gameObject.SetActive(true);
        btnRight.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        btnLeft.gameObject.SetActive(false);
        btnRight.gameObject.SetActive(false);
    }
}