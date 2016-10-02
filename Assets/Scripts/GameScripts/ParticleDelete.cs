using UnityEngine;

public class ParticleDelete : MonoBehaviour {

    void Start() {
        DeleteObj();
    }

    void DeleteObj() {
        Destroy(gameObject, 1.3f);
    }
}