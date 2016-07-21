using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerExplainMaster : MonoBehaviour {

    [SerializeField]
    private GameObject buttonSpecial;

    void Start() {
        buttonSpecial.gameObject.SetActive(false);

        if (PlayerPrefs.GetInt("Hiscore01") >= 3000 && PlayerPrefs.GetInt("Hiscore02") >= 4000)
        {
            buttonSpecial.gameObject.SetActive(true);
        }
    }

    public void StartStage(object o, int i) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + i);
    }
}