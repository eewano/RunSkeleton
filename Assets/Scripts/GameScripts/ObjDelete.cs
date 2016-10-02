using UnityEngine;

public class ObjDelete : MonoBehaviour {

    void OnTriggerEnter(Collider hit) {
        if (hit.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}