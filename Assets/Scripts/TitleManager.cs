using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour {

    public static bool Stage01;
    public static bool Stage02;
    public static bool Stage03;
    public static bool Special;

    private Text titleLabel;

    [SerializeField]
    private Text hiScore01Label;
    [SerializeField]
    private Text hiScore02Label;
    [SerializeField]
    private Text hiScore03Label;
    [SerializeField]
    private GameObject Stage03Button;

    private TitleSoundEffect titleSoundEffect;

    void Awake() {
        if (PlayerPrefs.GetInt("Hiscore01") >= 3000 && PlayerPrefs.GetInt("Hiscore02") >= 4000)
            Special = true;
    }

    void Start() {
        Stage03Button.gameObject.SetActive(false);
        titleLabel = GameObject.Find("TitleLabel").GetComponent<Text>();
        hiScore01Label.text = "Normal : " + PlayerPrefs.GetInt("Hiscore01") + "pts";
        hiScore02Label.text = "Hard : " + PlayerPrefs.GetInt("Hiscore02") + "pts";
        hiScore03Label.text = "";
        titleSoundEffect = GameObject.Find("TitleSoundEffect").GetComponent<TitleSoundEffect>();
        Stage01 = false;
        Stage02 = false;
        Stage03 = false;

        if (Special == true)
        {
            Stage03Button.gameObject.SetActive(true);
            hiScore03Label.text = "Special : " + PlayerPrefs.GetInt("Hiscore03") + "pts";
            titleLabel.color = new Color(255f / 255f, 0f / 255f, 0f / 255f);
        }
    }

    public void OnDescriptionButtonClicked() {
        titleSoundEffect.Description();
        Invoke("GoToDescription", 1.0f);
    }

    public void OnStage01ButtonClicked() {
        titleSoundEffect.GameStart();
        Invoke("GoToStage01", 1.0f);
    }

    public void OnStage02ButtonClicked() {
        titleSoundEffect.GameStart();
        Invoke("GoToStage02", 1.0f);
    }

    public void OnStage03ButtonClicked() {
        titleSoundEffect.GameStart();
        Invoke("GoToStage03", 1.0f);
    }

    void GoToDescription() {
        SceneManager.LoadScene("Description");
    }

    void GoToStage01() {
        Stage01 = true;
        SceneManager.LoadScene("Stage01");
    }

    void GoToStage02() {
        Stage02 = true;
        SceneManager.LoadScene("Stage02");
    }

    void GoToStage03() {
        Stage03 = true;
        SceneManager.LoadScene("Stage03");
    }
}