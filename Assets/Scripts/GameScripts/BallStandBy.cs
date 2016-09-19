using System;
using UnityEngine;

public class BallStandBy : MonoBehaviour {

    private delegate void EventHandler(object sender, EventArgs e);

    private BallMove02 ballMove02;

    void Awake() {

    }

    void OnControllerColliderHit(ControllerColliderHit hit) {
        if (hit.gameObject.tag == "Player")
        {
        }
    }
}