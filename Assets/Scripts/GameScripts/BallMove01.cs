using UnityEngine;

public class BallMove01 : MonoBehaviour {

    private const float amplitude = 5.0f;    //ボールのX軸の振れ幅
    private float speed;

    void Start() {
        speed = Random.Range(0.8f, 1.8f);
    }

    void Update() {
        //変位を計算する
        float x = amplitude * Mathf.Cos(Time.time * speed);

        //xを変位させたポジションに再設定する
        transform.localPosition = new Vector3(x, 0, 0);
    }
}