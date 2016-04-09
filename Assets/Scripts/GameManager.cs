using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	enum State {PLAYING, GAMEOVER, EMPTY}
	private State state;

	[SerializeField] private PlayerController player;
	[SerializeField] private Text score01Label;
	[SerializeField] private Text score02Label;
	[SerializeField] private GameObject ButtonLeft;
	[SerializeField] private GameObject ButtonRight;
	[SerializeField] private GameObject ButtonJump;

    private Text gameOverLabel;
    private Text toTitleLabel;
	private AudioSource stageBGM;
	private StageSoundEffect stageSoundEffect;

    void Awake()
    {
        gameOverLabel = GameObject.Find("GameOverLabel").GetComponent<Text>();
        toTitleLabel = GameObject.Find("ToTitleLabel").GetComponent<Text>();
        stageBGM = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        stageSoundEffect = GameObject.Find("StageSoundEffect").GetComponent<StageSoundEffect>();
    }

	void Start()
	{
        gameOverLabel.text = "";
        toTitleLabel.text = "";
		Playing ();
	}

	void Update()
	{
		switch (state) {

		case State.PLAYING:
			//-----NORMAL STAGE のスコアラベルを更新する-----
			if (TitleManager.Stage01) {
				int score01 = CalcScoreStage01 ();
				score01Label.text = "Score : " + score01 + "pts";
				if (player.Life () <= 0) {
					if (PlayerPrefs.GetInt ("Hiscore01") < score01) {
						PlayerPrefs.SetInt ("Hiscore01", score01);	//NORMAL STAGE のハイスコアを更新する
					}
					//Invokeで0.5病後にGameOver関数を呼び出すが、この0.5秒間に続けてInvokeがひたすら呼び出されてしまう。
					Invoke ("GameOver", 0.5f);
					//よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
                    state = State.EMPTY;
				}
			}
			//----------

			//-----HARD STAGE のスコアラベルを更新する-----
			else if(TitleManager.Stage02) {
				int score02 = CalcScoreStage02 ();
				score02Label.text = "Score : " + score02 + "pts";
				if (player.Life () <= 0) {
					if (PlayerPrefs.GetInt ("Hiscore02") < score02) {
						PlayerPrefs.SetInt ("Hiscore02", score02);	//HARD STAGE のハイスコアを更新する
					}
					//Invokeで0.5病後にGameOver関数を呼び出す間、0.5秒間Invokeがひたすら呼び出されてしまう。
					Invoke ("GameOver", 0.5f);
					//よって、空のステートに移行させておく事でInvokeの重複呼び出しを防止する。
                    state = State.EMPTY;
				}
			}
			//----------

			break;

		case State.GAMEOVER:
			if(Input.GetMouseButtonDown(0))
				SceneManager.LoadScene("Title");
			break;

		case State.EMPTY:
			break;
		}
	}

	//-----まずはすべてのテキストやボタンを非表示にしてから、各ステートで表示させたいものをtrueにしている-----
	void AllFalse()
	{
		score01Label.enabled = false;
		score02Label.enabled = false;

		ButtonLeft.gameObject.SetActive(false);
		ButtonRight.gameObject.SetActive(false);
		ButtonJump.gameObject.SetActive(false);
	}
	//----------

	void Playing()
	{
		state = State.PLAYING;
		AllFalse ();

		if (TitleManager.Stage01) {
			score01Label.enabled = true;
		} else if (TitleManager.Stage02) {
			score02Label.enabled = true;
		}

		ButtonLeft.gameObject.SetActive(true);
		ButtonRight.gameObject.SetActive(true);
		ButtonJump.gameObject.SetActive(true);
	}

	void GameOver()
	{
		state = State.GAMEOVER;
		AllFalse ();

		if (TitleManager.Stage01) {
			score01Label.enabled = true;
		} else if (TitleManager.Stage02) {
			score02Label.enabled = true;
		}

        gameOverLabel.text = "G A M E\nO V E R";
        toTitleLabel.text = "画 面 を ク リ ッ ク し て\n下 さ い 。";

		stageBGM.Stop();
		stageSoundEffect.GameIsOver ();
		//PlayerPrefs.DeleteAll();	//ハイスコアを初期化する
	}

	//-----プレイヤーの走行距離をスコアとする-----
	int CalcScoreStage01()
	{
		return(int)player.transform.position.z;	//NORMAL STAGE
	}

	int CalcScoreStage02()
	{
		return(int)player.transform.position.z;	//HARD STAGE
	}
	//----------
}