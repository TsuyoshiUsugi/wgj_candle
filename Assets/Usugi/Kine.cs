using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 杵の動きを管理するクラス
/// </summary>
public class Kine : MonoBehaviour
{
    //参照
    [SerializeField] GameObject _kineRotateAxisObj;
    [SerializeField] GameObject _moti;

    //設定値
    [SerializeField] float _round;

    float _originAngle;
    float _orginMousePosY;
    [SerializeField] float _moveDis;


    [SerializeField] bool _isOk;

    // Start is called before the first frame update
    void Start()
    {
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        var screenMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        _orginMousePosY = screenMousePos.y;

        _originAngle = _kineRotateAxisObj.transform.localEulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        //マウスのY座標をworldのY座標に変換
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        var screenMousePos = Camera.main.ScreenToWorldPoint(mousePos);
        var mousePosY = screenMousePos.y;

        _moveDis = _orginMousePosY - mousePosY;
        if (_moveDis > _round ) return;

        //マウス位置と角度の変換
        var aa = mousePosY * mousePosY;
        var cc = _round * _round;
        var bb = cc - aa;
        var c = _round;
        var b = Mathf.Sqrt(bb);
        var rad = Mathf.Asin(b / c);
        var angle = rad * 180 / Mathf.PI;

        if (float.IsNaN(rad)) return;

        transform.localEulerAngles = new Vector3(0, 0, _originAngle + angle);
    }

}
