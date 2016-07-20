using UnityEngine;
using System.Collections;

public class Mgr_SEExplain : MonoBehaviour {

    private AudioSource startSound;

    void Start() {
        startSound = GetComponent<AudioSource>();
    }

    public void GameStart() {
        startSound.PlayOneShot(startSound.clip);
    }
}