using UnityEngine;

public class Mgr_BtnCtrlPlace : MonoBehaviour {

    private RectTransform ctrlBtnPanel;
    private float x, y;

    void Awake() {
        ctrlBtnPanel = GameObject.Find("ButtonPanel").GetComponent<RectTransform>();
    }

    void Start() {
        if (PlayerPrefs.GetInt("Dominant") == 1)
        {
            ctrlBtnPanel.localPosition = new Vector3(-135.0f, -260.0f);
        }
        else if (PlayerPrefs.GetInt("Dominant") == 2)
        {
            ctrlBtnPanel.localPosition = new Vector3(135.0f, -260.0f);
        }
    }
}