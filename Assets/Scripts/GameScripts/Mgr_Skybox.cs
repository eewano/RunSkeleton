using UnityEngine;
using System.Collections;

public class Mgr_Skybox : MonoBehaviour {

    // Skyboxのマテリアル
    public Material stage03Skybox;

    void Start() {
        // Skyboxを変更する
        RenderSettings.skybox = stage03Skybox;
    }

    void Update() {
    }
}