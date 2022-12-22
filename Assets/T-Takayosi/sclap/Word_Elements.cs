
using System;
using UnityEngine;
using UnityEngine.UI;

public enum CellState
{
    None = 0,

    MO=75,
    TI=42,

    I = 9,
    M = 13,
    O = 15,
    T = 20,

}

public class Word_Elements : MonoBehaviour
{
    [SerializeField]
    private Text _view = null;

    [SerializeField]
    private CellState _cellState = CellState.None;
    public CellState CellState
    {
        get => _cellState;
        set
        {
            _cellState = value;
            OnCellStateChanged();
        }
    }

    private void OnValidate()
    {
        OnCellStateChanged();
    }

    private void OnCellStateChanged()
    {
        if (_view == null) { return; }

        if (_cellState == CellState.None)
        {
            _view.text = "";
        }
        else
        {
            _view.text = CellState.ToString();
            _view.color = Color.blue;
        }
    }


    void Update()
    {
        DownKeyCheck();
    }

    void DownKeyCheck()
    {
        if (Input.anyKeyDown)
        {
            foreach (KeyCode code in Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKeyDown(code))
                {
                    //èàóùÇèëÇ≠
                    Debug.Log(code);

                    break;
                }
            }
        }
    }
}