using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ManagerTitleMaster : MonoBehaviour {

    public static bool Special;

    private Text titleLabel;

    [SerializeField]
    private Text textScore01;
    [SerializeField]
    private Text textScore02;
    [SerializeField]
    private Text textScore03;
    [SerializeField]
    private GameObject Stage03Button;

    private Mgr_SETitle titleSoundEffect;

    void Awake() {
        if (PlayerPrefs.GetInt("Hiscore01") >= 3000 && PlayerPrefs.GetInt("Hiscore02") >= 4000)
            Special = true;
    }

    void Start() {
        Stage03Button.gameObject.SetActive(false);
        titleLabel = GameObject.Find("TitleLabel").GetComponent<Text>();
        textScore01.text = "Normal : " + PlayerPrefs.GetInt("Hiscore01") + "pts";
        textScore02.text = "Hard : " + PlayerPrefs.GetInt("Hiscore02") + "pts";
        textScore03.text = "";
        titleSoundEffect = GameObject.Find("TitleSoundEffect").GetComponent<Mgr_SETitle>();

        if (Special == true)
        {
            Stage03Button.gameObject.SetActive(true);
            textScore03.text = "Special : " + PlayerPrefs.GetInt("Hiscore03") + "pts";
            titleLabel.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }
    }

    void GoToDescription() {
        SceneManager.LoadScene("Description");
    }

    void GoToStage01() {
        SceneManager.LoadScene("Stage01");
    }

    void GoToStage02() {
        SceneManager.LoadScene("Stage02");
    }

    void GoToStage03() {
        SceneManager.LoadScene("Stage03");
    }

    public void StartStage(object o, int i) {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1 + i);
    }
}