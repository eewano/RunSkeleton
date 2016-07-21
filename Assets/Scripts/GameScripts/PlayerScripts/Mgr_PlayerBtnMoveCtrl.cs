using System;
using UnityEngine;

public class Mgr_PlayerBtnMoveCtrl : MonoBehaviour {

    [SerializeField]
    private GameObject btnLeft;
    [SerializeField]
    private GameObject btnRight;
    [SerializeField]
    private float moveSpeed;
    private Mgr_GameSE mgrGameSE;

    private bool leftON = false;
    private bool rightON = false;

    void Awake() {
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
    }

    void Start() {
    }

    void Update() {
        if (leftON)
        {
            MoveLeft();
        } else if (rightON)
        {
            MoveRight();
        }
    }

    void PushLeftDown() {
        leftON = true;
    }

    void PushLeftUp() {
        leftON = false;
    }

    void PushRightDown() {
        rightON = true;
    }

    void PushRightUp() {
        rightON = false;
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
