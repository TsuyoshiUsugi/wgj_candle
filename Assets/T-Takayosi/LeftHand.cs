//条件がそろった場合、腕などのObjectを拡大、縮小するプログラム
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    private GameObject lefthand;    //　ゲームオブジェクトを入れる変数

    Vector3 _Image;  //実際の演出

    Vector3 _Image_Base;  //初期値

    bool x=false;
    float y = 0;
    public bool _do;

    void Start()
    {
        _Image_Base = gameObject.transform.position; //初期の座標を代入

    }

    // Update is called once per frame
    void Update()
    {
        //何かしらのトリガーが起動した場合この処理を行う
        if (_do)
        {
            _do = false;
            x = true;
        }

        //起動条件が揃ったら動く
        if (x == true)
        {
            y += Time.deltaTime*4;//デルタタイム分表示を更新
            if (y >= Mathf.PI)
            {
                x = false;
                y = 0;
            }
            float r = Mathf.Sin(y);
            _Image.x = _Image_Base.x + (r * .6f);  //初期値から移動
            _Image.y = _Image_Base.y + (r * -.3f);  //初期値から移動

            gameObject.transform.position = _Image; //映像に反映


        }
    }
}
