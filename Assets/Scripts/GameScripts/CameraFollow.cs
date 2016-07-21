using UnityEngine;
using System.Collections;

//単純にMainCameraをプレイヤーオブジェクトの子オブジェクトにして映す方法を取らないのは、
//プレイヤーを隠したい時にカメラを追跡させない為（障害物に衝突した時や落下した時等）
public class CameraFollow : MonoBehaviour {

    [SerializeField]
    private ManagerPlayerMaster player;
    [SerializeField]
    private Transform target;
    private Vector3 offset;

    void Start() {
        offset = GetComponent<Transform>().position - target.position * Time.deltaTime;
    }

    void Update() {
        GetComponent<Transform>().position = target.position + offset;
    }

    void CameraStop() {
        return;
    }
}