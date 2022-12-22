//この製品を適当なGameObjectに挿入すると、このスクリプトがAudio　Souceを要求する
//項目を表示します。加速させたい曲をこのなかにいれると、
//ゲームの進行速度に合わせて曲が加速します

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
            //再生速度をあげる
            audioSource.pitch = Mathf.Min(audioSource.pitch + 0.1f, 3);
            x++;
        }

        else if (Input.GetKeyDown(KeyCode.DownArrow)&&(x>0))
        {
            //再生速度を下げる
            audioSource.pitch = Mathf.Max(audioSource.pitch - 0.1f, 0.5f);
            x--;
        }

        else if (Input.GetKeyDown(KeyCode.R))
        {
            //再生速度を当倍にする
            audioSource.pitch = 1;
            x=0;
        }
        
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            //逆再生
            audioSource.pitch = -1;
            x=0;
        }


    }
}
