using UnityEngine;
using System.Collections;

public class ObjSpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject prefab;

    void Start() {
        //プレハブを同ポジションに生成
        GameObject go = (GameObject)Instantiate(
                prefab,
                Vector3.zero,
                Quaternion.identity
        );

        //一緒に削除される様に生成した敵オブジェクトを子に設定
        go.transform.SetParent(transform, false);
    }

    void OnDrawGizmos() {
        //ギズモの底辺が地面と同じ高さになる様にオフセットを設定
        Vector3 offset = new Vector3(0, 0.5f, 0);

        //球を表示
        Gizmos.color = new Color(1, 0, 0, 0.5f);
        Gizmos.DrawSphere(transform.position + offset, 0.5f);

        //プレハブ名のアイコンを表示
        if (prefab != null)
        {
            Gizmos.DrawIcon(transform.position + offset, prefab.name, true);
        }
    }
}