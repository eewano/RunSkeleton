using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnExplainSpecial : MonoBehaviour {

    [SerializeField]
    private GameObject buttonSpecial;
    private Mgr_SEButton mgrSEButton;
    private ManagerExplainMaster managerExplainMaster;

    private event EveHandPLAYSE playSE_Enter;

    private event EveHandGotoStage goToStageSpecial;

    void Awake() {
        mgrSEButton = GameObject.Find("Mgr_SEButton").GetComponent<Mgr_SEButton>();
        managerExplainMaster = GameObject.Find("ManagerExplainMaster").GetComponent<ManagerExplainMaster>();
    }

    void Start() {
        playSE_Enter = new EveHandPLAYSE(mgrSEButton.SE_EnterEvent);
        goToStageSpecial = new EveHandGotoStage(managerExplainMaster.StartStage);
    }

    public void OnButtonSpecialClicked() {
        this.playSE_Enter(this, EventArgs.Empty);
        StartCoroutine(ToStageSpecial());
    }

    IEnumerator ToStageSpecial() {
        yield return new WaitForSeconds(1.0f);
        this.goToStageSpecial(this, 2);
    }
}