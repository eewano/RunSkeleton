using UnityEngine;

public class ItemSpawnPoint : MonoBehaviour {

    [SerializeField]
    private GameObject itemScorePrefab;
    [SerializeField]
    private GameObject itemBombPrefab;

    void Start() {
        int dice = Random.Range(0, 10);

        if (dice <= 4)
        {
            GameObject goItemScore = (GameObject)Instantiate(
                    itemScorePrefab,
                    Vector3.zero,
                    Quaternion.identity
            );
            goItemScore.transform.SetParent(transform, false);
        }
        else if (dice == 9)
        {
            GameObject goItemBomb = (GameObject)Instantiate(
                    itemBombPrefab,
                    Vector3.zero,
                    Quaternion.identity
            );
            goItemBomb.transform.SetParent(transform, false);
        }
    }
}