using System;
using UnityEngine;

public class Mgr_BtnCtrl : MonoBehaviour {

    [SerializeField]
    private GameObject btnLeft;
    [SerializeField]
    private GameObject btnRight;
    [SerializeField]
    private GameObject btnJump;

    void Start() {
        btnLeft.gameObject.SetActive(true);
        btnRight.gameObject.SetActive(true);
        btnJump.gameObject.SetActive(true);
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
}