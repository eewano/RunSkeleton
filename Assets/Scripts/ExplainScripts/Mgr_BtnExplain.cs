using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnExplain : MonoBehaviour {

    [SerializeField]
    private GameObject buttonExplain;
    private Mgr_ButtonSE mgrSEButton;
    private ManagerTitleMaster managerTitleMaster;

    private event EveHandPLAYSE playSE_Explain;

    private event EveHandGotoStage goToExplain;

    void Awake() {
        mgrSEButton = GameObject.Find("Mgr_ButtonSE").GetComponent<Mgr_ButtonSE>();
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
    }

    void Start() {
        playSE_Explain = new EveHandPLAYSE(mgrSEButton.SE_ExplainEvent);
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