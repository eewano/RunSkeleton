using System;
using UnityEngine;

public class BallMove02 : MonoBehaviour {

    void Start() {
        gameObject.SetActive(false);
    }

    public void BallAppear(object o, EventArgs e) {
        gameObject.SetActive(true);
    }

    void OnTriggerEnter(Collider col) {
        if(col.gameObject.tag == "Ball02StandBy")
        {
            Destroy(gameObject);
        }
    }
}