using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnExplainNormal : MonoBehaviour {

    [SerializeField]
    private GameObject buttonNormal;
    private Mgr_ButtonSE mgrSEButton;
    private ManagerExplainMaster managerExplainMaster;

    private event EveHandPLAYSE playSE_Enter;

    private event EveHandGotoStage goToStageNormal;

    void Awake() {
        mgrSEButton = GameObject.Find("Mgr_ButtonSE").GetComponent<Mgr_ButtonSE>();
        managerExplainMaster = GameObject.Find("ManagerExplainMaster").GetComponent<ManagerExplainMaster>();
    }

    void Start() {
        playSE_Enter = new EveHandPLAYSE(mgrSEButton.SE_EnterEvent);
        goToStageNormal = new EveHandGotoStage(managerExplainMaster.StartStage);
    }

    public void OnButtonNormalClicked() {
        this.playSE_Enter(this, EventArgs.Empty);
        StartCoroutine(ToStageNormal());
    }

    IEnumerator ToStageNormal() {
        yield return new WaitForSeconds(1.0f);
        this.goToStageNormal(this, 0);
    }
}