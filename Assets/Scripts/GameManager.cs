using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    enum State {PLAYING, GAMEOVER, EMPTY}
    private State state;

    private bool isDoubleTapStart;
    private float doubleTapTime;

    [SerializeField] private PlayerController player;
    [SerializeField] private GameObject ButtonLeft;
    [SerializeField] private GameObject ButtonRight;
    [SerializeField] private GameObject ButtonJump;
    [SerializeField] private GameObject RetryButton;

    private Text gameOverLabel;
    private Text toTitleLabel;
    private Text scoreLabel;

    void Awake()
    {
        gameOverLabel = GameObject.Find("GameOverLabel").GetComponent<Text>();
        toTitleLabel = GameObject.Find("ToTitleLabel").GetComponent<Text>();
        scoreLabel = GameObject.Find("ScoreLabel").GetComponent<Text>();
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
                break;

            case State.GAMEOVER:
                if (isDoubleTapStart)
                {
                    doubleTapTime += Time.deltaTime;
                    if (doubleTapTime < 0.3f)
                    {
                        if (Input.GetMouseButtonDown (0))
                        {
                            Debug.Log ("double tap");
                            isDoubleTapStart = false;
                            doubleTapTime = 0.0f;
                            SceneManager.LoadScene("Title");
                        }
                    }
                    else
                    {
                        Debug.Log ("reset");
                        // reset
                        isDoubleTapStart = false;
                        doubleTapTime = 0.0f;
                    }
                }
                else
                {
                    if (Input.GetMouseButtonDown (0))
                    {
                        Debug.Log ("down");
                        isDoubleTapStart = true;
                    }
                }
                break;

            case State.EMPTY:
                break;
        }
    }

    //-----まずはすべてのテキストやボタンを非表示にしてから、各ステートで表示させたいものをtrueにしている-----
    void AllFalse()
    {
        ButtonLeft.gameObject.SetActive(false);
        ButtonRight.gameObject.SetActive(false);
        ButtonJump.gameObject.SetActive(false);
        RetryButton.gameObject.SetActive(false);
    }
    //----------

    void Playing()
    {
        state = State.PLAYING;
        AllFalse ();

        ButtonLeft.gameObject.SetActive(true);
        ButtonRight.gameObject.SetActive(true);
        ButtonJump.gameObject.SetActive(true);
    }

    void GameOver()
    {
        state = State.GAMEOVER;
        AllFalse ();

        gameOverLabel.text = "G A M E\nO V E R";
        toTitleLabel.text = "画 面 を ダ ブ ル タ ッ プ\nし て 下 さ い 。";

        RetryButton.gameObject.SetActive(true);

        //PlayerPrefs.DeleteAll();	//ハイスコアを初期化する
    }

    public void OnRetryButtonClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene ().buildIndex);
    }

    //-----プレイヤーの走行距離をスコアとする-----
    int CalcScoreStage01()
    {
        return(int)player.transform.position.z * 10;	//NORMAL STAGE
    }

    int CalcScoreStage02()
    {
        return(int)player.transform.position.z * 10;	//HARD STAGE
    }

    int CalcScoreStage03()
    {
        return(int)player.transform.position.z * 10;	//SPECIAL STAGE
    }
    //----------
}