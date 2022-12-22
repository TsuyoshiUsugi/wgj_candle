using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour
{
    [SerializeField] GameObject _parentObj;

    private void OnDisable()
    {
        Destroy(_parentObj);
    }
}
