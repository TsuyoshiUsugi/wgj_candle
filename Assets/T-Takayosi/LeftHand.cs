//��������������ꍇ�A�r�Ȃǂ�Object���g��A�k������v���O����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHand : MonoBehaviour
{
    private GameObject lefthand;    //�@�Q�[���I�u�W�F�N�g������ϐ�

    Vector3 _Image;  //���ۂ̉��o

    Vector3 _Image_Base;  //�����l

    bool x=false;
    float y = 0;
    public bool _do;

    void Start()
    {
        _Image_Base = gameObject.transform.position; //�����̍��W����

    }

    // Update is called once per frame
    void Update()
    {
        //��������̃g���K�[���N�������ꍇ���̏������s��
        if (_do)
        {
            _do = false;
            x = true;
        }

        //�N���������������瓮��
        if (x == true)
        {
            y += Time.deltaTime*4;//�f���^�^�C�����\�����X�V
            if (y >= Mathf.PI)
            {
                x = false;
                y = 0;
            }
            float r = Mathf.Sin(y);
            _Image.x = _Image_Base.x + (r * .6f);  //�����l����ړ�
            _Image.y = _Image_Base.y + (r * -.3f);  //�����l����ړ�

            gameObject.transform.position = _Image; //�f���ɔ��f


        }
    }
}
