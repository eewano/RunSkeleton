using System;
using System.Collections;
using UnityEngine;

public class Mgr_BtnTitleHard : MonoBehaviour {

    [SerializeField]
    private GameObject buttonHard;
    private Mgr_SEButton mgrSEButton;
    private ManagerTitleMaster managerTitleMaster;

    private event EveHandPLAYSE playSE_Enter;

    private event EveHandGotoStage goToStageHard;

    void Awake() {
        mgrSEButton = GameObject.Find("Mgr_SEButton").GetComponent<Mgr_SEButton>();
        managerTitleMaster = GameObject.Find("ManagerTitleMaster").GetComponent<ManagerTitleMaster>();
    }

    void Start() {
        playSE_Enter = new EveHandPLAYSE(mgrSEButton.SE_EnterEvent);
        goToStageHard = new EveHandGotoStage(managerTitleMaster.StartStage);
    }

    public void OnButtonHardClicked() {
        this.playSE_Enter(this, EventArgs.Empty);
        StartCoroutine(ToStageHard());
    }

    IEnumerator ToStageHard() {
        yield return new WaitForSeconds(1.0f);
        this.goToStageHard(this, 2);
    }
}