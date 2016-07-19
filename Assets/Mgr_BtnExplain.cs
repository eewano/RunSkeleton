using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnExplain : MonoBehaviour {

    [SerializeField]
    private GameObject buttonExplain;
    private Mgr_SETitle mgrSETitle;
    private ManagerTitleMaster managerTitleMaster;

    private event EveHandPLAYSE playSE_Explain;

    private event EveHandGotoStage goToExplain;

    void Awake() {
        mgrSETitle = GameObject.Find("Mgr_SETitle").GetComponent<Mgr_SETitle>();
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
    }

    void Start() {
        playSE_Explain = new EveHandPLAYSE(mgrSETitle.SE_ExplainEvent);
        goToExplain = new EveHandGotoStage(managerTitleMaster.StartStage);
    }

    public void OnButtonExplainClicked() {
        this.playSE_Explain(this, EventArgs.Empty);
        StartCoroutine(ToExplain());
    }

    IEnumerator ToExplain() {
        yield return new WaitForSeconds(1.0f);
        this.goToExplain(this, 0);
    }
}