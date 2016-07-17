using System;
using UnityEngine;

public class Mgr_GameSE : MonoBehaviour {

    private AudioSource sEDown;
    private AudioSource sEFall;
    private AudioSource bgmGameOver;
    private AudioSource sEJump;
    private AudioSource sEMove;

    void Start() {
        AudioSource[] audioSources = GetComponents<AudioSource>();
        sEDown = audioSources[0];
        sEFall = audioSources[1];
        bgmGameOver = audioSources[2];
        sEJump = audioSources[3];
        sEMove = audioSources[4];
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

    public void SEJumpEvent(object o, EventArgs e) {
        sEJump.PlayOneShot(sEJump.clip);
    }

    public void SEMoveEvent(object o, EventArgs e) {
        sEMove.PlayOneShot(sEMove.clip);
    }
}