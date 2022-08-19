using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// FIXME MonoBehaviorいらないかも
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
    /// まだ生成されていない場合はマップを生成する
    /// </summary>
    public void CreateField()
    {
        if (!_cellPrefab)
        {
            _cellPrefab = Resources.Load<Cell>("Cell");
        }
        //FIXME ネストふか！
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
                        if (_cellArray[i, k].CurrentCellType ==CellTypes.Boss)
                        {
                            //ボス関数に引数を代入
                            CreateBoss(_cellArray[i, k]);
                        }
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

    MinionParamator _boss;
    public int BossHP => _boss.HP;
    void CreateBoss(Cell bossCell)
    {
        var red = Resources.Load<GameObject>("Red");
        var go = Instantiate(red,bossCell.transform);
        _boss = go.GetComponent<MinionParamator>();
        bossCell.MinionOnCell = _boss;
    }
    
}
