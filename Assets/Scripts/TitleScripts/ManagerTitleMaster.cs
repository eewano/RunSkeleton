using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerTitleMaster : MonoBehaviour {

    [SerializeField]
    private Text textScoreNormal;
    [SerializeField]
    private Text textScoreHard;
    [SerializeField]
    private Text textScoreSpecial;
    //    [SerializeField]
    //    private GameObject buttonSpecial;

    void Start() {
        //        buttonSpecial.gameObject.SetActive(false);
        textScoreNormal.text = "NORMAL : " + PlayerPrefs.GetInt("HScore_NORMAL") + "pts";
        textScoreHard.text = "HARD : " + PlayerPrefs.GetInt("HScore_HARD") + "pts";

        //        if (PlayerPrefs.GetInt("Hiscore01") >= 3000 && PlayerPrefs.GetInt("Hiscore02") >= 4000)
        //        {
        //            buttonSpecial.gameObject.SetActive(true);
        //            textScoreSpecial.text = "Special : " + PlayerPrefs.GetInt("Hiscore03") + "pts";
        //        }
    }

    public void StartStage(object o, int i) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + i);
    }
}