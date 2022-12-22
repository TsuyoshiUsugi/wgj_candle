using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Word_Canvas : MonoBehaviour
{
    [SerializeField]
    private Word_Elements _WordPrefab = null;


    [SerializeField]
    private GridLayoutGroup _gridLayoutGroup = null;


    private Word_Elements[,] cells;

    int Word_a = 0;
    int Word_b = 4;
    int cells_numa;
    int cells_numb;
    int[,] cells_data;

    int rows=0;//ê∂ê¨íÜÇÃóÒÇîcà¨
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //if (rows<3)
        {
            Word_a++;
            Debug.Log(Word_a);

            _gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
            _gridLayoutGroup.constraintCount = 4;

            cells = new Word_Elements[1, Word_b];

            var parent = _gridLayoutGroup.transform;
            //ÉZÉãÇê∂ê¨Ç∑ÇÈ
            for (var r = 0; r < 1; r++)
            {
                for (var c = 0; c < Word_b; c++)
                {
                    if(rows < 12){

                        var cell = Instantiate(_WordPrefab);
                        cell.transform.SetParent(parent);
                        cells[r, c] = cell;

                        int x = Random.Range(0, 2);
                        if (x == 0)
                        {
                            cell.CellState = CellState.MO;

                        }
                        else
                        {
                            cell.CellState = CellState.TI;

                        }
                        rows++;
                    }
                }
            }
        }



        if (Input.GetKeyUp(KeyCode.RightArrow)) {
            rows--;
        }
    }
}
