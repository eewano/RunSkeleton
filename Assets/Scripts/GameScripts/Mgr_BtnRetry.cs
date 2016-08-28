using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr_BtnRetry : MonoBehaviour {

    [SerializeField]
    private GameObject btnRetry;

    void Start() {
        btnRetry.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        btnRetry.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        btnRetry.gameObject.SetActive(false);
    }

    public void OnButtonRestartClicked() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}