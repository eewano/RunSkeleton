using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour {

	[SerializeField] private Text GameIsOver;
	[SerializeField] private Text scoreLabel;
	[SerializeField] private Text TapToTitle;
	[SerializeField] private GameObject ButtonLeft;
	[SerializeField] private GameObject ButtonRight;
	[SerializeField] private GameObject ButtonJump;

	private AudioSource stageBGM;
	private StageSoundEffect stageSoundEffect;
    private PlayerController playerController;

    void Awake()
    {
        stageBGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        stageSoundEffect = GameObject.Find("StageSoundEffect").GetComponent<StageSoundEffect>();
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
    }

	void Start()
	{
        GameIsOver.enabled = false;
        TapToTitle.enabled = false;

		StartCoroutine(GamePlaying());
	}

	void Update()
    {
        if(playerController.Life() <= 0) {
            if(Input.GetMouseButtonDown(0)) {
				SceneManager.LoadScene("Title");
			}
        }
	}

    IEnumerator GamePlaying() {



		while (true) {
            int score = CalcScore();
            scoreLabel.text = "Score : " + score + "pts";

		    if (playerController.Life() <= 0)
		    {
			    if (PlayerPrefs.GetInt("Hicore") < score) {
				    PlayerPrefs.SetInt("Hiscore", score);
			    }
			    yield return new WaitForSeconds(0.5f);
                Debug.Log("GAMEOVER");
			    stageBGM.Stop();
			    stageSoundEffect.GameIsOver();
                GameIsOver.enabled = true;
                TapToTitle.enabled = true;
			    break;
		    }
        }
	}

	//-----プレイヤーの走行距離をスコアとする-----
	int CalcScore()
	{
		return(int)playerController.transform.position.z;
	}
}