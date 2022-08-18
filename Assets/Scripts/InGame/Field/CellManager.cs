using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
public class CellManager : MonoBehaviour
{
    Cell[,] _cellArray = null;
    Cell _cellPrefab;
    GridLayoutGroup _grid;

    [SerializeField]
    int _colm = 5;
    [SerializeField]
    int _row = 5;

    private void Awake()
    {
        _grid = GetComponent<GridLayoutGroup>();
        _cellPrefab = Resources.Load<Cell>("Cell");
        if (_cellArray == null)
        {
            _cellArray = new Cell[_colm, _row];
            for (int i = 0;i< _colm;i++)
            {
                for (int k = 0;k<_row;k++)
                {
                    var cell = Instantiate(_cellPrefab,this.transform);
                    _cellArray[i, k] = cell;
                }
            }
        }
    }
}
