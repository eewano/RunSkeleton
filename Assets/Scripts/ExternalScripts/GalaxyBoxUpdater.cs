using UnityEngine;
using System.Collections;

public class GalaxyBoxUpdater : MonoBehaviour {

    [SerializeField]
    private Material galaxyBox;

    private Material workingMaterial;

    void Start() {
        workingMaterial = new Material(galaxyBox);
        RenderSettings.skybox = workingMaterial;
    }

    void Update() {
        workingMaterial.SetMatrix("_RotationMatrix", transform.localToWorldMatrix);
    }
}