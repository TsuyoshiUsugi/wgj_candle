//���̐��i��K����GameObject�ɑ}������ƁA���̃X�N���v�g��Audio�@Souce��v������
//���ڂ�\�����܂��B�������������Ȃ����̂Ȃ��ɂ����ƁA
//�Q�[���̐i�s���x�ɍ��킹�ċȂ��������܂�

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music_Spead : MonoBehaviour
{
    int x=0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    [SerializeField] AudioSource audioSource;

    private void Update()
    {


        if (Input.GetKeyDown(KeyCode.UpArrow)&&x<10)
        {
            //�Đ����x��������
            audioSource.pitch = Mathf.Min(audioSource.pitch + 0.1f, 3);
            x++;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)&&(x>0))
        {
            //�Đ����x��������
            audioSource.pitch = Mathf.Max(audioSource.pitch - 0.1f, 0.5f);
            x--;
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            //�Đ����x�𓖔{�ɂ���
            audioSource.pitch = 1;
            x=0;
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //�t�Đ�
            audioSource.pitch = -1;
            x=0;
        }


    }
}
