using System.Collections.Generic;
using UnityEngine;

public class AreaGenerator : MonoBehaviour {

    const int AreaTipSize = 50;    //各エリアのZ軸の長さを50に統一
    private int currentTipIndex;

    [SerializeField]
    private Transform character;
    //エリアチッププレファブ配列
    [SerializeField]
    private GameObject[] areaEasy;
    [SerializeField]
    private GameObject[] areaNormal;
    [SerializeField]
    private GameObject[] areaHard;

    [SerializeField]
    private int [] createAreaEasyPercent;
    [SerializeField]
    private int [] createAreaNormalPercent;
    [SerializeField]
    private int [] createAreaHardPercent;
    //自動生成開始インデックス
    [SerializeField]
    private int startTipIndex;
    //生成先読み個数
    [SerializeField]
    private int preInstantiate;
    //生成済みエリアチップ保持リスト
    [SerializeField] List<GameObject> generatedAreaList = new List<GameObject>();

    private int areaEasyGroupPer = 50;
    private int areaNormalGroupPer = 35;
    private int areaHardGroupPer = 15;

    void Start() {
        if (areaEasy.Length != createAreaEasyPercent.Length) {
            Debug.LogError("Not Equal Array Length");
        }

        if (areaNormal.Length != createAreaNormalPercent.Length) {
            Debug.LogError("Not Equal Array Length");
        }

        if (areaHard.Length != createAreaHardPercent.Length) {
            Debug.LogError("Not Equal Array Length");
        }

        currentTipIndex = startTipIndex - 1;
        UpdateArea(preInstantiate);
    }

    void Update() {
        //キャラクターの位置から現在のエリアのインデックスを計算する
        int charaPositionIndex = (int)(character.position.z / AreaTipSize);

        //次のエリアに入ったらエリアの更新処理を行なう
        if (charaPositionIndex + preInstantiate > currentTipIndex) {
            UpdateArea(charaPositionIndex + preInstantiate);
        }
    }

    //指定のIndexまでのエリアを生成して、管理下に置く
    void UpdateArea(int toTipIndex) {
        if (toTipIndex <= currentTipIndex)
            return;

        //指定のエリアまでを作成
        for (int i = currentTipIndex + 1; i <= toTipIndex; i++) {
            GameObject areaObject = GenerateArea(i);

            //生成したエリアを管理リストに追加する
            generatedAreaList.Add(areaObject);
        }

        //エリア保持上限内になるまで古いエリアを削除する
        while (generatedAreaList.Count > preInstantiate + 1)
            DestroyOldestArea();

        currentTipIndex = toTipIndex;
    }

    //指定のインデックス位置にAreaオブジェクトをランダムに生成する
    GameObject GenerateArea(int tipIndex) {
        GameObject areaObject;
        int randomNum = Random.Range(1, 100);
        int i = 0;

        //Easyグループの場合
        if (randomNum > areaEasyGroupPer) {
            randomNum = Random.Range(1, 100);
            for (i = 0; i < areaEasy.Length - 1; i++) {
                if (randomNum > createAreaEasyPercent[i]) {
                    break;
                }
            }
            areaObject = (GameObject)Instantiate(
                    areaEasy[i],
                    new Vector3(0, 0, tipIndex * AreaTipSize),
                    Quaternion.identity);

            return areaObject;
        }

        //Normalグループの場合
        if (randomNum > areaNormalGroupPer) {
            randomNum = Random.Range(1, 100);
            for (i = 0; i < areaNormal.Length - 1; i++) {
                if (randomNum > createAreaNormalPercent[i]) {
                    break;
                }
            }
            areaObject = (GameObject)Instantiate(
                    areaNormal[i],
                    new Vector3(0, 0, tipIndex * AreaTipSize),
                    Quaternion.identity);

            return areaObject;
        }

        //Hardグループの場合
        if (randomNum > areaHardGroupPer) {
            randomNum = Random.Range(1, 100);
            for (i = 0; i < areaHard.Length - 1; i++) {
                if (randomNum > createAreaHardPercent[i]) {
                    break;
                }
            }
        }
        areaObject = (GameObject)Instantiate(
                areaHard[i],
                new Vector3(0, 0, tipIndex * AreaTipSize),
                Quaternion.identity);

        return areaObject;
    }

    //一番古いエリアを削除する
    void DestroyOldestArea() {
        GameObject oldArea = generatedAreaList[0];
        generatedAreaList.RemoveAt(0);
        Destroy(oldArea);
    }
}