using System;
using UnityEngine;
using UnityEngine.UI;

public class Mgr_TextGameOver : MonoBehaviour {

    [SerializeField]
    private Text gameOverText;

    void Start() {
        gameOverText.fontSize = 120;
        gameOverText.color = new Color32(255, 0, 0, 255);
        gameOverText.text = "";
    }

    public void AppearTextEvent(object o, EventArgs e) {
        gameOverText.text = "G A M E\nO V E R";
    }

    public void HideTextEvent(object o, EventArgs e) {
        gameOverText.text = "";
    }
}