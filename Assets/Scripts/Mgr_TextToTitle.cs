using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TextToTitle : MonoBehaviour {

    [SerializeField]
    private Text toTitleText;
    [SerializeField]
    private Outline toTitleOutLine;

    void Start() {
        toTitleText.fontSize = 40;
        toTitleText.color = new Color32(255, 0, 128, 255);
        toTitleOutLine.effectDistance = new Vector2(2, 2);
        toTitleOutLine.effectColor = new Color32(255, 255, 255, 255);
        toTitleText.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        toTitleText.text = "画 面 を ダ ブ ル タ ッ プ\nし て 下 さ い 。";
    }

    public void HideTextEvent(object o, EventArgs e) {
        toTitleText.text = "";
    }
}