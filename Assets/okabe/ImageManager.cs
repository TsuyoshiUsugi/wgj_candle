using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageManager : MonoBehaviour
{
    [SerializeField] GameObject Image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
  public  void ImageOnOff()
    {
        if (!Image.activeSelf)
        {
            Image.gameObject.SetActive(true);
        }
       else
        {
            Image.gameObject.SetActive(false);
        }
    }
}
