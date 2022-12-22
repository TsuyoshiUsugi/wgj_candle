
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_MOTIMOTI : MonoBehaviour
{
    private GameObject title;    //　ゲームオブジェクト2を入れる為の変数
    float _rand;

    Vector3 _Image;  //①仮の変数宣言

    Vector3 _Image_Base;  //①仮の変数宣言

    void Start()
    {
        _Image_Base = gameObject.transform.localScale; //◆現在の大きさを代入

        _rand = Random.value;
    }

    // Update is called once per frame
    void Update()
    {


        _Image = gameObject.transform.localScale; //◆現在の大きさを代入

        float r = Mathf.Sin((Time.time * 4) + _rand);
        float r2 = Mathf.Sin((Time.time * 3) + _rand);

        _Image.x = _Image_Base.x * (1.75f + (r / 4));  //②変数_imageのx座標を1増やして代入
        _Image.y = _Image_Base.y * (1.8f + (r / 5));  //②変数_imageのy座標を1増やして代入

        gameObject.transform.localScale = _Image; //③大きさに変数_imageを代入
    }
}
