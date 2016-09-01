using System;
using UnityEngine;

//単純にMainCameraをプレイヤーオブジェクトの子オブジェクトにして映す方法を取らないのは、
//プレイヤーを隠したい時にカメラを追跡させない為（障害物に衝突した時や落下した時等）
public class CameraFollow02 : MonoBehaviour {

    private Vector3 diff;

    [SerializeField]
    private GameObject target;
    [SerializeField]
    private float followSpeed;

    private bool Fall = false;

    void Start() {
        diff = target.transform.position - transform.position;
    }

    void LateUpdate() {
        transform.position = Vector3.Lerp(
                transform.position,
                target.transform.position - diff,
                Time.deltaTime * followSpeed
        );

        if (Fall == true)
        {
            return;
        }
    }

    public void PlayerFall(object o, EventArgs e) {
        Fall = true;
    }
}