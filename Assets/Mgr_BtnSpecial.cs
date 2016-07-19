using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnSpecial : MonoBehaviour {

    [SerializeField]
    private GameObject buttonSpecial;
    private Mgr_SETitle mgrSETitle;
    private ManagerTitleMaster managerTitleMaster;

    private event EveHandPLAYSE playSE_Enter;

    private event EveHandGotoStage goToStageSpecial;

    void Awake() {
        mgrSETitle = GameObject.Find("Mgr_SETitle").GetComponent<Mgr_SETitle>();
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
    }

    void Start() {
        playSE_Enter = new EveHandPLAYSE(mgrSETitle.SE_EnterEvent);
        goToStageSpecial = new EveHandGotoStage(managerTitleMaster.StartStage);
    }

    public void OnButtonSpecialClicked() {
        this.playSE_Enter(this, EventArgs.Empty);
        StartCoroutine(ToStageSpecial());
    }

    IEnumerator ToStageSpecial() {
        yield return new WaitForSeconds(1.0f);
        this.goToStageSpecial(this, 3);
    }
}