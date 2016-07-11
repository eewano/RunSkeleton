using System;
using UnityEngine;

public class Mgr_PlayerKeyCtrl : MonoBehaviour {

    [SerializeField]
    private float keySpeed;

    private bool keyCtrl;

    void Start() {
        keyCtrl = true;
    }

    void Update() {
        if (keyCtrl == true)
        {
            float translation = Input.GetAxis("Horizontal") * keySpeed;
            translation *= Time.deltaTime;
            transform.Translate(translation, 0, 0);
        }
    }

    public void DisableKeyCtrl(object o, EventArgs e) {
        keyCtrl = false;
    }
}