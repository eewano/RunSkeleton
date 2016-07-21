using System;
using UnityEngine;

public class AreaGenerator : MonoBehaviour {

    [SerializeField]
    private GameObject firstArea;
    [SerializeField]
    private GameObject[] CreateAreas;
    [SerializeField]
    private float nowSpeed = 4.0f;
    [SerializeField]
    private float speedPlus = 0.05f;
    private const float AreaWidth = 50.0f;
    private GameObject[] Areas = new GameObject[4];

    private bool areaStop = false;

    void Awake() {
        firstArea.transform.localPosition = new Vector3(0, 0, 0);
    }

    void Start() {
        for (int i = 0; i < Areas.Length; i++) {
            Areas[i] = null;
            {
                Areas[i] = Instantiate(CreateAreas[UnityEngine.Random.Range(0, CreateAreas.Length)]);
                Areas[i].transform.localPosition = new Vector3(0, 0, i * 50 + 50);
                Areas[i].transform.parent = this.transform;
            }
        }
    }

    void Update() {
        nowSpeed += Time.deltaTime * speedPlus;

        for (int i = 0; i < Areas.Length; i++) {
            if (Areas[i] == null)
            {
                Areas[i] = Instantiate(CreateAreas[UnityEngine.Random.Range(0, CreateAreas.Length)]);
                Areas[i].transform.localPosition = new Vector3(0, 0, i * AreaWidth);
                Areas[i].transform.parent = this.transform;
            }

            if (areaStop == false)
            {
                if (firstArea != null)
                {
                    firstArea.transform.localPosition = new Vector3(
                            firstArea.transform.localPosition.x,
                            firstArea.transform.localPosition.y,
                            firstArea.transform.localPosition.z - Time.deltaTime * nowSpeed * 0.25f);
                }

                Areas[i].transform.localPosition = new Vector3(
                        Areas[i].transform.localPosition.x,
                        Areas[i].transform.localPosition.y,
                        Areas[i].transform.localPosition.z - Time.deltaTime * nowSpeed);
            }

            if (Areas[0].transform.localPosition.z < -50)
            {
                Destroy(firstArea);
                firstArea = null;
                Destroy(Areas[0]);
                Areas[0] = null;

                for (int f = 0; f < Areas.Length - 1; f++) {
                    if (Areas[f] == null)
                    {
                        Areas[f] = Areas[f + 1];
                        Areas[f + 1] = null;
                    }
                }
            }
        }
    }

    public void GameOverFlag(object o, EventArgs e) {
        areaStop = true;
    }
}