using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// ゲームシーンの進行管理をおこなうクラス
/// ゲーム開始前演出、カウントダウン、スコア保持、リザルトシーン移行
/// </summary>
public class GameSceneManager : MonoBehaviour
{
    [Header("スタート演出関連")]
    [SerializeField] GameObject _startText1;
    [SerializeField] GameObject _startText2;
    [SerializeField] int _StartTextWaitTime;
    [SerializeField] AudioClip _hoissle;
    [SerializeField] AudioSource _audioSource;

    [Header("プレイ中")]
    //スコア
    private static float _score;
    public static float Score => _score;
    [SerializeField] float _scoreTimes;

    //設定
    [SerializeField] bool _gameStart;
    [SerializeField] float _limitTime;
    [SerializeField] float _constantLimitTime;

    //参照
    [SerializeField] Text _timeText;
    [SerializeField] Text _scoreText;
    [SerializeField] KineJudge _kineJudge;
    [SerializeField] GameObject _cautionText;
    [SerializeField] Koneru _koneru;

    [Header("終了")]
    //参照
    bool _endGame;
    [SerializeField] GameObject _endText;
    [SerializeField] string _resultScene;
    [SerializeField] AudioClip _endSe;

    public enum State
    {
        koneru,
        tataku,
        end,
    }

    [SerializeField] public State _state;

    // Start is called before the first frame update
    private void Awake()
    {
        InitializedUI();
    }
    
    /// <summary>
    /// 表示するUIの初期化
    /// </summary>
    private void InitializedUI()
    {
        _startText1.SetActive(false);
        _startText2.SetActive(false);
        _endText.SetActive(false);
        _cautionText.SetActive(false);
        _koneru.enabled = false;
        _kineJudge._isOk = false;

        _constantLimitTime = _limitTime;

        _score = 0;
    }

    void Start()
    {
        StartCoroutine(nameof(ShowStart));
    }

    /// <summary>
    /// ゲーム開始前の演出を行う
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowStart()
    {
        _startText1.SetActive(true);
        yield return new WaitForSeconds(_StartTextWaitTime);
        _startText1.SetActive(false);

        _startText2.SetActive(true);
        _audioSource.PlayOneShot(_hoissle);
        yield return new WaitForSeconds(_StartTextWaitTime);
        _startText2.SetActive(false);
        _gameStart = true;
        _koneru.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!_gameStart) return;

        CountTime();
        CountScore();

        DecideTask();

        
    }

    /// <summary>
    /// つくのかこねるのか判定する
    /// </summary>
    void DecideTask()
    {


        if(_koneru._waitForKine)
        {
            _kineJudge._isOk = true;
        }
        else if(_kineJudge._isEnd)
        {
            _kineJudge._isOk = false;
            _koneru._waitForKine = false;
        }
        
    }

    /// <summary>
    /// 制限時間をカウントする
    /// </summary>
    void CountTime()
    {
        _limitTime -= Time.deltaTime;

        if(_limitTime <= _constantLimitTime/3 * 2 && _limitTime > _constantLimitTime/3)
        {
            _koneru._phaseNum = 1;
        }
        else if(_limitTime < _constantLimitTime/3)
        {
            _koneru._phaseNum = 2;
        }


        _timeText.text = $"Time:{ _limitTime.ToString("F1")}";
        if (_limitTime < 0) _timeText.text = "Time:0";

        if(_limitTime < 0 && !_endGame)
        {
            EndGame();
        }
    }

    /// <summary>
    /// ゲーム終了の演出を行う
    /// </summary>
    private void EndGame()
    {
        _endGame = true;
        _state = State.end;
        _audioSource.PlayOneShot(_endSe);
        _endText.SetActive(true);
        _timeText.text = $"Time:0";
        StartCoroutine(nameof(MoveResultScene));
    }

    /// <summary>
    /// リザルトシーンに移行する
    /// </summary>
    /// <returns></returns>
    IEnumerator MoveResultScene()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(_resultScene);
    }

    /// <summary>
    /// スコアを表示する
    /// </summary>
    void CountScore()
    {
        _score = _kineJudge._okTime * _scoreTimes + _koneru._okTime * _scoreTimes;
        _scoreText.text = $"Score:{_score}";
    }
}
