//�����Ȃǂ�Object���g��A�k������v���O����
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_MOTIMOTI_D : MonoBehaviour
{
    float time = 0;
    private GameObject title;    //�@�Q�[���I�u�W�F�N�g������ϐ�
    float _rand;//Random�֐�

    Vector3 _Image;  //���ۂ̉��o

    Vector3 _Image_Base;  //�����l

    void Start()
    {
        _Image_Base = gameObject.transform.localScale; //�����̑傫������

        _rand = Random.value;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        float r = Mathf.Sin((time * 4) + _rand);
        float r2 = Mathf.Sin((time * 3) + _rand);

        _Image.x = _Image_Base.x * (1.75f + (r / 4));  //�����l����ό`
        _Image.y = _Image_Base.y * (1.8f + (r2 / 5));  //�����l����ό`

        gameObject.transform.localScale = _Image; //�f���ɔ��f
    }
}
