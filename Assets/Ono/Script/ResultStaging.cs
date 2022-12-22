using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
using DG.Tweening;


public class ResultStaging : MonoBehaviour
{
    [SerializeField] private Image Moti;
    [SerializeField] private Image Moti1;
    [SerializeField] private Image Moti2;
    [SerializeField] private Image Moti3;
    [SerializeField] private Image Moti4;
    [SerializeField] private Image Moti5;
    [SerializeField] private Image Moti6;
    [SerializeField] private Image Moti7;
    [SerializeField] private Image Moti8;
    [SerializeField] private Image Moti9;
    [SerializeField] private Text ScoreText;
    [SerializeField] private Text OnewordText;
    [SerializeField]private float score;

    // Start is called before the first frame update
    void Start()
    {
        Moti.enabled = false;
        Moti1.enabled = false;
        Moti2.enabled = false;
        Moti3.enabled = false;
        Moti4.enabled = false;
        Moti5.enabled = false;
        Moti6.enabled = false;
        Moti7.enabled = false;
        Moti8.enabled = false;
        Moti9.enabled = false;
        //mainsceneからstaticで値を持ってくる。
        score = GameSceneManager.Score;
        ScoreText.text = string.Format("Score{0}", score);

        if (score >= 20)
        {
            Moti.transform.DOMove(new Vector2(161f, 903f), 1f).SetDelay(1f);
            Moti.enabled = true;
        }
        if (score >= 40)
        {
            Moti1.transform.DOMove(new Vector2(383f, 903f), 1f).SetDelay(1.5f);
            Moti1.enabled = true;
        }
        if (score >= 60)
        {
            Moti2.transform.DOMove(new Vector2(596f, 903f), 1f).SetDelay(2f);
            Moti2.enabled = true;
        }
        if (score >= 80)
        {
            Moti3.transform.DOMove(new Vector2(793f, 903f), 1f).SetDelay(3f);
            Moti3.enabled = true;
        }
        if (score >= 100)
        {
            Moti4.transform.DOMove(new Vector2(975f, 903f), 1f).SetDelay(3.5f);
            Moti4.enabled = true;
        }
        if (score >= 120)
        {
            Moti5.transform.DOMove(new Vector2(1135f, 903f), 1f).SetDelay(4f);
            Moti5.enabled = true;
        }
        if (score >= 140)
        {
            Moti6.transform.DOMove(new Vector2(1282f, 903f), 1f).SetDelay(5f);
            Moti6.enabled = true;
        }
        if (score >= 160)
        {
            Moti7.transform.DOMove(new Vector2(1386f, 903f), 1f).SetDelay(6f);
            Moti7.enabled = true;
        }
        if (score >= 180)
        {
            Moti8.transform.DOMove(new Vector2(1504f, 903f), 1f).SetDelay(6.5f);
            Moti8.enabled = true;
        }
        if (score >= 200)
        {
            Moti9.transform.DOMove(new Vector2(1688f, 903f), 1f).SetDelay(7.1f);
            Moti9.enabled = true;
        }
        if ((score >= 0) && (score <= 50))
        {
            OnewordText.text = string.Format("お疲れサマンサー!!");
        }
        if ((score >= 51) && (score <= 100))
        {
            OnewordText.text = string.Format("雑魚乙!!");
        }
        if ((score >= 101) && (score <= 200))
        {
            OnewordText.text = string.Format("もちち!!");
        }
    }
}
