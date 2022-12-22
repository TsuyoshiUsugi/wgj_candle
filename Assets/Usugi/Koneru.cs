using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// ランダムにコマンドを生成する
/// </summary>
public class Koneru : MonoBehaviour
{
    string[] text = { "mo", "chi" };
    [SerializeField] string order = "";

    //参照
    [SerializeField] GameObject _ankerObj;
    [SerializeField] GameObject _ankerObj2;
    [SerializeField] GameObject _moPrefab;
    [SerializeField] GameObject _chiPrefab;
    [SerializeField] GameSceneManager _gMManager;
    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _koneruse;
    [SerializeField] AudioClip _konemisu;
    [SerializeField] GameObject _cautionText;
    [SerializeField] LeftHand _leftHand;

    [SerializeField] public bool _waitForKine;
    [SerializeField] public int _phaseNum;

    [SerializeField] List<GameObject> _wordObjList;

    public int _okTime;
    public bool _isEnd;

    void Start()
    {
        order = GenerateOrder(4);
        _waitForKine = false;
    }

    string GenerateOrder(int wordNum)
    {
        for (int i = 0; i < wordNum; i++)
        {
            string word = text[Random.Range(0, 2)];
            if (word == text[0])
            {
                GameObject mo = Instantiate(_moPrefab);
                var wordObjs = mo.GetComponentsInChildren<Text>();

                foreach (var item in wordObjs)
                {
                    _wordObjList.Add(item.gameObject);
                }

                if(i > 3)
                {
                    mo.transform.SetParent(_ankerObj2.transform);
                }
                else
                {
                    mo.transform.SetParent(_ankerObj.transform);
                }
            }
            else
            {
                GameObject chi = Instantiate(_chiPrefab);

                var wordObjs = chi.GetComponentsInChildren<Text>();

                foreach (var item in wordObjs)
                {
                    _wordObjList.Add(item.gameObject);
                }

                if (i > 3)
                {
                    chi.transform.SetParent(_ankerObj2.transform);
                }
                else
                {

                    chi.transform.SetParent(_ankerObj.transform);
                }
            }

            order += word;
        }

        return order;
    }

    private void Update()
    {
        if (_gMManager._state != GameSceneManager.State.koneru) return;

        if (Input.anyKeyDown)
        {
            string inputKey = Input.inputString;
            if (inputKey == order[0].ToString())
            {
                Debug.Log("ok");
                _audioSource.PlayOneShot(_koneruse);
                _okTime++;
                //文字を消す
                _wordObjList[0].SetActive(false);
                _wordObjList.Remove(_wordObjList[0]);
                //先頭の文字を切り出す処理
                order = order.Substring(1, order.Length - 1);
                //切り出す文字が無くなったら
                if (order.Length == 0)
                {
                    _leftHand._do = true;
                    switch (_phaseNum)
                    {
                        case 0:
                            GenerateOrder(4);
                            break;
                        case 1:
                            GenerateOrder(6);
                            break;
                        case 2:
                            GenerateOrder(8);
                            break;
                    }
                    _gMManager._state = GameSceneManager.State.tataku;
                }
            }
            else
            {
                Debug.Log("違う！");
                _audioSource.PlayOneShot(_konemisu);
                StartCoroutine(nameof(ShowCaution));
            }
        }
    }

    IEnumerator ShowCaution()
    {
        _cautionText.SetActive(true);
        yield return new WaitForSeconds(1);
        _cautionText.SetActive(false);
    }
}
