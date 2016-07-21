using UnityEngine;
using System.Collections;

public class Mgr_BallObj : MonoBehaviour {

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "Player")
        {
            StartCoroutine(DeleteBall());
        }
    }

    IEnumerator DeleteBall() {
        yield return new WaitForSeconds(1.5f);
        Destroy(this.gameObject);
    }
}