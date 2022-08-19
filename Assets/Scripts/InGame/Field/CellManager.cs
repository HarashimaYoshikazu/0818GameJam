using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// FIXME MonoBehaviorÇ¢ÇÁÇ»Ç¢Ç©Ç‡
/// </summary>
[RequireComponent(typeof(GridLayoutGroup))]
public class CellManager : MonoBehaviour
{
    Cell[,] _cellArray = null;
    public Cell[,] CellArray => _cellArray;
    Cell _cellPrefab;

    [SerializeField]
    int _colm = 5;
    public int Colm => _colm;
    [SerializeField]
    int _row = 5;
    public int Row => _row;

    private void Awake()
    {
        CreateField();
    }

    /// <summary>
    /// Ç‹Çæê∂ê¨Ç≥ÇÍÇƒÇ¢Ç»Ç¢èÍçáÇÕÉ}ÉbÉvÇê∂ê¨Ç∑ÇÈ
    /// </summary>
    public void CreateField()
    {
        if (!_cellPrefab)
        {
            _cellPrefab = Resources.Load<Cell>("Cell");
        }

        if (_cellArray == null)
        {
            _cellArray = new Cell[_colm, _row];
            for (int i = 0; i < _colm; i++)
            {
                for (int k = 0; k < _row; k++)
                {
                    var cel = GameObject.Find($"{i} {k}");
                    if (cel)
                    {
                        _cellArray[i, k] = cel.GetComponent<Cell>();
                    }               
                }
            }
        }

        if (_cellArray == null|| !_cellArray[0,0])
        {
            _cellArray = new Cell[_colm, _row];
            for (int i = 0; i < _colm; i++)
            {
                for (int k = 0; k < _row; k++)
                {
                    var cell = Instantiate(_cellPrefab, this.transform);
                    cell.CellPos = new Vector2Int(i,k);
                    cell.name = $"{i} {k}";
                    _cellArray[i, k] = cell;
                }
            }
        }
    }
    
}
