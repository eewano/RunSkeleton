using System;
using UnityEngine;

public class Mgr_Ball01 : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    [SerializeField]
    private GameObject particleBall;

    private PlayerController playerController;

    private event EventHandler hitBallEvent;

    void Start() {
        playerController = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        hitBallEvent += new EventHandler(playerController.getBomb);
    }

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            this.hitBallEvent(this, EventArgs.Empty);
            Destroy(gameObject);
            particleBall = Instantiate(
                    particleBall, transform.position, transform.rotation) as GameObject;
        }
    }
}