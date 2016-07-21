using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mgr_BtnRetry : MonoBehaviour {

    [SerializeField]
    private GameObject btnRetry;
    private Mgr_GameSE mgrGameSE;

    private event EveHandPLAYSE restartSE;

    void Awake() {
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();
    }

    void Start() {
        restartSE = new EveHandPLAYSE(mgrGameSE.SEJumpEvent);
        btnRetry.gameObject.SetActive(false);
    }

    public void AppearBtnEvent(object o, EventArgs e) {
        btnRetry.gameObject.SetActive(true);
    }

    public void HideBtnEvent(object o, EventArgs e) {
        btnRetry.gameObject.SetActive(false);
    }

    void OnButtonRestartClicked() {
        this.restartSE(this, EventArgs.Empty);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}