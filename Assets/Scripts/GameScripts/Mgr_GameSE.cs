using System;
using UnityEngine;

public class Mgr_GameSE : MonoBehaviour {

    private AudioSource
    sEDown, sEFall, bgmGameOver, sEJump, sEMove;

    void Awake() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sEMove = audioSources[0];
        sEJump = audioSources[1];
        sEDown = audioSources[2];
        sEFall = audioSources[3];
        bgmGameOver = audioSources[4];
    }

    public void SEMoveEvent(object o, EventArgs e) {
        sEMove.PlayOneShot(sEMove.clip);
    }

    public void SEJumpEvent(object o, EventArgs e) {
        sEJump.PlayOneShot(sEJump.clip);
    }

    public void SEDownEvent(object o, EventArgs e) {
        sEDown.PlayOneShot(sEDown.clip);
    }

    public void SEFallEvent(object o, EventArgs e) {
        sEFall.PlayOneShot(sEFall.clip);
    }

    public void BGMGameOverEvent(object o, EventArgs e) {
        bgmGameOver.PlayOneShot(bgmGameOver.clip);
    }
}