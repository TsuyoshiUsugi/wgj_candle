
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_MOTIMOTI : MonoBehaviour
{
    private GameObject title;    //�@�Q�[���I�u�W�F�N�g2������ׂ̕ϐ�
    float _rand;

    Vector3 _Image;  //�@���̕ϐ��錾

    Vector3 _Image_Base;  //�@���̕ϐ��錾

    void Start()
    {
        _Image_Base = gameObject.transform.localScale; //�����݂̑傫������

        _rand = Random.value;
    }

    // Update is called once per frame
    void Update()
    {


        _Image = gameObject.transform.localScale; //�����݂̑傫������

        float r = Mathf.Sin((Time.time * 4) + _rand);
        float r2 = Mathf.Sin((Time.time * 3) + _rand);

        _Image.x = _Image_Base.x * (1.75f + (r / 4));  //�A�ϐ�_image��x���W��1���₵�đ��
        _Image.y = _Image_Base.y * (1.8f + (r / 5));  //�A�ϐ�_image��y���W��1���₵�đ��

        gameObject.transform.localScale = _Image; //�B�傫���ɕϐ�_image����
    }
}
