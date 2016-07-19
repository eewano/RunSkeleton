using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnNormal : MonoBehaviour {

    [SerializeField]
    private GameObject buttonNormal;
    private Mgr_SETitle mgrSETitle;
    private ManagerTitleMaster managerTitleMaster;

    private event EveHandPLAYSE playSE_Enter;

    private event EveHandGotoStage goToStageNormal;

    void Awake() {
        mgrSETitle = GameObject.Find("Mgr_SETitle").GetComponent<Mgr_SETitle>();
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
    }

    void Start() {
        playSE_Enter = new EveHandPLAYSE(mgrSETitle.SE_EnterEvent);
        goToStageNormal = new EveHandGotoStage(managerTitleMaster.StartStage);
    }

    public void OnButtonNormalClicked() {
        this.playSE_Enter(this, EventArgs.Empty);
        StartCoroutine(ToStageNormal());
    }

    IEnumerator ToStageNormal() {
        yield return new WaitForSeconds(1.0f);
        this.goToStageNormal(this, 1);
    }
}