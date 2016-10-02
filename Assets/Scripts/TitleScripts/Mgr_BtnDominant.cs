using UnityEngine;
using UnityEngine.UI;

public class Mgr_BtnDominant : MonoBehaviour {

    [SerializeField]
    private Text ctrlBtnText;
    private string keyDominant = "Dominant";

    void Start() {
        if (PlayerPrefs.GetInt("Dominant") == 0 || PlayerPrefs.GetInt("Dominant") == 2)
        {
            ctrlBtnText.text = "右 利き";
        }
        else if (PlayerPrefs.GetInt("Dominant") == 1)
        {
            ctrlBtnText.text = "左 利き";
        }
    }

    public void OnButtonDominantClicked() {
        if (PlayerPrefs.GetInt("Dominant") == 0 || PlayerPrefs.GetInt("Dominant") == 2)
        {
            ctrlBtnText.text = "左 利き";
            PlayerPrefs.SetInt(keyDominant, 1);
        }
        else if (PlayerPrefs.GetInt("Dominant") == 1)
        {
            ctrlBtnText.text = "右 利き";
            PlayerPrefs.SetInt(keyDominant, 2);
        }
    }
}