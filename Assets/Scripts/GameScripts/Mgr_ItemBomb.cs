using System;
using UnityEngine;

public class Mgr_ItemBomb : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    [SerializeField]
    private GameObject particleBomb;

    private PlayerController playerController;
    private Mgr_GameSE mgrGameSE;

    private Vector3 startPosition;
    private float amplitude = 0.05f;
    private float speed = 5.0f;

    private event EventHandler getBombEvent;

    void Start() {
        startPosition = transform.localPosition;
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        mgrGameSE = GameObject.Find("Mgr_GameSE").GetComponent<Mgr_GameSE>();

        getBombEvent += new EventHandler(playerController.getBomb);
        getBombEvent += new EventHandler(mgrGameSE.SEGetBombEvent);
    }

    void Update() {
        float y = amplitude * Mathf.Sin(Time.time * speed);
        transform.localPosition = startPosition + new Vector3(0, y, 0);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.getBombEvent(this, EventArgs.Empty);
            Destroy(gameObject);
            particleBomb = Instantiate(
                    particleBomb, transform.position, transform.rotation) as GameObject;
        }
    }
}