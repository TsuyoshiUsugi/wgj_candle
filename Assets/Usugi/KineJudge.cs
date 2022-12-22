using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineJudge : MonoBehaviour
{
    [SerializeField] GameObject _moti;
    [SerializeField] GameObject _cautionText;
    [SerializeField] GameObject _okText;

    [SerializeField] GameSceneManager _gmManager;

    [SerializeField] AudioSource _audioSource;
    [SerializeField] AudioClip _tatakuSe;
    [SerializeField] AudioClip _sippaiSe;

    public bool _isOk;
    public bool _isEnd;

    public int _okTime;

    /// <summary>
    /// �݂ƐڐG�������̏���
    /// </summary>
    /// <param name="collision"></param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == _moti)
        {
            Judge();
        }
    }

    /// <summary>
    /// ������s��
    /// </summary>
    void Judge()
    {
        if (_gmManager._state == GameSceneManager.State.tataku)
        {
            _okTime++;
            _gmManager._state = GameSceneManager.State.koneru;
            _audioSource.PlayOneShot(_tatakuSe);
            StartCoroutine(nameof(ShowOk));

        }
        else
        {
            StartCoroutine(nameof(ShowCaution));
            _audioSource.PlayOneShot(_sippaiSe);
        }
    }

    /// <summary>
    /// �ԈႦ�����̒��ӕ\��
    /// </summary>
    /// <returns></returns>
    IEnumerator ShowCaution()
    {
        _cautionText.SetActive(true);
        yield return new WaitForSeconds(1);
        _cautionText.SetActive(false);
    }
    
    IEnumerator ShowOk()
    {
        _okText.SetActive(true);
        yield return new WaitForSeconds(1);
        _okText.SetActive(false);
    }
}
