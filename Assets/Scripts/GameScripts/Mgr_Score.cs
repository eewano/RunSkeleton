using UnityEngine;
using UnityEngine.UI;

public class Mgr_Score : MonoBehaviour {

    [SerializeField]
    private Text scoreText;
    [SerializeField]
    private Outline scoreOutLine;
    private PlayerController player;
    private int score;

    void Awake() {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
    }

    void Start() {
        scoreText.fontSize = 40;
        scoreText.color = new Color32(0, 0, 0, 255);
        scoreOutLine.effectDistance = new Vector2(2, 2);
        scoreOutLine.effectColor = new Color32(255, 255, 255, 255);
        scoreText.text = "Score : " + score + "pts";
    }

    void Update() {
        score = CalcScore();
        scoreText.text = "Score : " + score + "pts";
    }

    public void ChangeScore(object o, int i) {
        score += i;
    }

    private int CalcScore() {
        return (int)player.transform.position.z * 10;
    }
}