//文字などのObjectを拡大、縮小するプログラム
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_MOTIMOTI_D : MonoBehaviour
{
    float time = 0;
    private GameObject title;    //　ゲームオブジェクトを入れる変数
    float _rand;//Random関数

    Vector3 _Image;  //実際の演出

    Vector3 _Image_Base;  //初期値

    void Start()
    {
        _Image_Base = gameObject.transform.localScale; //初期の大きさを代入

        _rand = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float r = Mathf.Sin((time * 4) + _rand);
        float r2 = Mathf.Sin((time * 3) + _rand);

        _Image.x = _Image_Base.x * (1.75f + (r / 4));  //初期値から変形
        _Image.y = _Image_Base.y * (1.8f + (r2 / 5));  //初期値から変形

        gameObject.transform.localScale = _Image; //映像に反映
    }
}
