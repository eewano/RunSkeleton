using System;
using UnityEngine;

public class Mgr_ItemScore : MonoBehaviour {

    private delegate void EveHandItemGet(object sender, int i);

    private delegate void EveHandPlaySE(object sender, EventArgs e);

    private Mgr_Score mgrScore;
    private Mgr_GameSE mgrGameSE;

    private Vector3 startPosition;
    private float amplitude = 0.05f;
    private float speed = 5.0f;

    private event EveHandItemGet getItemEvent;

    private event EveHandPlaySE sEPlayEvent;

    void Start() {
        startPosition = transform.localPosition;
        mgrScore = GameObject.Find("Mgr_GameText").GetComponent<Mgr_Score>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();

        getItemEvent += new EveHandItemGet(mgrScore.ChangeScore);
        sEPlayEvent += new EveHandPlaySE(mgrGameSE.SEGetItemEvent);
    }

    void Update() {
        float y = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = startPosition + new Vector3(0, y, 0);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.getItemEvent(this, 400);
            this.sEPlayEvent(this, EventArgs.Empty);
        }
        Destroy(gameObject);
    }
}