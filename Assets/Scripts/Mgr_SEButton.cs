using System;
using UnityEngine;

public class Mgr_SEButton : MonoBehaviour {

    private AudioSource sE_Explain;
    private AudioSource sE_Enter;

    void Start() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sE_Explain = audioSources[0];
        sE_Enter = audioSources[1];
    }

    public void SE_ExplainEvent(object o, EventArgs e) {
        sE_Explain.PlayOneShot(sE_Explain.clip);
    }

    public void SE_EnterEvent(object o, EventArgs e) {
        sE_Enter.PlayOneShot(sE_Enter.clip);
    }
}